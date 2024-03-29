---
title:  "[Memo-Unity] 5. 싱글톤 패턴(singleton)"
excerpt: "싱글톤"

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-10-19
update: 2023-12-22

---
- - -
<BR><BR>

<center><H1> 싱글톤 패턴(singleton)</H1></center>

<BR><BR>


<h1>싱글톤 패턴</h1>

<br><br><br><br><br><br>
- - - 

# 1. 싱글톤 패턴 사용이유

이 패턴은 주로 **객체 지향 프로그래밍**에서 쓰인다.  
싱글톤은 **전역에서 접근이 가능하기에(Static)** 원하는 스크립트에서 불러와서 마음대로 사용이 가능  
{: .notice}

public으로 매 스크립트마다 연결하는 것은 메모리의 사용이 스크립트의 수의 배수만큼 증가하지만,  
싱글톤을 사용하면 한 메모리의 할당만으로 원하는 스크립트의 기능을 가져올 수 있기에 자주 쓰는 스크립트의 경우 **메모리의 사용을 크게 줄일 수 있다.**  
**접근의 편의**와 **메모리의 할당을 줄이기 위해** 싱글톤 패턴을 사용
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 싱글톤 패턴 사용법

GameManager에서 싱글톤을 사용 하였다.  
{: .notice}

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;    //싱글톤 패턴 ()
    
    void Awake()                    //싱글톤 화
    {
        I = this;
    }
}
```
-   빗방울 게임에서는 스코어에 활용하기 위해 싱글톤 패턴이 사용되었다.
</div>

<br><br><br><br><br><br>
- - - 

# 3. 장단점

> 장점  
>   -   메모리 낭비가 현저히 줄어든다는 것, (public)을 데려오는 경우 보다 싱글톤 패턴이 **메모리를 절약**
>   -   싱글톤은 전역으로 접근이 가능하기에 가져올 필요 없이 **어느 스크립트에서나 사용할 수 있다는 것**
{: .notice}

> 단점  
>   -   전역변수가 가지는 모든 단점을 그대로 갖게 된다.
>   -   전역변수는 가장 마지막에 검색되게 때문에 조금 느릴 수 있으며, 유지보수가 조금 힘들어질 수 있다.
{: .notice}

<br><br><br><br><br><br>
- - - 

# 4. 12/22 추가

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


<br><br>

[C#] 싱글톤 패턴 정리

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
