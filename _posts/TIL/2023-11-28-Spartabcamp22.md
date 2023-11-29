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

**`과제`**  
Unity 를 이용해 게더를 모방해 만드는 과제입니다.  
타일맵을 이용해 배경을 꾸밉니다.  
기본 UI 들을 활용해 적용하는 연습이 포함됩니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

> **`필수 과제`**  
> 1. 캐릭터 만들기  
> 2. 캐릭터 이동  
> 3. 맵 만들기 튜터님   
> 4. 카메라 따라가기  


> **`추가 과제`**  
> 1. 캐릭터 애니메이션 추가  
> 2. 이름 입력 시스템  
> 3. 캐릭터 선택 시스템  
> 4. 참석 인원 UI  
> 5. 인게임 캐릭터 선택  
> 6. 인게임 이름 바꾸기  
> 7. 시간 표시  
> 8. NPC 대화  


<br><br>

# 1. 필수요구사항

## 1. 캐릭터 만들기

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ee0f198c-ae48-4d35-831c-505af0be8897)  
1.&nbsp;zep 캡쳐해서 만든 캐릭터  
2.&nbsp;국민님이 만들어주신 PostIT  

<br><br>

## 2. 캐릭터 이동
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a53f3c28-6179-4617-ba98-e69b47c930ae)  
방향키, WASD 움직임

<br><br>

## 3. 맵
![image](https://github.com/levell1/levell1.github.io/assets/96651722/fc62bf47-ca43-41e7-9879-19aaaa018971)

<br><br>

## 4. 카메라 따라가기
Player 에 MainCamera 넣어서 따라가기하기  
-> 다른방법 사용해보기  오늘 개선해보기.  
-> player 1, 2 나눠서 메인카메라가 있어 이상한점이 있다. 개선사항.   

<br><br><br><br><br>
- - - 

# 2. 선택요구사항

## 1. 캐릭터 애니메이션 추가  
하는법이 기억이 나질 않아 조금 시간이 걸렸다.  
1. 애니메이션 만들기. (IDLE)  
2. 만든 애니메이션 sprite에 추가 하기  -> Animator 생성됨  
3. animator 에서 parameter, Code를 이용해 애니메이션 전환  

<div class="notice--primary" markdown="1"> 

```c#
public class zepAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMove(InputValue value) // w  a  s d
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        animator.SetBool("Iswalk", moveInput != Vector2.zero);
    }
}
```
</div>

<br><br>

## 2. 이름 입력 시스템  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f3fc8791-d22c-4bb7-9bab-3100bbcfbbe9)  
글자 수 제한 3자 ~ 10자 

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

<br><br>

## 3. 캐릭터 선택 시스템  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ee0f198c-ae48-4d35-831c-505af0be8897)  
선택시 값을 저장 후 다음씬에서 선택된 player setactive true
지금 저장은 PlayerPrefebs로 사용중 -> 싱글톤,GameManager을 이용해서 개선해보기.  
<br><br>

## 4. 참석 인원 UI  
UI만 생성  
Manager 오브젝트에 npc들 생성후 추가해보기  
 transform.childCount , transform.GetChild(번호) 사용해보기  
 목록에 text는 어떻게 추가?  
<br><br>

## 5. 인게임 캐릭터 선택  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f32607d5-3a98-4a10-af1a-24c1328cb101)  
캐릭터 선택시 라벨 활성화, 라벨에 버튼으로된 캐릭터 클릭시 PLAYER 1,2 활성화
-> PLAYER을 두개를 만들지말고 하나의 플레이어안에 두 스프라이트로 조건만족시 1의 스프라이트, 애니메이션 적용 하는 방식으로 개선해보기.

<br><br>

## 6. 인게임 이름 바꾸기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f0203763-d822-4707-b585-0dc98252fc9e)  
이름바꿀때 wasd로 움직이는 문제발생 라벨이 false조건으로 실행
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

## 7. 시간 표시  
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
    
## 8. NPC 대화  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5c6eb70a-7c0f-4333-bf77-611dba089794)    
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e59c101b-028f-4384-b487-7c192b3f9f91)  
CircleCollider로 ontrigger enger, exit 로 대화 활성화 , 비활성화.

<br><br><br><br><br>
- - - 


# 정리

**씬옮기면서 데이터 관리는 싱글톤으로**  
1씬에서 2씬으로 넘어갈 때 데이터 옮기는 방법에 대해 많은 고민을 했다.  
지금 코드는 playerprefs로 데이터를 저장하고 불러오는 방식인데 다음엔 싱글톤을 사용해 봐야겠다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**GameManager 개선**  
1번째 씬에서 GameManager를 생성하고  
2번째 씬에서 gamemanager에 필요한 오브젝트를 넣어주는 방식을 사용하였다.
SceneSetting이라는 오브젝트,스크립트를 만들고 awake에서 gamemanager에 접근
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f769c403-1106-4678-9fcb-890aae481220)
<div class="notice--primary" markdown="1"> 

```c#
public class SceneSetting : MonoBehaviour
{
    [SerializeField] private GameObject zep;
    [SerializeField] private GameObject postit;
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.Instance.zep = zep;
        GameManager.Instance.postit = postit;
    }

}
```
</div>

지금상황의 개선이고 처음부터 더 좋은 방법이 있다고 하였다. 좀 더 생각해보기.

**getcomponent? &nbsp;&nbsp; [SerializeField]?**  
serializefield, public이 내 입장에서 너무 편해서 이걸썻고, getcomponent를 왜 쓰는가에 대해 생각해 봤다.  
이름이 바뀌거나 수정이 있을때 유니티에서 오류가 생긴다, 유니티 로딩이 오래 걸린다.
오늘 수정하면서 많은 오류를 겪었고, 최대한 getcomponent를 사용해 보도록 해야겠다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**player1,2**
player1,2를 나눠서 했는데 다른방법을 사용하자.
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
