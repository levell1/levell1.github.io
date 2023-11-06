---
title:  "[Sparta-BCamp] C# 연산자와 문자열 처리 ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-06 13:00

---
- - -
<BR><BR>

<center><H1> C# 연산자와 문자열 처리 </H1></center>
C# 연산자와 문자열 처리
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 산술, 관계, 논리 연산자 사용법

## 산술연산자

|**연산자**|설명|
|:---|:---|
|+|덧셈|
|-|뺄셈|
|*|곱셈|
|/|나눗셈|
|%|나머지|

<br>

## 관계연산자

관계 연산자는 두 값을 비교하여 참(True) 또는 거짓(False) 값을 반환합니다.
{: .notice--info}

|**연산자**|설명|
|:---|:---|
|==|같음|
|!=|다름|
|>|큼|
|<|작음|
|>=|크거나 같음|
|<=|작거나 같음|

<br>

## 논리연산자

논리 연산자는 참(True) 또는 거짓(False) 값을 대상으로 사용됩니다.
{: .notice--info}

|**연산자**|설명|
|:---|:---|
|&&|논리곱(AND)|
|\|\||논리합(OR)|
|!|논리부정(NOT)|

> 이거나 &&, 또는 \|\||, 그렇지않다면 !

<br><br><br><br><br><br>
- - - 

# 2. 비트연산자

비트 단위로 데이터를 조작하고, 이진수 연산
{: .notice}

|**연산자**|설명|
|:---|:---|
|& (AND)|두 비트 값이 모두 1일 때 1을 반환|
|\|(OR)|두 비트 값 중 하나라도 1일 때 1을 반환|
|^ (XOR)|두 비트 값이 서로 다를 때 1을 반환|
|~ (NOT)|비트 값의 보수(complement)를 반환|
|<< (왼쪽 시프트)|비트를 왼쪽으로 이동|
|>> (오른쪽 시프트)|비트를 오른쪽으로 이동|

<div class="notice--primary" markdown="1"> 

```c# 
int a = 0b1100; // 12 (2진수)
int b = 0b1010; // 10 (2진수)

int and = a & b; // 0b1000 (8)
int or = a | b; // 0b1110 (14)
int xor = a ^ b; // 0b0110 (6)

int c = 0b1011; // 11 (2진수)
int leftShift = c << 2; // 0b101100 (44)
int rightShift = c >> 1; // 0b0101 (5)

int d = 0b1100; // 12 (2진수)
int bit3 = (d >> 2) & 0b1; // 1 (3번째 비트)  1 & 1   1 
d |= 0b1000; // 0b1100 | 0b1000 = 0b1100 (12)

```

- 강의에서 int bit3 = (d >> 2) & 0b1; 결과가 0 이라고 설명하였는대
- 1인거 같아서 비쥬얼스튜디오에서 돌려서 확인해 보았다. 
</div>

<br><br><br><br><br><br>
- - - 

# 3. 복합 대입 연산자와 증감 연산자 활용
변수를 더 편리하게 조작하고 값을 증감시킬 수 있어요.
{: .notice}

## 1). 복합 대입 연산자
C#에서는 변수에 값을 할당하는 대입 연산자(=) 외에도, 다양한 복합 대입 연산자를 제공합니다.  
복합 대입 연산자는 변수에 연산을 수행한 결과를 저장하는 연산자입니다.
{: .notice}


|**연산자**|예시|설명|
|:---|:---|:---|
|+=|x += y;|x = x + y;|
|-=|x -= y;|x = x - y;|
|*=|x *= y;|x = x * y;|
|/=|x /= y;|x = x / y;|
|%=|x %= y;|x = x % y;|

<br>

## 2). 증감 연산자
증감 연산자는 변수의 값을 1 증가, 감소시키는 연산자입니다.
{: .notice}

|**연산자**|예시|설명|
|:---|:---|
|++|1증가|
|--|1감소|
  
x++, ++x  
x--, --x



<br><br><br><br><br><br>
- - - 

# 4. 연산자 우선순위

>   - 연산자 우선순위는 수식 내에서 연산자가 수행되는 순서를 결정합니다.  
>   - 연산자 우선순위에 따라 연산의 결과가 달라질 수 있으므로 중요한 개념입니다.  
{: .notice}

