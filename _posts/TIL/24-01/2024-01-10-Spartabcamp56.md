---
title:  "[TIL] 56 최종 팀 시작, 강의 디자인패턴  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-10 02:00

---
- - -


`Object Pool`, `Strategy` `Commend`

<BR><BR>

<center><H1>  최종 팀 프로젝트 시작  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 다른반 강의 듣기 스탠다드2 챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 디자인 패턴 이해,정리하기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 디자인패턴 

## Object Pool
**프레임 속도유지**, 자주 생성되는 요소를 일부 **메모리에 예약**하는게 좋음  
메모리에서 없애는 대신 다시 사용할 수 있도록 오브젝트 풀에 추가  
엔티티의 **새로운 인스턴스를 로드하는 초기의 초기화 비용이 들지 않음**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

object pool 객체의 풀을 **관리**, 객체 **생성**, **관리**, **파기**  
reusable pool : 실제로 재사용될 객체, object pool 이 여기 객체를 관리  
clien : 클라이언트는 필요할 때 오브젝트풀에서 reuablepool 객체를 요청, 사용 후 다시 풀에 반환  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**장점**  
&nbsp;&nbsp;1. 예측할 수 있는 메모리 사용  
&nbsp;&nbsp;2. **성능 향상**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

**단점**  
&nbsp;&nbsp;1. 이미 c# 이 메모리 최적화가 뛰어나서 굳이 필요없다? 썰    
&nbsp;&nbsp;2. 예측 불가능한 객체 상태   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 


<br><br>

<details>
<summary>DroneObjectPool</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEngine.Pool;

public class DroneObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;

    // 필요할 떄 오브젝트 풀을 생성함
    public IObjectPool<Drone> Pool 
    {
        get 
        {
            if (_pool == null)
                _pool = 
                    new ObjectPool<Drone>(
                        CreatedPooledItem, 
                        OnTakeFromPool, 
                        OnReturnedToPool, 
                        OnDestroyPoolObject, 
                        true, 
                        stackDefaultCapacity,
                        maxPoolSize);
            return _pool;
        }
    }

    private IObjectPool<Drone> _pool;

    private Drone CreatedPooledItem() 
    {
        var go = 
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        Drone drone = go.AddComponent<Drone>();
        
        go.name = "Drone";
        drone.Pool = Pool;
        
        return drone;
    }

    // 드론이 풀로 돌아올 때 호출됨
    private void OnReturnedToPool(Drone drone) 
    {
        drone.gameObject.SetActive(false);
    }

    // 드론이 풀에서 꺼내질 때 호출됨
    private void OnTakeFromPool(Drone drone) 
    {
        drone.gameObject.SetActive(true);
    }

    // 드론 오브젝트를 파괴할 때
    private void OnDestroyPoolObject(Drone drone) 
    {
        Destroy(drone.gameObject);
    }

    // 무작위 수의 드론을 생성하고 위치를 설정할 때
    public void Spawn() 
    {
        var amount = Random.Range(1, 10);
        
        for (int i = 0; i < amount; ++i) {
            var drone = Pool.Get();
            
            drone.transform.position = 
                Random.insideUnitSphere * 10;
        }
    }
}
```
</div>
</details>


<details>
<summary>DroneObjectPool</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEngine.Pool;

public class DroneObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;

    // 필요할 떄 오브젝트 풀을 생성함
    public IObjectPool<Drone> Pool 
    {
        get 
        {
            if (_pool == null)
                _pool = 
                    new ObjectPool<Drone>(
                        CreatedPooledItem, 
                        OnTakeFromPool, 
                        OnReturnedToPool, 
                        OnDestroyPoolObject, 
                        true, 
                        stackDefaultCapacity,
                        maxPoolSize);
            return _pool;
        }
    }

    private IObjectPool<Drone> _pool;

    private Drone CreatedPooledItem() 
    {
        var go = 
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        Drone drone = go.AddComponent<Drone>();
        
        go.name = "Drone";
        drone.Pool = Pool;
        
        return drone;
    }

    // 드론이 풀로 돌아올 때 호출됨
    private void OnReturnedToPool(Drone drone) 
    {
        drone.gameObject.SetActive(false);
    }

    // 드론이 풀에서 꺼내질 때 호출됨
    private void OnTakeFromPool(Drone drone) 
    {
        drone.gameObject.SetActive(true);
    }

    // 드론 오브젝트를 파괴할 때
    private void OnDestroyPoolObject(Drone drone) 
    {
        Destroy(drone.gameObject);
    }

    // 무작위 수의 드론을 생성하고 위치를 설정할 때
    public void Spawn() 
    {
        var amount = Random.Range(1, 10);
        
        for (int i = 0; i < amount; ++i) {
            var drone = Pool.Get();
            
            drone.transform.position = 
                Random.insideUnitSphere * 10;
        }
    }
}

```
</div>
</details>


<details>
<summary>Drone</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class Drone : MonoBehaviour 
{
    public IObjectPool<Drone> Pool { get; set; }

    public float _currentHealth;

    [SerializeField] 
    private float maxHealth = 100.0f;
    [SerializeField] 
    private float timeToSelfDestruct = 3.0f;

    void Start() 
    {
        _currentHealth = maxHealth;
    }
    
    void OnEnable() 
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }

    private void OnDisable() 
    {
        ResetDrone();
    }

    IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(timeToSelfDestruct);
        TakeDamage(maxHealth);
    }
    
    private void ReturnToPool() {
        Pool.Release(this);
    }
    
    private void ResetDrone() {
        _currentHealth = maxHealth;
    }

    public void AttackPlayer() {
        Debug.Log("Attack player!");
    }

    public void TakeDamage(float amount) {
        _currentHealth -= amount;
        
        if (_currentHealth <= 0.0f)
            ReturnToPool();
    }
}

