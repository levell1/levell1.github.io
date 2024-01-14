---
title:  "[Design Pattern] 5. 컴포넌트 패턴(component)"
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:05

---
- - -
<BR><BR>
 

<center><H1> component패턴   </H1></center>

`component` 

<br><br><br><br>
- - - 

# 5. 컴포넌트 패턴 (component)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a3a13fc7-deb3-4c97-861d-06b092bea969){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

> - 객체의 행동을 작은 부품(Componenet) 으로 분리
> - 부품을 조합하여 복잡한 동장을 구현하는 방식
{: .notice--info} 

<details>
<summary>component 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 컴포넌트 인터페이스
public interface IComponent
{
    void Update();
}

// 구체적인 컴포넌트 클래스들
public class MovementComponent : IComponent
{
    public void Update()
    {
        // 이동 관련 로직
    }
}

public class JumpComponent : IComponent
{
    public void Update()
    {
        // 점프 관련 로직
    }
}

// 게임 오브젝트 클래스
public class GameObject
{
    private List<IComponent> components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }

    public void Update()
    {
        foreach (var component in components)
        {
            component.Update();
        }
    }
}

// 사용 예시
GameObject player = new GameObject();
player.AddComponent(new MovementComponent());
player.AddComponent(new JumpComponent());

player.Update();
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
