---
title:  "[TIL] 55 1인개발 강의  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-09 02:00

---
- - -




<BR><BR>

<center><H1>  1인개발 강의  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 다른반 강의 듣기   
&nbsp;&nbsp; [o] 1인 개발자 강의  
&nbsp;&nbsp; [o] 리더 부리더 세션  
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 남은 강의듣기, 디자인 패턴 이해,정리하기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


<H3> 1인개발자 강의 </H3>
퇴근길랠리 - 문홍재님

# 에셋
## UI 작업  
손으로 그리는 UI 시간많이걸림 -> UI. 기본도형의 조합으로 조합을 짜서 구현  
아이콘 - 저작권 없는 아이콘 사용(Noun Project)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 애니메이션 직접 만듬 - 유니티 내장 

## 모델 
복셀 모델과 폴리곤 모델로 구성  
지형은 폴리곤  
캐릭터 자잘한거, 차량은 복셀 모델  
중요한 부분, 은 외부 협력자에게 하는 방법도 좋다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 지형 레벨 디자인 - 만드는 환경을 자체적으로 개발하여 자동생성

## 콘텐츠 아이콘
아이템, 스킬아이콘  
dall.e -> 생성형 인공지능  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 효과음/ 음악
외주 -> 사이브 라이브러리 결제  
효과음 선별시간이 많이 걸림.  
효과음 없고 있고의 차이는 있지만  
효과음의 퀄리티는 크지않다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 저장
실시간으로 동기화되는 백엔드가 필요하다고 판단.  
**Google Firebase**   
생산성과 확장성면 좋다.  
NO SQL/ 클라우드 기반  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
뒤끝?  

<br><br><br><br><br>
- - - 

# 개발 반복 주기

(개발 - 확인) -> (개발 확인) ->....-> 출시  
(개발 - 확인)의 시간.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**실행이 오래걸릴 때**  
유니티 ENTER PLAY MODE 선택사항 -> 실행 화면이 뜰 때 까지의 시간을 향상시켜줌  
정적 필드에 대한 문제를 해결해 줘야 함.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

게임 정적 정의값은 무조건 **EXCEL로 작업**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**씬은 최대한 작게** 
씬 속 오브젝트의개수, 등 가능한 작게.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**프리팹 과 반복주기 향상**  
씬에서 하나만 수정하고싶다 -> 프리팹으로 다른씬으로 옮겨서 작업하면 에디터에서의 시간을 줄일 수 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 데이터/UI 의 관계의 설계
MVC (Model, View, Controller)  

M V C 를 나눠어서 협업  
Model - 데이터  
View - UI  
Controller - 행동  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

경험치 행동은 MODEL 만 고친다 -> MODEL를 기반으로 UI를 수정 한다.  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9c139900-6c53-41f9-bba7-6d1243273084){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
행동 -> MODEL 의 값이 바뀜 -> 바뀌면 해당 객체의 상태 바꿈.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<br><br><br><br><br>
- - - 

# 임의 지점에서 테스트 할 수 있는 환경  
코루틴을 실행하는거로 해결 EX) 3스테이지로 가고싶으면 3스테이지로 가는걸 만들어서 실행  

<br><br>

# 1인 개발 동기부여 
인디라- 정보  

<br><br><br><br><br>
- - - 

# 라이센스 강의
[라이센스](https://levell1.github.io/memo%20unity/MUnity-License/)

<br><br><br><br><br>
- - - 

# 유니티 공식문서 잘 사용하기
공식문서는 원래 어렵다 어렵다고 안본다? X  
이해하고 쓰려고 노력하자  

<br><br><br><br><br>
- - - 

# 잡담,정리
SO 씬을 넘나드는 싱글톤?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
