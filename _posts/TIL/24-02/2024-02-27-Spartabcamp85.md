---
title:  "[TIL] 85 해상도 관련 UI수정, 유니티 생명주기⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-27 02:00

---
- - -


<BR><BR>

<center><H1>  최종 팀 프로젝트 27일차  </H1></center>

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

# 해상도
해상도 관련해서 신경쓰지않고 UI를 만들었다.  
그리고 **WIDE** 모니터, 등 많은 다른 모니터들이 있고, 화면마다 다르게 UI 가 보이는 현상이 있었다.  다른 해상도로 체크해보면서 앵커,UI 배치 등 바꾸었다.  
UI 설정 시 앵커, 위치등 다음부턴 처음에 만들 때 신경쓸 거 같다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

# 기술면접
## 26. 유니티 생명주기

Unity의 생명주기(Unity Life Cycle)는 게임 오브젝트 및 스크립트가 실행되는 과정을 설명하는 것입니다. 이것은 게임 오브젝트의 초기화, 업데이트, 렌더링 및 파괴 과정을 포함합니다.  
초기화(awke onenable start), 업데이트 (FixedUpdate - update - lateUpdate), 렌더링, 소멸 의 순서로 여러개의 함수가 실행, 반복합니다.  

<br><br>

**Initialization**
> - Awake: 이 함수는 항상 Start 함수 전에 호출되며 프리팹이 인스턴스화 된 직후에 호출됩니다. 게임 오브젝트가 시작하는 동안 비활성 상태인 경우 **Awake 함수는 활성화될 때까지 호출되지 않습니다.**
> - OnEnable: 오브젝트 활성화 직후 이 함수를 호출합니다. 레벨이 로드되거나 스크립트 컴포넌트를 포함한 게임 오브젝트가 인스턴스화될 때와 같이 MonoBehaviour를 생성할 때 이렇게 할 수 있습니다.
> - Start: 스크립트 인스턴스가 활성화된 경우에만 첫 번째 프레임 업데이트 전에 호출됩니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

**FixedUpdate**
> - Update 보다 더 자주 호출됩니다. 프레임 속도가 낮은 경우 프레임당 여러 번 호출될 수 있으며 프레임 속도가 높은 경우 프레임 사이에 호출되지 않을 수 있습니다. 모든 물리 계산 및 업데이트는 FixedUpdate 후 즉시 발생합니다. 
> - FixedUpdate 의 움직임 계산을 적용할 때 Time.deltaTime 만큼 값을 곱할 필요가 없습니다.  물리 엔진 업데이트와 관련된 작업에 사용됩니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

**Update**
> - 프레임당 한 번 호출됩니다. 프레임 업데이트를 위한 주요 작업 함수입니다.
> - 게임 로직이나 사용자 입력 처리 등 게임 상태의 변경을 다룹니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

**LateUpdate**
> - Update 가 끝난 후 프레임당 한 번 호출됩니다. Update 에서 수행된 모든 계산은 LateUpdate 가 시작할 때 완료됩니다. LateUpdate 는 일반적으로 다음의 3인칭 카메라에 사용합니다.
> - 캐릭터를 움직이고 Update 로 방향을 바꾸게 하는 경우 LateUpdate 에서 모든 카메라 움직임과 로테이션 계산을 수행할 수 있습니다. 이렇게 하면 카메라가 포지션을 추적하기 전에 캐릭터가 완전히 움직였는지 확인할 수 있습니다.
> - 주로 카메라 이동이나 따르는 오브젝트의 처리와 같은 작업에 사용됩니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

**Rendering**: 화면에 그려질 내용을 처리합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

Destruction
OnDestroy: 오브젝트 존재의 마지막 프레임에 대해 모든 프레임 업데이트를 마친 후 이 함수가 호출됩니다. 오브젝트는 Object.Destroy 또는 씬 종료에 대한 응답으로 파괴될 수 있습니다. 리소스 해제나 정리 작업을 수행합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 잡담,정리

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
