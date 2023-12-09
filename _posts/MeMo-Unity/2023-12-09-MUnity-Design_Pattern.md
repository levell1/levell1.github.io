---
title:  "[Memo-Unity] 12. Design Pattern : `singleton`, `state`, `observer`, `command` `component`, `builder`, `flyweight`  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-09

---
- - -
<BR><BR>

Design Pattern  
`singleton`, `state`, `observer`, `command`  
`component`, `builder`, `flyweight`  

<center><H1> Design Pattern </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. 싱글톤 패턴 (singleton)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/357ef27b-e877-445f-b3a5-a8c679541e91)   

> - 특정 클래스의 인스턴스가 단 하나만 존재하도록 보장하는 디자인 패턴
> - 클래스의 인스턴스를 전역적으로 접근 가능
> - 게임의 설정, 오디오 매니저, UI 매니저 같이 전역적으로 하나만 존재
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<details>
<summary>코드보기</summary>


<div class="notice--primary" markdown="1"> 

```c#


```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 2. 상태패턴 (state)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8ef94cd9-ef44-4cae-911f-1ba64cdbc912)  

> - 객체의 상태에 따라 객체의 행동을 변경 해주는 디자인 패턴
> - 조건문으로 나누는 것이 아니라 **객체의 상태를 별도의 클래스로 캡슐화**
> - 게임 캐릭터의 상태(대기, 이동, 공격)에 따라 행동이 달라지게 구현
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br><br>
- - - 

# 3. 관찰자 패턴(observer)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1a971805-1f06-4989-a18e-3cccc5c6223d)  

> - 한 객체의 상태 변화를 관찰하는 다수의 객체(관찰자들)
> - 주인공 객체가 변하면 관찰자들에게도 자동으로 이를 알려줌
> - 상태 변화에 따른 자동 업데이트 (**`구동 시스템과 유사`**)
> - 의존성 줄이고 중요한 정보를 적절히 공유하는 형태
> - ex) 플레이어 체력변화에 따른 이벤트를 구현할 때 유용
<br><br><br><br><br><br>
- - - 

# 4. command

<br><br><br><br><br><br>
- - - 

# 5. component

<br><br><br><br><br><br>
- - - 

# 6. builder

<br><br><br><br><br><br>
- - - 

# 7. flyweight



<br><br>
- - - 

[C#] 디자인 패턴 (Design Pattern)
[참조](https://docs.unity3d.com/kr/2021.3/Manual/Coroutines.html)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
