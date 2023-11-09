---
title:  "[Sparta-BCamp] C# 객체 지향 (상속과 다형성)  ⭐⭐⭐ "
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
<BR><BR>

<center><H1> C# 객체 지향 (클래스와 객체 상속과 다형성)  </H1></center>
C# 객체 지향 (상속과 다형성)
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 상속
기존의 클래스(부모 클래스 또는 상위 클래스)를 확장하거나 재사용하여 새로운 클래스(자식 클래스 또는 하위 클래스)를 생성  
자식 클래스는 부모 클래스의 멤버(필드, 메서드, 프로퍼티 등)를 상속받아 사용할 수 있습니다.  
상속을 통해 부모 클래스의 기능을 확장하거나 수정하여 새로운 클래스를 정의  
{: .notice}

> **장점**
> - 1.&nbsp;코드의 재사용성  
> - 2.&nbsp;계층 구조의 표현  
> - 3.&nbsp;유지보수성의 향상  
{: .notice--info}

> **종류**
> - 1.&nbsp;단일 상속 = C#에서는 단일 상속만 지원
> - 2.&nbsp;다중 상속 = 여러 개의 부모 클래스 상속 C#에는 X
> - 3.&nbsp;인터페이스 상속 : 인터페이스는 다중 상속을 지원하며, 클래스는 하나의 클래스와 여러 개의 인터페이스를 동시에 상속받을 수 있습니다.
{: .notice--info}

> **특징**
> - 1.&nbsp;부모 클래스의 멤버에 접근
> - 2.&nbsp;메서드 재정의: 
> - 3.&nbsp;유지보수성의 향상  
{: .notice--info}

 부모 클래스의 멤버의 접근 제한자에 따라 자식 클래스에서 해당 멤버에 접근할 수 있는 범위가 결정, 접근 제한자로  캡슐화와 정보 은닉을 구현
 {: .notice}

<details>
<summary>전체 코드 보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
// 부모 클래스
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Eat()
    {
        Console.WriteLine("Animal is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("Animal is sleeping.");
    }
}

// 자식 클래스
public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog is bark.");
    }
}

public class Cat : Animal
{
    public void Sleep()
    {
        Console.WriteLine("Cat is sleeping.");
    }

    public void Meow()
    {
        Console.WriteLine("Cat is meow.");
    }
}

// 사용 예시
Dog dog = new Dog();
dog.Name = "Bobby";
dog.Age = 3;

dog.Eat();      // Animal is eating.
dog.Sleep();    // Animal is sleeping.
dog.Bark();     // Dog is barking

Cat cat = new Cat();
cat.Name = "KKami";
cat.Age = 10;

cat.Eat();
cat.Sleep();
cat.Meow();
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 2. 다형성
> - 가상(Virtual) 메서드
> - 추상(Abstract) 클래스와 메서드
> - 오버라이딩 과 오버로딩
{: .notice}

## 가상 메서드
> - 기본적으로 부모 클래스에서 정의되고 자식 클래스에서 재정의할 수 있는 메서드
> - 가상 메서드는 **`virtual`** 키워드를 사용하여 선언, 자식 클래스에서 필요에 따라 재정의될 수 있습니다. 
> - 자식 클래스에서 부모 클래스의 메서드를 변경하거나 확장할 수 있습니다.
{: .notice}

Virtual void~ 자식이 재정의 했을 수 있다. 자식메서드 override void~
virtual 실형태가 다를 수 있으니 체크하고와라(Override가 있는지)
virtual 안쓰면 부모의 형태로 접근하면 부모의 메서드가 실행 될 경우가 있다.
{: .notice}
<details>
<summary>코드 보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
public class Unit
{
    public virtual void Move()
    {
        Console.WriteLine("두발로 걷기");
    }

    public void Attack()
    {
        Console.WriteLine("Unit 공격");
    }
}

public class Marine : Unit
{

}

public class Zergling : Unit
{
    public override void Move()
    {
        Console.WriteLine("네발로 걷기");
    }
}

// 사용 예시
// #1 참조형태와 실형태가 같을때
Marine marine = new Marine();
marine.Move();
marine.Attack();

Zergling zergling = new Zergling();
zergling.Move();
zergling.Attack();

// #2 참조형태와 실형태가 다를때   부모의 move가 동작을한다. -> Virtual 사용
List<Unit> list = new List<Unit>();
list.Add(new Marine());
list.Add(new Zergling());

foreach (Unit unit in list)
{
    unit.Move();    
}
```
</div>

</details>

<br><br>

## 추상(Abstract) 클래스와 메서드
직접적으로 인스턴스를 생성할 수 없는 클래스  
주로 상속을 위한 베이스 클래스로 사용  
추상 클래스는 abstract 키워드를 사용하여 선언  
추상 메서드는 구현부가 없는 메서드로, 자식 클래스에서 반드시 구현  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
abstract class Shape
{
    public abstract void Draw();
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

class Square : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a square");
    }
}

class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a triangle");
    }
}

List<Shape> list = new List<Shape>();
list.Add(new Circle());
list.Add(new Square());
list.Add(new Triangle());

foreach (Shape shape in list )
{
    shape.Draw();
}
```
</div>

# 3. 오버라이딩과 오버로딩
오버라이딩 : 부모 클래스에서 이미 정의된 메서드를 자식 클래스에서 재정의하는 것을 의미  
오버로딩 : 동일한 메서드 이름을 가지고 있지만, 매개변수의 개수, 타입 또는 순서가 다른  여러 개의 메서드를 정의하는 것을 의미
{: .notice}

# 정리 잡답
> - 상속 다형성, 가상메서드 추상 클래스와 메서드
> - 오버라이딩 오버로딩 의미 확인
{: .notice}

<br><br>
- - - 

[Unity] C# 메서드와 구조체

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
