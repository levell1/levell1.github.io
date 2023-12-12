---
title:  "[Memo-Unity] 15. Sound  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-10 09:01

---
- - -

`ParticleSystem` 
<BR><BR>

<center><H1>  MaskLayer  </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. 사운드

<div class="notice--primary" markdown="1"> 

`SoundManager`

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;
    private ObjectPool objectPool;

    private AudioSource musicAudioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        instance = this;
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
        musicAudioSource.loop = true;

        objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        ChangeBackGroundMusic(musicClip);
    }

    public static void ChangeBackGroundMusic(AudioClip music)
    {
        instance.musicAudioSource.Stop();
        instance.musicAudioSource.clip = music;
        instance.musicAudioSource.Play();
    }

    public static void PlayClip(AudioClip clip)
    {
        GameObject obj = instance.objectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance);
    }
}
```
</div>


<br><br>

<div class="notice--primary" markdown="1"> 

`SoundSource`

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    private AudioSource _audioSource;

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        CancelInvoke();
        _audioSource.clip = clip;
        _audioSource.volume = soundEffectVolume;
        _audioSource.Play();
        _audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);

        Invoke("Disable", clip.length + 2);
    }

    public void Disable()
    {
        _audioSource.Stop();
        gameObject.SetActive(false);
    }
}


public AudioClip damageClip;
if (damageClip)
    SoundManager.PlayClip(damageClip);

```
</div>

**`damageClip`**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f5639c35-8379-4daa-8d58-2e59cb0c783c)


<br><br><br><br><br><br>
- - - 

# 정리  

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}
<br><br>
- - - 

[Unity] ParticleSystem
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
