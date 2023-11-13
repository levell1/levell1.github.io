---
title:  "[C#] 조건문(if, switch, 3항 연산자), 반복문 ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-07 11:00

---
- - -
<BR><BR>

<center><H1> C# 조건문(if, switch, 3항 연산자), 반복문 </H1></center>
C# 조건문(if, switch, 3항 연산자), 반복문
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. C# 조건문(if, switch, 3항 연산자)

## switch
<div class="notice--primary" markdown="1"> 

```c# 
Console.WriteLine("게임을 시작합니다.");
Console.WriteLine("1: 전사 / 2: 마법사 / 3: 궁수");
Console.Write("직업을 선택하세요: ");
string job = Console.ReadLine();

switch (job)
{
    case "1":
        Console.WriteLine("전사를 선택하셨습니다.");
        break;
    case "2":
        Console.WriteLine("마법사를 선택하셨습니다.");
        break;
    case "3":
        Console.WriteLine("궁수를 선택하셨습니다.");
        break;
    default:
        Console.WriteLine("올바른 값을 입력해주세요.");
        break;
}

Console.WriteLine("게임을 종료합니다.");

```
</div>

<br><br>

## if, 3항 연산자
3항 연산자는 if 문의 간단한 형태로, 조건식의 결과에 따라 두 값을 선택하는 연산자입니다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int currentExp = 1200;
int requiredExp = 2000;
// if else 문
if (currentExp >= requiredExp)
{
    Console.WriteLine("레벨업 가능");
}
else
{
    Console.WriteLine("레벨업 불가능");
}

// 삼항 연산자
string result = (currentExp >= requiredExp) ? "레벨업 가능" : "레벨업 불가능";
Console.WriteLine(result);

```
</div>

<br><br>

## 조건문으로 로그인 프로그램
&& 와  ||  논리연산자에 대해 다시 확인해봅시다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
string id = "myid";
string password = "mypassword";

Console.Write("아이디를 입력하세요: ");
string inputId = Console.ReadLine();
Console.Write("비밀번호를 입력하세요: ");
string inputPassword = Console.ReadLine();

if (inputId == id && inputPassword == password)
{
    Console.WriteLine("로그인 성공!");
}
else
{
    Console.WriteLine("로그인 실패...");
}

```
</div>

<br><br><br><br><br><br>
- - - 

# 2. 반복문

## for, while

강의들으며 for, while, 복습  
> for, while 차이점  
> - for 문은 반복 횟수를 직관적으로 알 수 있고, 반복 조건을 한 눈에 확인할 수 있어 가독성이 좋습니다.
> - while 문은 반복 조건에 따라 조건문의 실행 횟수가 유동적이며, 이에 따라 코드가 더 간결할 수 있습니다.
> - 따라서 어떤 반복문을 사용할지는 코드의 흐름에 따라 상황에 맞게 선택하는 것이 좋습니다.
{: .notice}

<br><br>

## do while

do while 
최초실행 후 while  
ex) 입력받고 while 시킬 때
{: .notice}

<br><br>

## foreach
foreach문은 배열이나 컬렉션에 대한 반복문을 작성할 때 사용합니다.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
string[] inventory = { "검", "방패", "활", "화살", "물약" };

foreach (string item in inventory)
{
    Console.WriteLine(item);
}
```
</div>

<br><br>

## break, continue 
> - **`break`**는 반복문을 중지시키는 역할
> - **`continue`**는 현재 반복을 중지하고 다음 반복을 진행하는 역할
{: .notice--info}

<div class="notice--primary" markdown="1"> 

```c# 

for (int i = 1; i <= 10; i++)
{
    if (i % 3 == 0)
    {
        continue; // 3의 배수인 경우 다음 숫자로 넘어감
    }

    Console.WriteLine(i);
    if (i == 7)
    {
        break; // 7이 출력된 이후에는 반복문을 빠져나감
    }
}
```
</div>

<br><br><br><br><br><br>
- - - 

# 정리 잡답
> - 조건문 **`if`**, **`switch`**, 3항 연산자  
> - 반복문 **`for`**, **`while`**, **`foreach`**, **`break`**, **`continue`**    (foreach 자주쓸 거) 
{: .notice}



<br><br>
- - - 

[Unity] C# 조건문(if, switch, 3항 연산자), 반복문

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
