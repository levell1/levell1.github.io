---
title:  "[TIL] 98 AR VR 스터디 ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-03-28 02:00

---
- - -

`AR` `AR Foundation` `AR Core`

<BR><BR>

<center><H1>  이력서 진행중, 강의듣기,AR VR 스터디 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53       
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기. 책사기  
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
&nbsp;&nbsp; [x] 포트폴리오 강의듣고 만들기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

**AR**

# AR세팅 준비
[AR_Sample](https://github.com/Unity-Technologies/arfoundation-samples/tree/5.1)  

> **AR 프로젝트 세팅**  
> - 3D 프로젝트 생성  
> - &nbsp;&nbsp; 1. 플러그인 설치 [AR Foundation](https://unity.com/unity/features/arfoundation)  
> - &nbsp;&nbsp; 2. 윈도우 -> 패키지 매니저 -> AR Foundation설치, ARCore(Google ARCore XR Plugin) 설치
> - &nbsp;&nbsp; 3. Edit > Project Settings > **XR Plug-in Management** > Android ARCore 체크 , 빌드세팅 안드로이드로 변경
> - &nbsp;&nbsp; 4. hierarchy 메인카메라 삭제, XR -> **AR Sessio**n 추가, **XR Origin** 추가 
> - &nbsp;&nbsp; 5. Edit > Project Settings > **Player** - Other Settings -> autoGraphics API 체크해제, Vulkan 삭제  
> - &nbsp;&nbsp; 6. Identification -> minimum API Level -Nougat(24), Configuration -> Scripting Backend =IL2CPP, Target Architectures = ARM 64 체크 
> - &nbsp;&nbsp; 프로젝트 빌드 세팅 끝. 

**AR Foundation** -> AR 플랫폼 간에 전환할 때 현재 사용할 수 없는 기능을 어디에서나 이용가능하게 해주는 역할
**AR Session** -> AR에 맞는 생명주기,세팅의 기본
**XR Origin** -> 실제 세계 좌표를 유니티 좌표로 변경, 카메라 관련
AR Core는 Vulkan 지원 x
minimum API Level -Nougat(24) 부터 AR 가능

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ed97f84c-6f1b-4756-94b6-603fac29d6b6){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

<br><br><br><br><br>
- - - 

# AR 
**AR 테스트**

> **포인트 체크**
> - AR Default Point Cloud -> 프리팹화
> - AR Origin 에 AR Point Cloud Manager 컴포넌트추가 (포인트 추출을 위해), 만든 프리팹 연결
> - 빌드 후 실행 -> 포인트 잘 나오는지 체크

**테스트**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ea5a8956-1c88-41de-902e-ddc423010be0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

AR Default Point Cloud 꼭짓점

<br><br><br><br><br>
- - - 

# 잡담, 일기?
포톤강의 - 나중에 필요할 때 더 알아보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -
