---
title:  "[C#] 변수와 자료형, Split ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-06 12:00

---
- - -
<BR><BR>

<center><H1> C# 변수와 자료형 </H1></center>
C# 변수와 자료형
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 변수와 자료형

C#에서 사용되는 기본 자료형  

|**자료형**|.NET 데이타 타입|크기|범위|
|:---|:---|:---|:---|
|sbyte|System.SByte|1|-128 ~ 127|
|byte|System.Byte|1|0 ~ 255|
|short|System.Int16|2|-32,768 ~ 32,767|
|ushort|System.UInt16|2|0 ~ 65,535|
|**Int**|System.Int32|4|-2,147,483,648 ~ 2,147,483,647|
|uInt|System.UInt32|4|0~ 4,294,967,295|
|**long**|System.Int64|8|-9,223,372,036,854,775,808 ~ 9,223,372,036,854,775,807|
|ulong|System.UInt64|8|0 ~ 18,446,744,073,709,551,615|
|**float**|System.Single|4|±1.5 × 10^-45 ~ ±3.4 × 10^38|
|**double**|System.Double|8|±5.0 × 10^-324 ~ ±1.7 × 10^308|
|decimal|System.Decimal|16|±1.0 × 10^-28 ~ ±7.9 × 10^28|
|**char**|System.Char|2|유니코드 문자|
|**string**|System.String| |유니코드 문자열|
|**bool**|System.Boolean|1|true 또는 false|

> **변수를 세분화 해서 사용하는 이유**
>   -   메모리의 효율적인 사용
>   -   정확한 데이터 표현
>   -   타입 안정성
{: .notice--info}

<br><br>

## 리터럴(literal)

>   **리터럴의 개념과 역할**
>   -   프로그램에서 직접 사용되는 상수 값으로, 소스 코드에 직접 기록되어 있는 값
>   -   C#에서 리터럴은 컴파일러에 의해 상수 값으로 처리되며, 변수나 상수에 할당되거나 연산에 사용
{: .notice}

>   **리터럴의 종류와 예시**
>   - C#에서 다양한 종류의 리터럴 지원
>   -   각각의 리터럴은 다른 형식으로 표현, 다양한 값의 범위를 가지고 있다.
{: .notice--info}

C#에서 지원하는 리터럴의 종류, 예시

> 정수형 리터럴
>   -   10 (int)
>   -   0x10 (16진수 int)
>   -   0b10 (2진수 int)
>   -   10L (long)
>   -   10UL (unsigned long)
>   부동소수점형 리터럴
>   -   3.14(double)
>   -   3.14f(float)
>   -   3.14m(decimal)
>   문자형 리터럴
>   -   'A' (char)
>   -   '\n' (개행 문자)
>   -   '\u0022'(유니코드 문자)
>   문자열 리터럴
>   -   "Hello" (String)
>   -   "문자열 내 "따옴표" 사용"
>   -   @ "문자열 내 개행 문자 사용하기"


<div class="notice--primary" markdown="1"> 

```c# 
int num = 10;
float f = 3.14f;
char c = 'A';
string str = "Hello, World!";

int num1 = 0x10;
int num2 = 0b1010;
long num3 = 100000000000000L;

const a = 1;    //const = 상수 1 = 리터럴

```
- 상수는 메모리 위치(공간)이며, 메모리 값을 변경할 수 없다.  
- 리터럴은 메모리 위치(공간) 안에 저장되는 값이다.
</div>


<br><br><br><br><br><br>
- - - 

# 2. 변수 선언과 초기화 방법

변수 : 데이터를 저장하고 사용하기 위한 할당 받은 공간  
필요에 따라 데이터를 저장하거나 수정 가능  
예를 들면 게임에서의 HP, 공격력, 재화 같은 정보를 저장하기 위해 사용  
{: .notice}

<br><br>

## 선언, 초기화

<div class="notice--primary" markdown="1"> 

```c# 

// 선언
// 자료형 변수이름;
int num1, num2, num3;

// 초기화
//변수이름 = 값;
num1 = 10;

// 선언+초기화
int num4 = 23;
int num1, num2, num3 = 10;  // num3만 초기화된다.

num1 = num2 = num3 = 10; // 1,2,3 모두 10이 된다.

```
</div>

<br><br>

## 변수명

### 1). 키워드 
> 키워드
> - C#에는 **이미 예약된 단어들 ( 키워드Keywords )**이 있기 때문에 변수, 메서드, 클래스, 등의 이름으로 사용할 수 없다.
> - abstract  as  base  bool  break  byte  case  catch  char  checked  class  const  continue decimal  default  delegate  do  double  else  enum  event  explicit  extern  false  finally fixed  float  for  foreach  goto  if  implicit  in  int  interface  internal  is  lock long  namespace  new  null  object  operator  out  override  params  private  protected  public readonly  ref  return  sbyte  sealed  short  sizeof  stackalloc  static  string  struct  switch this  throw  true  try  typeof  uint  ulong  unchecked  unsafe  ushort  using  virtual  void volatile  while
{: .notice--info}

