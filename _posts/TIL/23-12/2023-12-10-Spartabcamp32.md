---
title:  "[TIL] 32 투사체 구현하기   ⭐⭐ "
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

`MaskLayer`, `TrailRenderer` 

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

# 정리  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  



<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
