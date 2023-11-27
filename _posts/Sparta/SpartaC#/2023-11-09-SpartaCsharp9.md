---
title:  "[C#] 문법 제너릭, out, ref ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-09 10:00

---
- - -
<BR><BR>

<center><H1> C# 문법 제너릭, out, ref  </H1></center>
C# 문법 제너릭, out, ref
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 제너릭
코드의 재사용성, 유연성 향상
다양한 자료형에 대응  
\<T> 형태의 키워드를 이용하여 제너릭을 선언
여러 데이터 형식에 동일한 로직을 적용할 때  
{: .notice}

<details>
<summary>전체 코드 보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using System;

namespace out_ref
{
    internal class Program
    {
        class Stack<T>
        {
            private T[] elements;
            private int top;

            public Stack() {
                elements = new T[100];
                top = 0;
            }
            public void Push(T item)
            {
                elements[top++] = item; //top 0 에 item 추가 후 ++
            }
            public T Pop()
            {
                return elements[--top];
            }

            public T[] Elements
            {
                get{
                    Console.WriteLine("get");
                    return elements; }
                set
                {
                    Console.WriteLine("Set");
                    elements = value; 
                }
            }

        }
        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();
            Stack<string> stringStack = new Stack<string>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            stringStack.Push("1");
            stringStack.Elements[1] = "2";
            Console.WriteLine(stringStack.Elements[1]);
            Console.WriteLine(intStack);

            Pair<int, string> pair1 = new Pair<int, string>(1, "One");
            pair1.Display();

            Pair<double, bool> pair2 = new Pair<double, bool>(3.14, true);
            pair2.Display();
        }
  

// 두개 이상의 제너릭
    class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public void Display()
        {
            Console.WriteLine($"First: {First}, Second: {Second}");
        }
    }
}
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 2. ref, out
> - out, ref 키워드는 메서드에서 매개변수를 전달할 때 사용합니다.
> - out 키워드는 메서드에서 반환 값을 매개변수로 전달하는 경우에 사용합니다.
> - ref 키워드는 메서드에서 매개변수를 수정하여 원래 값에 영향을 주는 경우에 사용합니다.
> - out, ref 키워드를 사용하면 메서드에서 값을 반환하는 것이 아니라, 매개변수를 이용하여 값을 전달할 수 있습니다.
{: .notice}

<details>
<summary>전체 코드 보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
// out 키워드 사용 예시
void Divide(int a, int b, out int quotient, out int remainder)
{
    quotient = a / b;
    remainder = a % b;
}

int quotient, remainder;
Divide(7, 3, out quotient, out remainder);
Console.WriteLine($"{quotient}, {remainder}"); // 출력 결과: 2, 1

// ref 키워드 사용 예시
void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

int x = 1, y = 2;
Swap(ref x, ref y);
Console.WriteLine($"{x}, {y}"); // 출력 결과: 2, 1


```
</div>
</details>

> **주의사항**
> - 값의 변경 가능성 : `ref` 변수의 값을 직접 변경하여 예기치 않은 동작을 초래
> - 성능 이슈 : `ref` 가독성 떨어질 수 있다.
> - 변수 변경 여부 주의 
{: .notice}

<br><br><br><br><br><br>
- - - 

# 정리 잡답
> - 제너릭 사용법 익히기, 
> - ref, out 많이 써보기
> - return대신 ref out을 쓰는이유  
return은 1개의 값만 반환가능  
ref out은 여러개 값을 상황에 따라 반환가능
{: .notice}


<br><br>
- - - 

[C#] C# 문법 제너릭, out, ref

<br>

참고 : [유니티](https://docs.unity3d.com/kr/) [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
