---
title:  "[TIL] 80 3D 최적화 컬링, 오쿨루전 컬링, LOD그룹 ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-15 02:00

---
- - -

`Light` `Camera` `Occlusion Culling` `LOD`  

<BR><BR>

<center><H1>  최종 팀 프로젝트 22일차  </H1></center>

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

# 3D 최적화에 관하여
> - 코드최적화? -> 하면 할수록 명확하다.  
> - 렌더링 최적화 - 난이도가 높아 실력자가 한다.  
> - 최적화할때는 프로파일링을 겸해서 성능이 좋아지는지 확인 필요.  
> - 포폴에 이런 최적화 기법이 있어서 써보니 성능이 좋아졌다. 이런식으로 하면 가장 좋은데 어려움  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**Stats창**  
> Stats의 상태가 빌드했을 때의 상태는 아님  
> 에디터가 돌아가는 동작까지 포함시키는 것  
> 씬 탭을 끄면 프레임이 올라감  
> 체크 모드로 빌드하면 상단에 프레임이 뜸  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br>

## Light
> **빛 Light**  
> - realtime mixed bake  
> - realtime을 쓰면 ->  계산량이 많다. 광원 계산 - 성능부하  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/0b830e78-2d8e-441b-9b25-cd87df2d100d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - Generate Lighting 보다 실제로 라이트 세팅 에셋을 만들어서 개발자가 세팅해주는 작업이 필요.
> - 라이트맵 세팅이 가장 중요한데 오래 걸림 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 카메라
> **Camera세팅**  
> ![image](https://github.com/levell1/levell1.github.io/assets/96651722/58827e61-9883-4068-8390-3d5cd281bcd0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> -Far Clip Plane을 줄임 -> 컬링
> - Far Clip Plane: 180 -> 평균
> - Lighting - Other Settings - Fog 선택 - 
> - Texture도 넣어서 디테일하게 안개가 낀 것 처럼 보일 수 있음
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/104c7242-def9-415b-815c-539279dfc50b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> **volume settings**  
> ![image](https://github.com/levell1/levell1.github.io/assets/96651722/f608b2f5-a2d3-423a-95ae-ecb996446614){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 버츄얼 카메라 add ~~extension -> 많은 효과들이 있다.  
> - Main Camera - PostProcessing 체크해야 가능  
> - Cinemachine Volume Settings  
> - Depth Of Field : 뒤에 있는 것을 흐리게 할 수 있음  
> - 많은 효과들을 주면 배칭이 높아질 수 있다, 잘 섞어서 사용해야된다.  패키지 에서 포스트 프로세싱 적용 생각해보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## Occlusion Culling
> **오클루전 컬링(Occlusion Culling)**  
> - 카메라 범위에 들어가긴 하는데 안 보이는 애들은 렌더링하지 않는(배치에 안들어가게 하는) 기법  
> - -> gpu 의 부하를 줄이고 건물들을 판단하는데 cpu의 부하가 생긴다.  
> - 오클루더(Occluder) 앞에 가리는 건물  
> - 오클루디(Occludee) 뒤에 사라진 건물  
> - 오클루더가 쉐이더면 뒤에건물이 가려지지 않는다. (조심) 성능 저하
> - 인스펙터창 스테틱 오른쪽 화살표 오쿨루더 오쿨루디가 있다.(둘 다 선택도 가능함)  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/42700e68-9775-46a5-88e5-d22f3bfae65e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 오클루젼에서 옵션들 설정해서 Bake
> - 바라보지 않으면 렌더링을 하지 않는다.
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/281ec09b-4f99-471c-8593-6037d80add4b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 미로같은맵 오클루션 컬링을 유도할 수도 있다
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## LOD
> **LOD Group**  
> - **컴포넌트로 LOD 그룹 추가**
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/48c90f72-e6f8-4880-8ebd-a508292e8550){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 여러개 오브젝트 만들어서 카메라의 거리에 따라 보이는 오브젝트가 달라진다.
> - 거리설정가능, 멀수록 랜더링을 덜하게 한다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


## Materials - Gpu instancing
똑같은 materials에 ebable gpu instancing 을 하면 한번에 그린다.
묶어서 한번에 그린다.
<br><br><br><br><br>
- - - 

# 잡담,정리
`Light` `Camera` `Occlusion Culling` `LOD`  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
