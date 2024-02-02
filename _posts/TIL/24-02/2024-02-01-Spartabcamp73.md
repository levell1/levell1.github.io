---
title:  "[TIL] 73 사냥터, UI, ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-01 02:00

---
- - -

``

<BR><BR>

<center><H1>  최종 팀 프로젝트 16일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 사냥터 디자인

<br><br><br><br><br>
- - - 

# 식당준비 UI
음식 주문가능 수 손님에 맞게 수정  

<br><br><br><br><br>
- - - 

# 리펙토링
using, 변수명 정리  

<br><br><br><br><br>
- - - 

# 선택 정렬과 버블 정렬
**선택 정렬** : 배열에서 최소값을 찾아 앞쪽에 교환하는 과정을 반복하여 정렬  

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

<br><br>

**버블 정렬** : 인접한 두 원소를 비교해 가장 큰 원소를 끝으로 보내는 과정을 반복하여 정렬  

<div class="notice--primary" markdown="1"> 

```c# 
for (int i = 0; i < arr.Length - 1; i++)
{
    for (int j = 0; j < arr.Length - i - 1; j++)
    {
        if (arr[j] > arr[j + 1])
        {
            int temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}
```
</div>


<br><br><br><br><br>
- - - 


# 잡담,정리
디자인
**이번 주 할 일**  
사냥터 마무리, 코드 리펙토링, 게임 다듬기 버그 수정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
