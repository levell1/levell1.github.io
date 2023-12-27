---
title:  "[TIL] 45 반별강의(Design_Pattern), 심화주차  ⭐⭐ "
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

&nbsp;&nbsp; [o] 알고리즘 문제  - 49   
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [o] 디자인 패턴 복습하기  
&nbsp;&nbsp; [x] ui 2회차 듣기      
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 알고리즘

list = list.Distinct().ToList();  
list 에 있는 중복된 요소 지우기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 
<h2> 반별강의 </h2>

# 1. 싱글톤 패턴 (singleton)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/357ef27b-e877-445f-b3a5-a8c679541e91){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

> - 특정 클래스의 인스턴스가 단 하나만 존재하도록 보장하는 디자인 패턴
> - 클래스의 인스턴스를 전역적으로 접근 가능
> - 게임의 설정, 오디오 매니저, UI 매니저 같이 전역적으로 하나만 존재
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<details>
<summary>singleton 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
public class AudioManager
{
    // 이 인스턴스는 프로그램의 실행 동안 단 한 번만 생성됨
    private static AudioManager _instance;

    // 싱글톤 인스턴스에 대한 접근자
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AudioManager();
            }
            return _instance;
        }
    }

    // 생성자를 private으로 설정하여 외부에서 인스턴스를 생성하는 것을 방지
    private AudioManager() 
    {
        // 초기화 코드
    }

    // 오디오 관련 메소드
    public void PlaySound(string soundName)
    {
        // 소리 재생
    }

    public void StopSound(string soundName)
    {
        // 소리 중지
    }
}

// 메모리 사용을 최적화하고 코드를 깔끔하게 사용할 수 있게 해주는 싱글톤 패턴!
AudioManager.Instance.PlaySound("backgroundMusic");

```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 2. 상태패턴 (state)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8ef94cd9-ef44-4cae-911f-1ba64cdbc912){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

> - 객체의 상태에 따라 객체의 행동을 변경 해주는 디자인 패턴
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

# 8.델리게이트, 이벤트
개발자가 정의한 특정조건이나 행동에 반응하는 사용자 정의 이벤트  

> - 델리게이트  
>  c#  에서 메소드를 참조하는 타입  
>  메소드의 참조를 변수에 저장하고, 다른 메소드로 전달, 호출을 동적으로 결정할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> - 이벤트  
> 이벤트는 델리게이트를 기반으로 함  
> 특정 상황이 발생했을 때 이벤트를 구독하는 모든 메소드를 호출하는데 사용됨.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

<h2> UI강의 </h2>

[UI](https://levell1.github.io/memo%20unity/MUnity-Ui1/)

<br><br><br><br><br>
- - - 

# 잡담,정리
Simulator gameView 에서 simulator 로 변경하면 폰화면 미리보기 가능.  
Window -> Analysis -> Profiler : 프레임,cpu, gpu, 메모리 등 사용량을 체크할 수 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  
 

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
