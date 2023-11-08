---
title:  "[Sparta-BCamp] TIL 8 ( 숙제, 메서드, 구조체 ) ⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-07 13:00

---
- - -
<BR><BR>

<center><H1> 개인 공부 C# 3일차   </H1></center>
2주차 강의 남은 거 듣기.   
어제 코드 컨벤션 정리하기.  
14:00 학습법 강의.  
3주차 듣고 숙제, 시간 남으면 개인과제  
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 2주차 과제

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


<br><br><br><br><br><br>
- - - 

# 2. C# 강의 내용 정리
강의 3일차 내용 정리
{: .notice}

[⭐C# 메서드와 구조체⭐](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp6/)  
메서드, 매개변수, 반환값, 오버로딩, 재귀호출, 구조체 **`struct`**
{: .notice--info}


{: .notice--info}



<br><br><br><br><br><br>
- - - 

# 3. 코드 컨벤션 강의
어제 코드 컨벤션강의 내용 정리.  
{: .notice}

## 코드 컨벤션

> **코드 컨벤션 스타일** 
>   -   BSD,K&R이 있다.  가장큰 차이는 중괄호{}의 위치.  
>   -   BSD스타일 : 줄간격이 한눈에 들어오지만 코드가 길어진다는 단점.
>   -   K&R스타일 : 블록을 조건에 한 줄로 같은 행에 배치 코드 줄 수 절약, 한눈에 많은 코드를 작성 할 수 있다.
>   -   유니티 C# 은 BSD 스타일로 사용한다.
{: .notice}

>   -   클래스명, 변수명, 함수 모두 의미있는 이름을 지어주어야 한다.
>   -   내 코드를 다른 사람이 쉽게 이해할 수 있도록.
>   -   오랜 시간 뒤에 내가 내 코드를 알아보기 위해서
>   -   가독성. 취직.
{: .notice--success}

<div class="notice--primary" markdown="1"> 

```c# 
// BSD
if(조건)
{
    처리로직
}

// K&R
if(조건){
    처리로직
}

// 추가 GNU 코딩 스타일   : 블록 표시하여 구조가 잘 보인다
//  수평으로 많은 코드를 작성할 수 없다.
if(조건)
    {
        처리로직
    }
```
</div>

## 표기법, 네이밍 규칙


> - PascalCase  : 모든 단어에서 첫 글자를 대문자로 쓰는 방식
> - camelCase&nbsp;   : 첫 단어를 제외하고 나머지 첫 글자를 대문자로 쓰는 방식
> - snake_case  : 단어가 합쳐진 부분마다 중간에 언더바(_)을 사용 
> - kebab-case  : 단어가 합쳐진 부분마다 중간에 하이픈(-)을 사용 
{: .notice}


> - 유니티에서는 
{: .notice--info}


습관처럼 만들자

<br><br><br><br><br><br>
- - - 

# 4. 정리, 잡담

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
