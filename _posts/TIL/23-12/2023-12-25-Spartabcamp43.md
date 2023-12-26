---
title:  "[TIL] 43 반별강의(AI,NAV), 심화주차  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-25 02:00

---
- - -



<BR><BR>


<center><H1>  유니티 심화주차 3일 , 개인공부 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 48   
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [x] ui 2회차 듣기      
&nbsp;&nbsp; [x] 심화주차 강의 듣기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

<h2> 반별강의 </h2>

# 꿀팁
Simulator gameView 에서 simulator 로 변경하면 폰화면 미리보기 가능.  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/c7e5165a-ab9a-44a8-999a-126468b80cc0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

Window -> Analysis -> Profiler (ctrl+7) : 프레임,cpu, gpu, 메모리 등 사용량을 체크할 수 있다.  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/4847a5a5-671b-4f6a-987e-062faa562e9e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
그래픽 관련 최적화 Frame Debugger  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

인스펙터창 2개로 편하게 값 옮기기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/c8c69f9e-6914-408b-9e1e-70d44834cef1){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

Context Menu : 테스트용도로 특정함수 수동으로 호출할 때  
에셋 사용할 때 샘플을 보고 사용하자.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

# AI
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
