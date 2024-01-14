---
title:  "[Design Pattern] 2. 상태 패턴(state)  "
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:02

---
- - -
<BR><BR>



<center><H1> 상태 패턴(state) </H1></center>

`상태(state)패턴`

<br><br><br><br>
- - - 

# 상태패턴 (state)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8ef94cd9-ef44-4cae-911f-1ba64cdbc912){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

> - 객체의 상태에 따라 **객체의 행동을 변경** 해주는 디자인 패턴
> - 캐릭터 상태가 **끊임없이 전환** 객체가 내부 상태를 기반으로 움직이는 시스템  
> - 조건문으로 나누는 것이 아니라 **객체의 상태를 별도의 클래스로 캡슐화**
> - 게임 캐릭터의 상태(대기, 이동, 공격)에 따라 행동이 달라지게 구현
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>state 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 상태 인터페이스
public interface IState
{
    void HandleInput(Player player, string input);
    void Update(Player player);
}

// 상태에 따른 클래스들, 대기 상태 클래스
public class StandingState : IState
{
    public void HandleInput(Player player, string input)
    {
        if (input == "SPACE") 
        {
            player.SetState(new JumpingState());
        }
    }

    public void Update(Player player)
    {
        // 대기 상태에서 할 행동
    }
}

// 점프 상태 클래스
public class JumpingState : IState
{
    public void HandleInput(Player player, string input)
    {
        // 점프 상태에서의 입력 처리
    }

    public void Update(Player player)
    {
        // 점프 상태에서 할 행동
    }
}

// 플레이어 클래스
public class Player
{
    private IState currentState;

    public Player()
    {
        currentState = new StandingState();
    }

    public void SetState(IState newState)
    {
        currentState = newState;
    }

    public void HandleInput(string input)
    {
        currentState.HandleInput(this, input);
    }

    public void Update()
    {
        currentState.Update(this);
    }
}

// 상태 패턴 사용 예시
Player player = new Player();
player.HandleInput("SPACE"); // 점프 상태로 변경
player.Update(); // 현재 상태(점프)에 맞는 행동 실행
```
</div>
</details>

<h3> 추가 </h3>  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/18deb7d4-6bf5-4971-9c33-e5fd610adec0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 상태를 불러내는 호출자 -> 인터페이스 -> 상태ABC  
> - Context 클래스는 객체의 내부 상태를 변경하도록 요청하는 클래스  
> - IState 인터페이스는 구체적인 상태 클래스로 연결할 수 있도록 설정함  
> - Context 오브젝트가 Istate 인터페이스를 구현한 클래스들을 호출함  

**장점**  
&nbsp;&nbsp;1. 캡슐화  
&nbsp;&nbsp;2. 긴 조건문, 방대한 클래스 구현하는 것을 막음  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**단점**  
&nbsp;&nbsp;1. 만약 상태가 전환되는 사이에서 발생하는건 따로 구현을 해야함.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

**코드**  
`CharaccterStateContext`, `ICharacterState`, `CharacterController`, `CharacterStartState`

<details>
<summary>state 예시</summary>

<div class="notice--primary" markdown="1"> 

```c# 
CharaccterStateContext  
public class CharaccterStateContext
    {
        public ICharacterState CurrentState
        {
            get; set;
        }
        
        private readonly CharacterController _characterController;

        public CharacterStateContext(CharacterController characterController)
        {
            _characterController = characterController;
        }

        public void Transition()
        {
            CurrentState.Handle(_characterController);
        }
        
        public void Transition(ICharacterState state)
        {
            CurrentState = state;
            CurrentState.Handle(_characterController);
        }
    }

ICharacterState
public interface ICharacterState
{
    void Handle(CharacterController controller);
}

using UnityEngine;

CharacterController
public class CharacterController : MonoBehaviour {
            
    private ICharacterState 
        _startState, _stopState, _turnState;
    
    private CharacterStateContext _characterStateContext;

    private void Start() {
        _chracterStateContext = 
            new CharacterStateContext(this);
        
        _startState = 
            gameObject.AddComponent<CharacterStartState>();
        _stopState = 
            gameObject.AddComponent<CharacterStopState>();
        _turnState = 
            gameObject.AddComponent<CharacterTurnState>();
        
        _characterStateContext.Transition(_stopState);
    }

    public void StartCharacter() {
        _characterStateContext.Transition(_startState);
    }

    public void StopCharacter() {
        _chracterStateContext.Transition(_stopState);
    }
}

CharacterStartState
 public class CharacterStartState : MonoBehaviour, ICharacterState
{
    private CharacterController _characterController; 
    
    public void Handle(CharacterController characterController)
    {
        if (!_characterController)
            _characterController = characterController;
        
        _characterController.CurrentSpeed = 10.0f;
    }
}
```
</div>
</details>

<br><br><br><br><br>
- - - 


# 잡담, 정리
> - 디자인 패턴은 애초에 특정 문제를 해결하기 위해 고려된 것.(성능, 메모리 사용 고려)
{: .notice--success} 

<br><br>
- - - 

[C#] 디자인 패턴 (Design Pattern)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
