---
title:  "[Memo-Unity] 24. CameraView  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-18 01:11

---
- - -

`CameraView` 
<BR><BR>

<center><H1>  CameraView  </H1></center>
CameraView   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--succ} 
<br><br><br><br><br><br>
- - - 

# 3. 카메라 뷰
카메라 Projection = Orthographic -> 원근감 X  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/af632df7-4ffa-4735-a6e1-bfd1178d148b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 1) 탑다운
2D, 3D : X축 45도이상   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/abd542e9-7011-4237-8949-316d36cb88e4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 2) 사이드
원근법 무시 (2D, 3D : Orthographic, 캐릭터 follow)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/09cd8df0-eeff-4ef9-bd6f-0ff90e942430){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 3)1인칭 주인공 시점
3D, 캐릭터 Follow  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/cf4205fd-0bd9-4453-b0d5-0a538e44e895){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 4) 3인칭 백뷰(숄더뷰) 
3D 주로, 캐릭터 후방 상공에서 X축 살짝 회전  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/77ea29d5-2e74-4bcd-a92b-eda836601331){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 5)아이소메트릭(쿼터뷰)
원근법 무시 + x축 30도 y축 45도  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/d82ef192-c32b-4d93-ac37-50223e519a96){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  




<br><br><br><br>
- - - 

# 잡담
project view 에 폴더 정렬 해서 깔끔하게 보기  
01.Scene  
02.Scripts  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  
<br><br>
- - - 

[Unity] CameraView
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
