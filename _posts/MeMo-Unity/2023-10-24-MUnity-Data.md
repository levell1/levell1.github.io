---
title:  "[Memo-Unity] 6. 데이터 보관 (Playerprefs)"
excerpt: "데이터 보관"

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-10-24

---
- - -
<BR><BR>

<center><H1> 데이터 보관 (Playerprefs) </H1></center>

[최고기록 예시](https://levell1.github.io/sparta%20unity/SpartaUnity2/#7-데이터-보관-playerprefs)
<br><br><br><br><br><br>
- - - 

# 1. 데이터 보관 (Playerprefs)
앱을 껐다 켜도 데이터가 유지되게 - 유니티에서 데이터를 보관하는 방법
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b2df9199-8c6c-4c7a-b57f-ca228fe0920a){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
// 데이터 저장하기 Set~~~~
Playerprefs.SetFloat("bestScore", 어떤숫자값);
Playerprefs.SetString("bestScore", 어떤문자열);

// 데이터 불러오기 get~~~~
Playerprefs.getFloat("bestScore");
Playerprefs.getString("bestScore");

// 저장하고 있는지 확인
Playerprefs.HasKey("bestScore") //"bestScore" 라는 이름으로 저장하고 있는지 확인

// 모두 지우기
Playerprefs.DeleteAll();
```
</div>

<br><br>

[C#] 데이터 보관 (Playerprefs)

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