1.괄호 (): 괄호로 감싸진 부분은 가장 높은 우선순위로 먼저 계산됩니다.  
2.단항 연산자: 단항 연산자들(++, --, +, -, ! 등)은 괄호 다음으로 높은 우선순위를 가집니다.  
3.산술 연산자: 산술 연산자들(*, /, %, +, -)은 단항 연산자보다 우선순위가 낮습니다.  
4.시프트 연산자: 시프트 연산자(<<, >>)는 산술 연산자보다 우선순위가 낮습니다.  
5.관계 연산자: 관계 연산자들(<, >, <=, >=, ==, !=)는 시프트 연산자보다 우선순위가 낮습니다.  
6.논리 연산자: 논리 연산자들(&&, ||)는 관계 연산자보다 우선순위가 낮습니다.  
7.할당 연산자: 할당 연산자들(=, +=, -=, *=, /= 등)는 논리 연산자보다 우선순위가 낮습니다.  
{: .notice--success}

<br><br><br><br><br><br>
- - - 

# 5. 문자열 처리 기능 및 메서드

## 1).문자열 생성(new)

<div class="notice--primary" markdown="1"> 

```c# 
string str1 = "Hello, World!"; // 리터럴 문자열 사용
string str2 = new string('H', 5); // 문자 'H'를 5개로 구성된 문자열 생성
```
</div>
<br>

## 2).연결(+)
이 코드는 str1 문자열과 str2 문자열을 공백으로 구분하여 연결한 새로운 문자열 str3을 생성합니다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
string str1 = "Hello";
string str2 = "World";
string str3 = str1 + " " + str2;
```
</div>
<br>

## 3).분할(Split)

<div class="notice--primary" markdown="1"> 

```c# 
string str = "Hello, World!";
string[] words = str.Split(',');
// 쉼표로 구분
```
</div>
<br>

## 4).검색 (IndexOf)

<div class="notice--primary" markdown="1"> 

```c# 
string str = "Hello, World!";
int index = str.IndexOf("World");
// 실행 경과 7이 나왔다.
```

- "World" 문자열의 첫 번째 인덱스를 찾아 index 변수에 저장
</div>
<br>

## 5).대체(Replace)

<div class="notice--primary" markdown="1"> 

```c# 
string str = "Hello, World!";
string newStr = str.Replace("World", "Universe");
```

-   "World" 문자열을 "Universe" 문자열로 대체한 새로운 문자열 newStr을 생성합니다.
</div>
<br>

## 6).변환(Parse)

<div class="notice--primary" markdown="1"> 

```c# 
string str = "123";
int num = int.Parse(str);

int num = 123;
string str = num.ToString();
```

- 앞에서 본 형변환
</div>
<br>

## 7).비교(string.Compare)

<div class="notice--primary" markdown="1"> 

```c# 
//문자열 값 비교
string str1 = "Hello";
string str2 = "World";
bool isEqual = str1 == str2;

//문자열 대소 비교
string str1 = "Apple";
string str2 = "Banana";
int compare = string.Compare(str1, str2);
```

- 이 코드는 str1 문자열과 str2 문자열을 대소 비교한 후, compare 변수에 그 결과를 저장합니다.  
- compare 변수는 0보다 작으면 str1이 str2보다 작고, 0이면 str1과 str2가 같으며, 0보다 크면 str1이 str2보다 큽니다.  
</div>
<br>

## 8).포멧팅(string.Format, $)

<div class="notice--primary" markdown="1"> 

```c# 
// 문자열 형식화 string.Format
string name = "John";
int age = 30;
string message = string.Format("My name is {0} and I'm {1} years old.", name, age);

// 문자열 보간 $
string name = "John";
int age = 30;
string message = $"My name is {name} and I'm {age} years old.";
```

- {x} 부분을 , 뒤 순서대로 삽입
- 보간기능 위보다 더 간단하게 사용
</div>


<br><br><br><br><br><br>
- - - 

# 정리 잡답
> - 연산자를 사용할 때에는 연산자 우선순위를 항상 고려하여 코드를 작성하는 것이 중요합니다,  괄호를 사용하여 우선순위를 변경할 수 있습니다.
> - 분할(Split), 검색(indexOf), 대체(Replace), 변환(Parse), 비교(String.Compare), 포멧팅(String.Format, $)
{: .notice}

<br><br>
- - - 

[Unity] C# 연산자와 문자열 처리

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
