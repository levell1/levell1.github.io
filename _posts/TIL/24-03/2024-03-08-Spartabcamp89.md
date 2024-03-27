---
title:  "[TIL] 89 Behavior Tree(BT), 던전 정리 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-03-08 02:00

---
- - -

`Behavior Tree` `BT` `던전`

<BR><BR>

<center><H1>  최종 팀 프로젝트 31일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# Behavior Tree
트리 구조 -> 위에서 아래, 왼쪽에서 오른쪽 순으로 진행  

<br><br>

## 노드
**Action**, **Selector**, **Sequence** 로 구성  

> **Action** : 행동을 정의한 노드  
> - 플레이어체크, 에어본스킬, 원거리공격, 빛전기공격, 도망, 돌진 공격 등등  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/0ab02bcd-bc4d-499e-9e42-eb6097a869da){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

> **Selector** : or 연산자의 기능 
> - 왼쪽에서 오른쪽으로 진행 (성공한 노드가 있다면 노드를 실행하고 종료.)
> - 여러 행동 중 하나만 실행 할 때 사용하기 좋다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

> **Sequence** : and연산자의 기능
> - 자식노드중 실패한 노드가 있을 때 까지 진행
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/06973421-2474-4592-853f-c0e4d8e8a060){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

> **Decorator** 제어문을 실현하기 위한 노드
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>


**보스 Aieht BT**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/df228316-a796-4a82-ab69-4afb1a71b650){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 

# 던전 정리

> **던전 맵구성** - 매번 다른경험을 위해 랜덤 맵 제작  
> - -> 랜덤 맵 제작은 했지만 문과 다음방의 연결에 대한 고민이 해결되지않았다.  
> - -> 1주안에 할 수 있을까에 대한 고민 (시간적인 고민)  
> - -> 1주안에 힘들다 생각하여 고정맵을 만들고, 포탈만 랜덤생성으로 변경  
> - -> 1층, 2층, 3층(보스방) 던전  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning}  

> **몬스터 생성, 던전진행**
> - 층마다 다른 몬스터들을 랜덤종류, 랜덤수만큼 생성
> - 방에 있는 몬스터 모두 처치 시 다음방 으로가는 문이 열리게 설정
> - 다음층으로 가는 포탈으로 다음층진행
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/e74ca520-181b-4600-85a8-838aa6d47283){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
맵 끝에 랜덤으로 포탈이 생성, 다음층으로 연결  
1 -> 2-> 3(보스방)층으로 구성 보스를 깨면 클리어.  

<br><br><br><br><br>
- - - 

# 잡담,정리
`Behavior Tree` `BT` `던전` 정리  
아직 BT사용에 미숙하고 써보지못한 노드들 Decorator 등 많은 기능을 사용 할 수 있었다.  
다음에 다시 할 때 더 완성된 형태로 할 수 있을 거 같다..  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
