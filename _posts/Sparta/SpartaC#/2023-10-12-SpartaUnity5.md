---
title:  "[C#] 4. 제어문 - 반복문 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-12

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


# 1. 반복문

<br><br><br><br><br><br>
- - - 

# 2. For 

<H3>For문 구성</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ba22f84e-0267-4fb6-8949-985f92b8b23f){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
어떤일을 여러번 계속 실행할 때 사용하는 기능
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
// 1부터 세기 시작 ; 5까지 셀것 ; +1 씩 샙니다

for ( int i = 1 ;   i <= 5    ;  i++ ) 
{
		Console.WriteLine(i); // 조건을 만족하는한 계속 반복됩니다.
}

실행결과
1
2
3
4
5
```
</div>


<br><br><br><br><br><br>
- - - 

# 2. While

<H3>While문 구성</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/2714fb0e-7196-4bf1-af3d-02bd30d5b182){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
For문에비해 간단, 조건 체크후 계속 반복  
초기화 가 필요하면 별도로 
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int i = 1;      // 1부터 세기 시작

while(i <= 5)  // 5까지 셀것
{
		Console.WriteLine(i); 
		i++;        // +1 씩 증가
}

실행결과
1
2
3
4
5

```

</div>


<br><br><br><br><br><br>
- - - 

# 3. for, while

<H3>For</h3>

>   -   식 안에 초기화, 조건, 변화 가 있다.
>   -   기본적인 사용방법
{: .notice}

<H3>While</h3>

>   -    조건만 체크하는 반복문
>   -   초기화, 변화는 외부에서 진행
>   -   외부의 조건에 의해 영향 받을 때 사용
>   -   조건을 잘설정하지 않으면 무한반복이 된다.
{: .notice}


<br><br><br><br><br><br>
-   -   -

# 4. do while

![image](https://github.com/levell1/levell1.github.io/assets/96651722/e75fb8a7-538b-40c0-a156-58ad926eff14){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
내용을 한번 실행 후 while 반복문으로 간다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int i = 11;

do
{
		// 원래는 11이 10보다 크기 때문에 싱행되면 안됩니다.
        // 하지만 do while 에서는 무조건 한번은 실행됩니다.
        // 11을 한번 출력하고 종료됩니다.
		Console.WriteLine(i);  
		i++;       
}
while(i <= 10)  

실행결과
11

```

</div>

<br><br><br><br><br><br>
-   -   -

# 5. 연습문제

##  연습문제 6
<div class="notice--primary" markdown="1"> 

```c# 
{
    // 연습문제 6

    // 1. 구구단 2단을 만들기
    //for문
    for (int i = 2; i < 10; i++)
    {
        Console.WriteLine("2 x " + i + " = " + 2 * i);
    }
    //while문
    int x = 2;
    while (x < 10)
    {
        Console.WriteLine("2 x " + x + " = " + 2 * x);
        x++;
    }


    // 2. 입력받은 데이터로 구구단 만들기
    Console.WriteLine("출력하고 싶은 단을 입력해주세요."); 
    string input = Console.ReadLine();
    int num;
    bool isInt = int.TryParse(input, out num);

    if (isInt)
    {
        for (int y = 2; y < 9; y++)
        {
            Console.WriteLine(num + " x " + y + " = " + num * y);
        }
    }
    else
    {
        Console.WriteLine("문자열입니다.");
    }


    // 3. 피보나치 수열 구하기 
    int num1 = 1;
    int num2 = 0;
    int num3 = 0;

    for (int z = 1; z <= 10; z++)
    {
        num3 = num2 + num1;
        Console.Write(num3 + " ");
        num1 = num2;
        num2 = num3;
    }
    Console.WriteLine("");


    // 4. 입력받은 수만큼 피보나치 수열 구하기 
    Console.WriteLine("몇개의 피보나치 수열을 출력하고 싶으신가요?");
    string input1 = Console.ReadLine();
    int count;
    bool isInt1 = int.TryParse(input1, out count);
    Console.Write(count + " ");

    num1 = 1;
    num2 = 0;
    num3 = 0;

    if (isInt)
    {
        if (count > 0)
        {
            if (count <= 46)
            {
                for (int re = 0; re < count; re++)
                {
                    num3 = num2 + num1;
                    Console.Write(num3 + " ");
                    num1 = num2;
                    num2 = num3;
                }
            }
            else
            {
                Console.WriteLine("숫자가 너무 큽니다.");
            }
        }
        else
        {
            Console.WriteLine("양수를 입력해주세요");
        }

    }
    else
    {
        Console.WriteLine("문자열입니다.");
    }

}
```

</div>

<br><br>

##  연습문제 7

<div class="notice--primary" markdown="1"> 

```c# 
{
    // 연습문제 7
    // 1. 이름 입력하기
    // 2. 조건에 맞을때 까지 이름 입력    
    // 3. 반복시 기존 내용 지우기

    bool x = true;
    while (x)
    {
        Console.WriteLine("이름을 입력해주세요. (3~10글자)");
        string name = Console.ReadLine();
        int length = name.Length;

        if (3 <= length && length <= 10)
        {
            Console.WriteLine("안녕하세요! 제 이름은 " + name + " 입니다.");
            x = false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("이름을 확인해주세요");
        }
    }
    
}
```

-   Console.Clear(); console 표시된 메시지 지우기
</div>

<br><br>

[C#] 제어문 - 반복문

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
