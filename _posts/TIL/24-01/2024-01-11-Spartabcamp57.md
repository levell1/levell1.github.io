---
title:  "[TIL] 57 강의 자료구조  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-11 02:00

---
- - -


자료구조
수정필요

<BR><BR>

<center><H1>  자료구조, 팀 2일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 다른반 강의 듣기 스탠다드2 챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 디자인 패턴 이해,정리하기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 배열과 연결리스트

## 배열

### 특징, 장단점

**특징**  
&nbsp;&nbsp; 1. 고정된 크기  
&nbsp;&nbsp; 2. 연속된 메모리 할당  
&nbsp;&nbsp; 3. 동일한 데이터 타입  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**장점**  
&nbsp;&nbsp; 1. 빠른 읽기와 쓰기 : 인덱스 사용  
&nbsp;&nbsp; 2. 메모리 효율성 : 연속적 - 캐싱 효율적   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp; 1. 고정된 크기
&nbsp;&nbsp; 2. 낭비되는 메모리 공간
&nbsp;&nbsp; 3. 복잡한 삽입.삭제
&nbsp;&nbsp; 4. 메모리 할당 문제
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning}  

### 게임 개발 활용

**활용 상황**  
&nbsp;&nbsp; 1. 데이터 접근 빈번
&nbsp;&nbsp; 2. 데이터 크기나 요소 수가 고정
&nbsp;&nbsp; 3. 요소 삽입, 삭제가 적을 때
&nbsp;&nbsp; 4. 순차적 접근이 주를 이룰 때
&nbsp;&nbsp; 5. 메모리 사용이 중요한 상황일 때
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

**활용 예시**  
&nbsp;&nbsp; 1. 슬롯이 정해진 인벤토리 - 
&nbsp;&nbsp; 2. 맵 타일 관리
&nbsp;&nbsp; 3. 애니메이션 프레임 관리
&nbsp;&nbsp; 4. 오디오 트랙 관리 - 특정 상황에 오디오를 배열에서 바로 찾아 재생하기 용이
&nbsp;&nbsp; 5. 스킬 및 능력치 시스템
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br><br>

## 연결 리스트

### 특징, 장단점
**특징**  
&nbsp;&nbsp; 1. 노드 기반 구조 : 데이터 , 포인터  
&nbsp;&nbsp; 2. 비연속적 메모리 할당  
&nbsp;&nbsp; 3. 동적 크기 조정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**장점**  
&nbsp;&nbsp; 1. 동적인 메모리 관리  
&nbsp;&nbsp; 2. 데이터 삽입. 삭제 편함   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp; 1. 메모리 오버헤드 : 각 노드가 데이터, 포인터를 저장, 메모리 많이 사용  
&nbsp;&nbsp; 2. 순차 탐색 접근 : 배열과 달리 특정 요소에 접근하기 위해서는 리스트를 순차적으로 탐색해야함.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning}  

### 게임 개발 활용

**활용 상황**  
&nbsp;&nbsp; 1. 데이터가 자주 추가되거나 제거 상황   
&nbsp;&nbsp; 2. 접근하는게 순차적일때    
&nbsp;&nbsp; 3. 크기가 불확실할 때     
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

**활용 예시**  
&nbsp;&nbsp; 1. 동적 인벤토리 시스템  
&nbsp;&nbsp; 2. npc 행동 관리(순차적)  
&nbsp;&nbsp; 3. 레벨 내 동적 객체 관리(맵에서 적, 아이템 장애물 등 추가 제거)  
&nbsp;&nbsp; 4. 멀티플레이어 게임에서 플레이어 관리(접속해제 빈번, 플레이어 관리 용이)  
&nbsp;&nbsp; 5. 타이머 이벤트 관리(시간 순서 이벤트, 예전된 이벤트 실행, 제거에 편리)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br><br><br><br><br>
- - - 

# 스택과 큐

## 스택

### 특징, 장단점
PUSH, POP  

**특징**  
&nbsp;&nbsp; 1. LIFO(Last in First Out)  
&nbsp;&nbsp; 2. 간단한 연산 (push,pop)  
&nbsp;&nbsp; 3. 빠른 연산 속도  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**장점**  
&nbsp;&nbsp; 1. 단순한 구조  
&nbsp;&nbsp; 2. 데이터 순서 유지  
&nbsp;&nbsp; 3. 고정된 메모리 사용  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp; 1. 유연성 부족 : 중간요소에 접근, 수정 어려움  
&nbsp;&nbsp; 2. 메모리 제한 : 스택크기 고정되어 있을 경우 , 메모리 용량 초과 -> 오버플로우   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning}  

### 게임 개발 활용

**활용 상황**  
&nbsp;&nbsp; 1. 역순 처리가 필요한 상황   
&nbsp;&nbsp; 2. 임시 데이터 저장할 때     
&nbsp;&nbsp; 3. 재귀적 구조를 처리할 때  
&nbsp;&nbsp; 4. UI 관리할 때도 적합함  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

**활용 예시**  
&nbsp;&nbsp; 1. 되돌리기   
&nbsp;&nbsp; 2. 대화 시스템 . 탐색지, 이전대화로 복귀  
&nbsp;&nbsp; 3. 이벤트 처리 - 순차적으로 처리될 경우  
&nbsp;&nbsp; 4. 재귀적 탐색 - 복잡한 퍼즐,재귀적으로 해결 경로를 찾을 때, 각 단계 스택에 저장    
&nbsp;&nbsp; 5. 메뉴 시스템 - 다양한 메뉴가 중첩적으로 열릴 때 , 각 메뉴의 상태가 스택에 저장, 이전메뉴로 돌아감  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 


