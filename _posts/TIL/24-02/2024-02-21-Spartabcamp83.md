---
title:  "[TIL] 83 버그 수정, 사운드 추가 빌드 준비⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-21 02:00

---
- - -


<BR><BR>

<center><H1>  최종 팀 프로젝트 25일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 오브젝트 풀 버그
여러종류 동시에 오브젝트풀 사용시 오류가 발생.
-> 따로 빼서 오브젝트 풀 사용
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br><br>
- - - 

# 사운드 추가
배경음, 배경음페이드 아웃 , 효과음 오브젝트풀로 추가
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br>

## SoundManager
모든 리소스 캐싱 후 배경음악, 효과음 재생메서드, 수정필요
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<details>
<summary>SoundManager</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private AudioClip _audioClip;
    private AudioMixer _mixer;
    private string _bgFilename;

    private Queue<AudioSource> _bgmQueue = new Queue<AudioSource>();
    private Dictionary<string, AudioClip> _soundDictionary = new Dictionary<string, AudioClip>();

    private Coroutine _coroutine = null;

    public GameObject Prefabs;
    public int Size;
    public Transform SpawnPoint;


    private Queue<GameObject> _poolObject;


    private void Awake()
    {
        _audioClip = GetComponent<AudioClip>();
        _mixer = Resources.Load<AudioMixer>("Sound/AudioMixer");
        intit();
    }

    private void Start()
    {
        var pre = Resources.LoadAll<AudioClip>("Sound");
        foreach (var p in pre)
        {
            _soundDictionary.Add(p.name, p);
        }
        SceneManager.sceneLoaded += LoadedsceneEvent;
        BgmSoundPlay("TitleBGM");
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == SceneName.VillageScene)
        {
            _bgFilename = BGMSoundName.VillageBGM1;
        }
        else if (scene.name == SceneName.TycoonScene)
        {
            _bgFilename = BGMSoundName.TycoonBGM1;
        }
        else if (scene.name == SceneName.DungeonScene)
        {
            _bgFilename = BGMSoundName.DungeonBGM;
        }
        else if (scene.name == SceneName.HuntingScene)
        {
            _bgFilename = BGMSoundName.HuntingField;
        }
        if (_bgFilename != null)
        {
            BgmSoundPlay(_bgFilename);
        }
        _bgFilename = null;
    }

    public void SFXPlay(string sfxName, Vector3 audioPosition, float audioVolume)
    {
        GameObject AudioObject = GetSoundObject();
        AudioSource audiosource = AudioObject.GetComponent<AudioSource>();
        _audioClip = _soundDictionary[sfxName];

        if (_audioClip != null)
        {
            audiosource.clip = _audioClip;
            audiosource.volume = audioVolume;
            audiosource.Play();

            StartCoroutine(SFXStop(AudioObject, audiosource));
        }

    }
    public void SFXPlay(string sfxName)
    {
        GameObject AudioObject = GetSoundObject();
        AudioSource audiosource = AudioObject.GetComponent<AudioSource>();
        _audioClip = _soundDictionary[sfxName];

        if (_audioClip != null)
        {
            audiosource.clip = _audioClip;
            audiosource.volume = 0.5f;
            audiosource.Play();

            StartCoroutine(SFXStop(AudioObject, audiosource));
        }

    }
    IEnumerator SFXStop(GameObject AudioObject, AudioSource audiosource)
    {
        yield return new WaitForSecondsRealtime(audiosource.clip.length);
        ReturnSoundObject(AudioObject);
    }


    public void BgmSoundPlay(string BgName)
    {

        if (_bgmQueue.Count != 0)
        {
            AudioSource firstAudio = _bgmQueue.Dequeue();
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            StartCoroutine(BgmVolumeDown(firstAudio));
        }

        GameObject AudioGo = new GameObject(BgName);
        DontDestroyOnLoad(AudioGo);
        AudioSource audiosource = AudioGo.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = _mixer.FindMatchingGroups("BGSound")[0];
        _audioClip = _soundDictionary[BgName];

        if (_audioClip != null)
        {
            audiosource.clip = _audioClip;
            audiosource.loop = true;
            _coroutine = StartCoroutine(BgmVolumeUp(audiosource));
            audiosource.Play();
        }
        _bgmQueue.Enqueue(audiosource);

    }
    IEnumerator BgmVolumeDown(AudioSource bgmsource)
    {
        while (bgmsource.volume > 0.04f)
        {
            bgmsource.volume -= 0.03f;
            yield return new WaitForSeconds(0.3f);
            if (bgmsource == null)
            {
                break;
            }
        }
        Destroy(bgmsource.gameObject);
    }
    IEnumerator BgmVolumeUp(AudioSource bgmsource)
    {
        bgmsource.volume = 0;
        while (bgmsource.volume < 0.3f)
        {
            bgmsource.volume += 0.03f;
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void SetMasterVolume(float volume)
    {
        _mixer.SetFloat("MasterSound", volume);
    }

    public void SetMusicVolume(float volume)
    {
        _mixer.SetFloat("BGSound", volume);
    }

    public void SetSFXVolume(float volume)
    {
        _mixer.SetFloat("SFXSound", volume);
    }

    public void intit()
    {
        _poolObject = new Queue<GameObject>();
        for (int i = 0; i < Size; i++)
        {
            var newObj = Instantiate(Prefabs, SpawnPoint);
            newObj.gameObject.SetActive(false);
            _poolObject.Enqueue(newObj);
        }
    }

    public void ReturnSoundObject(GameObject obj)
    {
        _poolObject.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject GetSoundObject()
    {
        GameObject obj = _poolObject.Dequeue();
        obj.SetActive(true);
        return obj;
    }

}

```
</div>
</details>

<br><br><br><br><br>
- - - 

# 맵 구현
> - RenderTexture를 이용한 구현  
> - RenderTexture로 바뀌는 화면에 대한 미니맵 구현 -> 카메라와, 이미지 세팅  
> - 문제점 -> 맵을 키면 batches가 너무 늘어났다. RenderTexture의 문제점? 맵전체를 현재화면으로 그려줘서? 문제가 있다.
> - 개선법 -> 맵은 2D화면 사진으로찍어서 이미지 하나로 대체, 캐릭터, 보스의 위치만 실시간으로 RenderTexture와 카메라
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f3e9b25f-fa5f-4fcd-962b-cfbe3d336191){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br>

## 던전 맵 구현
> - 던전 방 별로 카메라에 표시되는 오브젝트 하나 생성
> - 방 클리어 시 갈 수 있는 방 색변경 -> 맵에 표시
![image](https://github.com/levell1/levell1.github.io/assets/96651722/67a59af9-2199-4160-a592-61ffcf71d910){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br><br>
- - - 

# 기술면접
## 24. 디자인 패턴(Singleton, Observer 등) 사용하는 이유는 무엇인가요?

> - 코드의 구조화: 디자인 패턴은 코드를 구조화하고 모듈화하여 유지보수와 확장을 쉽게 만듭니다. 코드의 가독성과 유지보수성
> - 재사용성: 디자인 패턴을 사용하면 일반적인 문제에 대한 해결책을 재사용할 수 있습니다. 이는 개발 속도를 높이고 코드 중복을 방지하는 데 도움이 됩니다.
> - 개발자 간의 의사소통: 디자인 패턴은 개발자 간의 의사소통을 촉진할 수 있습니다. 공통된 용어와 개념을 사용하므로 팀원들 간의 협업이 원활해집니다.
> - 유지보수와 확장성: 디자인 패턴은 변경에 대한 유연성을 제공합니다. 프로젝트 요구사항이 변경되거나 새로운 기능이 추가될 때, 디자인 패턴을 통해 코드를 쉽게 수정하고 확장할 수 있습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


Unity를 사용하면서 경험해볼 수 있는 대표적인 디자인패턴이 무엇인지 설명해주세요.
상태패턴, 관찰자패턴, 이벤트 버스 패턴, 전략패턴 등이 있습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br><br>
- - - 


# 잡담,정리
오브젝트 풀 생각, 사운드 추가, 디자인패턴, 맵 구현
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
