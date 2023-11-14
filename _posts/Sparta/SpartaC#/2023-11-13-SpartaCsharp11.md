---
title:  "[C#] 예외처리, 값형과 참조형 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-13 13:00

---
- - -
<BR><BR>

<center><H1> C# 예외처리, 값형과 참조형  </H1></center>
C# 예외처리, 값형과 참조형
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 예외처리
<U>예외 : 예기치 않는 상황, 정상적인 흐름을 방해하고 오류를 야기할 수 있다.</U>

> **필요성**  
> - 프로그램을 안정적으로 유지하는 데 도움을 준다.  
> - 오류 상황을 적절히 처리하고, 실행을 계속할 수 있다.
> - 프로그램의 안정성을 높이고 디버깅을 용이하게 한다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

> **`try-catch`** 사용  
> - **`try`** 내에 예외가 발생할 수 있는 코드 작성  
> - **`catch`** 에서 예외 처리.
{: .notice--info}

<br><BR>

## 예외 종류

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

## Try-catch 코드

<details>
<summary>try-catch</summary>

<div class="notice--primary" markdown="1"> 

```c# 
try
{
    // 예외가 발생할 수 있는 코드
}
catch (ExceptionType1 ex)
{
    // ExceptionType1에 해당하는 예외 처리
}
catch (ExceptionType2 ex)
{
    // ExceptionType2에 해당하는 예외 처리
}
finally
{
    // 예외 발생 여부와 상관없이 항상 실행되는 코드
}
```
</div>
</details>

> - Catch 는 순서대로 실행, 하지만 상속 관계에 있는 경우 상위 예외 타입이 먼저 실행
> - 다중 catch로 다양한 예외 타입을 처리가능
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br><BR>

## Finally 블록
<U>예외 발생 여부와 상관없이 항상 실행되는 코드</U>  
예외 처리의 마지막 단계로, 정리작업, 리소스해제 등의 코드를 포함  
생략가능  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><BR>

