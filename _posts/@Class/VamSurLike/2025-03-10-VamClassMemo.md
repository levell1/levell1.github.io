---
title:  "[Unity 강의] 뱀서라이크 강의 정리"
excerpt: ""

categories:
    - Class VamSurLike
tags:
    - [C#, Unity, VamSurLike]

toc: true
toc_sticky: true
 
date: 2025-03-10 08:00

---
- - -

`1 ~ 3 유니티 기초` `4 ~ 8 오브젝트와 데이터` `9 ~ 12 보석과 스킬 ` `13 ~ 16 보스와AI ` `17 ~ 19 마무리` `부록`

<br>
- - - 

# 1강 (유니티 기초)
✔ 게임오브젝트 - 컴포넌트 의 통신, 게임오브젝트 - 게임오브젝트 간의 작용  
✔ 게임오브젝트 - 게임오브젝트 간의 작용 (SerializeField, Find(사용 X))  
✔ 상속 활용하기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 2강 (컨텐츠 기초)
✔ 리소스 관리  
✔ SceneManager  
✔ 카메라 = LateUpdate  
✔ normalized 방향정보  
✔ Prefabs 작업시 override 체크  
✔ 배경 작업할때 - Order in Layer 규칙 정하기.  
✔ 리소스 관리 규칙 정하기(오브젝트별, 폴더분류).  
✔ Order in Layer 규칙 정하기.  
✔ 게임 플레이에 따라 순차적으로 작업 (플레이어이동 -> 스킬 -> 드랍)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 3강 (조이스틱)
✔ 게임오브젝트 - 컴포넌트의 연결 좋은방법으로 고민하기.(Find,Manager사용)  
✔ Canvas Scaler - UI Scale Mode -> Scale With Screen Size (화면크기에 맞게 UI조정 )  
✔ Raycast Target 체크 확인  
✔ magnitude = vector의 크기(거리)  
✔ Static - 객체랑 무관하다. (종속x) Static에 관하여 공부.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 4강 (매니저)
✔ 설계적인 부분을 생각하며 만들자.  
✔ 오브젝트간 연결 - 코드에서 관리   
✔ 최상위 매니저(싱글톤) - MonoBehaviour - 다른매니저를 들고있는  
✔ 하위 매니저 - 일반 클래스로  
✔ 델리게이트 공부하기  
✔ [Manager](https://levell1.github.io/class%20vamsurlike/VamClass04/#1-manager)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 5강 (Addressable) ⭐
[Addressable](https://levell1.github.io/class%20vamsurlike/VamClass05)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br>
- - - 

# 잡담, 일기?
모든 강의 정리.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -