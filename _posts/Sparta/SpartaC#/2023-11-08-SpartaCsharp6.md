---
title:  "[Sparta-BCamp] C# 메서드와 구조체  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-08 09:30

---
- - -
<BR><BR>

<center><H1> C# 메서드와 구조체  </H1></center>
C# 메서드와 구조체 
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 메서드

> - 메서드(Method)는 일련의 코드 블록으로, 특정한 작업을 수행하기 위해 사용되는 독립적인 기능 단위입니다.
> - 코드의 재사용성과 모듈화를 위해 사용되며, 필요할 때 호출하여 실행
{: .notice}

> **메서드 역할과 중요성**
> - 코드의 재사용성: 메서드를 사용하면 동일한 작업을 반복해서 구현하지 않아도 됩니다. 필요할 때 메서드를 호출하여 작업을 수행할 수 있습니다.
> - 모듈화: 메서드를 사용하여 코드를 작은 단위로 분리하고 관리할 수 있습니다. 각 메서드는 특정한 기능을 수행하므로 코드의 구조가 더욱 명확해집니다.
> - 코드의 추상화: 메서드를 통해 작업 단위를 추상화하고, 메서드 이름을 통해 해당 작업이 어떤 역할을 하는지 파악할 수 있습니다.
> - 가독성과 유지보수성
> - 코드의 중복 제거
{: .notice--info}

<div class="notice--primary" markdown="1"> 

```c# 
// 구조
[접근 제한자] [리턴 타입] [메서드 이름]([매개변수])
{
    // 메서드 실행 코드
}

// 호출 방벙
[메서드 이름]([전달할 매개변수]);
```
</div>

<br><br><br><br><br><br>
- - - 

# 2. 매개변수와 반환값

> - 매개변수 : 매개변수는 메서드에 전달되는 입력 값  
> - 반환값 : 반환값은 메서드가 수행한 작업의 결과를 호출자에게 반환하는 값  
> - 반환값(Void) : 해당 메서드가 값을 반환하지 않음을 나타냅니다.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
// 구조
void PrintLine()
{
    for (int i = 0; i < 10; i++)
    {
        Console.Write("=");
    }
    Console.WriteLine();
}

void PrintLine2(int count)
{
    for (int i = 0; i < count; i++)
    {
        Console.Write("=");
    }
    Console.WriteLine();
}

int Add(int a, int b)
{
    return a + b;
}

[사용 예시]
PrintLine();
PrintLine2(20);

int result = Add(10, 20);
Console.WriteLine(result);

```
</div>
<br><br><br><br><br><br>
- - - 


# 3. 오버로딩
> - 메서드 오버로딩은 동일한 이름의 메서드를 **다양한 매개변수 목록으로 다중 정의**하는 개념입니다.
> - 매개변수의 **개수, 타입, 순서가 다른** 여러 메서드를 동일한 이름으로 정의하여 메서드 **호출 시 매개변수의 형태에 따라 적절한 메서드가 선택**되도록 할 수 있습니다.
> - 오버로딩은 메서드의 **기능이나 작업은 동일**하지만 **입력값에 따라 다르게 동작**해야 할 때 사용됩니다.
{: .notice}
<br><br>

<div class="notice--primary" markdown="1"> 

```c# 
void PrintMessage(string message)
{
    Console.WriteLine("Message: " + message);
}

void PrintMessage(int number)
{
    Console.WriteLine("Number: " + number);
}

// 메서드 호출
PrintMessage("Hello, World!");  // 문자열 매개변수를 가진 메서드 호출
PrintMessage(10);  // 정수 매개변수를 가진 메서드 호출

int AddNumbers(int a, int b)
{
    return a + b;
}

int AddNumbers(int a, int b, int c)
{
    return a + b + c;
}

// 메서드 호출
int sum1 = AddNumbers(10, 20);  // 두 개의 정수 매개변수를 가진 메서드 호출
int sum2 = AddNumbers(10, 20, 30);  // 세 개의 정수 매개변수를 가진 메서드 호출

```
</div>

<br><br><br><br><br><br>
- - - 

# 4. 재귀호출  
> - 메서드가 **자기 자신을 호출**하는 것을 의미합니다.
> - 재귀 호출은 문제를 작은 부분으로 분할하여 해결하는 방법 중 하나로, 작은 부분의 해결 방법이 큰 문제의 해결 방법과 동일한 구조를 갖고 있는 경우에 적합합니다.
> - 재귀 호출은 호출 스택에 호출된 메서드의 정보를 순차적으로 쌓고, 메서드가 반환되면서 스택에서 순차적으로 제거되는 방식으로 동작합니다.
{: .notice}

> **사용 시 주의점**
>- 재귀 호출은 복잡한 문제를 **단순한 방식으로 해결할 수 있는 장점**이 있습니다.
>- 재귀 호출을 사용할 때 주의해야 할 점은 **종료 조건을 명확히 정의**해야 하며, 종료 **조건을 만족하지 못하면 무한히 재귀 호출이 반복**되어 스택 오버플로우 등의 오류가 발생할 수 있습니다.
>- 재귀 호출은 **메모리 사용량이 더 크고 실행 속도가 느릴** 수 있으므로, 필요한 경우에만 적절히 사용하는 것이 좋습니다.
{: .notice--warning}
<div class="notice--primary" markdown="1"> 


```c# 
void CountDown(int n)
{
    if (n <= 0)
    {
        Console.WriteLine("Done");
    }
    else
    {
        Console.WriteLine(n);
        CountDown(n - 1);  // 자기 자신을 호출
    }
}

// 메서드 호출
CountDown(5);
```
</div>

<br><br><br><br><br><br>
- - - 

# 5. 구조체 
> - **여러 개의 데이터를 묶어서** 하나의 사용자 정의 형식으로 만들기 위한 방법입니다.
> - 구조체는 값 형식(Value Type)으로 분류되며, **데이터를 저장하고 필요한 기능을 제공**할 수 있습니다.
> - 구조체는 **`struct`** 키워드를 사용하여 선언합니다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
struct Person
{
    public string Name;
    public int Age;

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

```
- 구조체의 멤버는 변수와 메서드로 구성될 수 있습니다.
</div>

<br><br>

## 구조체 사용
> - 구조체는 변수를 선언하여 사용할 수 있습니다.
> - 구조체의 멤버에는 접근할 때 . 연산자를 사용합니다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
Person person1;
person1.Name = "John";
person1.Age = 25;
person1.PrintInfo();
```
- 구조체의 멤버는 변수와 메서드로 구성될 수 있습니다.
</div>

# 정리 잡답
> - 오버로딩 : 매개변수의 **개수, 타입, 순서가 다른** 동일한이름의 여러 메서드 
> - 구조체 : **`struct`** 키워드
{: .notice}


<br><br>
- - - 

[Unity] C# 메서드와 구조체

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