<br><br>

## 큐

### 특징, 장단점
PUSH, POP  

**특징**  
&nbsp;&nbsp; 1. FIFO(First In, First Out)  
&nbsp;&nbsp; 2. 순차적 처리  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**장점**  
&nbsp;&nbsp; 1. 직관적인 구조  
&nbsp;&nbsp; 2. 데이터 처리에 공정함  
&nbsp;&nbsp; 3. 자원 관리에 유용함(cpu 스케쥴링, 네트워크 요청)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp; 1. 유연성 부족 : 중간요소에 접근, 수정 어려움  
&nbsp;&nbsp; 2. 메모리 제한 : 스택크기 고정되어 있을 경우 , 메모리 용량 초과 -> 오버플로우   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning}  

### 게임 개발 활용

**활용 상황**  
&nbsp;&nbsp; 1. 역순 처리가 필요한 상황   
&nbsp;&nbsp; 2. 임시 데이터 저장할 때     
&nbsp;&nbsp; 3. 재귀적 구조를 처리할 때  
&nbsp;&nbsp; 4. UI 관리할 때도 적합함  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

**활용 예시**  
&nbsp;&nbsp; 1. 되돌리기   
&nbsp;&nbsp; 2. 대화 시스템 . 탐색지, 이전대화로 복귀  
&nbsp;&nbsp; 3. 이벤트 처리 - 순차적으로 처리될 경우  
&nbsp;&nbsp; 4. 재귀적 탐색 - 복잡한 퍼즐,재귀적으로 해결 경로를 찾을 때, 각 단계 스택에 저장    
&nbsp;&nbsp; 5. 메뉴 시스템 - 다양한 메뉴가 중첩적으로 열릴 때 , 각 메뉴의 상태가 스택에 저장, 이전메뉴로 돌아감  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 


특징


장점

단점
낮은 유연성 : 중간에 위치한 요소에 직접접근 어려움.

예시
순차적인 이벤트나 행동 처리
공유 자원을 순차적으로 관리
멀티 플레이어 동기화가 필요한 상황
비동기 작업 관리

활용 예시
입력 이벤트 처리
캐릭터 동작 대기열
ai 명령 처리
네트워크 메시지 처리
리소스 로딩 관리

<br><br><br><br><br>
- - - 

# 트리 구조

특징 
정렬, 검색이 쉽다. db관리에 많이 사용
루트 노드, 부모/자식 노드
깊이와 높이

장점
계층적 구조 : 파일 시스템
효율적인 검색 및 정렬 : 이진 탐색 트리
동적인 구조 : 노드 추가/ 제거가 쉬움
효율적인 데이터 관리 : 데이터 베이스 시스템에 적합

단점
?
?

이진 탐색 트리(BST)
왼쪽노드는 작은 값, 오른쪽 노드는 큰 값
최대 두개의 자식 노드
데이터 정렬된 상태로 저장, 빠른 검색, 삽입, 삭제가 필요할 때
현업에서 별로 잘 안쓴다. 불균형하게 될 가능성이 높다. AVL, 레드블랙트리 많이 사용

AVL, 레드 블랙트리 - 자동으로 균형을 맞춰준다.

AVL 균형맞출 때 계산량이 많다 -> 랭킹검색
레드 블랙트리 업데이트 자주 있을 때 잦은캐릭터 정보 변화 

힙 완전 이진트리
최소힙
TOP =최소값

최대힙 TOP = 최대값

서버 개발자 
B--, B++ 트리 대량의 데이터를 관리하는데 적합한 구조

클라이언트 개발자
옥트리, 쿼드트리
2D,3D 공간을 분할하고, 렌더링, 물리 시뮬레이션 등의 최적화에 사용됨.


<br><br><br><br><br>
- - - 

# 그래프

특징
노드와 간선
방향성
간선마다 가중치

장점

단점

활용 상황
탐색 그래프
게임 세계의 특정 위치나 지역을 노드가 나타내고,
간선은 위치 간의 이동 가능한 경로를 나타냄
네비게이션 그래프

상호작용 그래프


활용 예시
경로 찾기
캐릭터 행동 제어
NPC와의 관계 모델링
오픈 월드 지도 설계

<br><br><br><br><br>
- - - 

# 해시 테이블 - Dictionary

특징
해시 함수: 키, 해시테이블의 주소로 변환
key, value 쌍 구조  
해시충돌 두개이상의 같은 해시 값을 가질 때 충돌이 발생함, 해결하기 위한 여러 방법이 존재함

장점
빠른 검색 속도, 0(1)
데이터의 삽입과 삭제도 빠름
직관적인 키- 값
데이터 확장성이 뛰어남


단점
해시 충돌로 인한 성능 저하
해시 테이블은 순서가 없음
좋은 해시 함수의 필요성

활용 상황
대량 데이터를 빠르게 접근, 수정해야할 때
리소스를 관리할 때
서버와 클라이언트 간에 데이터를 주고받을 때 데이터의 무결성을 보장받아야할 때
게임 내에서 중요한 정보를 암호화 할 때
무작위 수를 생성할 때

아이템 관리
리소스 관리
멀티플레이어 시 데이터 동기화

<br><br><br><br><br>
- - - 

# 잡담,정리
자료구조는 기본이며 개발실력에 큰 부분.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
