---
title:  "[Unity6] 2D Behavior Tree 3( Chase, Attack  ) "
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-04-30 05:00

---
- - -


<br>
- - - 

# Chase, Attack 행동
1.&nbsp;Blackboard 거리변수추가  
**currentDistance** : Target과의 거리 체크  
**chaseDistance** : chaseDistance에 들어오면 따라가기  
**attackDistance** : attackDistance안에 들어오면 Attack  
**fallOutDistance** : fallOutDistance보다 멀어지면 Idle상태,순찰  
&nbsp;  
2.&nbsp;투사체, 무기 관련 작업  
3.&nbsp;EnemyPrefab - Behavior Agent, weapon 설정하기
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


**거리계산**  
새로운 **On Start** Node 생성(별도의 로직으로 처리)  
[UpdateDistance](https://levell1.github.io/go%20unity/GoUnityBehavior3/#updatedistance) CurrentDistance를 갱신  
[Conditional Branch, Create New Condition](https://levell1.github.io/go%20unity/GoUnityBehavior3/#conditional-branch-create-new-condition)로 조건(current, chaseDistance 비교)에 따라 IstargetDetected 변경  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior3_1.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br>

## Chase
**Target이attackDistance보다 멀면 따라가기 / 가까우면 Attack행동 Target이 fallOutDistance보다 멀어지면 Idle**  
[Chase](https://levell1.github.io/go%20unity/GoUnityBehavior3/#chase-1) : Self Navigation To Target  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_Chase.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

## Attack
**현재무기로 공격/ 타겟이 멀어지면 Idle**  
[Weapon](https://levell1.github.io/go%20unity/GoUnityBehavior3/#weapon) : Try Attack With currentWeapon  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_Attack.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br><br><br>

# New Action Node
**Chase** Action : Self Navigate To Target  
**UpdateDistance** Action : Update Self and Target CurrentDistance  
**Weapon** Action : try attack with CurrentWeapon  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

## Chase
**Chase Action** : agent의 속도, 이동위치 설정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<details>
<summary>EnemyState</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Self] Navigate To [Target]", category: "Action", id: "1b2920d167edfa9124c5af5b723e5a4d")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private NavMeshAgent agent;

    protected override Status OnStart()
    {
        agent = Self.Value.GetComponent<NavMeshAgent>();
        agent.speed = 5f;
        agent.SetDestination(Target.Value.transform.position);

        return Status.Running;
    }
}
```
</div>
</details>

<br>

## UpdateDistance
**UpdateDistance Action** : CurrentDistance(target과 자신과의 거리)를 갱신  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>EnemyState</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "UpdateDistance", story: "Update [Self] and [Target] [CurrentDistance]", category: "Action", id: "4e20c120715722a8167532f3cb55152d")]
public partial class UpdateDistanceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> CurrentDistance;

    protected override Status OnUpdate()
    {
        CurrentDistance.Value = Vector2.Distance(Self.Value.transform.position, Target.Value.transform.position);

        return Status.Success;
    }
}


```
</div>
</details>

<br>

## Weapon
**Weapon Action** : 무기에 맞게 TryAttack() 실행  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>EnemyState</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Weapon", story: "try attack with [CurrentWeapon]", category: "Action", id: "c4825c53b5e000692e69d1965c1a4f14")]
public partial class WeaponAction : Action
{
    [SerializeReference] public BlackboardVariable<WeaponBase> CurrentWeapon;

    protected override Status OnUpdate()
    {
        CurrentWeapon.Value.TryAttack();
        return Status.Success;
    }
}
```
</div>
</details>

<br><br><br>

# 이것저것 메모

## Conditional Branch, Create New Condition
조건(True, false)에 따라 노드를 실행하는 조건 분기 노드  
두 수 비교조건 Inspector - Assign Condition - Variable Comparison  
Create New Action과 같이 **Create New Condition**으로 새로운 조건을 생성할 수 있다.  
CheckTargetDetect : Compare values of CurrentDistance and ChaseDistance  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>CheckTargetDetectCondition</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckTargetDetect", story: "Compare values of [CurrentDistance] and [ChaseDistance]", category: "Conditions", id: "d502e9fb2afcf10ac06045774d095dd5")]
public partial class CheckTargetDetectCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> CurrentDistance;
    [SerializeReference] public BlackboardVariable<float> ChaseDistance;

    
    public override bool IsTrue()
    {
        if (CurrentDistance.Value <= ChaseDistance.Value)
        {
            return true;
        }

        return false;
    }
}

```
</div>
</details>


<br><br><br>
- - - 

# 잡담, 일기?
Behavior 마무리  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -