---
title:  "[TIL] 68 카메라감도-POV  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-25 02:00

---
- - -

`UI`,`POV`

<BR><BR>

<center><H1>  최종 팀 프로젝트 12일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 다른반 강의 듣기 스탠다드2 챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# POV
**카메라 감도 조정**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9e689fdf-32bf-47fb-8ff2-7f09ee8b1dd6){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
카메라 감도를 바꾸기 위해서는 Virtual Camera에 Aim ->POV -> Vertical,Horizontal Axis 의 Speed 를 바꿔야 됐다.  
<div class="notice--primary" markdown="1"> 

```c# 
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MouseSettingUI : MonoBehaviour
{
    private Slider _slider;
    private CinemachinePOV _virtualcamera;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _virtualcamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
    }
    private void Start()
    {
        _slider.onValueChanged.AddListener(SetCam);
    }
    void SetCam(float value)
    {
        _virtualcamera.m_VerticalAxis.m_MaxSpeed = value;
        _virtualcamera.m_HorizontalAxis.m_MaxSpeed = value;
    }
}


```
</div>


<br><br><br><br><br>
- - - 

# 잡담,정리
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
