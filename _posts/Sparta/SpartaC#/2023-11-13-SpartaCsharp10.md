---
title:  "[C#] 인터페이스(Interface), 열거형(Enum) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-13 13:00

---
- - -
<BR><BR>

<center><H1> C# 인터페이스(Interface), 열거형(Enum)  </H1></center>
C#은 다중상속을 지원하지 않는다. -> 인터페이스는 다중상속이 가능하다.  
인터페이스(Interface), 열거형(Enum)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


> **다중 상속을 사용하지 않는 이유**
> - **1.&nbsp;다이아몬드 문제** : 한 클래스가 두 개 이상의 부모 클래스로 부터 동일한 멤버를 상속받는다.  
코드가 복잡, 가독성 저하
> - **2.&nbsp;설계의 복잡성 증가** : 클래스간의 관계가 복잡  
코드의 유지 보수성이 저하
> - **3.&nbsp;이름 충돌과 해결의 어려움** : 다중 상속받는 멤버들의 이름이 충돌할 수 있다.  
복잡성 증가, 오류 발생 가능성 
> - **4.&nbsp;설계의 일관성, 단순성 유지** : c#은 단일 상속으로 일관성, 단순성 유지 가독성, 이해도 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}


<br><br><br><br><br><br>
- - - 

# 1. 인터페이스(Interface)
다중상속 지원. &nbsp;&nbsp;클래스가 구현해야 하는 멤버들을 정의,&nbsp;&nbsp; I로 시작 (IUseable)  
클래스에 대한 제약 조건을 명시하는 것. = 클래스가 인터페이스를 구현할 경우, 모든 인터페이스 멤버를 구현해야한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

## 사용이유

> - **1.&nbsp;코드의 재사용성** : 다른 클래스에서 해당 인터페이스를 구현하여 동일한 기능을 공유, 동일한 동작을 수행할 수 있다.
> - **2.&nbsp;다중 상속 제공** : C#은 단일상속을 지원하지만, Interface는 다중 상속을 지원, 여러 인터페이스(기능)을 조합할 수 있다.
> - **3.&nbsp;유연한 설계** : 클래스와 인터페이스 간에 느슨한 결합
{: .notice--info}
<br>

<details>
<summary>구현 예제</summary>

<div class="notice--primary" markdown="1"> 

```c# 
// 아이템을 사용할 수 있는 인터페이스
public interface IUsable
{
    void Use();
}

// 아이템 클래스
public class Item : IUsable
{
    public string Name { get; set; }

    public void Use()
    {
        Console.WriteLine("아이템 {0}을 사용했습니다.", Name);
    }
}

// 플레이어 클래스
public class Player
{
    public void UseItem(IUsable item)
    {
        item.Use();
    }
}

// 게임 실행
static void Main()
{
    Player player = new Player();
    Item item = new Item { Name = "Health Potion" };
    player.UseItem(item);
}
```
</div>
</details>

> - 인터페이스 IUseable을 상속받은 클래스 Item
> - Item은 Use라는 메서드를 구현해야한다.
> - Player 클래스에서 item.Use를 사용
> - Main 에서 Player, Item 인스턴스화(Name )
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br>

<details>
<summary>다중 상속 구현 예제</summary>

<div class="notice--primary" markdown="1"> 

```c# 
// 인터페이스 1
public interface IItemPickable
{
    void PickUp();
}

// 인터페이스 2
public interface IDroppable
{
    void Drop();
}

// 아이템 클래스
public class Item : IItemPickable, IDroppable
{
    public string Name { get; set; }

    public void PickUp()
    {
        Console.WriteLine("아이템 {0}을 주웠습니다.", Name);
    }

    public void Drop()
    {
        Console.WriteLine("아이템 {0}을 버렸습니다.", Name);
    }
}

// 플레이어 클래스
public class Player
{
    public void InteractWithItem(IItemPickable item)
    {
        item.PickUp();
    }

    public void DropItem(IDroppable item)
    {
        item.Drop();
    }
}

// 게임 실행
static void Main()
{
    Player player = new Player();
    Item item = new Item { Name = "Sword" };

    // 아이템 주울 수 있음
    player.InteractWithItem(item);

    // 아이템 버릴 수 있음
    player.DropItem(item);
}
```
</div>
</details>

