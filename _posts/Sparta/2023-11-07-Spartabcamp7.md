---
title:  "[Sparta-BCamp] TIL 7 (숙제, 조건문, 반복문, 배열, 컬렉션) ⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-07 10:00

---
- - -
<BR><BR>

<center><H1> 개인 공부 C# 2일차   </H1></center>
강의 1주차 과제 후 2주차 강의 듣기.   
15:00 코드 컨벤션 강의  
16:00 ~ 조퇴  
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 1주차 과제

## 사용자로부터 입력 받기

이름과 나이를 입력 받고 출력하는 코드를 작성하세요.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
void UserInfo() // 1. 입력받기
{
    Console.Write("이름: ");
    string name = Console.ReadLine();

    Console.Write("나이: ");
    int age = int.Parse(Console.ReadLine());
    Console.WriteLine();

    Console.WriteLine($"이름 :\t {name}\n나이 :\t {age}");
}
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/71417b69-2b8c-4465-842b-c16d610c8218){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## 간단한 사칙연산 계산기
두 수 입력받고 사칙연산 결과 나타내기.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
void Calculator() // 2. 사칙연산 계산기
{
    Console.Write("두 수를 입력해주세요(\" \") : ");
    string nums = Console.ReadLine();
    string[] num = nums.Split(' ');
    int num1 = int.Parse(num[0]);
    int num2 = int.Parse(num[1]);

    Console.WriteLine($"덧셈(+)\t\t{num1} + {num2} = {num1 + num2}");
    Console.WriteLine($"뺄셈(-)\t\t{num1} - {num2} = {num1 - num2}");
    Console.WriteLine($"곱셈(x)\t\t{num1} * {num2} = {num1 * num2}");
    Console.WriteLine($"나눗셈(/)\t{num1} / {num2} = 몫{num1 / num2} 나머지{num1 % num2}");
}
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/97f83ed8-c64d-420b-b6db-1e7b1fd33805){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## 온도 변환기 만들기
섭씨온도를 화씨온도로 변환하는 프로그램  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
void Temperature() // 3. 온도 변환기
{
    Console.Write("섭씨온도(°C) 를 입력해 주세요 : ");
    float Celsius = float.Parse(Console.ReadLine());
    float Fahrenheit = (Celsius * 9 / 5) + 32;
    Console.WriteLine($"섭씨온도 : {Celsius}°C\n화씨온도 : {Fahrenheit}°F");
}
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/98de0182-ebda-41a6-9133-a9ffdd2547f2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## BMI 계산기
BMI 지수를 계산하는 프로그램
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
void Bmi() // 4. BMI
{
    Console.Write("몸무게(Kg) 를 입력해 주세요 : ");
    float kg= float.Parse(Console.ReadLine());
    Console.Write("키(Cm) 를 입력해 주세요 : ");
    float cm = float.Parse(Console.ReadLine());
    float bmi= kg/((cm/100) * (cm/100));
    Console.WriteLine("BMI : {0:N2}",bmi);
}
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/7192a3cc-638e-4579-8e5b-bc1eb7ffe6a9){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br><br><br><br><br>
- - - 

# 2. C# 강의 내용 정리
강의 2일차 내용 정리
{: .notice}

[C# 조건문(if, switch, 3항 연산자), 반복문](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp4/)  
조건문 **`if`**, **`switch`**, 3항 연산자  
반복문 **`for`**, **`while`**, **`foreach`**, **`break`**, **`continue`**    (foreach 자주쓸 거)
{: .notice--info}

[C# 배열, 컬렉션](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp5/)  
컬렉션 **`list`**, **`Dictionary`**, **`Stack`**, **`Queue`**, **`Hashset`**    
{: .notice--info}



<br><br><br><br><br><br>
- - - 

# 3. 정리, 잡담



> **조건문**
> - 조건문 **`if`**, **`switch`**, 3항 연산자  
> - 3항 연산자는 if 문의 간단한 형태로, 조건식의 결과에 따라 두 값을 선택하는 연산자입니다.
> - for 문은 반복 횟수를 직관적으로 알 수 있고, 반복 조건을 한 눈에 확인할 수 있어 가독성이 좋습니다.
> - while 문은 반복 조건에 따라 조건문의 실행 횟수가 유동적이며, 이에 따라 코드가 더 간결할 수 있습니다.
> - 따라서 어떤 반복문을 사용할지는 코드의 흐름에 따라 상황에 맞게 선택하는 것이 좋습니다.
{: .notice}

> **반복문**
> - 반복문 **`for`**, **`while`**, **`foreach`**, **`break`**, **`continue`**    (foreach 자주쓸 거)
> - foreach문은 배열이나 컬렉션에 대한 반복문을 작성할 때 사용합니다. 
> - **`break`**는 반복문을 중지시키는 역할
> - **`continue`**는 현재 반복을 중지하고 다음 반복을 진행하는 역할
{: .notice--info}


> **배열, 컬렉션**
> - 배열, 다차원배열
> - 컬렉션 **`list`**, **`Dictionary`**, **`Stack`**, **`Queue`**, **`Hashset`**    
> - 컬렉션은 배열과 비슷한 **자료 구조**
> - 배열과는 다르게 크기가 **가변적**
> - C#에서는 다양한 종류의 컬렉션을 제공
> - 사용하기 위해서는 **`System.Collections.Generic`** 네임스페이스를 추가
{: .notice}

> - 디버그 줄에 F9 : 중단점 설정, F10 프로시저 단위 실행
> - char input = Console.ReadLine()[0]; 맨앞에 한글자만 가져온다.  
{: .notice}

<br><br>

**잡담**  
오늘 점심시간에 소소한 행복을 느꼈다. 30분 정도 였지만 기분이 좋았다.  
월, 화요일 조퇴를 하여 12시간 공부를 하지 못했다. 주말에 시간 보고 따로 공부를 해야 할 것 같다.  
내일은 2주차 강의 메서드와 구조체 강의 들으면서 정리할 계획이다.
{: .notice--success}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/2eb7bf00-c498-4083-8251-2b208e30cffa){:style="border:1px solid #eaeaea; border-radius: 7px;"}   
👑금주Til 왕관👑  
오늘 zep에 접속했는데👑이 있었다.. 🙌  


<br><br>
- - - 

[Unity] TIL 7

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
