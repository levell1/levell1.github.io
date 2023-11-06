---
title:  "[Sparta-BCamp] C# 환경, 기본요소 ⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-06 11:00

---
- - -
<BR><BR>

<center><H1> C# 환경, 기본요소  </H1></center>
C# 환경, 기본요소
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. C#소개, 개발 환경 설정
>   -   1.무엇(What)일까 고민하는 것보다 중요한 것은 **왜(Why)** 에 집중하는 것입니다.  의도  
>   -   2.빠르게 실패하기. (많은 코드 접해보기.)  
{: .notice--info}

<br><br>

## 자동완성

클래스, 메서드, 변수 등의 이름을 입력할 때 일부를 입력하고, Tab 키를 눌러 나머지를 자동 완성합니다.  
메서드ㅡ나 변수를 입력하는 도중에 Ctrl + Space를 눌러 InstelliSense를 호출하면, 해당 메서드나 변수에 대한 정보와 예제를 볼 수 있습니다.  
코드 템플릿을 사용하여 코드를 더 빠르게 작성합니다.   
**Tab, Ctrl + Space**
{: .notice}


<br><br><br><br><br><br>
- - - 

# 2. 프로그래밍 기본 요소 


<div class="notice--primary" markdown="1"> 

```c# 
using System;

namespace HelloWorld
{
  class program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");    
    }
  }
}
```
-   **using System;** 은 C#에서 기본적으로 제공하는 네임스페이스를 사용하기 위한 코드입니다.  
-   **namespace** 는 코드를 구성하는데 사용되며 클래스 및 기타 네임스페이스의 컨테이너입니다.  
-   **class Program** 은 C# 클래스를 정의하는 키워드입니다. 클래스 이름은 Program로 지정합니다.  
-   **static void Main()** 은 C#의 진입점입니다. Main 메서드는 프로그램이 시작할 때 자동으로 호출되는 메서드, 필수적  

</div>
<br><br>

## 출력
Console.Write : 출력하고 줄 바꿈 (X)  
Console.WriteLine : 출력 후 다음 줄로 이동
{: .notice}

<br><br>

## 이스케이프 시퀸스(Escape Sequence)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/741df088-11bc-47b0-8fd7-cb13742a2778){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
Console.WriteLine("Hello\nWorld");
// 출력결과
// Hello
// World

Console.WriteLine("Name\tAge");
Console.WriteLine("Kero\t30");
Console.WriteLine("Young\t25");
// 출력결과
// Name    Age
// Kero    30
// Young   25

Console.WriteLine("We learn \"C# Programming\"");
// 출력결과
// The book is called "C# Programming"

Console.WriteLine("He said, \'Hello\' to me.");
// 출력결과
// He said, 'Hello' to me.

Console.WriteLine("C:\\MyDocuments\\Project\\");
// 출력결과
// C:\MyDocuments\Project\
```
-   \', \", \\, 작은, 큰따옴표, 역슬래시 추가  
-   \n, \r, 줄바꿈, 현재 줄 맨 앞으로 이동  
-   \t, \b  탭 삽입, 백스페이스 삽입  

</div>

<br><br>

## 주석
코드 설명, 개발자간 의사소통에 사용
{: .notice}

// : 한 줄 주석  
/* */ : 여러 줄 주석 시작, 끝 확인
{: .notice--info}

>   **주의할 점**
>   -   주석은 코드를 대체하지 않는다.  
>   -   주석의 내용은 정확하고 명확해야 한다.  
>   -   주석은 업데이트되어야 한다.  
>   -   주석은 필요한 경우에만 사용해야 한다.  
{: .notice--info}


<br><br>
- - - 

[C#] C# 환경, 기본요소

<br>

참고 : [유니티 문서](https://docs.unity3d.com/kr/)   
[C# 문서](https://learn.microsoft.com/ko-kr/dotnet/csharp/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
