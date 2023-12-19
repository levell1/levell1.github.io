---
title:  "[TIL] 36 3D 강의  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-14 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 7일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 44  
&nbsp;&nbsp; [o] 강의 듣기 - 15강~ 22  
&nbsp;&nbsp; [X] 다른반 강의 듣기    
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 3D강의정리
**SkyBox**  
Meterial - SKYbox  - 하늘을 표현.

## InputSystem  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/adf5517f-6d89-4c77-b4f1-7883313f61d0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

## 밤낮 구현
AnimationCurve  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<details>
<summary>DayNightCycle.cs</summary>

<div class="notice--primary" markdown="1"> 


```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;

    private void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    private void Update()
    {
        time = (time + timeRate * Time.deltaTime) % 1.0f;

        UpdateLighting(sun, sunColor, sunIntensity);
        UpdateLighting(moon, moonColor, moonIntensity);

        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);

    }

    void UpdateLighting(Light lightSource, Gradient colorGradiant, AnimationCurve intensityCurve)
    {
        float intensity = intensityCurve.Evaluate(time);

        lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 4.0f;
        lightSource.color = colorGradiant.Evaluate(time);
        lightSource.intensity = intensity;

        GameObject go = lightSource.gameObject;
        if (lightSource.intensity == 0 && go.activeInHierarchy)
            go.SetActive(false);
        else if (lightSource.intensity > 0 && !go.activeInHierarchy)
            go.SetActive(true);
    }
}
```

</div>
</details>

<br><Br>

**UpdateLighting**  
UpdateLighting(Light lightSource, Gradient colorGradiant, AnimationCurve intensityCurve)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> **float intensity = intensityCurve.Evaluate(time);** 
> - 애니메이션 커브에서 시간별(x축) y의 값을 intensity 에 저장
![image](https://github.com/levell1/levell1.github.io/assets/96651722/63594cf4-5059-4366-a834-b5a09778504f){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> -  **lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 4.0f;**
> - 햇빛의 각도를 시간별로 조정
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> - **lightSource.color = colorGradiant.Evaluate(time);**
> - 시간에 따른 색상값
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> - if, else if 문
> - `sun` 의 intensity 가 0 일때  time 이 0 ~ 0.2, 0.8 ~ 1.0 일때 sun setActive(False)
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/8aded1d6-9bcb-4693-a08d-cbcc239ba029){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - `Moon` 의 intensity 가 0 일때  time 이 0.3 ~ 0.7 일때 setActive(False)
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/19dbdbc3-14bd-4ac6-95d7-b930b8fcf450){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 개인과제 풀이영상 정리

[UI](https://levell1.github.io/memo%20unity/MUnity-UiCanvas/)

**Scale Mode**
![image](https://github.com/levell1/levell1.github.io/assets/96651722/32913432-1d08-4a76-923f-062930378d5e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

## 1. 앵커
기준점 -> 만약 해상도가 바뀌면 기준점을 기준으로 UI 조절된다.   
앵커에 따라 UI변형이 다르게 늘어난다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br>

## 2. TextMashPRO
폰트추가 -> WINDOW -> TMP -> FONT ASSET CREATOR  
-> GENERATE FONT ATLAS, SAVE -> FONT(ATLAS Population Mode = Dynamic)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/f33fe7b4-6ab4-424a-85aa-38906a26ab4e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

![image](https://github.com/levell1/levell1.github.io/assets/96651722/12c660e9-705f-46df-9830-f3f171e30c7a){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<br><br><br>

## 3. button

button 클릭시 보이고 나타나는 (setactive) 코드로도 가능하지만 버튼에 ON Click 에서도 가능하다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/e1ba03e8-541f-432c-a94b-4af8a033153d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

<br><br><br>

## 4. inpufield
content Type 으로 입력값 무었으로 할 지 가능  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/42c25211-3e33-4957-9e79-c75adde53743){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br>

## 5. Scoll View
GRID LAYOUT GROUP ->  정렬  
Content Size Filter -> perferred size 부모 크기 안의 내용에 맞게 조절
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/b6fe5f47-dfc3-4ac1-8efe-ef5c9fc88ee0){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8df88b61-9609-43f5-9e0a-af3625210b43){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 

# for문속 lambda

[Lambda](https://levell1.github.io/memo%20unity/MUnity-lambda/)
# 1. for문, 람다
onClick.AddListener 람다식으로 for문안에서 할당?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}
<div class="notice--primary" markdown="1"> 

```c#
// 오류
for (int i = 0; i < Btns.Length; i++)
{
    Btns[i].onClick.AddListener(() => PressBtnSelectGame(i));
}

// 수정
for (int i = 0; i < Btns.Length; i++)
{
    int temp = i; 
    Btns[temp].onClick.AddListener(() => PressBtnSelectGame(temp));
}
```
</div>

PressBtnSelectGame(i) 에서 i값이 0,1,2 ---라고 예상된다.  
람다식이 실제 실행 되기 전에는 내부 변수를 참조형태로 가지고 있다고 한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

<br><br><br><br><br>
- - - 

# 2반 4회차 
## 비트마스크 상태이상 시스템
System.Flags를  사용해서 중첩 비트마스크를 부여  
비트와 |OR, &AND 연산자로 상태 중첩,해제    
<div class="notice--primary" markdown="1"> 

```c#
[System.Flags]
public enum StatusEffects
{
    None = 0,
    Poisoned = 1 << 0,  // 0001
    Burned = 1 << 1,    // 0010
    Frozen = 1 << 2,    // 0100
    Paralyzed = 1 << 3  // 1000
}

public class StatusEffectManager
{
    private StatusEffects currentEffects = StatusEffects.None;

    public void AddEffect(StatusEffects effect)
    {
        currentEffects |= effect;
    }

    public void RemoveEffect(StatusEffects effect)
    {
        currentEffects &= ~effect;
    }

    public void ClearEffects()
    {
        currentEffects = StatusEffects.None;
    }

    public bool HasEffect(StatusEffects effect)
    {
				// 0100 & 0100 => 0100 != 0000 -> true
        return (currentEffects & effect) != StatusEffects.None;
    }

    public void PrintEffects()
    {
        Console.WriteLine("Current Status Effects: " + currentEffects);
    }
}

class Program
{
    static void Main()
    {
        StatusEffectManager manager = new StatusEffectManager();

        // 상태 이상 추가
        manager.AddEffect(StatusEffects.Poisoned);
        manager.AddEffect(StatusEffects.Frozen);

        // 현재 상태 이상 출력
        manager.PrintEffects(); // Poisoned, Frozen

        // 상태 이상 제거
        manager.RemoveEffect(StatusEffects.Poisoned);

        // 상태 이상 확인
        if (manager.HasEffect(StatusEffects.Frozen))
        {
            Console.WriteLine("The character is frozen.");
        }

        // 모든 상태 이상 제거
        manager.ClearEffects();
    }
}
```
</div>


<br><br><br><br><br>
- - - 

# 잡담,정리

**유니티**  
버튼 onclick 에 매개변수도 가능?  
project view 에 폴더 정렬 해서 깔끔하게 보기  
01.Scene  
02.Scripts  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ddf61c14-d050-4e3d-bb2c-d67547f47b14){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
