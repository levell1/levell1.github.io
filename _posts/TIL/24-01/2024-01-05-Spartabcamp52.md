---
title:  "[TIL] 52 오디오매니저 (AudioManager) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-05 02:00

---
- - -


`AudioManager`

<BR><BR>

<center><H1>  AudioManager  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 52  
&nbsp;&nbsp; [o] 다른반 강의 듣기   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# AudioManager

Resources.Load`<AudioClip>`("Audios/SFX/"+sfxName);  

<div class="notice--primary" markdown="1"> 

```c#

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioClip _audioClip;
    public AudioSource BgSound;
    public AudioSource[] SFXSound;
    public AudioMixer Mixer;
    private string _bgFilename;

    private float _soundValue;


    private void Awake()
    {
        _audioClip = GetComponent<AudioClip>();
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
        
        BgSoundPlay("BG1", 0.05f);
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode arg1)
    {
        if (scene.name == "KDH_Obstacle")
        {
            _bgFilename = "BG1";
        }
        else if (scene.name == "99.BJH")
        {
            _bgFilename = "BG3";
        }
        BgSoundPlay(_bgFilename, 0.05f);
    }

    public void SFXPlay(string sfxName, Vector3 audioPosition, float audioVolume)
    {
        GameObject AudioGo = new GameObject(sfxName + "Sound");
        AudioSource audiosource = AudioGo.AddComponent<AudioSource>();

        audiosource.outputAudioMixerGroup = Mixer.FindMatchingGroups("SFX")[0];
        _audioClip = Resources.Load<AudioClip>("Audios/SFX/"+sfxName);
        if (_audioClip!=null) 
        {
            audiosource.clip = _audioClip;
            audiosource.volume = audioVolume;
            audiosource.Play();

            Destroy(audiosource.gameObject, audiosource.clip.length);
        }
        
    }


    public void BgSoundPlay(string BgName, float audioVolume)
    {
        _audioClip = Resources.Load<AudioClip>("Audios/BGM/"+ BgName);
        BgSound.clip = _audioClip;
        BgSound.outputAudioMixerGroup = Mixer.FindMatchingGroups("BGSound")[0];
        BgSound.loop = true;
        BgSound.volume = audioVolume;
        BgSound.Play();
    }


    
    //볼륨조절
     public void BGSoundVolume(Slider _bgmSlider) 
    {
        _soundValue = _bgmSlider.value;
        Mixer.SetFloat("BGVolume", _soundValue);
    }
    public void SFXSoundVolume(Slider _sfxSlider)
    {
        _soundValue = _sfxSlider.value;
        Mixer.SetFloat("SFXVolume", _soundValue);
    }
    public void MasterVolume(Slider _masterSlider)
    {
        _soundValue = _masterSlider.value;
        Mixer.SetFloat("Master", _soundValue);
    }
}

충돌 시 충돌물체 이름받아서 그 사운드 실행
protected void OnCollisionEnter(Collision collision)
{
    {
        GameManager.Sound.SFXPlay((name), gameObject.transform.position, 0.1f);
    }
}

```
</div>

_audioClip = Resources.Load`<AudioClip>`("Audios/SFX/"+sfxName);   
> - Load를 사용해서 Resources폴더에 있는 파일을 불러와 clip으로 사용하였다.  
> - 충돌하는 물체의 name과 Audio의 이름을 맞춰줘야 됐다.   
> - clip을 리스트로 audiomanager가 가지고 있는 방법도 생각했었고,   
> - 여러 방법이 있을 때마다 무엇이 맞는지 고민하는 시간이 있었고,    
> - 비슷하다고 생각되면 편하고 끌리는 방법을 사용하자.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

오디오소스  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6aff610f-48b1-4354-886c-b0613dc0e9c5){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 

# PlayerSound 

<div class="notice--primary" markdown="1"> 

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _time;
    private float _delay =0.5f;
    private PlayerController _playerController;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody>();
        _playerController =GetComponent<PlayerController>();
    }
    private void Update()
    {
        WalkSound();
    }
    public void LandingSound() 
    {
        GameManager.Instance.AudioManager.SFXPlay(("landing"), gameObject.transform.position, 0.1f);
    }
    public void WalkSound()
    {
        _time += Time.deltaTime;
        RaycastHit _hit;
        if (Mathf.Abs(_rigidbody.velocity.y)<0.1f&& Mathf.Abs(_rigidbody.velocity.magnitude)> 0.1f)
        {
            if (_playerController.IsGrounded())
            {
                if (_time > _delay)
                {
                    GameManager.Instance.AudioManager.SFXPlay(("Footstep"), gameObject.transform.position, 0.1f);
                    _time = 0;
                }
            }
            
        }
    }
}
```
</div>

LandingSound 는 애니메이션이벤트에 추가  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br><br><br><br>
- - - 


소리 재생, 소리 조절 (3종).  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br><br><br><br>
- - - 

# 잡담,정리
Resources.Load`<AudioClip>`("Audios/SFX/"+sfxName);  
오디오매니저, 게임매니저, 싱글톤은 게임매니저만, 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
