---
title:  "[Memo-Unity] 7. 코루틴 (Coroutine)"
excerpt: "데이터 보관"

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-10-24
update: 2023-12-18
---
- - -
<BR><BR>

<center><H1> 코루틴 (Coroutine) </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. 코루틴 (Coroutine)
코루틴을 사용하면 작업을 다수의 프레임에 분산할 수 있습니다.  
Unity에서 코루틴은 실행을 일시 정지하고 제어를 Unity에 반환하지만 중단한 부분에서 다음 프레임을 계속할 수 있는 메서드입니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

대부분의 경우 메서드를 호출하면 실행을 완료한 뒤 호출한 메서드에 제어와 선택적 반환 값을 반환합니다. 즉 메서드 내에서 발생한 모든 행동은 단일 프레임 업데이트 내에서 발생해야 합니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

시간의 흐름에 따른 이벤트의 시퀀스나 절차상의 애니메이션을 포함하기 위해 메서드 콜을 사용하고자 하는 상황에서 코루틴을 사용할 수 있습니다.  
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
void Update()
{
    if (Input.GetKeyDown("f"))
    {
        StartCoroutine(DoCheck());
    }
}

IEnumerator DoCheck()
{
    for(;;)
    {
        //실행코드
        yield return new WaitForSeconds(.1f);
    }
}
```

-   StartCoroutine(DoCheck()); 로 코루틴함수 사용
-   IEnumerator DoCheck()  ~~~
-   WaitForSeconds(xf); x초간  WaitForSeconds
</div>

<br><br><br><br><br><br>
- - - 

# 2. 코루틴 정지
> StopCoroutine과 StopAllCoroutines을 사용하여 코루틴을 정지할 수 있습니다.   
> 코루틴에 연결된 게임오브젝트를 비활성화하기 위해 SetActive를 false로 설정하면 코루틴이 정지됩니다.  
> Destroy(example) (여기서 example은 MonoBehaviour의 인스턴스)를 호출하면 OnDisable을 즉시 트리거하며 Unity는 코루틴을 처리하여 효과적으로 정지시킵니다. 마지막으로 OnDestroy는 프레임 끝에서 호출됩니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<br><br><br><br><br><br>
- - - 

# 3. 12/18 추가
코루틴은 함수의 실행을 일시 중지하고, 이후에 다시 재개할 수 있는 기능을 제공합니다.  
예시) 무적상태 5초 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    bool invincible = false;

    void Start()
    {
        StartCoroutine(InvincibilityCoroutine());
    }

    IEnumerator InvincibilityCoroutine()
    {
        invincible = true;
        yield return new WaitForSeconds(5f);
        invincible = false;
    }
}

```
</div>

<br><br><br><br><br><br>
- - - 


# 4. Yeild 종류

> - yield return null : `다음 프레임`까지 대기
> - yield return new WaitForSeconds(float) : 입력한 `초(sec)` 만큼 대기
> - yield return new WaitForSecondsRealtime(float) : Timescale영향없는 `실제 시간` 기준 초 대기
> - yield return new WaitFixedUpdate() : 다음 프레임의 `FixedUpdate` 까지 대기
> - yield return new WaitForEndOfFrame() : 모든 `랜더링 작업이 끝날 때`까지 대기
> - yield return startCoroutiune(string) : 입력한 `다른 코루틴이 끝날 때`까지 대기
> - yield return new www(string) : 입력한 `웹 통신 작업이 끝날 때`까지 대기
> - yield break : 코루틴 종료
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

코루틴은 StopCoroutine과 StopAllCoroutines를 이용하여 코루틴을 정지가능하며  
코루틴을 소유하고 있는 게임오브젝트를 정지하거나 파괴하는 경우에도 종료됩니다. 단, 컴포넌트를 .enabled를 false로 하는 경우 꺼지지 않습니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<br><br><br><br><br><br>
- - - 

# 5. Enumerator
> - Enumerator는 IEnumerator 라는 인터페이스를 구현해야 합니다.  
> - IEnumerator 인터페이스는 Current (속성), MoveNext() (메서드), Reset() (메서드) 등 3개의 멤버로 이루어져 있는데,  
> Enumerator가 되기 위해서는 Current와 MoveNext() 를 반드시 구현해야 합니다.  
> 이를 통해 유니티의 DelayedCallManager가 등록하고 있다가 다음 단계에 실행하는 방식으로 구현되어 있습니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<br><br><br><br><br><br>
- - - 

# 24.01.01 추가
> - 다수의 프레임에 분산시켜서 실행할 수 있는 문법  
> - 일반 메서드는 1프레임에 실행  
> - 코루틴은 동시적이다, 비동기 X  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c# 
Coroutine coroutine = null

void Update()
{
    coroutine = StartCoroutine(CoFade())

    if(input.GetKeyDown("t"))
    {
        if(coroutine !=null) StopCoroutine(coroutine)
    }
}

```
- StopCoroutine(함수명()) 은 원하는 때에 멈추지 않을 수도 있다.  
- StopCoroutine("함수명"), stopAllCoroutine  
- StopCoroutine("함수명")은 추적이안된다.  
- 위 방법으로 변수를 이용해서 사용하자.  

</div>

> - Waitforsecont 보다 게임의 프레임을 맞추고 waitforendofframe을 쓰면 모든컴퓨터의 기준을 똑같이 가능.  
> - yield return WWW 서버관련  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br><br>
- - - 

[C#] 코루틴 (Coroutine)
[참조](https://docs.unity3d.com/kr/2021.3/Manual/Coroutines.html)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
