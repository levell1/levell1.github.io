---
title:  "[Memo-Unity] 4.`command`패턴 "
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:04

---
- - -
<BR><BR>

`커맨드(command)패턴`  

<center><H1> 커맨드(command)패턴   </H1></center>

<br><br><br><br><br><br>
- - - 

# 커맨드 패턴 (command)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1371e2fd-0f79-40d6-b145-98031ff04923){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

> - 버튼을 누르는 행위랑 발생하는 행동을 분리하는 패턴
> - 입력을 다룰 때 많이 사용하는 패턴  
> - 사용자의 요청을 발생시킨 코드와 요청을 수행하는 코드 사이의 의존성을 줄이는 것
> - 입력 처리를 깔끔, 유연하게 관리, 명령을 추가, 재사용 쉬워짐
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>command 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 커맨드 인터페이스
public interface ICommand
{
    void Execute();
}

// 구체적인 커맨드 클래스들. 이동 요청 클래스
public class MoveCommand : ICommand
{
    private Player player;
    private float x, y;

    public MoveCommand(Player player, float x, float y)
    {
        this.player = player;
        this.x = x;
        this.y = y;
    }

    public void Execute()
    {
        player.Move(x, y);
    }
}

// 점프 요청 클래스
public class JumpCommand : ICommand
{
    private Player player;

    public JumpCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Jump();
    }
}

// 플레이어 클래스
public class Player
{
    public void Move(float x, float y)
    {
        // 이동 로직
    }

    public void Jump()
    {
        // 점프 로직
    }
}

// 커맨드 사용
Player player = new Player();
ICommand moveCommand = new MoveCommand(player, 1.0f, 0.0f);
ICommand jumpCommand = new JumpCommand(player);

moveCommand.Execute(); // 플레이어 이동
jumpCommand.Execute(); // 플레이어 점프
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
