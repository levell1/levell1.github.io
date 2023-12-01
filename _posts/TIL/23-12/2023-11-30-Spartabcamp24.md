---
title:  "[TIL] 25 Unity 팀과제  ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-30 02:00

---
- - -


<BR><BR>



<center><H1>  유니티 팀과제 2일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   31 ~ 34    
&nbsp;&nbsp; [o] 팀과제
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 알고리즘 문자열
string.ToCharArray() :  문자열을 문자배열(char[])에 복사합니다.  
string s = new String(문자배열) char[]   -> 'a','b' ,'c'  
s = "abc"
<div class="notice--primary" markdown="1"> 

`문자열 내림차순`
```c# 
public string solution(string s) {
        string answer = "";
        char[] carr= s.ToCharArray();
        
        Array.Sort(carr);
        Array.Reverse(carr);
        
        answer = new String(carr);
        return answer;
    }
```
</div>


# 3. Unity Merge Scene 충돌



# 정리, 잡담

**느낀점**  
오늘은 이미지 관련 작업을 해서 코드를 못 만져서 아쉬웠다.  
이미지 작업을 처음 하다가 이미지의 위치가 다 달라서 애니메이션 작업하기 힘들겠다고 느꼈다. 그래서 애니메이션에서 편하게 작업할 수 있게 했다.
하면서 느낀점은 나도 코드를 쓸 때 다른 사람이 편하게 사용 할 수 있게, 다른 곳에서 어떻게 하면 편하게 할 수 있을지 고민하면서 코드를 작성해야겠다는 생각이 들었다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


**잡담**  
Scene에 object추가 하고 merge하지말기.  
prefebs나 새로운 Scene에서 작업, Merge 후 해결하기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


<br><br>
- - - 

[Unity] TIL 24

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
