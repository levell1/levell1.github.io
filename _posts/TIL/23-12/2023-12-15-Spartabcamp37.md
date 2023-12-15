---
title:  "[TIL] 37 3D 강의, UI  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-15 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 8일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 45  
&nbsp;&nbsp; [o] 강의 듣기 - 22강~  
&nbsp;&nbsp; [o] 강의 듣기 - UI강의~  
&nbsp;&nbsp; [o] 강의 듣기 - 2반강의~  
&nbsp;&nbsp; [X] 다른반 강의 듣기    
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 3D강의정리
AnimationCurve  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<details>
<summary>DayNightCycle.cs</summary>

<div class="notice--primary" markdown="1"> 

```c#

```

</div>
</details>


<br><br><br><br><br>
- - - 


# 2. UI강의
플레이어가 게임을 할 때 원활하게 플레이 할 수 있도록 설계하는 것  
게임UI : 몰입성 , 상황을 빠르게 이해, 화면중앙에 집중되게 심플한 디자인  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

## UI 체크사항  
> - 게임을 이해할 수 있도록 디자인
> - 적절한 방법, 명확한 안내  
> - 가이드, 튜토리얼 이해쉽게, 건너뛰기
> - 시각효과를 사용해 보상, 인앱 구매 눈에 띄게  
> - UI는 단순하게 복잡X 
> - 계층구조, 중요부분 표시 명확한 안내  
> - 사이드바 제공, 공간 확장  
> - 반응형 UI  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br>

## Mesh
작동원리  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/dc56588f-ed68-4fc0-80ab-42d6b065ad20){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/3f99e633-ed9f-4d15-9daf-10cc6119f115){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<br><br>

## DrawCall
계속 변하는 UI는 매번 CPU에서 연산 후 GPU로 넘기는 구조  
DRAWCALL = 화면에 그려줘~  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8e4a34f2-968c-4d03-9b2c-a41200e34908){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

## UGUI
> - Grapgics.cs : 그래픽적 요소를 가지고 있는 클래스(Image 등) 관리
> - Canvas.cpp : 그래픽적 요소를 가지고 있는 것을 하나의 버퍼로 만들어서 GPU에 할당  
Canvas 하위에 UI요소가 갱신되면 전체 Canvas를 갱신해야 함  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br>

## Canvas  
ui 생성시 Canvas 자동생성  
Canvas(도화지)  3D좌표상의 위치가 아닌 유저에게 보여지는 스크린에 대응하는  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/13442448-dd4f-4cf1-a1de-c1f156e43bfd){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br>

### `Rect TransForm` 
TransForm을 상속받은(불변)  (RENDER MODE - WORLD 면 수정가능)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

#### Anchors  
UI Elemnet 원점을 세팅하는 기준  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/489d44fa-b791-40e1-a8e5-d19ad8a9afb7){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**앵커값 기준으로 pos x ,y 가 정해진다.**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ad27f01e-a9cf-43b4-8a50-f73b92c06762){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**앵커 min,max 다를 때**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/61f1675e-6095-4db3-afe8-2ace4d7d38a3){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


#### Pivot
UI Elemnet 내부 기준점을 세팅하는 기준
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a245baa1-23ac-4a3d-9fa4-c0713cac0a4e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5e206030-dd0f-4e8c-8daa-088df6a7d663){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

### CanvasScale
####  Render Mode 
overlay -> 캔버스가 모든 오브젝트보다 앞에 그려진다
Cmara : 카메라 시점으로 캔버스가 보일 수 있다.
world : 오브젝트처럼 배치
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


#### Canvas Scaler(반응형으로) 
Scale Mode : Scale With Screen Size  
Reference Resolution 1920 1080  
#### Screen Math Mode
Match Width Or Height : 해상도 변화 시 넓이 또는 높이를 변경x
Expand : Reference Resolution 보다 작게 안만든다.




<br><br><br><br><br>
- - - 


# 3. 2반강의
## 데이터 저장
Serializable 직렬화 -> byte 배열로 만들 수 있는 형태?  
Serializable을 달면 직렬화 가능해진다.  

### 1)Playerprefs
문자열 실수 정수 값을 플랫폼 레지스트리에 저장할 수 있다.  
암호화x 민감한 데이터를 저장하는데 적합하지 않다.  

<div class="notice--primary" markdown="1"> 

```c#

```

</div>

### 2)CSV
CSV(Comma-Separated Values) 
각줄이 하나의 데이터 레코드를 나타낸다.

**예제**  
필요 정보를 ,를 구분하여 묶고 불러올때 같이 불러 오는 방법  

<div class="notice--primary" markdown="1"> 

```c#

```
</div>

<div class="notice--primary" markdown="1"> 

```c#

```

</div>

### 3)JSON
JSON(JavaScript Object Notation) 경량 데이터 교환 형식.  
json에는 csv와 달리 하나의 속성에 여러개의 값이 들어갈 수 있다.  
사람 기계 모두에게 읽기 쉽고 쓰기 쉬운 형식  

<div class="notice--primary" markdown="1"> 

```c#

```

</div>

### 4)ScriptableObject
유니티 엔진에서 사용되는 데이터 컨테이너.  
게임 오브젝트나 씬에 종속되지 않고 데이터를 저장, 공유 가능.  
리소스, 설정, 상태 등을 관리하는 데 사용   
유니티에 사용하는 요소(sprite, prefabs)등 을 저장 할 수 있다.  


**사용 시 주의점**  
에디터 사용 시 so 에 저장하는 작업는 편집, 런타임에 가능    
베포된 빌드에서는 so를 사용해 저장x, 개발 시 설정한 so 에셋의 저장된 데이터를 사용o  
-> 수정은 에디터에서만 가능 -> 플레이 중 수정되는 정보는 so로 사용하면 안된다.  
<div class="notice--primary" markdown="1"> 

```c#

```

</div>


### 5)Binary Formatter
데이터를 효율적으로 관리 공유  
데이터의 구조수정 x ex) 능력치 추가x  


### 메소드/ 프로퍼티
데이터 저장에 많이 쓰이는 메소드/프로퍼티
Application.persistentDataPath
File.Exists
File.ReadAllTEXT
File.WriteAllTEXT

**각각의 용도**
so - 값을 읽기만하는 데이터들   
csv, son - 읽고 쓰기 가능 한 데이터들  
Binary Formatter - 성능이 가장좋다. but 데이터 구조수정x  

**정리표**
img

**로컬(디바이스)**에 저장하는 방식  
개인이 수정이 가능해진다. -> 버그판이 나온다.  
서버에 저장하는것이 정답.


<br><br><br><br><br>
- - - 

# 잡담,정리
so - 값을 읽기만하는 데이터들   
csv, son - 읽고 쓰기 가능 한 데이터들  
Binary Formatter - 성능이 가장좋다. but 데이터 구조수정x  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ddf61c14-d050-4e3d-bb2c-d67547f47b14){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
