---
title:  "[Memo-Unity] 29. StateMachine  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-26 01:12

---
- - -

`StateMachine` `OnStateEnter` `OnStateExit` `OnStateUpdate`
<BR><BR>

<center><H1>  StateMachine  </H1></center>
StateMachine  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
<br><br><br><br><br><br>
- - - 


# StateMachine
StateMachine StateMachineBehaviour  
유니티에서는 StateMachine을 직접 구현할 수도 있고, 유니티에서 애니메이터에 확장하여 사용할 수 있는 StateMachineBehaviour를 제공합니다.  

<details>
<summary>StateMachine.cs</summary>

<div class="notice--primary" markdown="1"> 

```c#
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
	public GameObject particle;
	public float radius;
	public float power;
	
	protected GameObject clone;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
        Debug.Log("OnStateEnter ");
		clone = Instantiate(particle, animator.rootPosition, Quaternion.identity) as GameObject;
		Rigidbody rb = clone.GetComponent<Rigidbody>();
		rb.AddExplosionForce(power, animator.rootPosition, radius, 3.0f);
	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
        Debug.Log("OnStateExit ");
		Destroy(clone);
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("On Attack Update ");
	}
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("On Attack Move ");
	}
	override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("On Attack IK ");
	}
}
```

- OnStateEnter 애니메이션 실행 시
- OnStateExit  애니메이션 종료 시
- OnStateUpdate 매 프레임마다 실행
- OnAnimatorMove: 업데이트 프레임마다 루트 모션을 수정할 수 있도록 각 Animator 컴포넌트에 대해 한 번 호출됩니다.
- OnAnimatorIK: 애니메이션 IK를 설정합니다. IK pass가 활성화된 각 애니메이터 컨트롤러 레이어에 대해 한 번 호출됩니다.
	
</div>
</details>


<br><br><br><br><br>
- - - 

# 잡담
애니메이션에 스크립트 사용 StateMachineBehaviour
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] StateMachine
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
