---
title:  "[Sparta-BCamp] C# 문법 제너릭, out, ref ⭐⭐ "
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
        }
    }
}
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 2. ref, out
 
> - 가상(Virtual) 메서드
> - 추상(Abstract) 클래스와 메서드
> - 오버라이딩 과 오버로딩
{: .notice}



# 정리 잡답
> - 내일 정리
{: .notice}


<br><br>
- - - 

[Unity] C# 메서드와 구조체

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
