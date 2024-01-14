---
title:  "[TIL] 59 Sound - coroutine  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-12 02:00

---
- - -

`Stop coroutine`

<BR><BR>

<center><H1>  최종 팀 프로젝트 4일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 다른반 강의 듣기 스탠다드2 챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# Manager 

각각 매니저는 무슨 역할을 하는걸까? audio, data, resource 등 매니저들은 어떤 역할을 해야되는게 정해져 있나?  
계속 생각을 하다보니 조금의 감은 오지만 확실한 느낌이 오진않는다. 좀 더 알아보는 중..  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br>
- - - 

# Stop Coroutine

[**stop Coroutine**](https://levell1.github.io/til/Spartabcamp48/#%EC%BD%94%EB%A3%A8%ED%8B%B4coroutine)  
배경음볼륨 서서히 증가, 감소 추가.  
오늘 배경음 작업하면서 원하는대로 코루틴이 멈춰지지 않는 상황을 겪었다.  
그리고 저번에 튜터님의 강의에서 본 내용이 생각났고 강의내용으로 적용해보고 해결되었다. 🙏  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br>

# UI 만들기
UI관련 보기, 리소스에 관하여 생각중.  
리소스? 큐 - 리소스 로딩 관리 - 새로운 레벨 이동 시 리소스 로딩 작업 큐로 처리, 로딩 시간 최적화, 리소스의 우선순위 할당  
**딕셔너리(해시)활용 예시**  
&nbsp;&nbsp; 1. 아이템 관리 - 대형 아이템 DB를 다룰 때, 관리, 검색하기 위한 시스템  
&nbsp;&nbsp; 2. 리소스 관리 - 맵 유닛 등의 여러 데이터를 해시값으로 변환, 로딩   
&nbsp;&nbsp; 3. 멀티 플레이어 시 데이터 동기화(해시값 주기적 변환, 클라이언트와 비교)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}




<br><br><br><br><br>
- - - 

# 잡담,정리
주말에 이번 주 til 정리, 강의 정리 하기
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
