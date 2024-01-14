---
title:  "[Design Pattern] 10. Object Pool"
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:10

---
- - -
<BR><BR>


<center><H1> Object Pool   </H1></center>

`Object Pool`

<br><br><br><br>
- - - 

# Object Pool
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

<br><br>

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

<br><br>

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

# 잡담, 정리
> - 디자인 패턴은 애초에 특정 문제를 해결하기 위해 고려된 것.(성능, 메모리 사용 고려)
> - 추가 내용 정리
{: .notice--success} 

<br><br>
- - - 

[C#] 디자인 패턴 (Design Pattern)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
