---
title:  "[Memo-Unity] 19. FOR문 안의 람다식  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-14 09:07

---
- - -

`lambda` 
<BR><BR>

<center><H1>  lambda  </H1></center>
다른분의 과제 코드를 보다가 해결하는걸 보고 언젠간 겪을 거 같은 문제였다.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 
<br><br><br><br><br><br>
- - - 

# 1. for문, 람다
onClick.AddListener 람다식으로 for문안에서 할당?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}
<div class="notice--primary" markdown="1"> 

```c#
for (int i = 0; i < Btns.Length; i++)
{
    Btns[i].onClick.AddListener(() => PressBtnSelectGame(i));
}


for (int i = 0; i < Btns.Length; i++)
{
    int temp = i; 
    Btns[temp].onClick.AddListener(() => PressBtnSelectGame(temp));
}
```
</div>

PressBtnSelectGame(i) 에서 i값이 0,1,2 ---라고 예상된다.  
람다식이 실제 실행 되기 전에는 내부 변수를 참조형태로 가지고 있다고 한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


<br><br>
- - - 

[Unity] StatHandler
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
