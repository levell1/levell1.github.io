---
title:  "[C#] 배열, 컬렉션(list, Dictionary, Stack, Queue, Hashset) ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-07 11:50

---
- - -
조건문, 반복문, 배열, 컬렉션(list, Dictionary, Stack, Queue, Hashset)
<BR><BR>

<center><H1> C# 배열, 컬렉션(list, Dictionary, Stack, Queue, Hashset) </H1></center>
C# 배열, 컬렉션
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. C# 배열

<div class="notice--primary" markdown="1"> 

```c# 
// 배열 선언
데이터_유형[] 배열_이름;

// 배열 초기화
배열_이름 = new 데이터_유형[크기];

// 배열을 한 줄로 선언 및 초기화
데이터_유형[] 배열_이름 = new 데이터_유형[크기];

// 배열 요소에 접근
배열_이름[인덱스] = 값;
값 = 배열_이름[인덱스];

int[] array1 = new int[5];
```
</div>


> - 동일한 데이터 유형을 가지는 데이터 요소들을 한 번에 모아서 다룰 수 있는 구조
> - 인덱스를 사용하여 요소에 접근 가능
> - 선언된 크기만큼의 공간을 메모리에 할당받음
> - list..Length = 배열의 길이
{: .notice}

<br><br>

## 다차원 배열
<div class="notice--primary" markdown="1"> 

```c# 
int[,] array3 = new int[2, 3]; // 2D 2행 3열
int[,,] array3D = new int[2, 3, 4]; // 3D 2면 3행 4열이   3행4열이 2개
```
- 2D 2행 3열
- 3D 2면 3행 4열 &nbsp;&nbsp;&nbsp;&nbsp;   3행4열이 2개
</div>

> - 여러 개의 배열을 하나로 묶어 놓은 배열
> - 행과 열로 이루어진 표 형태와 같은 구조
> - 2차원, 3차원 등의 형태의 배열을 의미
> - C#에서는 다차원 배열을 선언할 때 각 차원의 크기를 지정하여 생성합니다.
{: .notice}

<br><br>

## 배열을 이용한 맵

<div class="notice--primary" markdown="1"> 

```c# 
int[,] map = new int[5, 5] 
{ 
    { 1, 1, 1, 1, 1 }, 
    { 1, 0, 0, 0, 1 }, 
    { 1, 0, 1, 0, 1 }, 
    { 1, 0, 0, 0, 1 }, 
    { 1, 1, 1, 1, 1 } 
};

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        if (map[i, j] == 1)
        {
            Console.Write("■ ");
        }
        else
        {
            Console.Write("□ ");
        }
    }
    Console.WriteLine();
}
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/1f1e1668-0221-4f7c-ba1a-f7c67e3a5395){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br><br><br><br><br>
- - - 

# 컬렉션
> - 컬렉션은 배열과 비슷한 **자료 구조**
> - 배열과는 다르게 크기가 **가변적**
> - C#에서는 다양한 종류의 컬렉션을 제공
> - 사용하기 위해서는 **`System.Collections.Generic`** 네임스페이스를 추가
{: .notice}
<br><br>

## List
> - List는 가변적인 크기를 갖는 배열
> - List를 생성할 때는 List에 담을 자료형을 지정
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
List<int> numbers = new List<int>(); // 빈 리스트 생성
numbers.Add(1); // 리스트에 데이터 추가
numbers.Add(2);
numbers.Add(3);
numbers.Remove(2); // 리스트에서 데이터 삭제

foreach(int number in numbers) // 리스트 데이터 출력
{
    Console.WriteLine(number);
}
```
</div>
<br><br>

## Dictionary
> - 딕셔너리(Dictionary)는 키와 값으로 구성된 데이터를 저장
> - 딕셔너리는 중복된 키를 가질 수 없으며, 키와 값의 쌍을 이루어 데이터를 저장
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
using System.Collections.Generic;

Dictionary<string, int> scores = new Dictionary<string, int>(); // 빈 딕셔너리 생성
scores.Add("Alice", 100); // 딕셔너리에 데이터 추가
scores.Add("Bob", 80);
scores.Add("Charlie", 90);
scores.Remove("Bob"); // 딕셔너리에서 데이터 삭제

foreach(KeyValuePair<string, int> pair in scores) // 딕셔너리 데이터 출력
{
    Console.WriteLine(pair.Key + ": " + pair.Value);
}
```
</div>


|**Key**|Value|
|:---|:---|
|Alice|100|
|Bob|80|
|Charlie|90|

Bob Remove

<br><br>

## Stack
> - Stack은 후입선출(LIFO) 구조를 가진 자료 구조
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
Stack<int> stack1 = new Stack<int>();  // int형 Stack 선언

// Stack에 요소 추가
stack1.Push(1);
stack1.Push(2);
stack1.Push(3);

// Stack에서 요소 가져오기
int value = stack1.Pop(); // value = 3 (마지막에 추가된 요소)
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/df5469f3-36ca-491b-b709-2cef331a6508){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## Queue
> - Queue는 선입선출(FIFO) 구조를 가진 자료 구조
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
Queue<int> queue1 = new Queue<int>(); // int형 Queue 선언

// Queue에 요소 추가
queue1.Enqueue(1);
queue1.Enqueue(2);
queue1.Enqueue(3);

// Queue에서 요소 가져오기
int value = queue1.Dequeue(); // value = 1 (가장 먼저 추가된 요소)
```
</div>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ebfce52e-3fc5-4e93-a685-dc56bd2e4a99){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## Hashset

> - 리스트랑 비슷, 중복X
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
HashSet<int> set1 = new HashSet<int>();  // int형 HashSet 선언

// HashSet에 요소 추가
set1.Add(1);
set1.Add(2);
set1.Add(3);

// HashSet에서 요소 가져오기
foreach (int element in set1)
{
    Console.WriteLine(element);
}
```
</div>

<br><br><br><br><br><br>
- - - 

# 3. 배열과 리스트의 차이
> 리스트는 동적, 유연한 데이터 구조를 구현할 수 있습니다. 하지만, 리스트를 무분별하게 사용하는 것은 좋지 않은 습관입니다.    
> - 1.&nbsp; 메모리 사용량 증가  : 리스트는 동적으로 크기를 조정할 수 있어 배열보다 많은 메모리를 사용합니다.  
> - 2.&nbsp; 데이터 접근 시간 증가  : 리스트에서 특정 인덱스의 데이터를 찾기 위해서는 연결된 노드를 모두 순회  .
> - 3.&nbsp; 코드 복잡도 증가 : 데이터 추가, 삭제 등의 작업을 적절히 처리하는 코드를 작성
> - 따라서, 리스트를 무분별하게 사용하는 것은 좋지 않은 습관입니다. 데이터 구조를 선택할 때는, 데이터의 크기와 사용 목적을 고려하여 배열과 리스트 중 적절한 것을 선택해야 합니다.
{: .notice}

<br><br><br><br><br><br>
- - - 

# 정리 잡답
> - 컬렉션 **`list`**, **`Dictionary`**, **`Stack`**, **`Queue`**, **`Hashset`**    
> - 배열의 길이는 length  컬렉션의 길이는 count
{: .notice}


<br><br>
- - - 

[C#] C# 배열, 컬렉션(list, Dictionary, Stack, Queue, Hashset)

<br>

참고 : [유니티](https://docs.unity3d.com/kr/) [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
