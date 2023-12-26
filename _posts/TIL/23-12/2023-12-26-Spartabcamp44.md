---
title:  "[TIL] 44 반별강의(Design_Pattern), 심화주차  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-26 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 심화주차 4일 , 개인공부 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 49   
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [o] 디자인 패턴 복습하기  
&nbsp;&nbsp; [x] ui 2회차 듣기      
&nbsp;&nbsp; [x] 심화주차 강의 듣기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

<h2> 반별강의 </h2>

# 디자인 패턴
[디자인 패턴](https://levell1.github.io/memo%20unity/MUnity-Design_Pattern/)  


# 델리게이트, 이벤트
개발자가 정의한 특정조건이나 행동에 반응하는 사용자 정의 이벤트  

> - 델리게이트  
>  c#  에서 메소드를 참조하는 타입  
>  메소드의 참조를 변수에 저장하고, 다른 메소드로 전달, 호출을 동적으로 결정할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br>

> - 이벤트  
> 이벤트는 델리게이트를 기반으로 함  
> 특정 상황이 발생했을 때 이벤트를 구독하는 모든 메소드를 호출하는데 사용됨.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

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
		clone = Instantiate(particle, animator.rootPosition, Quaternion.identity) as GameObject;
		Rigidbody rb = clone.GetComponent<Rigidbody>();
		rb.AddExplosionForce(power, animator.rootPosition, radius, 3.0f);
	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
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

</div>
</details>

## behaviour tree

**루트(root) 노드** CS에서의 트리의 뿌리는 항상 제일 아래에 있지 않고 제일 위에 있습니다.
**흐름 제어** 노드 (flow-control node)
- **Sequence node** : AND 역할을 하는 노드
- **Selector node** : OR 역할을 하는 

**리프(leaf) 노드** : 실제 행동이 들어가 있는 노드

![image](https://github.com/levell1/levell1.github.io/assets/96651722/361936dd-c77a-4ab0-b15e-351a606e36d0)

<details>
<summary>node</summary>

<div class="notice--primary" markdown="1"> 

```c#
public enum NodeState
{
    Running,
    Failure,
    Success
}

public abstract class Node
{
    protected NodeState state;
    public Node parentNode;
    protected List<Node> childrenNode = new List<Node>();

    public Node()
    {
        parentNode = null;
    }

    public Node(List<Node> children)
    {
        foreach(var child in children)
        {
            AttatchChild(child);
        }
    }

    public void AttatchChild(Node child)
    {
        childrenNode.Add(child);
        child.parentNode = this;
    }

    public abstract NodeState Evaluate();
}

public class SequenceNode : Node
{
    public SequenceNode() : base() {}

    public SequenceNode(List<Node> children) : base(children) {}

    public override NodeState Evaluate()
    {
        bool bNowRunning = false;
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Failure:
                    return state = NodeState.Failure;
                case NodeState.Success:
                    continue;
                case NodeState.Running:
                    bNowRunning = true;
                    continue;
                default:
                    continue;
            }
        }

        return state = bNowRunning ? NodeState.Running : NodeState.Success;
    }
}

public class SelectorNode : Node
{
    public SelectorNode() : base(){}

    public SelectorNode(List<Node> children) : base(children){}

    public override NodeState Evaluate()
    {
        foreach(Node node in childrenNode)
        {
            switch(node.Evaluate())
            {
                case NodeState.Failure:
                    continue;
                case NodeState.Success:
                    return state = NodeState.Success;
                case NodeState.Running:
                    return state = NodeState.Running;
                default:
                    continue;
            }
        }

        return state = NodeState.Failure;
    }
}

```

</div>
</details>



# 잡담,정리
Simulator gameView 에서 simulator 로 변경하면 폰화면 미리보기 가능.  
Window -> Analysis -> Profiler : 프레임,cpu, gpu, 메모리 등 사용량을 체크할 수 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

**리더**  
좋은 리더란 무엇인가?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
