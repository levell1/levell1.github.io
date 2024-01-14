---
title:  "[Design Pattern] 3. 관찰자 패턴(observer)"
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:03

---
- - -
<BR><BR>

`관찰자(observer)`

<center><H1> 관찰자(observer) Pattern </H1></center>

<br><br><br><br><br><br>
- - - 

# 관찰자 패턴 (observer)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1a971805-1f06-4989-a18e-3cccc5c6223d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

> - 한 객체의 상태 변화를 관찰하는 다수의 객체(관찰자들)
> - 주인공 객체가 변하면 관찰자들에게도 자동으로 이를 알려줌
> - 상태 변화에 따른 자동 업데이트 (**`구동 시스템과 유사`**)
> - 의존성 줄이고 중요한 정보를 적절히 공유하는 형태
> - ex) 플레이어 체력변화에 따른 이벤트를 구현할 때 유용
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

<details>
<summary>observer 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 관찰자 인터페이스
public interface IObserver
{
    void Update(int health);
}

// 주인공 인터페이스
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// 플레이어 클래스 (주인공)
public class Player : ISubject
{
    private int health;
    private List<IObserver> observers = new List<IObserver>();

    public int Health
    {
        get { return health; }
        set 
        { 
            health = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(health);
        }
    }
}

// UI 클래스 (관찰자)
public class HealthDisplay : IObserver
{
    public void Update(int health)
    {
        Console.WriteLine("Health updated to: " + health);
        // UI 업데이트 로직
    }
}

// 옵저버 패ㄴ 사용 예시
Player player = new Player();
HealthDisplay display = new HealthDisplay();

player.Attach(display);
player.Health = 90; // 플레이어의 체력 변경. 자동으로 관찰자들에게 알림이 감. //set부분에 notify()

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
