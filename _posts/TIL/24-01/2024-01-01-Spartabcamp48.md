---
title:  "[TIL] 48 강의 - 코루틴(coroutine), 디자인패턴  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-01 02:00

---
- - -

`coroutine`

<BR><BR>


<center><H1>  유니티 심화주차 8일 , 개인공부 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 51  
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 코루틴(coroutine)
다수의 프레임에 분산시켜서 실행할 수 있는 문법  
일반 메서드는 1프레임에 실행  
코루틴은 동시적이다, 비동기 X  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c# 
Coroutine coroutine = null

void Update()
{
    coroutine = StartCoroutine(CoFade())

    if(input.GetKeyDown("t"))
    {
        if(coroutine !=null) StopCoroutine(coroutine)
    }
}

```
- StopCoroutine(함수명()) 은 원하는 때에 멈추지 않을 수 도 있다.  
- StopCoroutine("함수명"), stopAllCoroutine  
- StopCoroutine("함수명")은 추적이안된다.  
- 위 방법으로 변수를 이용해서 사용하자.  

</div>

Waitforsecont 보다   
게임의 프레임을 맞추고 waitforendofframe을 쓰면 모든컴퓨터의 기준을 똑같이 가능.  
yield return WWW 서버관련  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<br><br><br><br><br>
- - - 

# 동기 비동기

**동기, 비동기**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8ff085aa-b01b-4653-8662-1fc88858d0ba)

유니티 단일 스레드  
C# 멀티스레드 이용가능 BUT 유니티 기능에 접근 불가능  
UnityMainThreadDispatcher등을 이용, 구현(Queue사용)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

**심화주차강의**  
# FSM
유한 상태 기계(Finite State Machine, FSM)  

> - **FSM의 개념**  
> FSM은 유한 상태 기계를 나타내는 디자인 패턴입니다.
> 상태와 상태 간의 전환을 기반으로 동작하는 동작 기반 시스템입니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice-success}  

> - **FSM의 구성 요소**
> 상태 (State): 시스템이 취할 수 있는 다양한 상태를 나타냅니다.
> 전환 조건 (Transition Condition): 상태 간 전환을 결정하는 조건입니다.
> 동작 (Action): 상태에 따라 수행되는 동작 또는 로직을 나타냅니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice-success}  

> - **FSM의 예시**: 플레이어 상태 관리
> 상태: 정지 상태, 이동 상태, 점프 상태
> 전환 조건: 이동 입력, 점프 입력, 충돌 등의 조건
> 동작: 이동 애니메이션 재생, 점프 처리, 이동 속도 조정 등
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br><br><br><br>
- - - 

# 추상클래스, 인터페이스 차이

 
**추상클래스(Abstract)** - 메서드 : **설계목적** 구현x -> 상속받은 자식이 새로 구현(반드시 오버라이딩) 반드시 구현해야 할 건 추상클래스로 선언하자.  
부모 public abstract void 함수();  
자식 public override void 함수();  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

추상클래스 **문제점**  -> 다중상속 x -> Interface 사용  
다중상속 안되는 이유 -> 추상클래스에는 **일반함수도 포함** 되어 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

**인터페이스(Interface)** -> 일반함수, 일반변수 선언 X -> **다중상속 O**  
추상함수인데 일반함수,변수가 없는 추상함수라고 생각  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 


# Input system 
inputAction.CallbackContext 를 통해 input value를 받아올 수 있다.  
해당 값은 inputAction에서 지정한 형태로 Cast 가능  
**`Event`** 에는 총 3가지 가 있다. started, performed, canceled 가 있다.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

move.stared += onmovement;   
move.canceled -= onmovement;  

<br><br><br><br><br>
- - - 

# 잡담,정리
코루틴은 비동기같은 동기  
추상클래스, 인터페이스 차이  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
