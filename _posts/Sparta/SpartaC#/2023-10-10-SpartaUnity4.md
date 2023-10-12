---
title:  "[C#] 4. 제어문 - 조건문 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-10

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


# 1. 조건문

<br><br><br><br><br><br>
- - - 

# 2. IF 

<H3>IF문 구성</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/87371dfa-ca29-465f-879d-b6c9b86e84e0){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
If문은 조건을 체크해서 만족하면 { } 안의 내용을 실행시킨다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
if(3 > 1)   // 3이 1보다 큰지 체크했습니다.  - O
{
		// 조건을 만족했기에 실행합니다.
		Console.WriteLine("3은 1보다 크다!");
}
```
</div>


<br><br><br><br><br><br>
- - - 

# 2. Else If 

<H3>Else IF문 구성</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/5ab1ce93-77e7-4d82-8372-f62276c584a6){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
if문 뒤에 붙는다. if 문을 만족하지 못했을 때 다시 조건을 체크
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int x = 20;

// x가 10보다 큰지 체크했습니다.  - O
if(x > 10)
{
		// 조건을 맞아서 if문 안에 내용을 실행합니다.
		Console.WriteLine("x는 10보다 크다!");
}
else if(x > 5)
{
		Console.WriteLine("x는 10 보다는 작지만 5보다는 크다");
}
```

-   if 와 else if 가 있을 때 **둘 중 하나만 실행**됩니다

</div>




<br><br><br><br><br><br>
- - - 

# 3. else 

<H3>else 구성</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ddf5a196-f4d5-43c2-887c-553ceacc6ed5){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
If문은 만족하지 못했을때 실행 
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
// 0이 1보다 큰지 체크했습니다.  - X
if(0 > 1)
{		
		Console.WriteLine("0은 1보다 크다!");
}
else
{
		// 틀렸기 떄문에 else 가 실행됩니다.
		Console.WriteLine("틀렸습니다!!");
}
```

-   if 와 else 가 있을 때 **둘 중 하나만 실행**됩니다

</div>


<br><br><br><br><br><br>
-   -   -

# 4. if, elseif, else 같이사용

![image](https://github.com/levell1/levell1.github.io/assets/96651722/2f80fb2a-d537-4d19-b0e8-bf3641a2e24e){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
여러 조건문들이 있을 때 모든 조건 중 단 하나만 실행
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
{
    int score = 60;

    if(score > 90){
        Console.WriteLine("성적이 매우 우수합니다!!!!!");
    }
    else if(score > 70){
        Console.WriteLine("성적이 우수합니다.");
    }
    else if(x > 50){
        Console.WriteLine("합격은 했지만 좀 더 노력하세요");    // 실행
    }
    else{
        Console.WriteLine("불합격 입니다.");
    }
}
```

</div>

<br><br><br><br><br><br>
-   -   -

# 5. Switch case

<H3>IF문 구성</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/0236520b-6dba-43fa-9efb-34517cc6c4d2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
하나의 변수가 무엇인지 확인하는 조건문 (한가지 조건을 정교하게 체크)
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int x = 5;

switch(x)
{
	case 1:
		Console.WriteLine("치킨을 주문하자.");
		break;

	case 2:
		Console.WriteLine("피자를 주문하자.");
		break;

	default:
		Console.WriteLine("마라탕을 주문하자.");
		break;
}
```

</div>

<br><br><br><br><br><br>
-   -   -

# 6. 연습문제

##  연습문제 3
<div class="notice--primary" markdown="1"> 

```c# 
{
// 연습문제 3
// 1. 입력받은 데이터가 숫자인지 문자열인지 판단
// 2. 입력받은 데이터가 숫자인지 문자열인지 불리언인지 판단
// 3. 입력받은 데이터가 숫자라면 100 보다 큰지 작은지 알려주는 프로그램 만들기
// 4. 입력받은 데이터가 숫자라면 짝수인지 홀수인지 알려주는 프로그램 만들기

string input = Console.ReadLine(); // 데이터를 입력하고 Enter 를 누르면 다음으로 넘어갑니다.
//  Console.WriteLine("입력받은 데이터는 " + input + " 입니다.");
int num;
bool isInt = int.TryParse(input, out num);

bool b;
bool isbool = bool.TryParse(input, out b);

if (isInt)
{
    if (num>=100) //100 이상 이하 확인
    {
        Console.WriteLine(num+"은 100보다 같거나 큰수입니다.");
    }
    else{
        Console.WriteLine(num + "은 100보다 작은수입니다.");
    }

    if (num % 2 == 1) //짝수 홀수 확인
    {
        Console.WriteLine(num + "는 홀수 입니다.");
    }
    else
    {
        Console.WriteLine(num + "는 짝수 입니다.");
    }
}
else if (isbool)
{
    Console.WriteLine("불리언 입니다.");
}
else
{
    Console.WriteLine("문자열입니다.");
}
}
```

</div>

<br><br>

##  연습문제 4

<div class="notice--primary" markdown="1"> 

```c# 
{
 // 연습문제 4
 // 1. 숫자를 두번 입력받아서 두번 다 숫자인지 확인
 // 2. 숫자를 두번 입력받아서 두번 다 숫자인지 하나만 숫자인지 확인
 // 3. 숫자를 두번 입력받아서 두 수를 비교
 Console.WriteLine("첫번째 수를 입력해 주세요.");
 string input = Console.ReadLine();
 Console.WriteLine("두번째 수를 입력해 주세요.");
 string input1 = Console.ReadLine();

 int num;
 bool isInt = int.TryParse(input, out num);
 int num1;
 bool isInt1 = int.TryParse(input1, out num1);

 if (isInt && isInt1)
 {
     Console.WriteLine("두 데이터는 모두 숫자입니다.");
     if (num == num1)
     {
         Console.WriteLine(num +" 와 "+ num1 + " 는 같은 수 입니다.");
     }
     else if (num > num1)
     {
         Console.WriteLine(num + " 은 " + num1 + " 보다 큰 수 입니다.");
     }
     else if (num < num1)
     {
         Console.WriteLine(num + " 은 " + num1 + " 보다 작은 수 입니다.");
     }
 }
 else if (isInt || isInt1)
 {
     Console.WriteLine("하나만 숫자입니다.");
 }
 else
 {
     Console.WriteLine("모두 숫자가 아닙니다.");
 }
}
```

</div>

<br><br>

##  연습문제 5

<div class="notice--primary" markdown="1"> 

```c# 
{
// 연습문제 5
// 1. 퀴즈를 내서 정답을 맞추는 프로그램 작성
// 2. 주어진 보기를 선택하면 해당하는 선택지에 맞는 메시지 출력
Console.WriteLine("Q. 대한민국의 수도는 어디인가요?");
Console.WriteLine("1.인천 2.평창 3.서울 4.부산");
string input = Console.ReadLine();
int num;
bool isInt = int.TryParse(input, out num);

if (isInt)
{
    switch (num)
    {
        case 1:
            Console.WriteLine("오답입니다.");
            break;
        case 2:
            Console.WriteLine("오답입니다.");
            break;
        case 3:
            Console.WriteLine("정답입니다.");
            break;
        case 4:
            Console.WriteLine("오답입니다.");
            break;

        default:
            Console.WriteLine("1~4 의 숫자를 입력해주세요.");
            break;
    }
    if (num>=1 && num <=4)
    {
        if (num == 3)
        {
            Console.WriteLine("정답입니다.");
        }
        else
        {
            Console.WriteLine("오답입니다.");
        }
    }
    else
    {
        Console.WriteLine("1~4 의 숫자를 입력해주세요.");
    }
}
else
{
    Console.WriteLine("숫자가 아닙니다.");
}
}
```
- Switch case 문과 if ifelse else 문 사용

</div>

<br><br>

[C#] 제어문 - 조건문

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
