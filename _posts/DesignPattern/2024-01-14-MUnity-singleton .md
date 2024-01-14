---
title:  "[Design Pattern] 1. 싱글톤 패턴(singleton)"
excerpt: "싱글톤"

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:01

---
- - -
<BR><BR>

`싱글톤 패턴(singleton)`

<center><H1> 싱글톤 패턴(singleton)</H1></center>

<br><br><br><br><br>
- - - 

# 1. 싱글톤 패턴 사용이유

![image](https://github.com/levell1/levell1.github.io/assets/96651722/357ef27b-e877-445f-b3a5-a8c679541e91){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

이 패턴은 주로 **객체 지향 프로그래밍**에서 쓰인다.  
싱글톤은 **전역에서 접근이 가능하기에(Static)** 원하는 스크립트에서 불러와서 마음대로 사용이 가능  
{: .notice}

public으로 매 스크립트마다 연결하는 것은 메모리의 사용이 스크립트의 수의 배수만큼 증가하지만,  
싱글톤을 사용하면 한 메모리의 할당만으로 원하는 스크립트의 기능을 가져올 수 있기에 자주 쓰는 스크립트의 경우 **메모리의 사용을 크게 줄일 수 있다.**  
**접근의 편의**와 **메모리의 할당을 줄이기 위해** 싱글톤 패턴을 사용
{: .notice--info}


> - 특정 클래스의 인스턴스가 단 하나만 존재하도록 보장하는 디자인 패턴
> - 클래스의 인스턴스를 전역적으로 접근 가능
> - 게임의 설정, 오디오 매니저, UI 매니저 같이 전역적으로 하나만 존재
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br><br><br>
- - - 

# 2. 싱글톤 패턴 사용법

<details>
<summary>싱글톤 AudioManager</summary>

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

# 3. 장단점

> **장점**  
>   -   메모리 낭비가 현저히 줄어든다는 것, (public)을 데려오는 경우 보다 싱글톤 패턴이 **메모리를 절약**
>   -   싱글톤은 **전역으로 접근**이 가능하기에 가져올 필요 없이 **어느 스크립트에서나 사용할 수 있다는 것**
>   -   공유 자원에 동시 접근을 제한하거나 사용할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

> **단점**  
>   -   유닛 테스트가 어려움  
>   -   잘못된 프로그래밍 습관을 유발함  
>   -   전역변수가 가지는 모든 단점을 그대로 갖게 된다.
>   -   전역변수는 가장 마지막에 검색되게 때문에 조금 느릴 수 있으며, 유지보수가 조금 힘들어질 수 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 


<br><br><br><br><br><br>
- - - 

# 4. 12/22 추가
싱글톤 GameManager

<div class="notice--primary" markdown="1"> 

```c#
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {   // 다른 곳에서 GaneManager.Instance~~ 를 실행 했을때 NULL 이면(게임메니저가 없으면) GameManager을 생성, DondestroyOnload
            // Instance = 새로 생성된 게임 오브젝트의 GameManager.cs 의 PRIVATE _instance
            if(_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                _instance = go.GetComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
        }
    }   
}
```

- **Instance - get, set**
- 다른 곳에서 GaneManager.Instance~~ 를 실행 했을때 NULL 이면(게임메니저가 없으면) GameManager을 생성, DondestroyOnload
- **Awake**
- 싱글톤화, DondestroyOnLoad, 새로 생긴 GameObject 가 있으면 삭제(Destroy).

</div>

<br><br><br><br><br><br>
- - - 

# 제네릭 싱글톤
**제네릭 싱글톤 만들어서 필요한 매니저에 상속**  

<details>
<summary>제네릭 싱글톤</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class Singleton <T>: MonoBehaviour where T: Component
{
    private static T_instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class GameManager : Singleton<GameManager>
{
    void Start()
    {

    }
}
```
</div>
</details>

<br><br>

[C#] 싱글톤 패턴 정리

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
