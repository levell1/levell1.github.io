---
title:  "[TIL] 64 UI 에 PLAYER 정보  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-19 02:00

---
- - -

`UIManager`

<BR><BR>

<center><H1>  최종 팀 프로젝트 9일차  </H1></center>

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

# 체력, 스테미나, exp
hp, 스테미나, exp 바에 공통된 부분이 있어서 상속을 이용해 시도해보았다.  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a4816902-8a05-49d7-9663-d5325b0e45ab){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   
<br><br><br><br><br>
- - - 

# PlayerBaseSlider

<div class="notice--primary" markdown="1"> 

```c# 
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseSlider : MonoBehaviour
{
    protected Slider _slider;
    [SerializeField] private TMP_Text _Text;

    [SerializeField] private int _currentValue;
    [SerializeField] private int _maxValue;

    protected virtual void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected virtual void ChangeBar(int _currentValue, int _maxValue)
    {
        _Text.text = (_currentValue + "/" + _maxValue);
        _slider.value = (float)_currentValue / (float)_maxValue;

    }
}

```
</div>

<br><br>

## PlayerExpBar : PlayerBaseSlider
**경험치바 변경**  
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class PlayerExpBar : PlayerBaseSlider
{ 
    [SerializeField] private PlayerExpSystem _playerExpSystem;
    private new void Awake()
    {
        base.Awake();
        _playerExpSystem.OnChangeExpUI += base.ChangeBar;
    }

}


PlayerExpSystem
public event Action<int, int> OnChangeExpUI;

OnChangeExpUI.Invoke(_playerExp, _maxExp);

```
</div>

## PlayerStatSlider : PlayerBaseSlider

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatSlider : PlayerBaseSlider
{

    [SerializeField] private Image _leftImage;
    [SerializeField] private Image _rightImage;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void ChangeBar(int _currentValue,int _maxValue)
    {
        base.ChangeBar(_currentValue, _maxValue);
        if (_slider.value == 1)
        {
            _rightImage.color = new Color32(255, 255, 255, 255);
        }
        else if (_slider.value != 1)
        {
            _rightImage.color = new Color32(155, 140, 140, 60);
        }

        if (_slider.value == 0)
        {
            _leftImage.color = new Color32(155, 140, 140, 60);
        }
        else if (_slider.value != 0)
        {
            _leftImage.color = new Color32(255, 255, 255, 255);
        }
    }
}
```
</div>


<br><br><br>

### PlayerStaminaBar : PlayerStatSlider
**스테미나 변경**  

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class PlayerStaminaBar : PlayerStatSlider
{
    [SerializeField] private StaminaSystem _staminaSystem;

    public new void Awake()
    {
        base.Awake();
        _staminaSystem.OnChangeStaminaUI += base.ChangeBar;
    }
}

StaminaSystem
public  Action<int, int> OnChangeStaminaUI;
OnChangeStaminaUI.Invoke(_stamina, _maxStamina);
```
</div>

### PlayerHPBar : PlayerStatSlider

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : PlayerStatSlider
{
    [SerializeField] private HealthSystem _healthSystem;

    public new void Awake()
    {
        base.Awake();
        _healthSystem.OnChangeHpUI += base.ChangeBar;
    }
}

HealthSystem

public  Action<int,int> OnChangeHpUI;
OnChangeHpUI.Invoke(_health, _maxHealth);

```
</div>


![image](https://github.com/levell1/levell1.github.io/assets/96651722/be460435-2061-4ae4-ab70-8545756f8935){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  




# 잡담,정리
ctrl \ + t -> todo주석찾기  
UI로 캔버스를 불러오는 게 맞는걸까? 캔버스안의 것을 변수에 저장하는 게 맞는지 생각해보기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
