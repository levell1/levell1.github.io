---
title:  "[TIL] 52 강의 - 오디오매니저 (AudioManager) ⭐⭐⭐ "
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

    public Slider _bgmSlider;
    public Slider _sfxSlider;
    public Slider _masterSlider;


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
    public void BGSoundVolume() 
    {
        float bgmsound = _bgmSlider.value;
        Mixer.SetFloat("BGVolume", bgmsound);
    }
    public void SFXSoundVolume()
    {
        float sfxsound = _sfxSlider.value;
        Mixer.SetFloat("SFXVolume", sfxsound);
    }
    public void MasterVolume()
    {
        float mastersound = _masterSlider.value;
        Mixer.SetFloat("Master", mastersound);
    }
}

```
</div>

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
오디오매니저, 게임매니저, 싱글톤은 게임매니저만, 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
