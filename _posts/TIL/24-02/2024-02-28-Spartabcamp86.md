---
title:  "[TIL] 86 소리크기 저장 , 면접 준비 ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-28 02:00

---
- - -


<BR><BR>

<center><H1>  최종 팀 프로젝트 28일차  </H1></center>

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

# 소리저장
소리는 PlayerPrefs을 이용하여 저장하였다.  
암호화가 필요없고, 이어하기 시 불러오는게 아니라   
게임시작 시 필요하다고 생각돼서 PlayerPrefs를 사용.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c# 
_soundManager.GetMasterVolume(out MasterSoundVolume);
_soundManager.GetSFXVolume(out SFXSoundVolume);
_soundManager.GetMusicVolume(out BGMSoundVolume);


if (PlayerPrefs.HasKey("BGMSoundVolume"))
        {
            GameManager.Instance.SoundManager.SetMasterVolume(PlayerPrefs.GetFloat("MasterSoundVolume"));
            GameManager.Instance.SoundManager.SetSFXVolume(PlayerPrefs.GetFloat("SFXSoundVolume"));
            GameManager.Instance.SoundManager.SetMusicVolume(PlayerPrefs.GetFloat("BGMSoundVolume"));
        }
```
</div>


<br><br><br><br><br>
- - - 

# 잡담,정리
면접준비, 소리저장
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
