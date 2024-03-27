---
title:  "[TIL] 88 최적화 글 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-03-04 02:00

---
- - -


<BR><BR>

<center><H1>  최종 팀 프로젝트 30일차  </H1></center>

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

# 게임에 사용된 최적화

## 맵최적화
**RanderTexture → Image**

미니맵에서 RanderTexture로 사용 시 모든 맵을 그리기 때문에 배치수가 1000이상이 증가 되어서 최적화필요.
뒤의 배경은 RanderTexture 대신 이미지 한장으로 배치수 1000 → 2 로 줄었고, 보스, 플레이어 표시하는 오브젝트는 RanderTexture로 실시간으로 하여서 표시.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/34b06880-ccd6-4dea-8558-12d95bcf7528){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

## 컬링
프러스텀 컬링 사용 시야거리 줄이기
-> 부자연스러운 시야 -> 안개를 사용해 자연스러운 연출
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## LOD
몬스터 거리에따라 다른 모습, 보이지않게, 랜더링
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## Sprite Atlas
UI에 사용되는 요소를 Sprite Atlas를 이용하여 배치수를 줄임.  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/0b2da0d3-9095-445c-a707-d987b9dbd9d0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

### 비동기 로드, 오브젝트 풀링
비동기 로드, ObjectPool  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 마을 최적화    
**전**  
![01아무처리도안했을경우](https://github.com/levell1/levell1.github.io/assets/96651722/f94541a1-73d2-4c85-b5f8-df903397e2b7){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**후**  
![06미니맵카메라삭제](https://github.com/levell1/levell1.github.io/assets/96651722/ac9f8dd0-fe4e-473a-b690-fb37f7ebb8b3){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


<br><br><br><br><br>
- - - 

# 잡담,정리
최적화
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