```
</div>
</details>


<details>
<summary>ClientObjectPool</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class ClientObjectPool : MonoBehaviour
{
    private DroneObjectPool _pool;
    
    void Start()
    {
        _pool = gameObject.AddComponent<DroneObjectPool>();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Spawn Drones"))
            _pool.Spawn();
    }
}


```
</div>
</details>

<br><br><br><br><br>
- - - 


## 전략 패턴(Strategy)
**드론구현**  
드론의 다양한 동작을 구현하는 상황  
**런타임에 특정 동작을 객체에 바로 할당**할 수 있음  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

context : 자신의 작업을 수행하는데 **필요한 전략을 선택**하는 클래스  
strategy : 전략 인터페이스를 구현한 클래스들로, **특정 행동을 제공**함
Client : 클라이언트에서 **context 클래스를 생성**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ec46bec5-1f43-4bc3-ac21-4f8094b5e626){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


**장점**  
&nbsp;&nbsp;1. **캡슐화** 잘 될 수 있음.  
&nbsp;&nbsp;2. 런타임에 객체가 사용하는 **알고리즘을 교환**할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


**전략 패턴과 상태패턴이 혼동될 수 있음, 구조가 유사하지만 의도가 매우 다름.**  
전략 패턴 : 같은 문제를 해결하는 여러 알고리즘이 있을 때 이들 중 하나를 런타임에 선택해야 할 때, 즉 **알고리즘 선택에 중점**  
상태 패턴 : 객체가 여러 상태를 가지고 있고, 상태에 따라 행동이 달라져야 할 때. 즉, **상태에 따른 행동 변경**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

<details>
<summary>Drone</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class Drone : MonoBehaviour {
    public void ApplyStrategy(IBehaviour strategy) {
        strategy.Maneuver(this);
    }
}
```
</div>
</details>


<details>
<summary>ClientStrategy</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using System.Collections.Generic;

public class ClientStrategy : MonoBehaviour {
    
    private GameObject _drone;
    private List<IBehaviour> 
        _components = new List<IBehaviour>();
    
    private void SpawnDrone() {
        _drone = 
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        _drone.AddComponent<Drone>();
        
        _drone.transform.position = 
            Random.insideUnitSphere * 10;
        
        ApplyRandomStrategies();
    }

    private void ApplyRandomStrategies() {
        _components.Add(
            _drone.AddComponent<Weaving>());
        _components.Add(
            _drone.AddComponent<Bopping>());
        _components.Add(
            _drone.AddComponent<Fallback>());
        
        int index = Random.Range(0, _components.Count);
        
        _drone.GetComponent<Drone>().
            ApplyStrategy(_components[index]);
    }
    
    void OnGUI() {
        if (GUILayout.Button("Spawn Drone")) {
            SpawnDrone();
        }
    }
}
```
</div>
</details>

<br><br><br><br><br>
- - - 

## 커맨드 패턴

커맨드 패턴은 게임 내에서 발생하는 모든 행동을 명령으로 캡슐화를 할 수 있음, 그리고 이 명령들은 모두 **쉽게 기록**이 됨!.  
기록을 재생하여 **리플레이 시스템**을 구현할 수 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

Client : 커맨드 **객체를 생성**, 그 커맨드가 어떤 **receiver와 연결될 지 결정**  
Invoker(호출자) : 커맨드를 받아서 실행함.  
Command(커맨드) : 실행될 모든 명령에 대한 인터페이스  
Receiver(수신자): 실제로 **작업을 수행할 객체**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/e7b43e8f-8a1b-4191-8f1b-3d3c563d1b3b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**장점**  
&nbsp;&nbsp;1. **분리** : 실행하는 객체와 호출하는 객체가 분리됨   
&nbsp;&nbsp;2. 명령하는 것을 **큐에 넣어서 리플레이**, **매크로**, 명령 큐 등을 구현할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


**단점**  
&nbsp;&nbsp;1. 각각의 명령을 하나의 클래스로 구현해야돼서 좀 **복잡함**.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

<details>
<summary>Command</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public abstract class Command
{
    public abstract void Execute();
}
```
</div>
</details>

<details>
<summary>TurnRight</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public class TurnRight : Command
{
    private CharacterController _controller;

    public TurnRight(CharacterController controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Turn(CharacterController.Direction.Right);
    }
}
```
</div>
</details>

<details>
<summary>TurnLeft</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public class TurnLeft : Command
{
    private CharacterController _controller;

    public TurnLeft(CharacterController controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Turn(CharacterController.Direction.Left);
    }
}
```
</div>
</details>

<details>
<summary>Invoker</summary>
<div class="notice--primary" markdown="1"> 

```c# 
class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, Command> _recordedCommands = 
        new SortedList<float, Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();
        
        if (_isRecording) 
            _recordedCommands.Add(_recordingTime, command);
        
        Debug.Log("Recorded Time: " + _recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        
        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands to replay!");
        
        _recordedCommands.Reverse();
    }
    
    void FixedUpdate()
    {
        if (_isRecording) 
            _recordingTime += Time.fixedDeltaTime;
        
        if (_isReplaying)
        {
            _replayTime += Time.fixedDeltaTime;

            if (_recordedCommands.Any()) 
            {
                if (Mathf.Approximately(
                    _replayTime, _recordedCommands.Keys[0])) {

                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + 
                                _recordedCommands.Values[0]);
                    
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}
```
</div>
</details>

<br><br><br><br><br>
- - - 


# 잡담,정리
SO 씬을 넘나드는 싱글톤?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
