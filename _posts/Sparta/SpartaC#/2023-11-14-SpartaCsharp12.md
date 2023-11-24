---
title:  "[C#] 델리게이트(Delegate), 람다(Lambda), Func,Action, LINQ ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-14 01:00

---
- - -
<BR><BR>

<center><H1> C# 델리게이트(Delegate), 람다(Lambda), Func,Action, LINQ   </H1></center>

델리게이트(**`Delegate`**), 람다(**`Lambda`**), **`Func`**,**`Action`**, **`LINQ`**
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 델리게이트(Delegate)
<U>메서드를 참조하는 타입, 다른 언어에서는 함수포인터와 비슷, 차이점있다.</U>  
메서드를 매개변수로 전달하거나 변수에 할당할 수 있습니다.  
접근이 불편한 상황, 여러개 메소드 사용할 때 유용하다  
Delegate = 메서드1  
Delegate += 메서드2  
두 메서드 실행  
어떤 처리를 할 때 순서대로 += 기능 으로 모두 실행하게 한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<details>
<summary>두개 이상의 메서드 등록, 사용</summary>

<div class="notice--primary" markdown="1"> 

```c# 
delegate void MyDelegate(string message);

static void Method1(string message)
{
    Console.WriteLine("Method1: " + message);
}

static void Method2(string message)
{
    Console.WriteLine("Method2: " + message);
}

class Program
{
    static void Main()
    {
        // 델리게이트 인스턴스 생성 및 메서드 등록
        MyDelegate myDelegate = Method1;
        myDelegate += Method2;

        // 델리게이트 호출
        myDelegate("Hello!");

        Console.ReadKey();
    }
}
```
</div>
</details>

<br><br><br><br>

**Event**
> - 다음 예제에서는 event 를 붙여서 사용했다
> - event는 할당연산자( = )를 사용할 수 없으며, 클래스 외부에서는 직접 이벤트를 호출할 수 없다.(보안성, 캡슐화)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>사용 예제</summary>

<div class="notice--primary" markdown="1"> 

```c# 
d// 델리게이트 선언
public delegate void EnemyAttackHandler(float damage);

// 적 클래스
public class Enemy
{
    // 공격 이벤트
    public event EnemyAttackHandler OnAttack;

    // 적의 공격 메서드
    public void Attack(float damage)
    {
        // 이벤트 호출
        OnAttack?.Invoke(damage);
				// null 조건부 연산자
				// null 참조가 아닌 경우에만 멤버에 접근하거나 메서드를 호출
    }
}

// 플레이어 클래스
public class Player
{
    // 플레이어가 받은 데미지 처리 메서드
    public void HandleDamage(float damage)
    {
        // 플레이어의 체력 감소 등의 처리 로직
        Console.WriteLine("플레이어가 {0}의 데미지를 입었습니다.", damage);
    }
}

// 게임 실행
static void Main()
{
    // 적 객체 생성
    Enemy enemy = new Enemy();

    // 플레이어 객체 생성
    Player player = new Player();

    // 플레이어의 데미지 처리 메서드를 적의 공격 이벤트에 추가
    enemy.OnAttack += player.HandleDamage;

    // 적의 공격
    enemy.Attack(10.0f);
}
```
</div>
</details>

> - Enemy안에 이벤트 델리게이트(OnAttack)생성 [Event](https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/event)  
> - main ->  enemy.OnAttack += player.HandleDamage;  
enemy.onattack델리게이트에 메서드 추가
> -  enemy.Attack(10.0f) -> enemy.attack 메서드로 이동
> -  onattack?.Invoke(damage) onattack에 있던 player.HandleDamage 실행  
?은 null조건부 연산자 -> null이 아닌경우만 접근해 호출
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 람다(Lambda)
<U>익명 메서드를 만드는 방법입니다, 메서드의 이름 없이 메서드 생성</U>  
람다는 델리게이트를 사용하여 변수에 할당하거나, 메서드의 매개변수로 전달할 수 있습니다.  
재사용X 메서드거나, 간단하게 사용할 때 사용.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<details>
<summary>람다 구현</summary>

