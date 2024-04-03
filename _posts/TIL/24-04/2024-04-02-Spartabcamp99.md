---
title:  "[TIL] 99 VR 강의 세팅, 스터디 ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-04-02 02:00

---
- - -

`HMD`

<BR><BR>

<center><H1>  이력서 진행중, 강의듣기, VR 스터디 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53       
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기. 책사기  
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
&nbsp;&nbsp; [x] 포트폴리오 강의듣고 만들기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# VR

**HMD(Head Mounted Display)**  

> **VR 패키지**  
> - PROVIDER PLUG-INS  
> - XR Interaction Toolkit  
> - XR Core Utilities  
> - Input System  
> - VR project template  
> - Hand tracking  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

> **VR 플러그인**  
> - Apple VisionOS XR  
> - Oculus  
> - OpenXR  
> - Playstation VR  
> - XR Simulator  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

> **주 사용 플러그인**  
> - XR Interaction Toolkit  
> - Vive Input Utility  
> - Oculus Integration  
> - SteamVR Plugin  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

> - **VR 개발 주의점**  
> - UI - 3D공간에 자연스럽게 녹아들도록 만들기  
> - 멀미 - 시너메신 X , 오브젝트 속도 빠르게 X  
> - 인터랙션 - 트래커, 손, 시선 추적 기능 고려  
> - 성능 최적화 - 모바일기반 HMD는 최적화 필요  
> - 환경 설계 -FOV 고려한 환경 설계, 360 도 환경 구성, 오브젝트가 너무 가까우면 초점 힘들다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br><br>
- - - 

# XR Toolkit 예제

> 처음부터 세팅 하기, (예제x)  
> - 3D 프로젝트 생성  
> - 패키지 Input System, Oculus XR Plugin, XR Interaction Toolkit  
> - Project settings - XR Plug-in Management 에서 세팅  
> - Player- resolutin - run in Backgroun 체크  
> - XR Interaction Toolkit -samples - starter assets, xr device simulator import  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

[XR 예제](https://github.com/Unity-Technologies/XR-Interaction-Toolkit-Examples)  

**인풋시스템**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ae90c4cd-ef6e-4752-b79e-8668d0f52a75)  

> 샘플로 시작  
> - Hierarchy 에 XR Origin 생성  
> - XR Device Simulator 프리팹 추가  
> - XR Origin 의 Modelprefab에 XRControllerLeft, Right 모델을 추가
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 



**XR Origin** - 중심점  
XR Device Simulator - HMD 연결없이 마우스 키로 시뮬레이션 가능하게 해준다.  

**트레킹 컴포넌트**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/4e6a6496-e11a-42b8-9529-06d1365b0910)

공부 : [Unity Learn](https://learn.unity.com/course/create-with-vr) 보면서 따라해보기  

<br><br><br><br><br>
- - - 

# 잡담, 일기?
VR Meta 위주로 공부?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -
