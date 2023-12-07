---
title:  "[TIL] 30 Unity 강의  ⭐ "
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


<center><H1>  유니티 숙련주차 1일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   41   
&nbsp;&nbsp; [o] 강의 듣기  
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [o] 다른반 발표 보기  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 알고리즘 문자열

<div class="notice--primary" markdown="1"> 

```c# 
public string solution(string s) {
        string answer = "";
        s= s.ToUpper();
        string[] words = s.Split(' ');
        for(int i =0; i<words.Length;i++)
        {
            char[] c = words[i].ToCharArray();
            for(int j=1; j<words[i].Length; j++)
            {
                if(j%2==1)
                {
                c[j]=char.ToLower(c[j]);
                }
            }
            words[i] = new string(c);
        }
        answer = string.Join(' ',words);
        return answer;
    }


```
</div>

<br><br><br><br><br>
- - - 



<br><br><br><br><br>
- - - 

[Unity] TIL 30

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
