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


<center><H1>  유니티 심화주차 5일 , 개인공부 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 50   
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [o] 디자인 패턴 복습하기  
&nbsp;&nbsp; [o] ui 2회차 듣기      
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

<H2> UI강의 2회차 12/26 </H2> 

# UGUI - Event System
canvas의 Graphic Raycaster 컴포넌트가 UI 요소에서 광선으로 터치 등의 이벤트를 알림  
EventSystem은 어떤 이벤트인지를 UI 요소에게 광선으로 알려주어서 반응하게 함  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/231f07bd-af4f-4cf5-9887-52b288b5f5e1){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

사용할 UI들 프리팹으로 만들어서 사용  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2850566c-2816-452a-b036-cc289de64adf){:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>
- - - 

# TMP
**TMP설정**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/70b04e23-3a5c-43b5-bf97-3aad20cafa50){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**material 만들고 적용하기 Material preset -> outline Red**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/506ab4d4-8566-4179-a9e0-0739d666e722){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>
- - - 

# DynamicUI

## Layout

**Vertical Layout Group**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/cccd2da1-feb3-4ac6-b78b-2d7ba573f822){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

|프로퍼티|기능|
|:---:|---|
|Padding|	레이아웃 그룹 에지의 패딩입니다.|
|Spacing|	레이아웃 요소 간의 간격입니다.|
|Child Alignment|	사용 가능한 공간을 모두 채우지 않을 경우 자식 레이아웃 요소에 사용할 얼라인먼트입니다.|
|Child Controls Size|	레이아웃 그룹이 자식의 너비와 높이를 제어할지 여부입니다.|
|Child Force Expand|	추가로 사용할 수 있는 공간을 채우기 위해 자식 레이아웃을 강제로 확장할지 여부입니다.|

<br><br>

**Horizomtal Layout Group**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/13e45ba5-70d5-4ea8-8773-e1a364430e90){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

|프로퍼티|기능|
|:---:|---|
|Padding|	레이아웃 그룹 에지의 패딩입니다.|
|Spacing|	레이아웃 요소 간의 간격입니다.|
|Child Alignment|	사용 가능한 공간을 모두 채우지 않을 경우 자식 레이아웃 요소에 사용할 얼라인먼트입니다.|
|Control Child Size|	레이아웃 그룹이 자식 레이아웃 요소의 너비와 높이를 제어할지 여부를 결정합니다.|
|Use Child Scale|	요소의 크기를 지정하거나 요소를 배치할 때 레이아웃 그룹이 해당 자식 레이아웃 요소의 스케일을 고려할지 여부를 결정합니다. Width 및 Height는 각 자식 레이아웃 요소의 Rect Transform 컴포넌트에 있는 Scale > X 및 Scale > Y 값에 해당합니다.|
|Child Force Expand|	추가로 사용할 수 있는 공간을 채우기 위해 자식 레이아웃 요소를 강제로 확장할지 여부를 결정합니다.|

<br><br>

**Grid Layout Group**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1ca57c17-8e77-499f-b35f-63700e6fd04a){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

|프로퍼티|기능|
|:---:|---|
|Padding|	레이아웃 그룹 에지의 패딩입니다.|
|Cell Size|	그룹의 각 레이아웃 요소가 사용할 크기입니다.|
|Spacing|	레이아웃 요소 간의 간격입니다.|
|Start Corner|	첫 요소가 위치하는 코너입니다.|
|Start Axis|	요소를 따라 배치할 주축을 지정합니다. 수평축으로 하면 새 행을 시작하기 이전 행을 전부 채웁니다. 수직축으로 하면 새 열을 시작하기 이전 열을 전부 채웁니다.|
|Child Alignment|	레이아웃 요소가 사용 가능한 공간을 전부 사용하지 않는 경우, 사용할 얼라인먼 방식입니다.|
|Constraint|	자동 레이아웃 시스템을 지원하기 위해 격자 무늬의 행렬 수를 제한합니다.|

<br><br>

## Size Fillter
**Content Size Fillter**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6bd53850-362d-4668-8eb3-f311266b959a){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**Horizontal Fit	너비 제어 방법입니다.**  
**Vertical Fit	높이 제어 방법입니다.**  

|프로퍼티|기능|
|:---:|---|
|Unconstrained|	레이아웃 요소에 기반하여 너비를 조정하지 않습니다.|
|Min Size|	레이아웃 요소의 최소 너비에 기반하여 너비를 조정합니다.|
|Preferred Size	|레이아웃 요소의 기본 너비에 기반하여 너비를 조정합니다.|

<br><br>

**Layout Element**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/0bf79f0b-fb74-4c11-88d4-36d70c528663){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
Layout Element 체크 -> transform 다시지정
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

|프로퍼티|기능|
|:---:|---|
|Ignore Layout|	활성화하면 레이아웃 시스템이 이 레이아웃 요소를 무시합니다.|
|Min Width|	이 레이아웃 요소의 최소 너비입니다.|
|Min Height|	이 레이아웃 요소의 최소 높이입니다.|
|Preferred Width|	추가 가용 너비가 할당되기 전에 이 레이아웃 요소의 선호 너비입니다.|
|Preferred Height|	추가 가용 높이가 할당되기 전에 이 레이아웃 요소의 선호 높이입니다.|
|Flexible Width|	레이아웃 요소가 형제 레이아웃에 상대적으로 채워야 하는 (추가 사용 가능한)너비의 상대적 크기입니다.|
|Flexible Height	|레이아웃 요소가 형제 레이아웃에 상대적으로 채워야 하는 (추가 사용 가능한)높이의 상대적 크기입니다.|
|Layout Priority|	이 컴포넌트에 대한 레이아웃 우선 순위입니다.

<br><br>

**Layout Priority**  
게임 오브젝트에 레이아웃 프로퍼티가 있는 컴포넌트가 두 개 이상(예: Image 컴포넌트와 LayoutElement| 컴포넌트) 있으면 레이아웃 시스템은 Layout Priority가 가장 높은 컴포넌트의 프로퍼티 값을 사용합니다.  
컴포넌트에 동일한 Layout Priority가 있으면 레이아웃 시스템은 어느 컴포넌트에서 왔든 상관없이 각 프로퍼티에 대한 가장 높은 값을 사용합니다.

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
