---
title:  "[Memo-Unity] 30. 추상클래스(Abstract), 인터페이스 (Interface)  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2024-01-01 01:14

---
- - -

`추상클래스(Abstract)` `인터페이스 (Interface)` 
<BR><BR>

<center><H1>  Abstract Interface  </H1></center>
Abstract Interface 생각나서 한번 정리  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
<br><br><br><br><br><br>
- - - 


# 추상클래스, 인터페이스 차이

**추상클래스(Abstract)** - **설계목적** 구현가능  
상속받은 자식이 새로 구현(반드시 오버라이딩)  
반드시 구현해야 할 건 추상클래스로 선언하자.  
부모 public abstract void 함수();  
자식 public override void 함수();  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

추상클래스 **문제점**  -> 다중상속 x -> Interface 사용  
다중상속 안되는 이유 -> 추상클래스에는 **일반함수도 포함**되어 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

**인터페이스(Interface)** -> 일반함수, 일반변수 선언 X, 구현X -> **다중상속 O**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br><br><br><br><br>
- - - 

# 잡담
추상 클래스는 구현을 가질 수 있고, 단일 상속만 가능합니다.  
상속받은 자식이 새로 구현 해야된다. (반드시 오버라이딩)  
상속을 강제하기 위함 상위 클래스의 기능을 이용하거나 확장하여 사용합니다.  

인터페이스는 구현을 가질 수 없고, 다중상속이 가능하다.  
인터페이스를 구현한 객체들에 대한 동일한 사용방법과 동작을 보장하기 위해 사용합니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] Abstract Interface
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
