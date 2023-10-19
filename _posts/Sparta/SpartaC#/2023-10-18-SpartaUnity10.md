---
title:  "[C#] 접근제한자 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-18

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


<h1> 접근제한자</h1>

<br><br><br><br><br><br>
- - - 

# 1. 접근제한자

내가 작업한 클래스의 변수 및 함수를 다른 클래스에서 접근하는 것을 설정할 수 있습니다.  
변수나 함수 앞에 public, private, protected, internal 중 한개를 선언하면 됩니다.  
이를 **접근 제한자** 하고 합니다.  함수도 변수와 동일합니다.  
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/1ec20bcf-49f8-4299-b04d-4ce536b4bb93){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
public  int x;
private int y;
```
-   접근제한자 변수타입 변수이름

</div>

## public
클래스에서 public 로 선언된 변수는 외부 클래스에서 접근할 수 있습니다.
{: .notice}

## private
클래스에서 private 로 선언된 변수는 외부 클래스에서 접근할 수 없습니다.  
앞에 아무것도 선언하지 않았을 때 자동으로 **private 로 간주**합니다.  
{: .notice}

<br><br>

[C#] 접근제한자

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
