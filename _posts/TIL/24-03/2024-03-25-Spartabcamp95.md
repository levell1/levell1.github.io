---
title:  "[TIL] 95 FSM 강의, 빌드관련 ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-03-25 02:00

---
- - -


<BR><BR>

<center><H1>  이력서 진행중, 강의듣기, </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53       
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기. 진행중  
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기. 책사기  
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 취업 설명회

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br>

# FSM 공격(콤보어택)

## SO
![image](https://github.com/levell1/levell1.github.io/assets/96651722/0cac61fd-7c36-490b-8b6e-f02cc302c5de){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
이름, 인덱스, 다음공격시간, 힘을받는때, 힘, 데미지  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

## Animation
![image](https://github.com/levell1/levell1.github.io/assets/96651722/c64c4f16-a8b8-4b1d-9ffe-97c1b0564c9f){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

## Animation
플레이어의 공격 타격안되는 부분 수정.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  
<br><br><br><br><br>
- - - 

# 적구현
적 SO, StatMachine, Animator 필요.   
거리안에 들어오면 플레이어에게 이동, 가까우면 공격상태,  
Idle, Chsing, Attack 상태  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br><br>
- - - 


# 게임 빌드 프로세스
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b3e8c541-0352-411c-9d50-2ace72595733){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

## 윈도우
1. 'File' > 'Build Settings'로 이동합니다.
2. 'Platform' 목록에서 'Windows'를 선택하고, 'Switch Platform'을 클릭합니다.
3. 원하는 씬을 'Scenes in Build' 목록에 추가합니다.
4. 'Player Settings'에서 게임의 설정을 변경할 수 있습니다. (예: 회사 이름, 게임 아이콘 등)
5. 'Build' 버튼을 클릭하여 빌드를 시작합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}

<br><br>

### Player Settings
    
> **General**
> - Company Name: 회사 이름을 입력하세요. 이 정보는 게임의 메타데이터에 저장됩니다.
> - Product Name: 게임의 이름을 입력하세요.
> - Version: 게임의 버전을 입력하세요.
> - Default Icon: 게임의 아이콘을 설정합니다. 해당 아이콘은 게임 실행 파일에 사용됩니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> **Resolution and Presentation**
> - Default Screen Width, Default Screen Height: 게임이 처음 실행될 때의 기본 화면 너비와 높이를 설정합니다.
> - Fullscreen Mode: 게임이 전체화면으로 실행될지, 창 모드로 실행될지를 결정합니다.
> - Visible in Background: 이 옵션은 창이 백그라운드에 있을 때 게임이 보일지 여부를 결정합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> **Icon**
> - 여기서 게임의 아이콘을 더욱 자세히 설정할 수 있습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

## 안드로이드
**1 2 3** 윈도우와 동일
4. 'Player Settings'에서 게임의 설정을 변경할 수 있습니다. (예: 회사 이름, 게임 아이콘, 번들 식별자 등)
5. 'Minimum API Level'과 'Target API Level'을 적절하게 설정합니다.
6. 'Build' 버튼을 클릭하여 빌드를 시작합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"} 

<br><br>

### 유의사항
> - Android 빌드를 위해서는 JDK와 Android SDK가 필요합니다.
> - 빌드 과정에서 발생할 수 있는 문제들, 예를 들면 플러그인 호환성 이슈, API 레벨 문제 등을 확인해야 합니다.
> - Android는 다양한 해상도와 기기를 지원하기 때문에, 이를 고려한 UI/UX 디자인이 필요합니다.
> - 안드로이드의 다양한 OS 버전과 호환성을 확보해야 합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

### Player Settings
    
> **General**
> - Company Name, Product Name, Version: 위의 Windows 설정과 동일합니다.
> - Bundle Identifier: 앱의 고유 식별자입니다. 보통 "com.CompanyName.GameName" 형식으로 작성됩니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> **Icon**
> - Default Icon: 게임의 아이콘을 설정합니다. 해당 아이콘은 안드로이드 앱 아이콘으로 사용됩니다.
> - Adaptive Icons: Android 8.0 이상에서 사용되는 적응형 아이콘을 설정할 수 있습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> **Resolution and Presentation**
> - Default Orientation: 게임이 시작될 때의 화면 방향을 설정합니다.
> - Auto Rotation: 화면이 자동으로 회전하는지 여부를 설정합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> **Other Settings**
> - Minimum API Level: 앱이 지원하는 최소 안드로이드 버전을 설정합니다.
> - Target API Level: 앱이 대상으로 하는 안드로이드 버전을 설정합니다. 최신 버전을 사용하는 것이 좋습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br><br>
- - - 

# 잡담, 일기?
서버관련 취업 설명회 듣기.
FSM 강의 듣기(공격), 적구현, 프로젝트 빌드 관련 내용
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
