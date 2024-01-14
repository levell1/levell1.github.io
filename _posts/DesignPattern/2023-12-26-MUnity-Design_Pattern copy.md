---
title:  "[Memo-Unity] 2.`state`, `observer`, `command` `component`, `builder`, `flyweight`, `EventBus`  "
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:00

---
- - -
<BR><BR>

`상태(state)`, `관찰자(observer)`, `커맨드(command)`  
`component`, `builder`, `flyweight`, `EventBus`

<center><H1> Design Pattern </H1></center>

<br><br><br><br><br><br>
- - - 

# 2. 상태패턴 (state)

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


<br><br><br><br><br><br>
- - - 

# 3. 관찰자 패턴 (observer)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1a971805-1f06-4989-a18e-3cccc5c6223d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

> - 한 객체의 상태 변화를 관찰하는 다수의 객체(관찰자들)
> - 주인공 객체가 변하면 관찰자들에게도 자동으로 이를 알려줌
> - 상태 변화에 따른 자동 업데이트 (**`구동 시스템과 유사`**)
> - 의존성 줄이고 중요한 정보를 적절히 공유하는 형태
> - ex) 플레이어 체력변화에 따른 이벤트를 구현할 때 유용
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

<details>
<summary>observer 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 관찰자 인터페이스
public interface IObserver
{
    void Update(int health);
}

// 주인공 인터페이스
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// 플레이어 클래스 (주인공)
public class Player : ISubject
{
    private int health;
    private List<IObserver> observers = new List<IObserver>();

    public int Health
    {
        get { return health; }
        set 
        { 
            health = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(health);
        }
    }
}

// UI 클래스 (관찰자)
public class HealthDisplay : IObserver
{
    public void Update(int health)
    {
        Console.WriteLine("Health updated to: " + health);
        // UI 업데이트 로직
    }
}

// 옵저버 패ㄴ 사용 예시
Player player = new Player();
HealthDisplay display = new HealthDisplay();

player.Attach(display);
player.Health = 90; // 플레이어의 체력 변경. 자동으로 관찰자들에게 알림이 감. //set부분에 notify()

