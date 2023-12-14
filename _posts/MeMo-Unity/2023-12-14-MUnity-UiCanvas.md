---
title:  "[Memo-Unity] 20. Ui  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-14 09:10

---
- - -

`UiCanvas` 
<BR><BR>

<center><H1>  Ui  </H1></center>
개인과제 풀이영상   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 
<br><br><br><br><br><br>
- - - 

# 1. UI Canvas
**Scale Mode**
![image](https://github.com/levell1/levell1.github.io/assets/96651722/32913432-1d08-4a76-923f-062930378d5e)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

## 앵커
기준점 -> 만약 해상도가 바뀌면 기준점을 기준으로 UI 조절된다.   
앵커에 따라 UI변형이 다르게 늘어난다.  

# 2. TextMashPRO
폰트추가 -> WINDOW -> TMP -> FONT ASSET CREATOR  
-> GENERATE FONT ATLAS, SAVE -> FONT(ATLAS Population Mode = Dynamic)  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/f33fe7b4-6ab4-424a-85aa-38906a26ab4e)   

![image](https://github.com/levell1/levell1.github.io/assets/96651722/12c660e9-705f-46df-9830-f3f171e30c7a)  

# 3. button

button 클릭시 보이고 나타나는 (setactive) 코드로도 가능하지만 버튼에 ON Click 에서도 가능하다.  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/e1ba03e8-541f-432c-a94b-4af8a033153d)  

# 4. inpufield
content Type 으로 입력값 무었으로 할 지 가능  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/42c25211-3e33-4957-9e79-c75adde53743)

# 5. Scoll View
GRID LAYOUT GROUP ->  정렬  
Content Size Filter -> perferred size 부모 크기 안의 내용에 맞게 조절

![image](https://github.com/levell1/levell1.github.io/assets/96651722/b6fe5f47-dfc3-4ac1-8efe-ef5c9fc88ee0)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8df88b61-9609-43f5-9e0a-af3625210b43)  

# 잡담
project view 에 폴더 정렬 해서 깔끔하게 보기  
01.Scene  
02.Scripts  
<br><br>
- - - 

[Unity] StatHandler
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
