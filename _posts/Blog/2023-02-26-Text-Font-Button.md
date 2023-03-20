---
title:  "[Blog Github.io]  폰트설정, Text, Button"
excerpt: " Text font Button "

categories:
  - Blog 
tags:
  - [Blog, Minimal Mistakes]
toc: true
toc_sticky: true

date: 2023-02-26
---
- - -
<br><br>

---
# 1. 폰트 설정하기
## 1) 폰트사이트 - [눈누](https://noonnu.cc/)  마음에드는 폰트 선택   
## 2) 웹폰트로 사용 복사후 main.scss에 추가  
![image](https://user-images.githubusercontent.com/96651722/226320419-4500bd01-f902-4e44-b009-26b5e1970053.png){: .align-left}{: width="40%" height="40%"}
![image](https://user-images.githubusercontent.com/96651722/226320491-1badb422-e0ea-4dfd-adc0-d70ff73c0f7f.png){: .align-right}{: width="50%" height="50%"} 

<br><br><br><br><br><br><br><br>


## 3) _variables.scss 에 추가   

![image](https://user-images.githubusercontent.com/96651722/221398446-bc6895c6-8eea-4954-88eb-5e35cc4d455e.png)  
  
<br><br><br>
---

# 2. 글 강조  
![image](https://user-images.githubusercontent.com/96651722/221509144-3a028211-67e5-4ce4-8857-24c25562046d.png)
```
**<u>글 강조</u>** 하하
{: .notice--primary}
```  
**<u>글 강조</u>** 하하
{: .notice--primary}  

<br><br><br>

---
# 3.  HTML코드  

```
<div class="notice--primary" markdown="1">
`Html` 코드 
  (```c#      ()제거
Console.WriteLine("C#코드");
  ```) 
- C#, Unity
- C++, Unreal
</div>
```  

<div class="notice--primary" markdown="1">
`Html` 코드
  ```c#
Console.WriteLine("C#코드");
  ``` 
- C#, Unity
- C++, Unreal
</div>

<br><br><br>

---
# 4.  간단  
```
<div class="notice">
  <h4> Post-IT블로그 </h4>
  <p> Post-IT </p>
</div>
```  
<div class="notice">
  <h4> Post-IT블로그 </h4>
  <p> Post-IT </p>
</div>

<br><br><br>

---
# 5.  버튼  

![image](https://user-images.githubusercontent.com/96651722/221512400-cacf42d0-efb6-4c73-96f8-6a32307bbb5f.png)  

```
<a href="#" class="btn--success">Success Button</a>
[Default Button](#){: .btn .btn--primary }
```  
<a href="#" class="btn--success">Success Button</a>
[Default Button](#){: .btn .btn--primary }

<br>

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
