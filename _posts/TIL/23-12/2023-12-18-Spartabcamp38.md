---
title:  "[TIL] 38 3D 강의, 팀과제  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-18 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 9일차, 팀과제 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 45  
&nbsp;&nbsp; [o] 강의 듣기 - 2개 복습하기  
&nbsp;&nbsp; [o] 반별 강의  
&nbsp;&nbsp; [X] 다른반 강의 듣기    
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 1. 팀과제
강의 코드를 베이스로 하였고, 
1. 원거리 적 추가
2. 적 체력 낮으면 도망가기 
3. 원거리는 도망가다가 사거리 안에 들어오면 다시 공격  
4. 몹젠 5마리  
5. 시간 지나면 기지로 어그로  
6. (추가하기) 죽이면 나눠져서 생성
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

# 2. 코루틴
코루틴은 함수의 실행을 일시 중지하고, 이후에 다시 재개할 수 있는 기능을 제공합니다.  
예시) 무적상태 5초 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    bool invincible = false;

    void Start()
    {
        StartCoroutine(InvincibilityCoroutine());
    }

    IEnumerator InvincibilityCoroutine()
    {
        invincible = true;
        yield return new WaitForSeconds(5f);
        invincible = false;
    }
}

```
</div>

<br><br><br><br><br><br>
- - - 

## 1) Enumerator
Enumerator는 IEnumerator 라는 인터페이스를 구현해야 합니다. IEnumerator 인터페이스는 Current (속성), MoveNext() (메서드), Reset() (메서드) 등 3개의 멤버로 이루어져 있는데, Enumerator가 되기 위해서는 Current와 MoveNext() 를 반드시 구현해야 합니다. 
이를 통해 유니티의 DelayedCallManager가 등록하고 있다가 다음 단계에 실행하는 방식으로 구현되어 있습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 2) Yeild 종류

> - yield return null : `다음 프레임`까지 대기
> - yield return new WaitForSeconds(float) : 입력한 `초(sec)` 만큼 대기
> - yield return new WaitForSecondsRealtime(float) : Timescale영향없는 `실제 시간` 기준 초 대기
> - yield return new WaitFixedUpdate() : 다음 프레임의 `FixedUpdate` 까지 대기
> - yield return new WaitForEndOfFrame() : 모든 `랜더링 작업이 끝날 때`까지 대기
> - yield return startCoroutiune(string) : 입력한 `다른 코루틴이 끝날 때`까지 대기
> - yield return new www(string) : 입력한 `웹 통신 작업이 끝날 때`까지 대기
> - yield break : 코루틴 종료
코루틴은 StopCoroutine과 StopAllCoroutines를 이용하여 코루틴을 정지가능하며  
코루틴을 소유하고 있는 게임오브젝트를 정지하거나 파괴하는 경우에도 종료됩니다. 단, 컴포넌트를 .enabled를 false로 하는 경우 꺼지지 않습니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br><br>
- - - 



# 3. 카메라 뷰
카메라 Projection = Orthographic -> 원근감 X  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/af632df7-4ffa-4735-a6e1-bfd1178d148b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 1) 탑다운
2D, 3D : X축 45도이상   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/abd542e9-7011-4237-8949-316d36cb88e4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 2) 사이드
원근법 무시 (2D, 3D : Orthographic, 캐릭터 follow)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/09cd8df0-eeff-4ef9-bd6f-0ff90e942430){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 3)1인칭 주인공 시점
3D, 캐릭터 Follow  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/cf4205fd-0bd9-4453-b0d5-0a538e44e895){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 4) 3인칭 백뷰(숄더뷰) 
3D 주로, 캐릭터 후방 상공에서 X축 살짝 회전  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/77ea29d5-2e74-4bcd-a92b-eda836601331){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 5)아이소메트릭(쿼터뷰)
원근법 무시 + x축 30도 y축 45도  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/d82ef192-c32b-4d93-ac37-50223e519a96){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 잡담,정리

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
