---
title:  "[Memo-Unity] 9. 제네릭 (<T>)"
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-08

---
- - -
<BR><BR>

제네릭 (<T>)

<center><H1> 제네릭 (<T>) </H1></center>

<br><br><br><br><br><br>
- - - 

## 제너릭 : 마법상자
> - 다양한 타입을 담을 수 있음
> - 코드의 재사용성과 유연성, 유지보수에 효율적
> - list에 int, string / GetComponent <T(ype)>
> - return을 t로 하거나 <T> 로도 퉁치기 가능
> - 여러 데이터를 동일한 로직에 사용할 떄
> - where - 제약조건 추가
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6ccd44e7-7759-4c45-9719-a5ee84463913)
> - 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c# 
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// 사용 예시
Calculator calculator = new Calculator();
int sum1 = calculator.Add(2, 3); // int Add(int a, int b) 메소드 호출
double sum2 = calculator.Add(2.5, 3.7); // double Add(double a, double b) 메소드 호출
int sum3 = calculator.Add(2, 3, 4); // int Add(int a, int b, int c) 메소드 호출
```

</div>
<br><br>
- - - 

[C#] 제네릭 (<T>)
[참조](https://docs.unity3d.com/kr/2021.3/Manual/Coroutines.html)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
