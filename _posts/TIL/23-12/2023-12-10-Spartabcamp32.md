---
title:  "[TIL] 32 투사체 구현하기, Objectpool, AnimationController   ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-10 02:00

---
- - -

`MaskLayer`, `TrailRenderer` `Objectpool`,`AnimationController`
![image](https://github.com/levell1/levell1.github.io/assets/96651722/95166e39-3981-4648-8d07-04f026f1a83b)
<BR><BR>


<center><H1>  유니티 숙련주차 3일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 43  
&nbsp;&nbsp; [o] 강의 듣기 - 2강~  
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 투사체 구현 

## onFire ->
실행 순서  PlayerInputController.cs OnFire ->  
TopDownCharacterController.cs (update - HandleAttackDelay -  OnAttackEvent?.Invoke(attackSO))
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
<div class="notice--primary" markdown="1"> 

```c#

// PlayerInputController.cs
PlayerInputController : TopDownCharacterController
public void OnFire(InputValue value)
{
    IsAttacking = value.isPressed; //value 는 좌클릭버튼
}


// TopDownCharacterController.cs
 protected bool IsAttacking {  get;  set; }

 protected virtual void Update()
 {
     HandleAttackDelay();   
 }

 private void HandleAttackDelay()
 {
     if (_timeSinceLastAttack <= Stats.CurrentStates.attackSO.delay)
     {
         _timeSinceLastAttack += Time.deltaTime;
     }

     if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStates.attackSO.delay)
     {
         _timeSinceLastAttack = 0;
         CallAttackEvent(Stats.CurrentStates.attackSO);
     }
 }
 // TopDownCharacterController.cs - OnAttackEvent 실행
     public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }


// -> TopDownShooting.cs -> OnAttackEvent += OnShoot;

```
</div>

<br><br>

## OnAttackEvent += OnShoot
TopDownShooting.cs -> Onshoot 이벤트에 추가  
_controller.OnAttackEvent += OnShoot;  
CreateProjectile ->  
ProjectileManager.cs ShootBullet() 에서 투사체생성   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c#

// TopDownShooting.cs
void Start()
{
    _projectileManager = ProjectileManager.instance;
    _controller.OnAttackEvent += OnShoot; // 이벤트에 OnShoot 추가
    _controller.OnLookEvent += OnAim;
}

// TopDownShooting.cs - OnShoot 
private void OnShoot(AttackSO attackSO)
{
    RangedAttackData rangedAttackData = attackSO as RangedAttackData;
    float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
    int numberOfProjectilesPerShot = rangedAttackData.numberofProjectilesPerShot;

    float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;


    for (int i = 0; i < numberOfProjectilesPerShot; i++)
    {
        float angle = minAngle + projectilesAngleSpace * i;
        float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
        angle += randomSpread;
        CreateProjectile(rangedAttackData, angle);
    }
// TopDownShooting.cs - CreateProjectile
private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
{
    _projectileManager.ShootBullet( // -> ProjectileManager.cs
            projectileSpawnPosition.position,
            RotateVector2(_aimDirection, angle),
            rangedAttackData
            );
}


// ProjectileManager.cs
public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedAttackData attackData)
{
    GameObject obj = Instantiate(testObj);  //생성
    
    //세팅
    obj.transform.position = startPostiion;
    RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
    attackController.InitializeAttack(direction, attackData, this);

    obj.SetActive(true);    //setActive True
}
```
</div>

<br><br><br><br><br>
- - -


# 2. MaskLayerm, TrailRenderer
[MaskLayer,TrailRenderer](https://levell1.github.io/memo%20unity/MUnity-MaskLayer/)  

<br><br><br><br><br>
- - -

# 3. Object Pool
Tag 를 이용해 사용  
size만큼 생성 후  
size개수 Dequeue, Enqueue 로 사용  
한번에 size이상 setactive 되면문제가 생김  
size늘리거나 , 다른방법  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject> ();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue (obj);
            }
            poolDictionary.Add (pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}

//ProjectileManager.cs 태그를 이용해 실행
GameObject obj = objectPool.SpawnFromPool(attackData.bulletNameTag);
```
</div>

RangedAttackData Bullet Name Tag
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ebc59f41-5a7e-43c1-b9b6-e3505eb72b2c)  

ProjectileManager.cs Tag  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/36a504a9-d6a5-4015-abb5-86baf5e2141a)

현재 list는 1개 , dictionary도 1개  
queue 에 GameObject(Arrow)를 저장해두고  Dequeue 로 뺴고 리턴  
리턴하기전 Queue 에 다음에 Dequeue 할 Arrow 저장 해두기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
<br><br><br><br><br>
- - -

# 4. Animations

상수 readonly  
StringToHash  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c#
// TopDownAnimatorController.cs : TopDownAnimations
private static readonly int IsWalking = Animator.StringToHash("IsWalking");
private static readonly int Attack = Animator.StringToHash("Attack");
private static readonly int IsHit = Animator.StringToHash("IsHit");
```

- StringToHash 스트링값을 hash 숫자값으로 변환 - 스트링비교연산 비용높기떄문에 숫자값으로 비교
- const는 컴파일 타임의 상수 선언과 동시에 초기화 변경 X
- readonly 런타임 상수 프로그램이 실행중에 초기화 하는것도 가능, 선언과동시에 초기화도 가능
</div>


**BaseLayer**
![image](https://github.com/levell1/levell1.github.io/assets/96651722/66fa9c7b-9817-45f6-b129-ac5fa13fe129)

**AttackLayer**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9b45ea50-3b04-42a8-8219-5e21e0a2a446)

<br><br><br><br><br>
- - -

# 정리  
 

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
