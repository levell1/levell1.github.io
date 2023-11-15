---
title:  "[C#] Nullable, 문자열 빌더(StringBuilder) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-14 01:00

---
- - -
<BR><BR>

<center><H1> C# Nullable, 문자열 빌더(StringBuilder)    </H1></center>

`Nullable`, 문자열 빌더(`StringBuilder`) 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. Nullable
<U>"아무것도 없음"을 의미, 참조형 변수가 어떠한 객체를 참조하지 않을 때 사용</U>   
값형 변수는 null 허용x -> null값을 지정할 수 있는 방법 제공  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

> **Nullable 이란**
> - Nullable은 C#에서 null 값을 가질 수 있는 값형에 대한 특별한 형식입니다.
> - 기본적으로 값형은 null을 허용하지 않습니다.
> - **<u>값형 변수에 null 값을 지정할 수 있는 방법을 제공</u>**하여 값형이나 구조체를 사용하는 프로그램에서 null 상태를 나타낼 수 있습니다.  
주로 값형 변수가 null인지 아닌지를 확인하고 처리해야 할 때 유용합니다.
> - 형식은 `?` 연산자를 사용하여 선언됩니다.  
`int?`는 int 형식에 null을 할당할 수 있는 Nullable<int> 형식을 나타냅니다.
> - 병합 연산자 ?? 0 -> 널이면 0을 반환
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

**사용예제**


<details>
<summary>Nullable</summary>

<div class="notice--primary" markdown="1"> 

```c# 
// Nullable 형식 변수 선언
int? nullableInt = null;
double? nullableDouble = 3.14;
bool? nullableBool = true;

// 값 할당 및 접근
nullableInt = 10;
int intValue = nullableInt.Value;

// null 값 검사
if (nullableDouble.HasValue)
{
    Console.WriteLine("nullableDouble 값: " + nullableDouble.Value);
}
else
{
    Console.WriteLine("nullableDouble은 null입니다.");
}

// null 병합 연산자 사용
// nullableInt ?? 0과 같이 사용되며, nullableInt가 null이면 0을 반환합니다.
int nonNullableInt = nullableInt ?? 0;
Console.WriteLine("nonNullableInt 값: " + nonNullableInt);
```

- 병합 연산자 ?? 0 -> 널이면 0을 반환

</div>
</details>

**조심**  
int? 와 int는 다르다.  
int? 의 형태의 변수는 .value, .hasvalue 등으로 사용 가능하다.  
{: .notice}

<br><br><br><br><br><br>
- - - 

# 2. 문자열 빌더(String Builder)

> - **<u>문자열 조작</u>** : StringBuilder는 Append(), Insert(), Replace(), Remove() 등 다양한 메서드를 제공  
문자열에 대한 추가, 삽입, 치환, 삭제 작업을 수행할 수 있습니다.  
> - **<u>가변성</u>** : 내부 버퍼를 사용하여 문자열 조작. 크기를 동적으로 조정  
문자열의 크기가 늘어나거나 줄어들어도 추가적인 메모리 할당이 발생하지 않습니다.
> - **<u>효율적인 메모리 관리</u>** :  메모리 할당 및 해제 오버헤드가 크게 감소  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

## 주요 메서드

> - **`Append`**: 문자열을 뒤에 추가합니다.
> - **`Insert`**: 문자열을 지정한 위치에 삽입합니다.
> - **`Remove`**: 지정한 위치에서 문자열을 제거합니다.
> - **`Replace`**: 문자열의 일부를 다른 문자열로 대체합니다.
> - **`Clear`**: StringBuilder의 내용을 모두 지웁니다.
{: .notice--info}

<details>
<summary>사용예제</summary>

<div class="notice--primary" markdown="1"> 

```c# 
StringBuilder sb = new StringBuilder();

// 문자열 추가
sb.Append("Hello");             //"Hello"
sb.Append(" ");                 //"Hello "
sb.Append("World");             //"Hello World"

// 문자열 삽입
sb.Insert(5, ", ");             //"Hello, World"

// 문자열 치환
sb.Replace("World", "C#");      //"Hello, C#"

// 문자열 삭제
sb.Remove(5, 2);                //"HelloC#"

// 완성된 문자열 출력
string result = sb.ToString();  //"HelloC#"
Console.WriteLine(result);
```
</div>
</details>



<br><br>
- - - 

[Unity] C# Nullable, 문자열 빌더(StringBuilder)

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)  [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
