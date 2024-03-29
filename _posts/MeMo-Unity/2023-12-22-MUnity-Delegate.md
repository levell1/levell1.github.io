---
title:  "[Memo-Unity] 25. Delegate LOAD(SO) "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-22 01:11

---
- - -

`Delegate` ,`LOAD(SO)`
<BR><BR>

<center><H1>  Delegate  </H1></center>
Delegate  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
<br><br><br><br><br><br>
- - - 

# 델리게이트(Delegate)

> - `Delegate` 메서드를 참조하는 객체로, 메서드의 시그니처(입력 매개변수와 반환 타입)에 대한 정보를 포함  
> - `Func` 반환 타입이 void가 아닌 0~n개의 매개변수를 가진 함수를 나타내는 제네릭 델리게이트  
> - `Action` 반환 타입이 void인 메소드를 위해 특별히 설계된 제네릭 델리게이트  
> - public Action action , public event Action action  
> - event 키워드를 붙이지 않고 Action을 선언할 경우 다른 클래스에서 Action을 실행할 수 있게 됩니다.  
> - button.onClick.AddListener, inputField.onValueChanged(인풋필드에 값이 변결될 때 마다) 도 Delegate  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/596da939-9186-410b-a4c5-f9a0d300c0c8){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c#
public delegate void TestDelegate();
public TestDelegate characterUpdate;

//Action
public Action action;

namespace System
{
    public delegate void Action();
}

//Func
public Func<int, float, bool> fun;

bool funcfunc(int a , float b) 
{
    return true;
}

```
</div>

<br><br>

**델리게이트 x public으로 cs.method로 사용**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/cb531277-c70d-4cec-8d31-c458dd4a3293){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c#

// Player
public class Player : MonoBehaviour
{
    public void GetExp()
    {
        Debug.Log("Get Exp");
    }
}

// QuestManager
public class QuestManager : MonoBehaviour
{
    public void UpdateQuest()
    {
        Debug.Log("Update Quest");
    }
}


// UIManager
public class UIManager : MonoBehaviour
{
    public void UpdateUI()
    {
        Debug.Log("Update UI");
    }
}

// GameManager
    public Player player;
    public QuestManager qm;
    public UIManager ui;

    void StageClear()
    {
        player.GetExp();
        qm.UpdateQuest();
        ui.UpdateUI();
    }

```
</div>

<br><br>

**Delegate Action**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/bcfa4b7f-b927-45fe-9a1c-a3c82968e682){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c#
// Player
public class Player : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.action += GetExp;
    }
    public void GetExp()
    {
        Debug.Log("Get Exp");
    }
}

// QuestManager
public class QuestManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.action += UpdateQuest;
    }
    public void UpdateQuest()
    {
        Debug.Log("Update Quest");
    }
}


// UIManager
public class UIManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.action += UpdateUI;
    }
    public void UpdateUI()
    {
        Debug.Log("Update UI");
    }
}

// GameManager
    public event Action action;

    void StageClear()
    {
        action?.Invoke();
    }
```

</div>

<br><br>

**Delegate_Action<int>**  

<div class="notice--primary" markdown="1"> 

```c#
// Player
public class Player : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.actionint += GetExpint;
    }
    public void GetExpint(int a)
    {
        Debug.Log("action"+a);
    }
}

// GameManager
void StageClear()
{
    actionint?.Invoke(1);
}
```

</div>

<br><br><br>
- - - 

### SO(Sctiptable Object)
**LOAD(SO)**  
`Resources.Load`  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e1e3cffe-0ff5-4317-b40e-c7490c003906){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
<div class="notice--primary" markdown="1"> 

```c#
// Player
private CharacterSO data;

private void Awake()
{
    data = Resources.Load<CharacterSO>("SO/DefaultCharacterData");
}
```

</div>

<br>

<div class="notice--primary" markdown="1"> 

```c#
// CharacterManager (so 변경)
private void Awake()
{
    data = Resources.Load<CharacterSO>("SO/DefaultCharacterData");
}

private void Start()
{
    characterUpdate += ChangeCharacter;
    characterUpdate += ChangeExp;
    characterUpdate += ChangeName;
}
public void ChangeCharacter()
{//데이터 읽어옴
    Debug.Log(data.hp);
}

public void ChangeExp()
{
    Debug.Log(data.exp);
}

public void ChangeName()
{
    Debug.Log(data.name);
}

// GameManager(데이터)
private CharacterSO data;

private void Awake()
{
    data = Resources.Load<CharacterSO>("SO/DefaultCharacterData");
}

private void Start()
{
    data.hp = 50;
    data.exp = 150;
    data.name = "Name";

    CharacterUpdate();
}

void CharacterUpdate()
{
    //데이터 변화
    CharacterManager.Instance.characterUpdate?.Invoke();
}
```

</div>


<br><br><br><br><br>
- - - 

**12.26추가**
# 델리게이트, 이벤트
개발자가 정의한 특정조건이나 행동에 반응하는 사용자 정의 이벤트  

> - **델리게이트**  
>  c#  에서 메소드를 참조하는 타입  
>  메소드의 참조를 변수에 저장하고, 다른 메소드로 전달, 호출을 동적으로 결정할 수 있음.  
> - **장점**   
> 유연성, 코드 재사용, 분리  
> - **단점**  
> 복잡성, 메모리 누수 위험
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br>

> - 이벤트  
> 이벤트는 델리게이트를 기반으로 함  
> 특정 상황이 발생했을 때 이벤트를 구독하는 모든 메소드를 호출하는데 사용됨.  
> - **장점**   
> 캡슐화, 의사소통 강화  
> - **단점**  
> 이해도 요구, 오버헤드
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 잡담

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  
<br><br>
- - - 

[Unity] Delegate
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
