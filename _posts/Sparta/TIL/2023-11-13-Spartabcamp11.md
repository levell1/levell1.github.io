---
title:  "[Sparta-BCamp] TIL 11 (TextGame, Interface, Enum, try-catch, finally) ⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-13 18:00

---
- - -

인터페이스(**`Interface`**), 열거형(**`Enum`**)  
 **`try-catch`**, **`finally`**, 값형**`(Value Type)`**, 참조형**`(Reference Type)`**, **`박싱과 언박싱`**    
<BR><BR>

<center><H1> 개인 공부 C# 6일차   </H1></center>

&nbsp;&nbsp; [o] 개인과제(TextGame) 진행  
&nbsp;&nbsp; [o] 4주차 강의 듣기    
&nbsp;&nbsp; [o] 사이트 신청하기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


# 1. 개인과제(TextGame)
[깃허브 Readme](https://github.com/levell1/Practice_Csharp/blob/main/README.md)

  
**느낀점**  
게임 진행부분의 while, if의 조건을 단축할 수 없을까 고민했고, list, 상속, 클래스, 매서드 등 잘 사용하지 못하여 아쉬웠고, 사용하면서 조금 더 배운 과제였습니다.
생각을 코드로 적고 코드들이 길어지며 클래스, 메서드, 변수명의 중요성을 꺠닫고, 중간에 수정 시 힘듦이 있어 처음부터 추가할 기능을 정하고, 코드의 구조를 짜고 시작하면 좋겠다고 느꼈습니다.
{: .notice}

<br><br><br><br><br><br>
- - - 

# 2. C# 강의 내용 정리
6일차 내용 정리  
4주차강의

[C# 인터페이스(Interface), 열거형(Enum)](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp10/)  
인터페이스(**`Interface`**), 열거형(**`Enum`**)  
{: .notice--info}

[C# 예외처리, 값형과 참조형](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp11/)  
 **`try-catch`**, **`finally`**, 값형**`(Value Type)`**, 참조형**`(Reference Type)`**, **`박싱과 언박싱`**    
{: .notice--info}

<br><br><br><br><br><br>
- - - 


# 3. 정리, 잡담

> **정리**  
인터페이스(**`Interface`**), 열거형(**`Enum`**)  
인터페이스는 제약조건(제시). 구현은 클래스가 | 열거형- 코드의 가독성, ENUM = 자료형  
{: .notice} 

> - 예외처리 : **`try-catch`**, **`finally`**
> - 값형 : **`int`**, **`float`**, **`double`**, **`bool`**
> - 참조형 : **`클래스`**, **`배열`**, **`인터페이스`** 
> - 박싱 -> Object 사용 int num1 = 10; **`object`** obj = num1;  
> - 언박싱 -> int num2 = (int)obj;
> - list에서 자연스럽게 박싱 언박싱이 일어난다. [list 박싱언박싱](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp11/#언박싱-unboxing)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br>

|**예외 종류**|설명|
|:---|:---|
|Exception|모든 종류의 예외를 처리할 수 있다.|
|ArgumentNullException|메서드에 전달 되는 인수가 null이다.|
|ArgumentException|메서드에 전달 되는 null이 아닌 인수가 잘못되었다.|
|ArgumentOutOfRangeException|인수가 유효한 값 범위를 벗어났다.|
|DirectoryNotFoundException|디렉터리 경로 일부가 잘못되었다.|
|DivideByZeroException|0으로 나누었다.|
|DriveNotFoundException|드라이브가 없거나 사용할 수 없다.|
|FileNotFoundException|파일이 없다.|
|FormatException|문자열에서 변환할 수 있는 적절 한 형식이 아니다.|
|IndexOutOfRangeException|인덱스가 배열 또는 컬렉션의 범위를 벗어났다.|
|InvalidOperationException|개체의 현재 상태에서 메서드 호출을 사용할 수 없다.|
|KeyNotFoundException|컬렉션의 멤버에 액세스 하는 데 지정 된 키를 찾을 수 없다.|
|NotImplementedException|메서드 또는 작업이 구현 되지 않았다.|
|NotSupportedException|메서드 또는 작업이 지원 되지 않는다.|
|ObjectDisposedException|삭제 된 개체에 대한 작업을 수행했다.|
|OverflowException|산술, 캐스팅 또는 변환 작업을 수행 하면 오버플로가 발생한다.|
|PathTooLongException|경로 또는 파일 이름이 시스템에서 정의한 최대 길이를 초과한다.|
|PlatformNotSupportedException|현재 플랫폼에서 작업이 지원 되지 않는다.|
|RankException|차원 수가 잘못되었다.|
|TimeoutException|작업에 할당 된 시간 간격이 만료 되었다.|
|UriFormatException|잘못 된 URI (Uniform Resource Identifier)가 사용 되었다.|

<br>


> **잡담**  
4주차 내용 정리 못한 거 내일 정리(람다,linq,Nullable 형,자열 빌더 (StringBuilder))  
오늘은 집중이 안 되는 하루였다. 오전에 집중이 안 됐고 밥을 먹고 난 후 잠이 너무 와서 조금 잤다.  
4주차 내용 2번 들었고, 내일 또 들어야겠다. 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] TIL 11

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
