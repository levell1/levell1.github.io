---
title:  "[Memo-Unity] 14. ParticleSystem  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-11 09:01

---
- - -

`ParticleSystem` 
<BR><BR>

<center><H1>  MaskLayer  </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. 파티클 시스템  
> - 파티클 시스템은 수 천개의 작은 2D 또는 3D 오브젝트들을 관리하고, 그들의 동작과 생애를 제어  
> - 주요 컴포넌트는 'emitter'(발사체), 'particles'(파티클), 'animator'(애니메이터), 'renderer'(렌더러) 등  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


**파티클**
ParticleSystem  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2373fd9c-55f5-4ffc-9950-e4750af92ce5)

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
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b7450b18-c90b-4f26-85d7-d08d537f5bb7)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/af86edff-c1e3-4315-bb97-d5b3ba97b3da)  

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
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ce78e50c-3b39-418b-8523-d5c3abc90624)  

**SetBurst**
![image](https://github.com/levell1/levell1.github.io/assets/96651722/4b1cac4f-1e24-4d70-99cf-85d7b659d991)  

**new PaticleSystem.Burst**
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6571ab2f-f8eb-4e89-bf34-7c3514e9ba40)  



<br><br><br><br><br><br>
- - - 

# 정리  

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}
<br><br>
- - - 

[Unity] ParticleSystem
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
