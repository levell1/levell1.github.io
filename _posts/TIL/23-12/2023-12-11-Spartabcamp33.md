---
title:  "[TIL] 33  파티클, 사운드  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-11 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 4일차  + 개인과제 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 43  
&nbsp;&nbsp; [o] 강의 듣기 - 15강~  
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 투사체 raycast 

> - Unity에서는 **`Physics.Raycast`** 또는 **`Physics2D.Raycast`**를 사용하여 Raycast를 수행할 수 있습니다. 이들 메서드는 시작점, 방향, 최대 거리, 그리고 선택적으로 레이어 마스크를 매개변수로 받습니다.
> - Raycast는 비주얼 디버깅을 위해 **`Debug.DrawRay`**와 함께 사용할 수 있습니다. 이를 통해 Scene 뷰에서 Raycast의 경로를 시각적으로 확인할 수 있습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**`Debug.DrawRay`**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5ef37f9c-30fc-4a5d-bac9-d40c2e22c6f8)  


<div class="notice--primary" markdown="1"> 

```c#
// TopDownRangeEnemyController.cs : TopDownEnemyController
int layerMaskTarget = Stats.CurrentStates.attackSO.target;
RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 11f, (1 << LayerMask.NameToLayer("Level")) | layerMaskTarget);
Debug.DrawRay(transform.position, direction, Color.green);
```

</div>

[raycast1](https://levell1.github.io/go%20unity/3DGoUnity4/#raycast)  

<br><br><br><br><br>
- - -

# 2. 넉백구현 

입력을 받지 않으면 knockbackDuration이 줄어들지 않는다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c#
// TopDownMovement
    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;

        if (knockbackDuration > 0.0f)
        {
            direction += _knockback;
        }
        _rigidbody.velocity = direction;
        knockbackDuration -= Time.fixedDeltaTime;
    }
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    }
}
```

- 코드에서 OnMove (방향키 입력 받을 때) 만  knockbackDuration -= Time.fixedDeltaTime; 가 된다. 그러므로 넉백이 계속 발생하는 현상이 있다고 생각했다.
- 코드를 ApplyMovement 부분에 넣었고 update가 되며 넉백시간이 적용되게 하였다.
</div>


<br><br><br><br><br>
- - -

# 3. 파티클 시스템  
> - 파티클 시스템은 수 천개의 작은 2D 또는 3D 오브젝트들을 관리하고, 그들의 동작과 생애를 제어  
> - 주요 컴포넌트는 'emitter'(발사체), 'particles'(파티클), 'animator'(애니메이터), 'renderer'(렌더러) 등  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


**파티클**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2373fd9c-55f5-4ffc-9950-e4750af92ce5){:style="border:1px solid #EAEAEA; border-radius: 7px;"}

<div class="notice--primary" markdown="1"> 

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleControl : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;
    [SerializeField] private ParticleSystem dustParticleSystem;

    public void CreateDustParticles()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
```
</div>

**애니메이션 이벤트 추가**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b7450b18-c90b-4f26-85d7-d08d537f5bb7){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/af86edff-c1e3-4315-bb97-d5b3ba97b3da){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

## 타격 시 파티클

<div class="notice--primary" markdown="1"> 

```c#
ProjectileManager 수정
public void CreateImpactParticlesAtPostion(Vector3 position, RangedAttackData attackData)
{
    _impactParticleSystem.transform.position = position;
    ParticleSystem.EmissionModule em = _impactParticleSystem.emission;
    em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(attackData.size * 5)));
    ParticleSystem.MainModule mainModule = _impactParticleSystem.main;
    mainModule.startSpeedMultiplier = attackData.size * 10f;
    _impactParticleSystem.Play();
}
​
RangedAttackController 수정
private void DestroyProjectile(Vector3 position, bool createFx)
{
    if(createFx)
    {
        _projectileManager.CreateImpactParticlesAtPostion(position, _attackData);
    }
    gameObject.SetActive(false);
}
```
</div>

**Particle System-Emission**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ce78e50c-3b39-418b-8523-d5c3abc90624){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

**SetBurst**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/4b1cac4f-1e24-4d70-99cf-85d7b659d991){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

**new PaticleSystem.Burst**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6571ab2f-f8eb-4e89-bf34-7c3514e9ba40){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    



<br><br><br><br><br>
- - -

# 4. 사운드
[Sound](https://levell1.github.io/memo%20unity/MUnity-Sound/)  

<br><br><br><br><br>
- - -

# 5. collider 2D 2개

trigger충돌도 추가로 가능  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/fe847b2e-69e4-4ad8-9f2f-ef3f5e6a6b84){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - -

# 6. setACtive, enabled  
[setACtive, enabled 차이](https://levell1.github.io/memo%20unity/MUnity-enabled/)  

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
