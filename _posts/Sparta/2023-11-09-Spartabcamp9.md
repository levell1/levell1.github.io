---
title:  "[Sparta-BCamp] TIL 9 (  ) ⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-09 09:00

---
- - -
<BR><BR>

<center><H1> 개인 공부 C# 4일차   </H1></center>

- [x] 3주차 강의 정리
- [x] 3주차 숙제 하기(뱀,블랙잭)
- [x] 2시, 7시 발표, 특강
- [x] 시간나면 4주차 or 개인과제
- [x] 사이트 신청하기
{: .notice}


<br><br><br><br><br><br>
- - - 

# 1. 3주차 강의 정리

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

<br><br><br><br><br><br>
- - - 

# 2. C# 강의 내용 정리
강의 4일차 내용 정리  
3주차강의
{: .notice}


[C# 클래스와 객체 상속과 다형성](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp7/)  
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
어제 틱택톡을 하며 부족한점이 많다고 느꼈고, 더 열심히 해야겠다.
{: .notice}


<br><br>
- - - 

[Unity] TIL 9

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
