---
title:  "[TIL] 22 Unity 개인과제(TopDown) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-28 02:00

---
- - -


<BR><BR>



<center><H1>  개인공부, 유니티 4일차 개인과제 </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제   28   
&nbsp;&nbsp; [o] 개인과제   
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 과제 
Unity 를 이용해 게더를 모방해 만드는 과제입니다.  
타일맵을 이용해 배경을 꾸밉니다.  
기본 UI 들을 활용해 적용하는 연습이 포함됩니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**개인 과제**  
&nbsp;1. 캐릭터 만들기  
&nbsp;2. 캐릭터 이동  
&nbsp;3. 맵 만들기 튜터님   
&nbsp;4. 카메라 따라가기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**추가 과제**  
&nbsp;1. 캐릭터 애니메이션 추가  
&nbsp;2. 이름 입력 시스템  
&nbsp;3. 캐릭터 선택 시스템  
&nbsp;4. 참석 인원 UI  
&nbsp;5. 인게임 캐릭터 선택  
&nbsp;6. 인게임 이름 바꾸기  
&nbsp;7. 시간 표시  
&nbsp;8. NPC 대화  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br>

## 1. 필수요구사항

### 1. 캐릭터 만들기

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ee0f198c-ae48-4d35-831c-505af0be8897){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
1.&nbsp;zep 캡쳐해서 만든 캐릭터  
2.&nbsp;국민님이 만들어주심 PostIT  

### 2. 캐릭터 이동
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a53f3c28-6179-4617-ba98-e69b47c930ae){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
방향키, WASD 움직임

### 3. 맵
![image](https://github.com/levell1/levell1.github.io/assets/96651722/fc62bf47-ca43-41e7-9879-19aaaa018971){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

### 4. 카메라 따라가기
Player 에 MainCamera 넣어서 따라가기하기  
-> 다른방법 사용해보기  
요구사항 다 하고 해볼려고 했지만 못했다.
-> player 1, 2 나눠서 메인카메라가 있어 이상한점이 있다. 확인해보기.  

<br><br><br><br><br>
- - - 

## 2. 선택요구사항

### 1. 캐릭터 애니메이션 추가  
하는법이 기억이 나질 않아 조금 시간이 걸렸다.  
1. 애니메이션 만들기.   
2. 만든 애니메이션 sprite에 추가 하기  -> Animator 생성됨  
3. animator 에서 parameter, Code를 이용해 애니메이션 전환  

### 2. 이름 입력 시스템  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f3fc8791-d22c-4bb7-9bab-3100bbcfbbe9){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   
3자 ~ 10자 

<div class="notice--primary" markdown="1"> 

```c#
 if (4 > ChangeArea.text.Length || ChangeArea.text.Length > 10) 
 {
     JoinButton.interactable = false;
 }else 
 {
     JoinButton.interactable = true;
 }
```
</div>

### 3. 캐릭터 선택 시스템  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ee0f198c-ae48-4d35-831c-505af0be8897){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
선택시 값을 저장 후 다음씬에서 선택된 player setactive true

### 4. 참석 인원 UI  
UI만 생성

### 5. 인게임 캐릭터 선택  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f32607d5-3a98-4a10-af1a-24c1328cb101){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
캐릭터 선택시 라벨 활성화, 라벨에 버튼으로된 캐릭터 클릭시 PLAYER 1,2 활성화
-> 문제가 있음.

### 6. 인게임 이름 바꾸기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f0203763-d822-4707-b585-0dc98252fc9e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
이름바꿀때 wasd로 움직이는 문제발생 라벨이 false면 실행
<div class="notice--primary" markdown="1"> 

```c#
public void OnMove(InputValue value) // w  a  s d
{
    if (!Label1.activeSelf)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}
```
</div>

### 7. 시간 표시  
시간표시

<div class="notice--primary" markdown="1"> 

```c#
private void Update()
    {
        DateTime currentTime = DateTime.Now;
        TimeSpan time = DateTime.Now.TimeOfDay;
        _timeTxt.text = $"{time.Hours} : {time.Minutes}";
    }

```
</div>
    
### 8. NPC 대화  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5c6eb70a-7c0f-4333-bf77-611dba089794){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e59c101b-028f-4384-b487-7c192b3f9f91){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
CircleCollider로 ontrigger enger, exit 로 대화 활성화 , 비활성화.

<br><br><br><br><br>
- - - 


# 정리, 잡담

**씬옮기면서 데이터 관리는 싱글톤으로**  
1씬에서 2씬으로 넘어갈 때 데이터 옮기는 방법에 대해 많은 고민을 했다.  
지금 코드는 playerprefs로 데이터를 저장하고 불러오는 방식인데 다음엔 싱글톤을 사용해 봐야겠다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**getcomponent? &nbsp;&nbsp; [SerializeField]?**  
serializefield, public이 내 입장에서 너무 편해서 이걸썻고, getcomponent를 왜 쓰는가에 대해 생각해 봤다.  
이름이 바뀌거나 수정이 있을때 유니티에서 오류가 생긴다, 유니티 로딩이 오래 걸린다.
오늘 수정하면서 많은 오류를 겪었고, 최대한 getcomponent를 사용해 보도록 해야겠다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  



<br><br>
- - - 

[Unity] TIL 22

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
