---
title:  "[C#] 객체 지향 (클래스와 객체)  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-09 09:30

---
- - -
클래스 프로퍼티, 구조체, 접근 제한자
<BR><BR>

<center><H1> C# 객체 지향 (클래스와 객체 상속과 다형성)  </H1></center>
C# 객체 지향 (클래스와 객체)
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 객체지향 프로그래밍
캡슐화 **`Encapsulation`** &nbsp;&nbsp;&nbsp;상속 **`Inheritance`** &nbsp;&nbsp;&nbsp;다형성 **`Polymorphism`**  
객체 **`Object`** &nbsp;&nbsp;&nbsp;추상화 **`Abstraction`**

> **특징**
> - 1.&nbsp;캡슐화 : 관련 데이터, 기능을 하나로 묶는 것, 정보은닉, 안정성 유지보수성
> - 2.&nbsp;상속 &nbsp;&nbsp;&nbsp;&nbsp;: 기존 클래스를 확장해 새 클래스를 만든다, 코드의 중복을 줄이고,구조화, 유지보수
> - 3.&nbsp;다형성 : 하나의 기능,인터페이스를 다양한 방식으로 구현, 사용하는 능력,  
>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;하나의 메서드 이름이 다양한 객체에 다르게 동작,  
>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;유연하고 확장가능, 가독성, 재사용성  
> - 4.&nbsp;추상화 : 복잡한 시스템,개념을 단순화, 실제 세계의 개념 모델링, 필요부분 정의  
>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;필요한 기능에 집중, 핵심 개념에 집중함으로써 코드의 이해와 유지보슈  
> - 5.&nbsp;객체 : 클래스로부터 생성된 실체, 데이터를 조작  
{: .notice}

<br><br><br><br><br><br>
- - - 

# 2. 클래스
클래스는 속성과 동작을 가진다. 속성은 필드로, 동작은 메서드로 표현  
객체를 생성하기 위해서는 클래스를 사용하여 인스턴스를 만들어야 한다.  
{: .notice}
<div class="notice--primary" markdown="1"> 

```c# 
class Person
{
    public string Name;
    public int Age;

    public void PrintInfo()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }
}

Person p = new Person();    //인스턴스화
p.Name = "John";
p.Age = 30;
p.PrintInfo(); // 출력: Name: John, Age: 30

```
- 클래스 선언과 인스턴스
</div>

<br><br>

## 필드, 메서드

<div class="notice--primary" markdown="1"> 

```c# 
class Player
{
    // 필드
    private string name;
    private int level;

    // 메서드
    public void Attack()
    {
        // 공격 동작 구현
    }
}

Player player = new Player();  // Player 클래스의 인스턴스 생성
player.Attack();  // Attack 메서드 호출

```
</div>

<br><br>

## 생성자
> - 생성자는 객체가 생성될 때 호출되는 특별한 메서드입니다.
> - 생성자는 클래스와 동일한 이름을 가지며, 반환 타입이 없습니다.
> - 생성자도 오버로딩 가능
{: .notice}
<details>
<summary>전체 코드 보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
class Person
{
    private string name;
    private int age;

    // 매개변수가 없는 디폴트 생성자
    public Person()
    {
        name = "Unknown";
        age = 0;
    }

    // 매개변수를 받는 생성자
    public Person(string newName, int newAge)
    {
        name = newName;
        age = newAge;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
}

Person person1 = new Person();                     // 디폴트 생성자 호출
Person person2 = new Person("John", 25);           // 매개변수를 받는 생성자 호출
```
</div>
</details>

<br><br>

## 소멸자
객체가 소멸되는 시점에서 자동으로 호출되는 특별한 메서드.   
이름 앞에 ~ 기호를 붙여 표현   
> - 자원 해제: 외부 리소스를 사용한 경우, 소멸자를 통해 리소스를 해제할 수 있습니다.  
> - 메모리 해제: 객체가 사용한 메모리를 해제하고 관련된 자원을 정리할 수 있습니다.  
> - 로깅 및 디버깅: 객체가 소멸되는 시점에 로깅 작업을 수행하거나 디버깅 정보를 기록할  수 있습니다.
{: .notice}


<div class="notice--primary" markdown="1"> 

```c# 
class Person
{
    private string name;