```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 4. 커맨드 패턴 (command)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1371e2fd-0f79-40d6-b145-98031ff04923){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

> - 버튼을 누르는 행위랑 발생하는 행동을 분리하는 패턴
> - 입력을 다룰 때 많이 사용하는 패턴  
> - 사용자의 요청을 발생시킨 코드와 요청을 수행하는 코드 사이의 의존성을 줄이는 것
> - 입력 처리를 깔끔, 유연하게 관리, 명령을 추가, 재사용 쉬워짐
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>command 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 커맨드 인터페이스
public interface ICommand
{
    void Execute();
}

// 구체적인 커맨드 클래스들. 이동 요청 클래스
public class MoveCommand : ICommand
{
    private Player player;
    private float x, y;

    public MoveCommand(Player player, float x, float y)
    {
        this.player = player;
        this.x = x;
        this.y = y;
    }

    public void Execute()
    {
        player.Move(x, y);
    }
}

// 점프 요청 클래스
public class JumpCommand : ICommand
{
    private Player player;

    public JumpCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Jump();
    }
}

// 플레이어 클래스
public class Player
{
    public void Move(float x, float y)
    {
        // 이동 로직
    }

    public void Jump()
    {
        // 점프 로직
    }
}

// 커맨드 사용
Player player = new Player();
ICommand moveCommand = new MoveCommand(player, 1.0f, 0.0f);
ICommand jumpCommand = new JumpCommand(player);

moveCommand.Execute(); // 플레이어 이동
jumpCommand.Execute(); // 플레이어 점프
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 5. 컴포넌트 패턴 (component)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a3a13fc7-deb3-4c97-861d-06b092bea969){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

> - 객체의 행동을 작은 부품(Componenet) 으로 분리
> - 부품을 조합하여 복잡한 동장을 구현하는 방식
{: .notice--info} 

<details>
<summary>component 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 컴포넌트 인터페이스
public interface IComponent
{
    void Update();
}

// 구체적인 컴포넌트 클래스들
public class MovementComponent : IComponent
{
    public void Update()
    {
        // 이동 관련 로직
    }
}

public class JumpComponent : IComponent
{
    public void Update()
    {
        // 점프 관련 로직
    }
}

// 게임 오브젝트 클래스
public class GameObject
{
    private List<IComponent> components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }

    public void Update()
    {
        foreach (var component in components)
        {
            component.Update();
        }
    }
}

// 사용 예시
GameObject player = new GameObject();
player.AddComponent(new MovementComponent());
player.AddComponent(new JumpComponent());

player.Update();
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 6. 빌더 패턴 (builder)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/7517e86f-622e-40a6-af6b-18da5053334d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**샌드위치**
> - 복잡한 객체의 생성 과정을 단계별 분리
> - 객체의 생성과 표현을 분리
> - 생성하는 과정에서 서로 다른 표현을 가진 객체를 만드는 것
> - 복잡한 게임오브젝트, 난이도조절할 때 사용(맵형태, 몹수)
{: .notice--info} 

<details>
<summary>builder 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 빌더 인터페이스
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    GameObject GetResult();
}

// 빌더 클래스
public class ConcreteBuilder : IBuilder
{
    private GameObject gameObject = new GameObject();

    public void BuildPartA()
    {
        // 객체의 일부분 A를 구축 (예: 캐릭터 모델 추가)
    }

    public void BuildPartB()
    {
        // 객체의 일부분 B를 구축 (예: 캐릭터 애니메이션 설정)
    }

    public void BuildPartC()
    {
        // 객체의 일부분 C를 구축 (예: 캐릭터 능력치 설정)
    }

    public GameObject GetResult()
    {
        return gameObject;
    }
}

// 게임 오브젝트 클래스
public class GameObject
{
    // 게임 오브젝트 관련 속성 및 메소드
}

// 빌더 사용
IBuilder builder = new ConcreteBuilder();
builder.BuildPartA();
builder.BuildPartB();
builder.BuildPartC();
GameObject player = builder.GetResult();
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 7. 플라이웨이트 패턴(flyweight)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/d428dfa5-e929-4c5e-b27c-ac770f8eaed4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**도서관**
> - **메모리 사용을 최적화** 하기 위한 패턴
> - **객체의 공유를 촉진하는 형태**  
> - 플라이 웨이트 패턴의 상태 종류
> 객체마다 다를 수 있는 개별상태
> 변경 불가능한 공유 상태
> - 공유 상태는 객체 내부에 저장, 개별 상태는 클라이언트에 의해 관리
> - 대규모 게임 환경에서 반복되는 아이템 같은 것을 관리할 때 유용함.  
{: .notice--info} 

<details>
<summary>flyweight 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 플라이웨이트 클래스, 모든 나무가 공유하는 정보.
public class TreeModel
{
    // 공유되는 상태 (예: 모델, 텍스처)
    public string Model { get; set; }
    public string Texture { get; set; }
}

// 공유되지 않는 상태를 관리하는 클래스, 각 나무의 고유한 정보를 저장. 위치를 관리함.
public class Tree
{
    private TreeModel model;
    private float x, y; // 나무의 위치, 고유 상태

    public Tree(TreeModel model, float x, float y)
    {
        this.model = model;
        this.x = x;
        this.y = y;
    }

    public void Draw()
    {
        // 나무를 그리는 로직, model의 정보와 위치 정보를 사용
    }
}

// 플라이웨이트 팩토리, TreeModel 클래스 인스턴스를 생성하고 관리함. 
// 같은 종류의 나무가 여러번 필요할 때 매번 TreeModel 클래스가 생성하지 않도록 하는게 핵심
public class TreeFactory
{
    private Dictionary<string, TreeModel> models = new Dictionary<string, TreeModel>();

    public TreeModel GetTreeModel(string model, string texture)
    {
        if (!models.ContainsKey(model))
        {
            models[model] = new TreeModel { Model = model, Texture = texture };
        }
        return models[model];
    }
}

// 사용 예시
TreeFactory factory = new TreeFactory();

var oakModel = factory.GetTreeModel("oak", "oakTexture");
var pineModel = factory.GetTreeModel("pine", "pineTexture");

List<Tree> trees = new List<Tree>();
trees.Add(new Tree(oakModel, 10, 20));
trees.Add(new Tree(pineModel, 50, 60));

foreach (var tree in trees)
{
    tree.Draw();
}
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 8. 이벤트 버스 패턴
**발행/구독** 패턴  
발행자와 구독자는 서로인식x **중간에 버스**가 있다.  
전역 이벤트를 관리하는 **중앙 허브 개념**  
게임에서 월드 이벤트 발생시 해당 캐릭터들에게 **이벤트를 발송**하는 식  
구현하기 의외로 매우 간단해서 많이 쓰임.  
어떤 객체에서 이벤트가 발생하면 다른 구독자가 신호를 받는 시스템  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**장점**  
&nbsp;&nbsp;1. 오브젝트를 직접 참조x, 이벤트 통신  
&nbsp;&nbsp;2. 구독 시스템을 쉽게 구현하게 만듬  
&nbsp;&nbsp;3. 프로토타입 만들 때 많이 쓰임 , 쉽고 빠르다  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp;1. 약간의 성능비용  
&nbsp;&nbsp;2. 이벤트 버스가 static 전역 변수라, 전역변수의 단점을 모두 가지게 됨.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

**코드**  

<details>
<summary>EventBus 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine.Events;
using System.Collections.Generic;

public enum WorldEventType
{
    COUNTDOWN, START, PAUSE, STOP, FINISH, RESTART, QUIT
}


public class WorldEventBus
{
    private static readonly 
        IDictionary<WorldEventType, UnityEvent> 
        Events = new Dictionary<WorldEventType, UnityEvent>();

    public static void Subscribe
        (WorldEventType eventType, UnityAction listener) {
        
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe
        (WorldEventType type, UnityAction listener) {

        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(WorldEventType type) {

        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent)) {
            thisEvent.Invoke();
        }
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
