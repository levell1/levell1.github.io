---
title:  "[Unity] Behavior Tree  "
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-04-24 05:00

---
- - -


<br>
- - - 

# Behavior Tree
[Behaviour Tree Manual](https://docs.unity3d.com/Packages/com.unity.behavior@1.0/manual/index.html)  
-&nbsp;Behaviour Tree - AI 캐릭터의 행동 제어나 상태 관리를 위해 사용합니다.  
-&nbsp;Behaviour Tree는 게임 개발에서 비선형적이고, 복잡한 AI 의사 결정을 간단하게 모듈화하여 구현할 수 있게 해줍니다.  
-&nbsp;Unity6 부터 Built-in으로 지원, 노드기반으로 관리할 수 있게 제공합니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## Node
✔ Action Node : 실제 행동을 수행하는 노드  
&nbsp;&nbsp; 트리의 하단에 위치, 에이전트가 해야 할 구체적인 작업 정의  
&nbsp;  
✔ Modifier Node : 트리의 흐름이나 실행 조건을 수정  
&nbsp;&nbsp; 특정 조건을 확인, 실행 결과를 반환  
&nbsp;  
✔ Sequencing Node : 해당 노드가 아닌 자식 노드들을 **특정 조건**에 따라 실행  
&nbsp;&nbsp; 모든 자식 노드가 성공해야 자신도 성공 상태 반환  
&nbsp;  
✔ Join Node : 여러 노드에서 발생한 결과를 결합해 행동을 결정하는데 사용  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## 사용법
1.&nbsp;Pacage Manager - Behavior install  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Project1/Behavior1.png?raw=true)  
&nbsp;  
2.&nbsp;Project - Behavior Graph 생성  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Project1/Behavior2.png?raw=true)  
&nbsp;  
3.&nbsp;Behavior Graph 더블클릭 - 우클릭-> 노드 추가    
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Project1/Behavior2.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## Behavior Graph
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Project1/Behavior3.png?raw=true)  
BlackBoard : 사용하는 변수 목록, 기본적으로 자기 자신을 나타내는 Self 변수 생성  
&nbsp;BlackBoard에 선언한 변수는 외부에서 접근 가능하기 때분에 Insspector View에 출력되며, 스크립트에서 Get/Set 가능  
&nbsp;  
노드 생성 : 우클릭 - Add  
&nbsp;Action -> Navigation -> Nav To Target(목표에게 이동), To Location, Patrol(순찰)을 제공  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Project1/Behavior4.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## 순찰(Patrols)
1.&nbsp; 노드 생성 : Add -> Action -> Navigation -> Patrol  
2.&nbsp; Agent - Self 드래그  
3.&nbsp; WayPoint 설정  
BlackBoard에 List - GameObject List 추가, 드래그  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br>
- - - 

# 잡담, 일기?
내일 또 정리, c# 기초 강의 찾아보고 기초 다지기.  
이력서다듬기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -