---
title:  "[Memo-Unity] 8. `EventBus`패턴  "
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:08

---
- - -
<BR><BR>
 
`EventBus`

<center><H1> EventBus패턴   </H1></center>

<br><br><br><br><br><br>
- - - 


# 이벤트 버스 패턴
**발행/구독** 패턴  
발행자와 구독자는 서로인식x **중간에 버스**가 있다.  
전역 이벤트를 관리하는 **중앙 허브 개념**  
게임에서 월드 이벤트 발생시 해당 캐릭터들에게 **이벤트를 발송**하는 식  
구현하기 의외로 매우 간단해서 많이 쓰임.  
어떤 객체에서 이벤트가 발생하면 다른 구독자가 신호를 받는 시스템  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**장점**  
&nbsp;&nbsp;1. 오브젝트를 직접 참조x, 이벤트 통신  
&nbsp;&nbsp;2. 구독 시스템을 쉽게 구현하게 만듬  
&nbsp;&nbsp;3. 프로토타입 만들 때 많이 쓰임 , 쉽고 빠르다  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp;1. 약간의 성능비용  
&nbsp;&nbsp;2. 이벤트 버스가 static 전역 변수라, 전역변수의 단점을 모두 가지게 됨.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning} 

**코드**  

<details>
<summary>EventBus 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine.Events;
using System.Collections.Generic;

public enum WorldEventType
{
    COUNTDOWN, START, PAUSE, STOP, FINISH, RESTART, QUIT
}


public class WorldEventBus
{
    private static readonly 
        IDictionary<WorldEventType, UnityEvent> 
        Events = new Dictionary<WorldEventType, UnityEvent>();

    public static void Subscribe
        (WorldEventType eventType, UnityAction listener) {
        
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscribe
        (WorldEventType type, UnityAction listener) {

        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(WorldEventType type) {

        UnityEvent thisEvent;

        if (Events.TryGetValue(type, out thisEvent)) {
            thisEvent.Invoke();
        }
    }
}
```
</div>
</details>

<br><br><br><br><br>
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
