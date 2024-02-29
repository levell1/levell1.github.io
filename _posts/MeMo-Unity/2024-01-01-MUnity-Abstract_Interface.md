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

**다형성을 구현하는 방법이지만 차이점이 있습니다.**
> - 추상클래스 추상메서드는 브 클래스에서 반드시 구현(오버라이딩)   
> - 일반 메서드, 필드, 생성자 등을 포함할 수 있습니다.   
> - 다른 하위 클래스들이 공유하는 기본 동작을 제공하고, 하위 클래스들이 필요에 맞게 확장할 수 있도록 합니다.
> - 다중상속x  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**인터페이스(Interface)** 
> - 함수 선언만 할 수 있다.  
> - 인터페이스 안에 선언한 모든 함수는 인터페이스를 상속하는 클래스에서 반드시 구현  
> - 서로 다른 클래스 간에 공통된 동작을 정의할 때 사용됩니다.  
> - 인터페이스를 사용하여 클래스 간의 계약(Contract)을 정의  
> - 다중상속O  
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