## 사용자 정의 예외
자신만의 예외 클래스를 작성  try부분에 추가한다.  
Exception 클래스를 상속받아 작성하며, 추가적인 기능이나 정보를 제공할 수 있습니다.  
[Exception](https://learn.microsoft.com/ko-kr/dotnet/api/system.exception?view=net-7.0)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<details>
<summary>예외처리,사용자 정의 예제</summary>

<div class="notice--primary" markdown="1"> 

```c# 
try
{
    int result = 10 / 0;  // ArithmeticException 발생
    Console.WriteLine("결과: " + result);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("0으로 나눌 수 없습니다.");
}
catch (Exception ex)
{
    Console.WriteLine("예외가 발생했습니다: " + ex.Message);
}
finally
{
    Console.WriteLine("finally 블록이 실행되었습니다.");
}

//사용자 정의 예외 처리
public class NegativeNumberException : Exception
{
    public NegativeNumberException(string message) : base(message)
    {
    }
}

try
{
    int number = -10;
    if (number < 0)
    {
        throw new NegativeNumberException("음수는 처리할 수 없습니다.");
    } //throw 일부러 예외처리 던질때
}
catch (NegativeNumberException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("예외가 발생했습니다: " + ex.Message);
}

```
</div>
</details>

> - throw new NegativeNumberException("1")
> - NegativeNumberException의 예외처리를 던진다.
{: .notice}

<br><br><br><br><br><br>
- - - 

# 2. 값형과 참조형
<U>C#에서 변수가 데이터를 저장하는 방식을 나타냅니다.  </U>
{: .notice}

## 값형(Value Type)

> **값형(Value Type)**
> - 변수에 값을 직접 저장
> - 변수가 실제 데이터를 보유하고 있으면 해당 변수에 할당하거나 전달할 때 **<U>값이 복사</U>**  
> - 해당 변수의 값만 변경, 다른 변수에 영향 X
> - **`int`**, **`float`**, **`double`**, **`bool`**등 기본 데이터 타입들
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>값형</summary>

<div class="notice--primary" markdown="1"> 

```c# 
struct MyStruct
{
    public int Value;
}

MyStruct struct1 = new MyStruct();
struct1.Value = 10;

MyStruct struct2 = struct1; // struct2는 struct1의 값 복사

struct2.Value = 20;

Console.WriteLine(struct1.Value); // 출력 결과: 10
```
</div>
</details>

<BR>

## 참조형(Reference Type)
> **참조형(Reference Type)**
> - 변수의 데이터에 대한 참조(메모리 주소)를 저장
> - 변수가 실제 데이터를 가리키는 참조를 갖고있다, 변수가 다른 변수를 할당하거나 전달할 때는  **<U>참조가 복사</U>**  
> - 참조형 변수는 동일한 데이터를 가리키고 있다, 다른 변수에 영향 O
> - **`클래스`**, **`배열`**, **`인터페이스`**등이 참조형에 해당
> - 저장할 수 있는 공통된 주소(공간)을 만들고 그 주소를 사용한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>참조형</summary>

<div class="notice--primary" markdown="1"> 

```c# 
class MyClass
{
    public int Value;
}

MyClass obj1 = new MyClass();
obj1.Value = 10;

MyClass obj2 = obj1; // obj2는 obj1과 동일한 객체를 참조

obj2.Value = 20;

Console.WriteLine(obj1.Value); // 출력 결과: 20
```
</div>
</details>

<br><BR>

## 값형과 참조형의 차이점
> - 값형은 실제 데이터를 변수에 저장, 참조형은 데이터에 대한 참조를 변수에 저장
> - 값형은 변수 간의 값 복사가 이루어지고, 참조형은 변수 간의 참조 복사가 이루어집니다.
> - 값형은 변수가 독립적으로 데이터를 가지며, 참조형은 변수가 동일한 데이터를 참조합니다.
{: .notice}

<br><br><br><br><br><br>
- - - 

# 3. 박싱과 언박싱
<U>값형과 참조형 사이의 변환을 의미합니다.</U>

## 박싱 (Boxing)
> - 값형 -> 참조형 변환 
> - 값형 변수의 값을 메모리의 힙 영역에 할당된 객체로 래핑
> - 박싱을 통해 값형이 참조형의 특징을 갖게 되며, 참조형 변수로 다뤄질 수 있습니다.
{: .notice}

## 언박싱 (UnBoxing)
> - 박싱된 객체 -> 값형 변환
> - 박싱된 객체에서 값을 추출하여 값형 변수에 할당
> - 언박싱은 명시적으로 타입 캐스팅을 해야 하며, 런타임에서 타입 검사가 이루어집니다.
> - 잘못된 형식으로 언박싱하면 런타임 에러가 발생할 수 있습니다.
{: .notice}

<br><br>

## 박싱, 언박싱 주의점
> - 반복적인 박싱과 언박싱은 성능 저하를 초래할 수 있으므로 주의
> - 박싱된 객체는 힙 영역에 할당되므로 가비지 컬렉션의 대상이 될 수 있습니다. 따라서 메모리 관리에 유의
> - 박싱된 객체와 원래의 값형은 서로 독립적이므로 값을 수정하더라도 상호간에 영향을 주지 않습니다.
{: .notice}

<br><br>

<details>
<summary>박싱, 언박싱, 리스트활용</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using System;

class Program
{
    static void Main()
    {
        // 값형
        int x = 10;
        int y = x;
        y = 20;
        Console.WriteLine("x: " + x); // 출력 결과: 10
        Console.WriteLine("y: " + y); // 출력 결과: 20

        // 참조형
        int[] arr1 = new int[] { 1, 2, 3 };
        int[] arr2 = arr1;
        arr2[0] = 4;
        Console.WriteLine("arr1[0]: " + arr1[0]); // 출력 결과: 4
        Console.WriteLine("arr2[0]: " + arr2[0]); // 출력 결과: 4

        // 박싱과 언박싱
        int num1 = 10;
        object obj = num1; // 박싱      obj로 박싱
        int num2 = (int)obj; // 언박싱  num2로 언박싱
        Console.WriteLine("num1: " + num1); // 출력 결과: 10
        Console.WriteLine("num2: " + num2); // 출력 결과: 10
    }
}

//리스트 활용
    List<object> myList = new List<object>();

    // 박싱: 값 형식을 참조 형식으로 변환하여 리스트에 추가
    int intValue = 10;
    myList.Add(intValue); // int를 object로 박싱하여 추가

    float floatValue = 3.14f;
    myList.Add(floatValue); // float를 object로 박싱하여 추가

    // 언박싱: 참조 형식을 값 형식으로 변환하여 사용
    int value1 = (int)myList[0]; // object를 int로 언박싱
    float value2 = (float)myList[1]; // object를 float로 언박싱
```
</div>
</details>

object는 .NET Common Type System (CTS)의 일부이며, 모든 클래스의 직간접적인 상위 클래스입니다.  
모든 클래스는 object에서 상속되며, object는 모든 형식을 참조할 수 있는 포괄적인 타입입니다.  
{: .notice}


# 4. 정리
> - 예외처리 : **`try`** **`catch`** **`finally`**  
> - 값형 : **`int`**, **`float`**, **`double`**, **`bool`**  
> - 참조형 : **`클래스`**, **`배열`**, **`인터페이스`**  
> - 박싱 -> Object 사용 int num1 = 10; **`object`** `obj` = num1;  
> - 언박싱 -> int num2 = (int)`obj`;
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


<br><br>
- - - 

[Unity] C# 예외처리, 값형과 참조형

<br>

참고 : [유니티](https://docs.unity3d.com/kr/) [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