<br><br>

### 2). 식별자
> 식별자 : 식별자란 변수, 메서드, 클래스, 인터페이스 등에 사용되는 이름을 말합니다. 이 이름은 키워드와 동일하게 사용할 수 없습니다.
> 규칙
> - 첫 문자는 알파벳, 언더스코어(_)가 올 수 있습니다.
> - 두번째 문자부터는 알파벳, 언더스코어, 숫자가 올 수 있습니다.
> - 대소문자를 구분합니다.
> - 키워드와 같은 이름으로 사용할 수 없습니다
{: .notice--info}

<div class="notice--primary" markdown="1"> 

```c# 

// 좋은 예시
int playerScore;
string playerName;
float itemPrice;

// 나쁜 예시 (중요 의미 있는 변수명 짓기)
int x1;  // 변수명이 의미를 알기 어려움
string a; // 변수명이 명확하지 않음

// 오류 예시
int 1stNumber;  // 변수명은 숫자로 시작할 수 없음
string my-name; // 변수명에 하이픈(-)을 사용할 수 없음
float total$;   // 변수명에 특수문자($)를 사용할 수 없음

```
</div>

<br><br>

### 3). 코드 컨벤션(Code convention)
코드 컨벤션(Code convention)은 개발자들 사이에서 약속된 코드 작성 규칙으로, 코드의 **가독성을 높이고 유지 보수**를 쉽게 하기 위해 사용됩니다.  
코드 컨벤션은 프로그래밍 언어마다 다를 수 있으며,  우리는 다음의 규칙을 따를 예정입니다.  
[C# 코드 규칙](https://learn.microsoft.com/ko-kr/dotnet/csharp/fundamentals/coding-style/coding-conventions)
{: .notice}

> 식별자 표기법
> - PascalCase: **클래스, 메서드, 프로퍼티** 이름 등에 사용됩니다. 단어의 **첫 글자는 대문자**로 시작하며, **이후 단어의 첫 글자도 대문자**로 표기합니다.  
> - 예를 들어, ClassName, MethodName, PropertyName과 같은 형태입니다.  
> - camelCase: **변수, 매개변수, 로컬 변수** 이름 등에 사용됩니다. 단어의 **첫 글자는 소문자**로 시작하며, **이후 단어의 첫 글자는 대문자**로 표기합니다.  
> - 예를 들어, variableName, parameterName, localVariableName과 같은 형태입니다.  
> - 대문자 약어: 예외적으로 전체 글자가 모두 대문자인 식별자도 있습니다. 대표적으로 ID, HTTP, FTP 등이 있습니다.
{: .notice--info}

> 들여쓰기
> - 탭(tab) 또는 스페이스(space) 4칸을 사용하여 코드 블록을 들여씁니다.
{: .notice}

> 중괄호 위치
> - 중괄호({})는 항상 새로운 줄에서 시작합니다.
{: .notice}

> 빈 줄 사용
> - **관련 없는 코드 사이**에는 **빈 줄을 사용**하여 구분합니다.  
> - 메서드, 클래스 등의 **블록 사이**에는 **두 줄을 띄어**씁니다.  
{: .notice}

> 주석
> - /* / 여러 줄 주석을 사용할 때는 / 를 다음 줄에서 시작하고, */ 를 새로운 줄에서 끝내도록 합니다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 

class MyClass
{
    // 필드는 camelCase 표기법을 사용합니다.
    private int myField;

    // 프로퍼티는 PascalCase 표기법을 사용합니다.
    public int MyProperty { get; set; }

    // 메서드는 PascalCase 표기법을 사용합니다.
    public void MyMethod()
    {
        if (true)
        {
            // 중괄호는 새로운 줄에서 시작합니다.
        }

        // 코드 블록은 탭(tab) 또는 스페이스(space) 4칸으로 들여씁니다.

        // 관련 없는 코드 사이에는 빈 줄을 사용하여 구분합니다.
				// 블록 사이에는 두 줄을 띄어씁니다.
				
		    /*
		    여러 줄 주석을 사용할 때는
		     / * 를 새로운 줄에서 시작하고,
		     * / 를 새로운 줄에서 끝내도록 합니다.
		    */
		}
}

```
</div>

<br><br><br><br><br><br>
- - - 

# 3. 명시적 및 암시적 형변환
C#에서는 자료형이 다른 변수 간에 값을 할당하거나 연산을 수행할 수 있습니다.  
이때, 자료형이 다른 변수 간에 값을 할당하거나 연산을 수행하려면 명시적 형변환(explicit casting) 또는 암시적 형변환(implicit casting)을 해주어야 합니다.
{: .notice}

> **명시적 형변환** (자료형) 형식으로 수행할 수 있습니다.

> **암시적 형변환**
> - 작은 데이터 타입에서 더 큰 데이터 타입으로 대입하는 경우  
> - 리터럴 값이 대입되는 경우  
> - 정수형과 부동소수점형 간의 연산을 수행하는 경우

<div class="notice--primary" markdown="1"> 

```c# 

class MyClass
{
  // 명시적 형변환
  int num1 = 10;
  long num2 = (long)num1;   // int를 long으로 명시적 형변환

  // 암시적 형변환
  //  1. 작은 데이터 타입에서 더 큰 데이터 타입으로 대입
  byte num1 = 10;
  int num2 = num1;  // byte형에서 int형으로 암시적 형변환

  // 2. 리터럴 값이 대입되는 경우 
  float result = 1;  // 1은 int형 리터럴 값이지만 float형으로 암시적 형변환

  // 3. 정수형과 부동소수점형 간의 연산을 수행하는 경우
  int num1 = 10;
  float num2 = 3.14f;
  float result = num1 + num2;  // int형과 float형의 덧셈에서 float형으로 암시적 형변환
}

```
- 암시적 형변환은 프로그래머가 직접 형변환 코드를 작성하지 않아도 되므로 코드를 간결하게 작성할 수 있습니다.
- 하지만, 암시적 형변환이 발생하는 경우 데이터 타입을 신중하게 고려하여 코드를 작성해야 합니다.
</div>

<br><br><br><br><br><br>
- - - 

# 4. Console.ReadLine을 이용한 입력
C#에서 콘솔 입력을 받을 때는 Console.ReadLine 메소드를 사용합니다.  
ReadLine 메소드는 사용자가 입력한 값을 문자열로 반환합니다.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 

Console.Write("Enter your name: ");
string name = Console.ReadLine();
Console.WriteLine("Hello, {0}!", name);

[출력]
Enter your name: Kero
Hello, Kero!

```

</div>

<br><br>

## Split / 한줄에 여러 값 입력받기
사용자로부터 여러 개의 값을 한 줄에 입력받고 싶을 때에는 **`Console.ReadLine`** 메소드를 사용하여 입력받은 값을 문자열로 받은 후,  
**`string.Split`** 메소드를 사용하여 문자열을 나누어서 처리할 수 있습니다.
예를 들어, 사용자로부터 공백으로 구분된 두 개의 정수를 입력받아 더하는 코드를 작성해보겠습니다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 

Console.Write("Enter two numbers: ");
string input = Console.ReadLine();    // "10 20"과 같은 문자열을 입력받음

string[] numbers = input.Split(' ');  // 문자열을 공백으로 구분하여 배열로 만듦
int num1 = int.Parse(numbers[0]);     // 첫 번째 값을 정수로 변환하여 저장
int num2 = int.Parse(numbers[1]);     // 두 번째 값을 정수로 변환하여 저장

int sum = num1 + num2;                // 두 수를 더하여 결과를 계산

Console.WriteLine("The sum of {0} and {1} is {2}.", num1, num2, sum);

[출력]
Enter two numbers: 10 20
The sum of 10 and 20 is 30.

```
- string input = Console.ReadLine(); 로 입력을받고
- iput을 " " 로 나누어 배열에 저장한다.
- 여러값을 입력받을 수 있다.
</div>

<br><br><br><br><br><br>
- - - 

# 5. var 키워드 사용법
C# 3.0부터는 var 키워드를 사용하여 변수를 선언할 수 있습니다.  
var 키워드를 사용하여 변수를 선언하면 변수의 자료형이 컴파일러에 의해 자동으로 결정됩니다.  
즉, 초기화하는 값의 자료형에 따라 변수의 자료형이 결정됩니다.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 

var num = 10;         // int 자료형으로 결정됨
var name = "kero";   // string 자료형으로 결정됨
var pi = 3.141592;    // double 자료형으로 결정됨

```
- **`string input = Console.ReadLine();`** 로 입력을받고
- iput을 " " 로 나누어 배열에 저장한다.
- 여러값을 입력받을 수 있다.
</div>

<br><br><br><br><br><br>
- - - 

# 정리 잡답
> 여러개 입력받기  
>   -  1.**`readLine`** 입력받기  
>   -  2.**`Split`** 을 이용해 배열에 문자열 나눠서 저장  
>   -  3.형변환하여 새로운 변수에 저장해서 사용  
{: .notice}

> 단축키 주석 Ctrl K C 주석하기 , Ctrl K U 주석 풀기  
> 여러줄 주석 ctrl Sshift /  
{: .notice}

<br><br>
- - - 

[Unity] C# 변수와 자료형, Split

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
