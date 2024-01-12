---
title:  "[TIL] 58 이전 TIL, 일주일 정리  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-12 02:00

---
- - -



<BR><BR>

<center><H1>  최종 팀 프로젝트 3일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 다른반 강의 듣기 스탠다드2 챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 디자인 패턴 이해,정리하기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 게임매니저에서 모든 매니저 관리 VS  2. 모든 매니저 싱글톤 상속

**게임매니저 - 싱글톤**  
편하지만 게임매니저의 의존성 커짐, 게임매니저를 부를 때 초기화된다.  
규모가 큰 게 아니면 게임 매니저에 넣는 게 좋다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br>

**매니저마다 상속**  
무겁지 않다, 의존성 떨어진다, 게임매니저를 통해 가는 게 아니라 주의가 필요함  
필요한 시점에 만들어 줄 수 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

**메모리 측면에서의 차이점**  
**파편화**  
1. 게임매니저 - 싱글톤  1~10 까지 메모리 차지  
2. 싱글톤 상속  메모리 1~2 , 6, 7  57, 67 등  
각자 알아서 공간을 차지함. 이 경우 다른 메모리 공간이 큰 걸 썼을 때 넣지 못할 수도 있다.  → 메모리를 옮기는 작업이 필요하다. 처리 속도가 느려진다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

**결과 : 1. 게임매니저- 싱글톤 결정.**  
매니저.  지금 당장은 너무 깊게 보단 게임 기능쪽으로 더 시간을 투자하자.  
규모가 큰 게 아니면 게임 매니저에 넣는 게 좋다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

**기술면접**  
# float와 int의 표현 가능한 수의 범위가 다른 이유는 무엇인가요?

**같은4Byte? 다른범위**  
우선 float 와 int 는 **같은 4byte** 를 가진다.   
하지만 표현 가능한 수의 **범위의 차이가 매우 큽니다.**  
int 는 간단하게 -2,147... ~ +2,147... 의 수를 표현 가능합니다.  
float의 범위는 int의 범위와 비교 불가능한 범위의 수를 가지고 있습니다.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**float는 어떻게 표현되나**  
float 는 지수비트(8), 유효자리비트(23)으로 나눴다고 해도 중간에 4byte로는 표현 하지 못하는 수가 있습니다.  그럼 그 수들은 어떻게 표현하나?  
아주 크거나 아주 작은 소수의 단위는 그 **근사치의 값을 취하게 됩니다**. 1.1E+10, 1.1E+10 +1 ,1.1E+10 +2, 1.1E+10 +3 이 모두 1.0E+10의 값을 취하게 됩니다.   
int로 치면 5~15가 10으로 표현되어서 9개의 숫자를 추가로 더 표현 하여 범위가 9만큼 늘어난 것이라고 생각합니다. 또 float 대신 좀 더 정확한 수를 위해서 double을 사용하면 좋다고 생각합니다.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**정리**  
결과적으로 int, float의 표현 할 수 있는 수의 **개수는 비슷하다고** 생각하지만 분포가 다르기 때문에 **범위가 다르다**.  라고 생각합니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

**고민의 흔적**  
**float 가 ^38인 이유?**  
**자리수 7자리?**

<div class="notice--primary" markdown="1"> 

```c#
-2,147,483,647 ~ 2,147,483,647
2 32

8,388,607 * 10 ~ 8,388,608 * 10
83,886,070  ~ 83,886,080  

2 23 * 2*8

+-*127 ~ 128
 -37 ~ 38

2 * 127 
170141183460469231731687303715884105728

-1.70141183460469231731687303715884105728 * 10 X 38

-1.7 10 ^38~ 3.4 10 ^38

255
-127 0 128 
```
</div>



<br><br><br><br><br>
- - - 

# 잡담,정리
주말에 이번 주 til 정리, 강의 정리 하기
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
