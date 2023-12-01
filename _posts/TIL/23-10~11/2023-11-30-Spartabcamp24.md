---
title:  "[TIL] 24 Unity 팀과제 시작 ⭐ "
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



<center><H1>  유니티 팀과제 1일차 </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 유니티 팀 프로젝트 발제  
&nbsp;&nbsp; [o] 알고리즘 문제   29 ~ 30    
&nbsp;&nbsp; [o] 팀회의   
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 팀 과제 회의

우리조는 닷지를 변형해 게임을 만들기로 했다.  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/c153818d-5247-4d58-82be-99077a610c0f)  

[1조 피그마](https://www.figma.com/file/TglXRlMkYd6kTjCM5iEtsY/1%EC%A1%B0-%EC%9D%BC%EB%8B%A8-%EB%B0%95%EC%A1%B0?type=whiteboard&node-id=0-1&t=hOCSGOG2cI5TUGXc-0)  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/b8119340-5498-4777-8410-34850a5a1198)  

<br><br><br><br><br>
- - - 

# 2. zep 이미지 작업
zep 캐릭터가 움직이는 게임을 만들기로 했다.  
zep에서 캡cj를 하고 다 배경 제거하는 작업을 했다.  
처음에는 [배경제거](https://www.remove.bg/ko/upload) 사이트를 사용하였다.  
하다가 더 디테일하게 작업해 보고 싶어서 [포토피아](https://www.photopea.com/) 를 사용하였다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/852a4d2c-23ac-4d06-964f-4d22a5996af6)

![IDLE5](https://github.com/levell1/levell1.github.io/assets/96651722/15ed44ff-e150-4f03-8476-20aa514a3864)  

![Run](https://github.com/levell1/levell1.github.io/assets/96651722/03cb7c38-8b3e-402d-b4f7-b31c42f403f3)  
 
![2023-11-30-20_12_51](https://github.com/levell1/levell1.github.io/assets/96651722/2919e436-64e8-41b1-b689-6585ab697352)  

[어도비 배경제거](https://www.adobe.com/kr/express/feature/image/remove-background) 그냥 이거 쓰면 좋고 빠르다. ㅠ

<br><br><br><br><br>
- - - 

# 3. Unity Merge Scene 충돌
유니티로 main에 merge할때 충돌이 났다 MainScene 에서 충돌이 났다.  
이유는 씬에 Object를 추가해서 Merge하면 이게 발생한다고 한다.  
2가지 방법이 있다.  
1.GameObject를 프리팹으로 만들어서 merge한다. merge후 풀거나 사용  
2.Scene을 하나 만들어서 merge 후 작업 한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  



<br><br><br><br><br>
- - - 

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
