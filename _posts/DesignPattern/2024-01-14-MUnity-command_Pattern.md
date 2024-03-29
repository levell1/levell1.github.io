---
title:  "[Design Pattern] 4. 커맨드 패턴(command) "
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



<center><H1> 커맨드(command)패턴   </H1></center>

`커맨드(command)패턴`  

<br><br><br><br>
- - - 

# 커맨드 패턴 (command)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1371e2fd-0f79-40d6-b145-98031ff04923){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

> - 버튼을 누르는 행위랑 발생하는 행동을 분리하는 패턴
> - 입력을 다룰 때 많이 사용하는 패턴  
> - 사용자의 요청을 발생시킨 코드와 요청을 수행하는 코드 사이의 의존성을 줄이는 것
> - 입력 처리를 깔끔, 유연하게 관리, 명령을 추가, 재사용 쉬워짐
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

커맨드 패턴은 게임 내에서 발생하는 모든 행동을 명령으로 캡슐화를 할 수 있음, 그리고 이 명령들은 모두 **쉽게 기록**이 됨!.  
기록을 재생하여 **리플레이 시스템**을 구현할 수 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

Client : 커맨드 **객체를 생성**, 그 커맨드가 어떤 **receiver와 연결될 지 결정**  
Invoker(호출자) : 커맨드를 받아서 실행함.  
Command(커맨드) : 실행될 모든 명령에 대한 인터페이스  
Receiver(수신자): 실제로 **작업을 수행할 객체**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

![image](https://github.com/levell1/levell1.github.io/assets/96651722/e7b43e8f-8a1b-4191-8f1b-3d3c563d1b3b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**장점**  
&nbsp;&nbsp;1. **분리** : 실행하는 객체와 호출하는 객체가 분리됨   
&nbsp;&nbsp;2. 명령하는 것을 **큐에 넣어서 리플레이**, **매크로**, 명령 큐 등을 구현할 수 있음.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


**단점**  
&nbsp;&nbsp;1. 각각의 명령을 하나의 클래스로 구현해야돼서 좀 **복잡함**.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 


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

<details>
<summary>Command</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public abstract class Command
{
    public abstract void Execute();
}
```
</div>
</details>

<details>
<summary>TurnRight</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public class TurnRight : Command
{
    private CharacterController _controller;

    public TurnRight(CharacterController controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Turn(CharacterController.Direction.Right);
    }
}
```
</div>
</details>

<details>
<summary>TurnLeft</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public class TurnLeft : Command
{
    private CharacterController _controller;

    public TurnLeft(CharacterController controller)
    {
        _controller = controller;
    }

    public override void Execute()
    {
        _controller.Turn(CharacterController.Direction.Left);
    }
}
```
</div>
</details>

<details>
<summary>Invoker</summary>
<div class="notice--primary" markdown="1"> 

```c# 
class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    private SortedList<float, Command> _recordedCommands = 
        new SortedList<float, Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();
        
        if (_isRecording) 
            _recordedCommands.Add(_recordingTime, command);
        
        Debug.Log("Recorded Time: " + _recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    public void Record()
    {
        _recordingTime = 0.0f;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0.0f;
        _isReplaying = true;
        
        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands to replay!");
        
        _recordedCommands.Reverse();
    }
    
    void FixedUpdate()
    {
        if (_isRecording) 
            _recordingTime += Time.fixedDeltaTime;
        
        if (_isReplaying)
        {
            _replayTime += Time.fixedDeltaTime;

            if (_recordedCommands.Any()) 
            {
                if (Mathf.Approximately(
                    _replayTime, _recordedCommands.Keys[0])) {

                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + 
                                _recordedCommands.Values[0]);
                    
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
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