<div class="notice--primary" markdown="1"> 

```c# 
Calculate calc = (x, y) => 
{	
		return x + y;
};

Calculate calc = (x, y) => x + y;

using System;

// 델리게이트 선언
delegate void MyDelegate(string message);

class Program
{
    static void Main()
    {
        // 델리게이트 인스턴스 생성 및 람다식 할당
        MyDelegate myDelegate = (message) =>
        {
            Console.WriteLine("람다식을 통해 전달된 메시지: " + message);
        };

        // 델리게이트 호출
        myDelegate("안녕하세요!");

        Console.ReadKey();
    }
}
```
</div>
</details>

<BR>

<details>
<summary>델리게이트 + 람다 게임분기 나타내기 </summary>

<div class="notice--primary" markdown="1"> 

```c# 
// 델리게이트 선언
public delegate void GameEvent();

// 이벤트 매니저 클래스
public class EventManager
{
    // 게임 시작 이벤트
    public event GameEvent OnGameStart;

    // 게임 종료 이벤트
    public event GameEvent OnGameEnd;

    // 게임 실행
    public void RunGame()
    {
        // 게임 시작 이벤트 호출
        OnGameStart?.Invoke();

        // 게임 실행 로직

        // 게임 종료 이벤트 호출
        OnGameEnd?.Invoke();
    }
}

// 게임 메시지 클래스
public class GameMessage
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

// 게임 실행
static void Main()
{
    // 이벤트 매니저 객체 생성
    EventManager eventManager = new EventManager();

    // 게임 메시지 객체 생성
    GameMessage gameMessage = new GameMessage();

    // 게임 시작 이벤트에 람다 식으로 메시지 출력 동작 등록
    eventManager.OnGameStart += () => gameMessage.ShowMessage("게임이 시작됩니다.");

    // 게임 종료 이벤트에 람다 식으로 메시지 출력 동작 등록
    eventManager.OnGameEnd += () => gameMessage.ShowMessage("게임이 종료됩니다.");

    // 게임 실행
    eventManager.RunGame();
}
```
</div>
</details>

> - 델리게이트(GameEvent), EventManager에서 start,end 이벤트 생성
> - Main에서 eventmanager 객체생성,  
eventmanager의 ongamestart(델리게이트)에 동작 추가  
eventmanager의 OnGameEnd(델리게이트)에 동작 추가  
eventmanager의 rungame안의 두 이벤트 호출  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}


<br><br><br><br><br><br>
- - - 

# 3. Func과 Action
<U>Func과 Action은 델리게이트를 대체하는 미리 정의된 제네릭 형식입니다.</U>  
Func 및 Action은 제네릭 형식으로 미리 정의되어 있어 매개변수와 반환 타입을 간결하게 표현할 수 있습니다.  

> **Func**
> - Func는 <u>값을 반환하는</u> 메서드를 나타내는 델리게이트   
> - Func<`int`, `string`>는 `int`를 입력으로 받아 `string`을 반환하는 메서드를 나타냅니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

> **Action**
> - Action은 <u>값을 반환하지 않는</u> 메서드를 나타내는 델리게이트
> - Action<`int`, `string`>은 int와 string을 입력으로 받고, 아무런 값을 반환하지 않는 메서드
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>Func과 Action 예제 </summary>

<div class="notice--primary" markdown="1"> 

```c# 
// Func를 사용하여 두 개의 정수를 더하는 메서드
int Add(int x, int y)
{
    return x + y;
}

// Func를 이용한 메서드 호출
Func<int, int, int> addFunc = Add;
int result = addFunc(3, 5);
Console.WriteLine("결과: " + result);

// Action을 사용하여 문자열을 출력하는 메서드
void PrintMessage(string message)
{
    Console.WriteLine(message);
}

// Action을 이용한 메서드 호출
Action<string> printAction = PrintMessage;
printAction("Hello, World!");
```
</div>
</details>

