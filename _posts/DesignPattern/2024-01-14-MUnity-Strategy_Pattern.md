---
title:  "[Design Pattern] 9. 전략 패턴(Strategy)"
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:09

---
- - -
<BR><BR>


<center><H1> Strategy패턴   </H1></center>

`Strategy`

<br><br><br><br>
- - - 


# 전략 패턴(Strategy)
**드론구현**  
드론의 다양한 동작을 구현하는 상황  
**런타임에 특정 동작을 객체에 바로 할당**할 수 있음  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

context : 자신의 작업을 수행하는데 **필요한 전략을 선택**하는 클래스  
strategy : 전략 인터페이스를 구현한 클래스들로, **특정 행동을 제공**함
Client : 클라이언트에서 **context 클래스를 생성**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ec46bec5-1f43-4bc3-ac21-4f8094b5e626){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


**장점**  
&nbsp;&nbsp;1. **캡슐화** 잘 될 수 있음.  
&nbsp;&nbsp;2. 런타임에 객체가 사용하는 **알고리즘을 교환**할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


**전략 패턴과 상태패턴이 혼동될 수 있음, 구조가 유사하지만 의도가 매우 다름.**  
전략 패턴 : 같은 문제를 해결하는 여러 알고리즘이 있을 때 이들 중 하나를 런타임에 선택해야 할 때, 즉 **알고리즘 선택에 중점**  
상태 패턴 : 객체가 여러 상태를 가지고 있고, 상태에 따라 행동이 달라져야 할 때. 즉, **상태에 따른 행동 변경**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

<details>
<summary>Drone</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class Drone : MonoBehaviour {
    public void ApplyStrategy(IBehaviour strategy) {
        strategy.Maneuver(this);
    }
}
```
</div>
</details>

<br><br>

<details>
<summary>ClientStrategy</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using System.Collections.Generic;

public class ClientStrategy : MonoBehaviour {
    
    private GameObject _drone;
    private List<IBehaviour> 
        _components = new List<IBehaviour>();
    
    private void SpawnDrone() {
        _drone = 
            GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        _drone.AddComponent<Drone>();
        
        _drone.transform.position = 
            Random.insideUnitSphere * 10;
        
        ApplyRandomStrategies();
    }

    private void ApplyRandomStrategies() {
        _components.Add(
            _drone.AddComponent<Weaving>());
        _components.Add(
            _drone.AddComponent<Bopping>());
        _components.Add(
            _drone.AddComponent<Fallback>());
        
        int index = Random.Range(0, _components.Count);
        
        _drone.GetComponent<Drone>().
            ApplyStrategy(_components[index]);
    }
    
    void OnGUI() {
        if (GUILayout.Button("Spawn Drone")) {
            SpawnDrone();
        }
    }
}
```
</div>
</details>

<br><br><br><br><br><br>
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
