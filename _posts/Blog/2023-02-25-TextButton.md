---
title:  "[Blog Post-IT]  Text,font,Button"
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


# Blog 사용법 1

## 폰트 설정하기
### 1. 폰트사이트 - [눈누](https://noonnu.cc/)  마음에드는 폰트 선택   
### 2. 웹폰트로 사용 복사후 main.scss에 추가  
### 3. _variables.scss 에 추가   

![image](https://user-images.githubusercontent.com/96651722/221398446-bc6895c6-8eea-4954-88eb-5e35cc4d455e.png)  
  
##  공지사항  
![image](https://user-images.githubusercontent.com/96651722/221509144-3a028211-67e5-4ce4-8857-24c25562046d.png)
```
**<u>공지 사항</u>** 하하
{: .notice--primary}
```  
**<u>공지 사항</u>** 하하
{: .notice--primary}  

##  HTML코드  

```
<div class="notice--primary" markdown="1">
안에 `코드`도 넣을 수 있다. 아래처럼! 
  (```c++
std::cout << "Hello. World! >> std::endl;
  ```) 
- C++ 열심히
- 공부하자
</div>
```  

<div class="notice--primary" markdown="1">
안에 `코드`도 넣을 수 있다. 아래처럼! 
  ```c++
std::cout << "Hello. World! >> std::endl;
  ``` 
- C++ 열심히
- 공부하자
</div>

##  간단  
<div class="notice">
  <h4>블로그 사용하기</h4>
  <p>블로그 1</p>
</div>

##  버튼  

![image](https://user-images.githubusercontent.com/96651722/221512400-cacf42d0-efb6-4c73-96f8-6a32307bbb5f.png)  

```
<a href="#" class="btn--success">Success Button</a>
[Default Button](#){: .btn .btn--primary }
```  
<a href="#" class="btn--success">Success Button</a>
[Default Button](#){: .btn .btn--primary }

<br>

[맨 위로 이동하기](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -