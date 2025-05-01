---
title:  "[Unity6] 2D Behavior Tree 2( Enumeration -Idle, Patrol, Wander  ) "
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-04-29 05:00

---
- - -


<br>
- - - 

# 열거형을 이용한 행동 관리
1.&nbsp;BlackBoard -> (+) -> **Enumeration**  
&nbsp;  
2.&nbsp;Enumeration생성 (currentState)  (Idle, Patrol, Wander, Chase, Attack)  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_1.png?raw=true)  
&nbsp;  
3.&nbsp;**Switch** 노드 추가 -> currentState (열거형이 자식노드로 자동생성)  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_3.png?raw=true)  
4.&nbsp;**Try in order**, **Abort**(타겟이 있으면 중단), **Random**, **Set Variable Value** 노드를 사용하여 행동변환  
&nbsp;- 각 노드 [Node](https://levell1.github.io/go%20unity/GoUnityBehavior2/#node)에 설명  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br>

## Idle
**Target이 범위에 없으면 1~3초 대기 후 Patrol, Wander상태로, 있다면 Chase**  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_idle.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

## Patrol
**Target이 없다면 순찰 (10초가 지나면 대기살태로 변경), 있다면 Chase**  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_patrol.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

## Wander
**Target이 없다면 임의의위치로 배회, 있다면 Chase**  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_Wander.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br>

# Node
✔ **Switch** : Enumeration를 선택하면 열거형이 자식노드로 자동생성됩니다.  
&nbsp;  
✔ **Try in order** : 성공할 때까지 분기를 순서대로 실행(좌->우)  
&nbsp;  
✔ **Abort** : 지정된 조건이 참이면 해당 분기 중단  
&nbsp;&nbsp; Inspector 뷰에서 설정가능 (변수값 비교)  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_4.png?raw=true)  
&nbsp;  
✔ **Random** : 임의의 자식노드를 선택해서 실행  
&nbsp;  
✔ **Set Variable Value** : Blackboard에 있는 변수 값을 설정하는 노드  
&nbsp;  
✔ [Create New Action](https://levell1.github.io/go%20unity/GoUnityBehavior2/#create-new-action-node) : 새로운 행동 노드 구현   
&nbsp;- 원하는 노드가 없으면 직접 새로운 노드를 만들 수 있습니다.   
&nbsp;- 단어 단위로 뛰어쓰기 하며 단어마다 변수, 일반 텍스트 형식으로 설정 가능합니다.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br>

# 이것저것 메모

## BlackboardEnum
EnemyState(**BlackboardEnum**)  
일반적인 Enum에 **BlackboardEnum** 어트리뷰트를 이용해 미리 생성해서 BlackBoard에서 바로 생성 가능하다.  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_2.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>EnemyState</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using Unity.Behavior;

[BlackboardEnum]
public enum EnemyState
{
    Idle,
	Patrol,
	Wandor,
	Chase,
	Attack
}
```
</div>
</details>

## Create New Action Node
모든 노드는 ⭐ NodeDescription 어트리뷰트에 노드의 이름, Story, Category, id 정보가 출력된다.  
⭐SerializeReference를 사용하고, **BlackboardVariable<>**로 선언하면 Behavior Graph의 Intpector에 변수 노출이 가능합니다.  
OnStart(), OnUdpdate(), OnEnd()  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


**Behavior Graph에서 생성**  
Add - Action - Create New Action  
**Name : Wander로 하면 WanderAction.cs 스크립트가 생성**  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_CreateActionNode.png?raw=true)  
&nbsp;  
**Story : 단어 단위로 뛰어쓰기 하며 단어마다 변수, 일반 텍스트 형식으로 설정 가능합니다.**  
&nbsp;![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2_CreateActionNode2.png?raw=true)  
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

//모든 노드는  NodeDescription 어트리뷰트에 노드의 이름, Story, Category, id 정보가 출력된다.  
[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Wander", story: "[Self] Navigate To WanderPosition", category: "Action", id: "7ca2472cbc539bcb9415b66682de271e")]
public partial class WanderAction : Action
{
    //SerializeReference를 사용하고, BlackboardVariable<>로 선언하면 Behavior Graph의 Intpector에 변수 노출이 가능합니다.  
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    private NavMeshAgent agent;
    private Vector3 wanderPosition;
    private float currentWanderTime = 0f;
    private float maxWanderTime = 5f;

    protected override Status OnStart()
    {
        int jitterMin = 0;
        int jitterMax = 360;
        float wanderRadius = UnityEngine.Random.Range(2.5f, 6f);
        int wanderJitter = UnityEngine.Random.Range(jitterMin, jitterMax);

        // 목표 위치 = 자신(Self)의 위치 + 각도(wanderJitter)에 해당하는 반지름(wanderRadius) 크기의 원의 둘레 위치
        wanderPosition = Self.Value.transform.position + Utils.GetPositionFromAngle(wanderRadius, wanderJitter);
        agent = Self.Value.GetComponent<NavMeshAgent>();
        agent.SetDestination(wanderPosition);
        currentWanderTime = Time.time;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if ((wanderPosition - Self.Value.transform.position).sqrMagnitude < 0.1f
            || Time.time - currentWanderTime > maxWanderTime)
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}
```
</div>
</details>

<br><br><br>
- - - 

# 잡담, 일기?
열거형을 이용한 행동 관리  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -