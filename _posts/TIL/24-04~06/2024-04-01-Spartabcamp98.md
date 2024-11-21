---
title:  "[TIL] 98 AR 강의 세팅, 스터디 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-04-01 02:00

---
- - -

`AR` `AR Foundation` `AR Core`

<BR><BR>

<center><H1>  이력서 진행중, 강의듣기, AR 스터디 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53       
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기. 책사기  
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
&nbsp;&nbsp; [x] 포트폴리오 강의듣고 만들기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# AR세팅 준비
[AR_Sample](https://github.com/Unity-Technologies/arfoundation-samples/tree/5.1)  

> **AR 프로젝트 세팅**  
> - 3D 프로젝트 생성  
> - &nbsp;&nbsp; **1.** 플러그인 설치 [AR Foundation](https://unity.com/unity/features/arfoundation)  
> - &nbsp;&nbsp; **2.** 윈도우 -> 패키지 매니저 -> **AR Foundation**설치, **AR Core**(Google ARCore XR Plugin) 설치  
> - &nbsp;&nbsp; **3.** Edit > Project Settings > **XR Plug-in Management** > **Android AR Core** 체크 , 빌드세팅 안드로이드로 변경  
> - &nbsp;&nbsp; **4.** hierarchy 메인카메라 삭제, XR -> **AR Session** 추가, **XR Origin** 추가  
> - &nbsp;&nbsp; **5.** Edit > Project Settings > **Player**  
> - &nbsp;&nbsp; **-** Other Settings -> **AutoGraphics API** 체크해제, **Vulkan** 삭제  
> - &nbsp;&nbsp; **-** Identification -> Minimum API Level - **Nougat(24)**  
> - &nbsp;&nbsp; **-** Configuration -> Scripting Backend = **IL2CPP**, Target Architectures = **ARM 64** 체크  
> - &nbsp;&nbsp; 프로젝트 빌드 세팅 끝.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> - **AR Foundation** -> AR 플랫폼 간에 전환할 때 현재 사용할 수 없는 기능을 어디에서나 이용가능하게 해주는 역할  
> - **AR Session** -> AR에 맞는 생명주기,세팅의 기본  
> - **XR Origin** -> 실제 세계 좌표를 유니티 좌표로 변경, 카메라 관련  
> - **AR Core**는 **Vulkan** 지원 x  
> - Minimum API Level - **Nougat(24)** 부터 AR 가능  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ed97f84c-6f1b-4756-94b6-603fac29d6b6){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br><br>
- - - 

# AR 테스트

## AR Point

> **Point Cloud**  
> - AR Default Point Cloud -> 프리팹화  
> - AR Origin 에 AR Point Cloud Manager 컴포넌트추가 (포인트 추출을 위해), 만든 프리팹 연결   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**테스트**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8547a07f-8b96-4f81-bfe8-767fdc5720af){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


<br><br>

## AR Plane

> **Plane**  
> - AR Default Plane -> 프리팹화  
> - AR Origin 에 AR Plane Manager 컴포넌트추가  만든 프리팹 연결   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**AR Plane Manager Detection Mode -> 설정가능**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b3a751dd-5b51-4e42-b7f8-eb05c91499ca){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


**예시**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8d024721-ec65-4ba1-8eca-91a04a238e3b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

## AR Face

> **Face**  
> - AR Default Face -> 프리팹화  
> - AR Origin 에 AR Face Manager 컴포넌트추가  만든 프리팹 연결  
> - **Maximam Count** (인식 face 수) 설정  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/1215e89c-eb22-47c2-aef7-a8cbd04768fa){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 전면 후면 카메라 설정 **AR CametaManager** -> **Facing Direction** 
> - (**World** - 후면),  (**User** - 전면)  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/4aa98aa6-fe63-4216-b41d-196590b1d47d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

> **Face 효과**  
> - New Material 생성 -> Albedo 에 넣어주고 (이미지는 sprite)  
> - Default Face 의 Materials 부분에 교체 해주면 이미지 확인  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br><br>
- - - 

# AR Plane 활용

## 오브젝트 배치

> **Plane에 큐브 놓기**  
> - 패키지 **XR Interaction Toolkit** 설치  
> - Hierarchy XR Origin(AR) 추가  
> - XR Origin 에 **Plane**, **Raycast** Manager 추가 Raycastmanager none으로  
> - Hierarchy **AR Placement Interactable** 추가 XR Interaction Manager , Origin 연결   
> - 빈오브젝트 속 큐브 만들기 Scale 1 = 1M 조정하기 선택 시 효과   
> - SelectCube Material Randeringmode - **TransParent** 로, 색 변경, 큐브에 Material 추가  
> - 오브젝트 프리팹화 하기  
> - AR Placement Interactable 에 프리팹 등록  
> - Main Camera에 **AR Gesture Interactor**컴포넌트 추가 Interaction, origin 연결  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/4e382eea-2b83-4d05-9b6f-5acfb28ec5e3){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

터치 인식 [AR Gesture Interactor](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit%402.0/manual/ar-gesture-interactor.html) 

<br><br>

## 오브젝트 옮기기

> **배치된큐브 옮기기**   
> - 큐브 오브젝트에 **AR Translation Interactalbe** 컴포넌트 추가   
> - AR Selection Interactable 컴포넌트에 Selection Visualizatior 에 selectcube 넣으면 선택시 효과 가능   
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/ce6dbd55-5fcd-4fc1-bc5b-db4755652891){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br>

## 오브젝트 줌, 회전

> **큐브 회전, 줌**
> - 큐브 오브젝트에 **AR Scale Interactalbe**, **AR Rotation Interactalbe** 컴포넌트   
> - 등 많은 컴포넌트 추가로 효과를 줄 수 있다.  
> - 두손으로 스케일, 회전 가능.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**테스트**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a5dea1d2-eeea-47c0-bd26-ef7680560fa9){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
배치, 선택 후 이동, 줌, 회전이 된다!. 신기


<br><br><br><br><br>
- - - 

# 잡담, 일기?
Point, Face, Plane Manager 코드 보기  
오브젝트 배치, 이동, 줌, 회전  
다양한 컴포넌트 확인  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -
