---
title:  "[Sparta-BCamp] TIL 18 팀 과제진행, 알고리즘 문제 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-21 02:00

---
- - -

<BR><BR>

<center><H1> 팀과제 6일차   </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제  
&nbsp;&nbsp; [O] (주) 팀 과제   
&nbsp;&nbsp; [O] 상담받고 오기.       
&nbsp;&nbsp; [X] 5주차 강의듣기(알고리즘).   
&nbsp;&nbsp; [X] 강의 못들은거 1 정리, 1개 다시듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<br><br><br><br><br><br>
- - - 

# 1. 알고리즘
18~20   

## 문제 20 정수 내림차순으로 배치하기  

<details>
<summary>전체코드</summary>

<div class="notice--primary" markdown="1"> 

```c#

public long solution(long n) 
    {
        long answer = 0;
        string s = n.ToString();
        long len = s.Length;
        int[] arr = new int[len];
        int temp;
        long x = 1;
        
        for(int i =0; i<len; i++)   
        {
            arr[i] = s[i]-'0';
        }
        
        //Array.Sort(arr);
        for(long i = 0; i<len; i++)
        {
            for(long j= i+1; j<len;j++)
            {
                if(arr[i] < arr[j])
                {
                    temp = arr[i];
                    arr[i]=arr[j];
                    arr[j]=temp;
                }
            }
        }
        for(long i= len-1; i>=0; i--)
        {
            answer += arr[i] * x;
            x=x*10;
        }
        
        return answer;
    }
```
</div>
</details>

<br>

**정렬**
Sort 코드로 짜보기  
<div class="notice--primary" markdown="1"> 

```c#
//Array.Sort(arr);
for(int i = 0; i<len; i++)
{
    for(int j= i+1; j<len;j++)
    {
        if(arr[i] > arr[j])
        {
            temp = arr[i];
            arr[i]=arr[j];
            arr[j]=temp;
        }
    }
}
```
</div>


<br><br><br><br><br>
- - - 

# 2. 팀 과제 
마무리 작업
{: .notice--info}

# 3. 정리, 잡담

> **잡담**  
내일 쓰자.
{:style="border:1px solid #000000; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - - 

[Unity] TIL 18

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
