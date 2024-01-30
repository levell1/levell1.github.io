---
title:  "[TIL] 71 씬 연결, Define  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-30 02:00

---
- - -

`Define`

<BR><BR>

<center><H1>  최종 팀 프로젝트 15일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 다른반 강의 듣기 스탠다드2 챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 씬 연결

<br><br>

# Define 만들기

<div class="notice--primary" markdown="1"> 

```c# 
public struct UIName
{
    public const string ControlKeyUI = "ControlKeyUI";
    public const string GoDungeonUI = "GoDungeonUI";
    public const string PlayerStatusUI = "PlayerStatusUI";
    public const string ReforgeUI = "ReforgeUI";
    public const string RestartUI = "RestartUI";
    public const string RestaurantUI = "RestaurantUI";
    public const string ResultUI = "ResultUI";
    public const string SettingUI = "SettingUI";
    public const string ShopUI = "ShopUI";
    public const string InventoryUI = "InventoryUI";
}

ex)

GameManager.instance.UIManager.ShowCanvas("InventoryUI");
GameManager.instance.UIManager.ShowCanvas(UIName.InventoryUI);
```
</div>


<br><br><br><br><br>
- - - 

# 콜백이란 무었인가?  
[참고자료](https://daekyoulibrary.tistory.com/entry/C-%EC%BD%9C%EB%B0%B1-%ED%95%A8%EC%88%98Callback%EB%8A%94-%EB%AC%B4%EC%97%87%EC%9D%B4%EA%B3%A0-%EB%8C%80%EB%A6%AC%EC%9E%90Delegate%EB%8A%94-%EB%AD%98%EA%B9%8C)  

콜백메서드는 A라는 메서드를 호출할 때, B라는 메서드를 매개변수로 넘겨주고 A메서드에서 B메서드를 호출하는 것인데, 함수에서 다른 함수를 호출할 때 보고받기 위해 사용하는 방법
피호출자가 호출자를 다시 호출하는 것.  

c#에는 콜백을 적용할 수 있게 도와주는 Delegate가 있다.  
대리자(Delegate)를 통해 할일을 전달 해주는 역할을 한다.  
1. 대리자와 메소드의 반환 형식, 매개변수는 일치해야된다.  
2. 대리자는 int,string과 같은 형식이라 **인스턴스를 따로 만들어야된다.**  

<div class="notice--primary" markdown="1"> 

```c# 
class Program
{
    delegate void Memo(string phoneNumber);  // 대리자 선언
    
    static void Callback(string phoneNumber)
    {
        Console.WriteLine($"{phoneNumber} 번호로 전화를 걸었습니다.");
    }
    
    static void Main(string[] args)
    {
        Memo memo = new Memo(Callback);      // 메소드를 인자로 주어 인스턴스 생성
        memo("010-1234-5678");               // 대리자 실행
    }
}
```
</div>
대리자는 현재 자신이 참조하고 있는 메소드 코드를 실행 후 그 결과를 호출자에게 반환한다.  

<br><br><br><br><br>
- - - 

# 잡담,정리
2일간 씬연결 작업  
**이번 주 할 일**  
사냥터 마무리, 코드 리펙토링, 게임 다듬기 버그 수정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