> - 인터페이스 IItemPickabel, IDroppable 을 상속받은 클래스 Item
> - Item은 Pickup, Drop 을 구현해야 한다.
> - Main에서 아이템을 줍고 버리는 기능 수행  
> **궁금한 점**  
Player 클래스에 매개변수 가 왜 인터페이스일까, 클래스Item으로 해도 되지 않을까?
> - **이유**  
클래스로 해도 가능하다, 하지만 나중에 InterFace가 많아지면서 그 메서드가 무슨 기능을 하는지 한눈에 보기 쉽게 Ineterface로 하면 좋다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}



> **추상 클래스의 장단점**  
> - 인터페이스와 비슷하지만 다른.
> - 단점 : 단일상속만 가능, 유연성 제한
> - 장점 : 하위 클래스에 재정의 X, 코드 중복방지, 확장성 제공
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 열거형 Enum
서로 관련된 상수들의 집합을 정의할 때 사용 ENUM = 자료형  
각 상수는 정숫값으로 지정
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

> **사용하는 이유**  
> - 가독성 : 연관된 상수들을 명명할 수 있다.
> - 자기 문서화 : 의미 있는 이름을 사용 
> - 스위치 문과의 호환성 : 스위치 문에서 다양한 상숫값에 대한 분기를 쉽게 작성
{: .notice--info}
<details>
<summary>열거형 사용 switch</summary>

<div class="notice--primary" markdown="1"> 

```c# 
// out 키워드 사용 예시
enum MyEnum
{
    Value1 = 10,
    Value2,   // ->11 이전값의 +1
    Value3 = 20
}

// 형변환
int intValue = (int)MyEnum.Value1;  // 열거형 값을 정수로 변환
MyEnum enumValue = (MyEnum)intValue;  // 정수를 열거형으로 변환

// 스위치문과 사용
switch(enumValue)
{
    case MyEnum.Value1:
        // Value1에 대한 처리
        break;
    case MyEnum.Value2:
        // Value2에 대한 처리
        break;
    case MyEnum.Value3:
        // Value3에 대한 처리
        break;
    default:
        // 기본 처리
        break;
}

// 월 열거형
public enum Month
{
    January = 1,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

// 월 출력 예제
// 처리하는 함수
static void ProcessMonth(int month)
{
    if (month >= (int)Month.January && month <= (int)Month.December)
    {
        Month selectedMonth = (Month)month;
        Console.WriteLine("선택한 월은 {0}입니다.", selectedMonth);
        // 월에 따른 처리 로직 추가
    }
    else
    {
        Console.WriteLine("올바른 월을 입력해주세요.");
    }
}

// 실행 예제
static void Main()
{
    int userInput = 7; // 사용자 입력 예시
    ProcessMonth(userInput);
}

```
</div>
</details>

<br><br>

## Enum호기심
Enum에 없는 int값 을 넣으면? 어떻게될까? 오류가 뜨나? ->  
튜터님에게 물어봤다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
enum MyEnum
{
    Value1 = 10,
    Value2, //11 +1
    Value3 = 20
}

// 게임 실행
static void Main()
{
    int intValue = (int)MyEnum.Value1;  // 열거형 값을 정수로 변환
    intValue = int.Parse(Console.ReadLine());
    //MyEnum enumValue = (MyEnum)intValue;  // 정수를 열거형으로 변환
    MyEnum enumValue = (MyEnum)100;  // 정수를 열거형으로 변환
    switch (enumValue)
    {
        case MyEnum.Value1:
            Console.WriteLine("10"+MyEnum.Value1);
            break;
        case MyEnum.Value2:
            Console.WriteLine("11"+MyEnum.Value2);
            break;
        case MyEnum.Value3:
            Console.WriteLine("20"+MyEnum.Value3);
            break;
        default:
            // 기본 처리
            break;
    }
    Console.WriteLine(intValue);
    Console.WriteLine("enumvalue : " + enumValue);      //Value1~3출력  enumValue=100 일때는 100이 출력된다.
    Console.WriteLine(MyEnum.Value1);
    Console.WriteLine(MyEnum.Value2);
    Console.WriteLine(MyEnum.Value3);
}
```
</div>

> - enumValue 에  10 -> Value1, 11 -> Value2, 20 -> Value3
> - 100을 넣으면? -> 100이 출력됌   
MyEnum enumValue = (MyEnum)100; 에서 오류가 안 뜨고 출력 부분에서  100이 출력됨   
> - 매칭이 안되는 값을 저장하려고 할 때 어떤 주소값에 <int>값으로 저장이 되긴 한다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

<br><br>
- - - 

[Unity] C# 인터페이스(Interface), 열거형(Enum)

<br>

참고 : [유니티](https://docs.unity3d.com/kr/) [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