> - func -> 매개변수를 받아 결과를 만들고 반환한다.
> - Action -> 매개변수를 받고 Action만 한다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br><br>

**활용 예제**

<details>
<summary>예제 </summary>

<div class="notice--primary" markdown="1"> 

```c# 
// 게임 캐릭터 클래스
class GameCharacter
{
    private Action<float> healthChangedCallback;

    private float health;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            healthChangedCallback?.Invoke(health);
        }
    }

    public void SetHealthChangedCallback(Action<float> callback)
    {
        healthChangedCallback = callback;
    }
}

// 게임 캐릭터 생성 및 상태 변경 감지
GameCharacter character = new GameCharacter();
character.SetHealthChangedCallback(health =>
{
    if (health <= 0)
    {
        Console.WriteLine("캐릭터 사망!");
    }
});

// 캐릭터의 체력 변경
character.Health = 0;
```
</div>
</details>

> - Health를 외부에서 set할 때 마다 Action(healthChangedCallBack)이 실행된다
> - 메인에서 체력이 0 이하면 캐릭터 사망.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}


<br><br><br><br><br><br>
- - - 

# 4. LINQ(Language Integrated Query)
<U>.NET 프레임워크에서 제공되는 쿼리 언어 확장</U>  

> - 데이터 소스(예: 컬렉션, 데이터베이스, XML 문서 등)에서 데이터를 쿼리하고 조작하는데 사용
> - 쿼리와 유사한 방식으로 데이터를 필터링, 정렬, 그룹화, 조인 등 다양한 작업을 수행
> - LINQ는 객체, 데이터베이스, XML 문서 등 다양한 데이터 소스를 지원
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

## 구조

<div class="notice--primary" markdown="1"> 

```c# 
var result = from 변수 in 데이터소스
             [where 조건식]
             [orderby 정렬식 [, 정렬식...]]
             [select 식];

//예제
// 데이터 소스 정의 (컬렉션)
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// 쿼리 작성 (선언적인 구문)
var evenNumbers = from num in numbers
                  where num % 2 == 0
                  select num;

// 쿼리 실행 및 결과 처리
foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}
```
- **`var`** 키워드는 결과 값의 자료형을 자동으로 추론
- **`from`** 절에서는 데이터 소스를 지정
- **`where`** 절은 선택적으로 사용하며, 조건식을 지정하여 데이터를 필터링합니다.
- **`orderby`** 절은 선택적으로 사용하며, 정렬 방식을 지정합니다.
- **`select`** 절은 선택적으로 사용하며, 조회할 데이터를 지정합니다.
</div>

> **예제**
> - List numbers ( 1, 2, 3, 4, 5 )
> - evenNumbers에 numbers중 num%2=0 인 값들을 조회, evenNumbers에 저장
> - foreach문으로 evenNumbers리스트 결과 확인
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}


<details>
<summary>람다 연습 </summary>

<div class="notice--primary" markdown="1"> 

```c# 
delegate void MyDelegate();

class Program
{
    static void Method1(string message)
    {
        Console.WriteLine("Method1: " + message);
    }

    static void Method2(string message)
    {
        Console.WriteLine("Method2: " + message);
    }
    static void Main()
    {
        string a = "1";
        string b = "2";
        // 델리게이트 인스턴스 생성 및 메서드 등록
        MyDelegate myDelegate;
        myDelegate = () => Method1(a);
        myDelegate += () => Method2(b);

        myDelegate += () => Method1(b);
        myDelegate += () => Method2(a);
        myDelegate += () =>
        {
            Console.WriteLine("테스트");
        };
        myDelegate();
        Console.ReadKey();
    }
}
```

</div>
</details>


<br><br>
- - - 

[C#] C# 델리게이트(Delegate), 람다(Lambda), Func,Action, LINQ

<br>

참고 : [유니티](https://docs.unity3d.com/kr/) [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
