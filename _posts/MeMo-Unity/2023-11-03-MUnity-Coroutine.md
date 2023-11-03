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

---
- - -
<BR><BR>

<center><H1> 코루틴 (Coroutine) </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. 코루틴 (Coroutine)
코루틴을 사용하면 작업을 다수의 프레임에 분산할 수 있습니다.  
Unity에서 코루틴은 실행을 일시 정지하고 제어를 Unity에 반환하지만 중단한 부분에서 다음 프레임을 계속할 수 있는 메서드입니다.  
대부분의 경우 메서드를 호출하면 실행을 완료한 뒤 호출한 메서드에 제어와 선택적 반환 값을 반환합니다. 즉 메서드 내에서 발생한 모든 행동은 단일 프레임 업데이트 내에서 발생해야 합니다.  
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
{: .notice}

<br><br><br><br><br><br>
- - - 

[C#] 코루틴 (Coroutine)
[참조](https://docs.unity3d.com/kr/2021.3/Manual/Coroutines.html)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