    public Person(string newName)
    {
        name = newName;
        Console.WriteLine("Person 객체 생성");
    }

    ~Person()
    {
        Console.WriteLine("Person 객체 소멸");
    }
}
```
</div>

<br><br>

## 프로퍼티(Property)
객체의 필드에 직접 접근하지 않고, 간접적으로 값을 설정하거나 읽을 수 있도록 합니다.
접근 제어와 데이터 유효성 검사 등을 수행
외부에서 접근할 때 추가적인 로직을 수행
{: .notice}

> **자동 프로퍼티**
> -  프로퍼티를 간단하게 정의하고 사용할 수 있는 편리한 기능
> - 필드의 선언과 접근자 메서드의 구현을 컴파일러가 자동으로 처리하여 개발자가 간단한 구문으로 프로퍼티를 정의
{: .notice}

<details>
<summary>코드 보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
[접근 제한자] [데이터 타입] 프로퍼티명
{
    get
    {
        // 필드를 반환하거나 다른 로직 수행
    }
    set
    {
        // 필드에 값을 설정하거나 다른 로직 수행
    }
}

// 사용 예시
class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}

Person person = new Person();
person.Name = "John";   // Name 프로퍼티에 값 설정
person.Age = 25;        // Age 프로퍼티에 값 설정

Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");  // Name과 Age 프로


// 접근 제한자 적용, 유효성 검사 예시
class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
        }
    }
}

Person person = new Person();
person.Name = "John";     // 컴파일 오류: Name 프로퍼티의 set 접근자는 private입니다.
person.Age = -10;         // 유효성 검사에 의해 나이 값이 설정되지 않습니다.

Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");  // Name과 Age 프로퍼티에 접근하여 값을 출력합니다.

//자동 프로퍼티

[접근 제한자] [데이터 타입] 프로퍼티명 { get; set; }

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

Person person = new Person();
person.Name = "John";     // 값을 설정
person.Age = 25;          // 값을 설정

Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");  // 값을 읽어 출력
```
</div>
</details>

필드를 public으로 하면 어떻게 안써도 되지 않나? 라는 생각을 했었고, 필드를 private로 사용하는 이유 정보은닉, 데이터 보호, 내부적으로만 사용등 많은 이유가 있다.
{: .notice}

<br><br>

## 구조체 vs 클래스

> **구조체**  
> - 구조체는 값 형식이며, 스택에 할당되고 복사될 때 값이 복사
> - 상속을 받을 수 없다
> - 작은 크기의 데이터 저장이나 단순한 데이터 구조에 적합
{: .notice}


> **클래스**  
> - 클래스는 참조 형식이며, 힙에 할당되고 참조로 전달
> - 클래스는 단일 상속 및 다중 상속이 가능
> - 더 복잡한 객체를 표현하고 다양한 기능을 제공
{: .notice}

<br><br><br><br><br><br>
- - - 

# 3. 접근 제한자
클래스의 캡슐화를 제어하는 역할  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
class Person
{
    public string Name;        // 외부에서 자유롭게 접근 가능
    private int Age;           // 같은 클래스 내부에서만 접근 가능
    protected string Address;  // 같은 클래스 내부와 상속받은 클래스에서만 접근 가능
}
```

</div>


# 정리 잡답
> - 객체지향, 클래스(필드, 메서드, 생성자, 소멸자, 프로퍼티)
> - 구조체,클래스 차이
> - 접근 제한자 Public Private Protected
{: .notice}


<br><br>
- - - 

[Unity] C# 객체 지향 (클래스와 객체) 

<br>

참고 : [유니티](https://docs.unity3d.com/kr/) [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
