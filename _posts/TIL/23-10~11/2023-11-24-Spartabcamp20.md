---
title:  "[TIL] 20 정렬, 유니티 시작.  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-24 02:00

---
- - -

선택 정렬 ( `Selection Sort` ), 삽입 정렬 ( `Insertion Sort` )  
퀵 정렬 ( `Quick Sort` ), 병합 정렬 ( `Merge Sort` )
<BR><BR>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/fc36cabd-1c1c-47c9-a933-48ec66b132cb){:style="border:1px solid #EAEAEA; border-radius: 7px;"}


<center><H1>  개인공부, 유니티 1일차  </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제   23~24   
&nbsp;&nbsp; [Δ] c# 5강듣기  5-3부터 다시  
&nbsp;&nbsp; [Δ] 유니티 강의 듣기   1-6부터 다시 듣기  
&nbsp;&nbsp; [X] 강의 못들은거 1 정리, 1개 다시듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. C# 강의 정렬

## 선택정렬
배열에서 최소값(또는 최대값)을 찾아 맨 앞(또는 맨 뒤)와 교환하는 방법   
{: .notice}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/55aae071-8846-4c58-9a6d-9a02be49f68f){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<div class="notice--primary" markdown="1"> 

```c# 
for (int i = 0; i < arr.Length - 1; i++)
{
    int minIndex = i;

    for (int j = i + 1; j < arr.Length; j++)
    {
        if (arr[j] < arr[minIndex])
        {
            minIndex = j;
        }
    }

    int temp = arr[i];
    arr[i] = arr[minIndex];
    arr[minIndex] = temp;
}

```
</div>

I  &nbsp;J  
0  &nbsp;1234  
1  &nbsp;234  
2  &nbsp;34  
3  &nbsp;4  
{: .notice--info}

## 삽입정렬
삽입 정렬은 정렬되지 않은 부분에서 요소를 가져와 정렬된 부분에 적절한 위치에 삽입   
{: .notice}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/dff1d112-1c9d-4615-8003-8055af318730){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<div class="notice--primary" markdown="1"> 

```c# 
for (int i = 1; i < arr.Length; i++)
{
    int j = i - 1;
    int key = arr[i];

    while (j >= 0 && arr[j] > key)
    {
        arr[j + 1] = arr[j];
        j--;
    }

    arr[j + 1] = key;
}
```
</div>

I  &nbsp;J  
1  &nbsp;0 
2  &nbsp;10  
3  &nbsp;210  
4  &nbsp;3210
{: .notice--info}

## 퀵 정렬
피벗을 기준으로 작은 요소들은 왼쪽, 큰 요소들은 오른쪽으로 분할하고 이를 재귀적으로 정렬하는 방법  
정렬 후 정렬된 다음번째에 기준값 배치 -> 왼쪽, 오른쪽 나눠서(2회) 정렬 시작, 반복  
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/a88a98ed-766f-44d6-a4af-8f4eb789a5a0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<details>
<summary>Quick Sort</summary>
<div class="notice--primary" markdown="1"> 

```c# 
void QuickSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int pivot = Partition(arr, left, right);

        QuickSort(arr, left, pivot - 1);
        QuickSort(arr, pivot + 1, right);
    }
}

int Partition(int[] arr, int left, int right)
{
    int pivot = arr[right];
    int i = left - 1;

    for (int j = left; j < right; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            Swap(arr, i, j);
        }
    }

    Swap(arr, i + 1, right);

    return i + 1;
}

void Swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

QuickSort(arr, 0, arr.Length - 1);

foreach (int num in arr)
{
    Console.WriteLine(num);
}


```

</div>
</details>

## 병합정렬
병합 정렬은 배열을 반으로 나누고, 각 부분을 재귀적으로 정렬한 후, 병합하는 방법  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/bfbed8da-2eba-4b1e-80a5-dc80e1fa9050){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<details>
<summary>Marge Sort</summary>
<div class="notice--primary" markdown="1"> 

```c# 
void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int mid = (left + right) / 2;

        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
}

void Merge(int[] arr, int left, int mid, int right)
{
    int[] temp = new int[arr.Length];

    int i = left;
    int j = mid + 1;
    int k = left;

    while (i <= mid && j <= right)
    {
        if (arr[i] <= arr[j])
        {
            temp[k++] = arr[i++];
        }
        else
        {
            temp[k++] = arr[j++];
        }
    }

    while (i <= mid)
    {
        temp[k++] = arr[i++];
    }

    while (j <= right)
    {
        temp[k++] = arr[j++];
    }

    for (int l = left; l <= right; l++)
    {
        arr[l] = temp[l];
    }
}

int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

MergeSort(arr, 0, arr.Length - 1);

foreach (int num in arr)
{
    Console.WriteLine(num);
}

```
</div>
</details>

## SORT
- `Sort` 메서드는 배열이나 리스트의 요소들을 정렬하는 메서드입니다.
- 정렬은 오름차순으로 수행되며, 요소들의 자료형에 따라 다양한 정렬 기준을 사용할 수 있습니다.

<div class="notice--primary" markdown="1"> 

```c# 
// 정수 배열 정렬 예제
int[] numbers = { 5, 2, 8, 3, 1, 9, 4, 6, 7 };
Array.Sort(numbers);
Console.WriteLine(string.Join(", ", numbers));

// 문자열 리스트 정렬 예제
List<string> names = new List<string> { "John", "Alice", "Bob", "Eve", "David" };
names.Sort();
Console.WriteLine(string.Join(", ", names));

```
</div>


<br><br><br><br><br>
- - - 

# 2. 정리, 잡담

**밀린강의듣기**  
C# 종합반 5-3 듣다가 너무 잠이와서 다른걸 유니티 강의를 들었다.  
C# 5주차, 특강 2개 더 들어야된다.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br>

**모기**  
어제 자기 전 모기를 잡지 못하고 잠에 들었다.  
2시간 간격으로 귀 옆에서 파닥거려서 잠에 깼다.  
그래서 그런지 오늘 강의 듣는데 잠이 너무 왔다. ㅠ
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - - 

[Unity] TIL 20

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
