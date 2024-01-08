---
title:  "[TIL] 54 팀프 디버그, 디자인패턴 강의 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-08 02:00

---
- - -


`Design_Pattern`,`디자인 패턴`

<BR><BR>

<center><H1>  Design_Pattern  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 52  
&nbsp;&nbsp; [o] 다른반 강의 듣기   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 남은 강의듣기, 디자인 패턴 이해,정리하기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# Design_Pattern

## 싱글턴
싱글턴 패턴으로 게임 매니저 구현  
유니티에서는 정말 많이 쓰는 패턴  
유일성, 전역적 - 하나의 인스턴스만 존재  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**장점**  
&nbsp;&nbsp;1. 전역적 접근 가능  
&nbsp;&nbsp;2. 공유 자원에 동시 접근을 제한하거나 사용할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**단점**  
&nbsp;&nbsp;1. 유닛 테스트가 어려움  
&nbsp;&nbsp;2. 잘못된 프로그래밍 습관을 유발함  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8b3637b3-5f7f-4fff-bafe-bebff943a30c)

제네릭 싱글톤 만들어서 필요한 매니저에 상속

<div class="notice--primary" markdown="1"> 

```c# 
코드로 적기
```
</div>

<br><br><br><br><br>
- - - 


## 상태 패턴
캐릭터 상태가 끊임없이 전환  
객체가 내부 상태를 기반으로 움직이는 시스템
상태를 불러내는 호출자 -> 인터페이스 -> 상태ABC
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**장점**  
&nbsp;&nbsp;1. 캡슐화
&nbsp;&nbsp;2. 긴 조건문, 방대한 클래스 구현하는 것을 막음
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**단점**  
&nbsp;&nbsp;1. 만약 상태가 전환되는 사이에서 발생하는건 따로 구현을 해야함.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**코드**  
<div class="notice--primary" markdown="1"> 

```c# 
코드로 적기
```
</div>

<br><br><br><br><br>
- - - 

## 이벤트 버스 패턴
전역 이벤트를 관리하는 중앙 허브 개념  
게임에서 월드 이벤트 발생시 해당 캐릭터들에게 이벤트를 발송하는 식
구현하기 의외로 매우 간단해서 많이 쓰임.  
어떤 객체에서 이벤트가 발생하면 다른 구독자가 신호를 받는 시스템
발행/구독 패턴
발행자와 구독자는 서로인식x 중간에 버스가 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**장점**  
&nbsp;&nbsp;1. 오브젝트를 직접 참조x, 이벤트 통신
&nbsp;&nbsp;2. 구독 시스템을 쉽게 구현하게 만듬
&nbsp;&nbsp;3. 프로토타입 만들 때 많이 쓰임 , 쉽고 빠르다
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**단점**  
&nbsp;&nbsp;1. 약간의 성능비용
&nbsp;&nbsp;2. 이벤트 버스가 static 전역 변수라, 전역변수의 단점을 모두 가지게 됨.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**코드**  
<div class="notice--primary" markdown="1"> 

```c# 
코드로 적기
```
</div>

<br><br><br><br><br>
- - - 

[시연영상](https://youtu.be/_TnqFKMlluw)
[excalidraw](https://excalidraw.com/#room=7f9af77f81201e6316f9,Pc9tAjBgRc27mN-BAg4pmQ)

<br><br><br><br><br>
- - - 

# 잡담,정리
게임 기획 -> 처음기획 너무 크게x, 처음기획에 집착, 점진적으로 아이디어 추가  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
