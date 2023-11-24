---
title:  "[C#] 탐색 알고리즘( 강의 듣고 추가 정리) ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-24 01:00

---
- - -
<BR><BR>

<center><H1> 탐색 알고리즘    </H1></center>
5-3 듣고 추가로 정리
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


# 탐색 알고리즘
탐색 알고리즘은 주어진 데이터 집합에서 특정 항목을 찾는 방법을 제공
{: .notice} 
## 선형 탐색(Linear Search)
배열의 각 요소를 하나씩 차례대로 검사
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c# 
int SequentialSearch(int[] arr, int target)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == target)
        {
            return i;
        }
    }

    return -1;
}
```
</div>

## 이진 탐색 (Binary Search)
배열에서 빠르게 원하는 항목을 찾는 방법입니다.  
중간 요소와 찾고자 하는 항목을 비교하여 대상이 중간 요소보다 작으면 왼쪽을, 크면 오른쪽을 탐색
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c# 
int BinarySearch(int[] arr, int target)
{
    int left = 0;
    int right = arr.Length - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (arr[mid] == target)
        {
            return mid;
        }
        else if (arr[mid] < target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }

    return -1;
}
```
</div>

<br><br>
- - - 

[C#] 탐색 알고리즘

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)  [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
