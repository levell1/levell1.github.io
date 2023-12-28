---
title:  "[TIL] 45 반별강의(ui), 심화주차  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-27 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 심화주차 6일 , 개인공부 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 51  
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [o] 디자인 패턴 복습하기   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 오류?

<div class="notice--primary" markdown="1"> 

```c#
public GameObject[] SpawnPosition;
GameObject bullet = _objectPool.SpawnFromPool("Bullet");
bullet.transform.position = SpawnPosition[_spawnCount].transform.position;

public Transform[] SpawnPosition;
GameObject bullet = _objectPool.SpawnFromPool("Bullet");
bullet.transform.position = SpawnPosition[_spawnCount].position;
```
</div>

**GameObject -> Transform 변경했더니 오류**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9bc99052-2f44-4342-b0da-ceb22f71dbcc){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/acc273f1-9989-4316-ac3e-c93a128c7c12){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8f929963-9040-488d-8113-e3c4f06e3892){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**배열에 값을 제거했다가 다시 넣어줘야 오류가 뜨지 않는다.**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5c638a02-c7c5-4970-a2e6-1a22ff615d86){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

유니티오류?  

<br><br><br><br><br>
- - - 

# 잡담,정리
오늘은 개인과제를 진행 하였고, 배운것들을 처음부터 구현 할려고 하니 많이 힘들었고, 좀 더 공부가 필요하다고 느끼는 시간이였다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  
 

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
