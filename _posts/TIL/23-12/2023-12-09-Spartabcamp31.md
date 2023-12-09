---
title:  "[TIL] 31 숙련과정 강의  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-08 02:00

---
- - -


<BR><BR>


<center><H1>  유니티 숙련주차 2일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 43
&nbsp;&nbsp; [o] 강의 듣기  
&nbsp;&nbsp; [X] 다른반 발표 보기  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 스탯 만들기

**스크립터블 오브젝트(Scriptable Object)**
> - 스크립터블 오브젝트는 Unity에서 데이터를 저장하고 관리하는 유연한 데이터 컨테이너입니다.  
> - 게임에서 재사용 가능한 데이터 또는 설정을 저장하는 데 사용
> - 코드와 데이터를 분리
<div class="notice--primary" markdown="1"> 

```c# 
public int solution(string t, string p) {
        int answer = 0;
        for(int i = 0; i < t.Length-p.Length+1; i++)
        {
            string strA = t.Substring(i, p.Length);
            int compare = strA.CompareTo(p);
            if (compare<=0) answer++;
        }
        return answer;
    }
```
> - **예) t = "123", p="2"**

**`t.Substring(i, p.Length)`**  
> - t의 i번째부터 p.Length(1) 개만큼 가져와서 strA에 저장.

<br>

**`strA.CompareTo(p)`**  
> - strA와 P를 비교한다 
> - strA가 크면 +1 
> - 같으면 0 
> - 작으면 -1

</div>

<br><br><br><br><br>
- - - 

<br><br><br><br><br>
- - -

# 잡담 


<br><br>
- - -

[Unity] TIL 30

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
