---
title:  "[Memo-Unity] 21. AnimationCurve  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-14 01:20

---
- - -

`AnimationCurve` 
<BR><BR>

<center><H1>  AnimationCurve  </H1></center>
AnimationCurve   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 
<br><br><br><br><br><br>
- - - 

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
![image](https://github.com/levell1/levell1.github.io/assets/96651722/63594cf4-5059-4366-a834-b5a09778504f)
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
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/8aded1d6-9bcb-4693-a08d-cbcc239ba029)
> - `Moon` 의 intensity 가 0 일때  time 이 0.3 ~ 0.7 일때 setActive(False)
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/19dbdbc3-14bd-4ac6-95d7-b930b8fcf450)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<br><br>
- - - 

[Unity] StatHandler
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
