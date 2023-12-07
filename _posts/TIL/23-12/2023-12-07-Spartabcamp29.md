---
title:  "[TIL] 29 Unity 팀과제  ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-07 02:00

---
- - -


<BR><BR>


<center><H1>  유니티 팀과제 6일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   41   
&nbsp;&nbsp; [o] 팀과제  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 알고리즘 문자열
[이상한문자 만들기](https://school.programmers.co.kr/learn/courses/30/lessons/12930)

**설명**  
문자열 s는 한 개 이상의 단어로 구성되어 있습니다. 각 단어는 하나 이상의 공백문자로 구분되어 있습니다. 각 단어의 짝수번째 알파벳은 대문자로, 홀수번째 알파벳은 소문자로 바꾼 문자열을 리턴하는 함수, solution을 완성하세요.

**제한 사항**  
문자열 전체의 짝/홀수 인덱스가 아니라, 단어(공백을 기준)별로 짝/홀수 인덱스를 판단해야합니다.
첫 번째 글자는 0번째 인덱스로 보아 짝수번째 알파벳으로 처리해야 합니다.

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
> - **예) s = "make til"**

**ToUpper()**  
> - s = s.ToUpper(); 문자열 s를 대문자로 변경하여 s에 다시 저장 
> - s = "MAKE TIL"

<br>

**Split(' ')**  
> - string[] words = s.Split(' ');  ' ' 스페이바 기준으로 문자열을 나눔
> - words [0] = "MAKE" , words[1] = "TIL"

<br>

**Split(string.ToCharArray())**  
> - char[] c = words[i].ToCharArray();
> - i = 0 일 때 c[0] = 'M' , c[1] = 'A' , c[2] = 'K' , c[3] = 'E'  
> - i = 1 일 때 c[0] = 'T' , c[1] = 'I' , c[2] = 'L'

<br>

**Split(char.ToLower(c[j]))**  
> - c[j]=char.ToLower(c[j]); 
> - i = 0 일때 c -> MaKe

<br>

**new string(c)**  
> - words[i] = new string(c)   c 문자배열을 합쳐서 문자열 words[i]에 저장
> - words[0] = "MaKe" words[1] = "TiL"

<br>

**string.Join(' ' , words)**  
> - answer = string.Join(' ' , words) answer 에 words[] 배열사이에 ' '를 넣고  합친다. 
> - answer= "MaKe TiL"

<br>

**시간 걸린부분**  
> - string, char에 관한 필요한 메서드를 찾는 과정
> - 메서드를 사용하고 결과를 변수에 넣지 않고 왜 안 바뀌는지 생각했던 부분

</div>

<br><br><br><br><br>
- - - 


# 프로젝트 영상

<iframe width="1120" height="630" src="https://www.youtube.com/embed/CMd0qiAZ0e0" title="팀과제 영상" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
- - - 

[Unity] TIL 29

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
