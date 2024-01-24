---
title:  "[TIL] 67 장비, 강화  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-24 02:00

---
- - -

`UI`

<BR><BR>

<center><H1>  최종 팀 프로젝트 11일차  </H1></center>

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

# 장비, 강화

## EquipmentData
**장비 데이터 SO+LEVEL,현스탯**  
<div class="notice--primary" markdown="1"> 

```c# 
[Serializable]
public class EquipmentData
{
    private int _level = 0;
    [field: SerializeField] private EquipmentBase _equipment;
    private float _currenthealth;
    private float _currentDef;
    private float _currentAttack;
    private float _currentUpgradeGold;
}
```
</div>

<br><br>

## EquipmentDatas
**장비 6개 데이터 +초기화,레벨업, 현스탯 SET**
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;

public class EquipmentDatas : MonoBehaviour
{
    public EquipmentData[] EquipData = new EquipmentData[6];
    private HealthSystem _healthSystem;

    public float SumHealth;
    public float SumDef;
    public float SumDmg;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            EquipData[i].Level = 0;
            SetEquipCurrent(i);
        }
        SumEquipStat();
        _healthSystem.SetMaxHealth();
    }
    public void EquipLevelUp(int i) 
    {
        EquipData[i].Level++;
        SetEquipCurrent(i);
        SumEquipStat();
        _healthSystem.SetMaxHealth();
        
    }
    public void SetEquipCurrent(int i) 
    { 
        EquipData[i].CurrentUpgradeGold = Mathf.Ceil(EquipData[i].Equipment.UpgradeGold + EquipData[i].Equipment.UpgradeGold* (Mathf.Pow(EquipData[i].Level, 2) / 2));
        EquipData[i].Currenthealth = Mathf.Ceil(EquipData[i].Equipment.EquipmentHealth+ EquipData[i].Equipment.EquipmentHealth * (Mathf.Pow(EquipData[i].Level, 2) / 2));
        EquipData[i].CurrentDef = Mathf.Ceil(EquipData[i].Equipment.EquipmentDef+ EquipData[i].Equipment.EquipmentDef * (Mathf.Pow( EquipData[i].Level, 2) / 2));
        EquipData[i].CurrentAttack = Mathf.Ceil(EquipData[i].Equipment.EquipmentDmg + EquipData[i].Equipment.EquipmentDmg * (Mathf.Pow(EquipData[i].Level, 2) / 2));
    }

    public void SumEquipStat() 
    {
        SumHealth = 0;
        SumDef = 0;
        SumDmg = 0;
        for (int i = 0; i < 6; i++)
        {
            SumHealth += EquipData[i].Currenthealth;
            SumDef += EquipData[i].CurrentDef;
            SumDmg += EquipData[i].CurrentAttack;
        }
    }
}
```
</div>

<br><br><br><br><br>
- - - 

# 강화 UI
**강화, UI표시**
<div class="notice--primary" markdown="1"> 

```c# 

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReforgeUI : BaseUI
{
    [SerializeField] GameObject _backUI;
    [SerializeField] GameObject _selectUI;
    [SerializeField] GameObject _resultUI;

    [SerializeField] Button[] _selectButton= new Button[6];
    [SerializeField] Image[] _equipimagelist = new Image[6];
    [SerializeField] TMP_Text[] _equiptext= new TMP_Text[6];

    [SerializeField] private EquipmentDatas _equipmentupgrade;
    [SerializeField] private PlayerSO _playerData;
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private Image _equipicon;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private TMP_Text _plusStatText;

    int _itemnum;

    private void Awake()
    {
        if (_equipmentupgrade == null)
        {
            _equipmentupgrade = GameObject.FindWithTag("Player").GetComponent<EquipmentDatas>();
        }
        if (_playerData == null)
        {
            _playerData = GameObject.FindWithTag("Player").GetComponent<Player>().Data;
        }

    }

    public void ClickUpgradeButton() 
    {
        if (_playerData.PlayerData.GetPlayerGold() > _equipmentupgrade.EquipData[_itemnum].CurrentUpgradeGold) {
            _playerData.PlayerData.SetPlayerGold(_playerData.PlayerData.GetPlayerGold() - (int)_equipmentupgrade.EquipData[_itemnum].CurrentUpgradeGold);
            _equipmentupgrade.EquipLevelUp(_itemnum);
            _resultUI.SetActive(true);
            _resultText.text = "강화 성공";
            
            setImagename();
        }
        else
        {
            _resultUI.SetActive(true);
            _resultText.text = "골드가 부족합니다.";
            
        }
        _selectUI.SetActive(false);
        Invoke("fialuifalse", 1f);
    }

    private void fialuifalse() 
    {
        _resultUI.SetActive(false);
    }
    public void ClickEquip()
    {
        for (int i = 0; i < 6; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == _selectButton[i].name)
            {
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);
                Debug.Log(_selectButton[i].name);
                _itemnum = i;   break;
            }
        }
        _goldText.text = _equipmentupgrade.EquipData[_itemnum].CurrentUpgradeGold.ToString()+"골드 필요";
        _equipicon.sprite = _equipmentupgrade.EquipData[_itemnum].Equipment.sprite;
        if (_equipmentupgrade.EquipData[_itemnum].CurrentDef != 0)
        {
            _plusStatText.text = "방어력 + " + (nextstatDef() - _equipmentupgrade.EquipData[_itemnum].CurrentDef);
        }
        else if (_equipmentupgrade.EquipData[_itemnum].Currenthealth != 0)
        {
            _plusStatText.text = "최대체력 + " + (nextstatHealth()-_equipmentupgrade.EquipData[_itemnum].Currenthealth);
        }
        else if (_equipmentupgrade.EquipData[_itemnum].CurrentAttack != 0)
        {
            _plusStatText.text = "공격력 + " + (nextstatDmg()- _equipmentupgrade.EquipData[_itemnum].CurrentAttack);
        }


        _selectUI.SetActive(true);
    }
    private void OnEnable()
    {
        setImagename();
        _selectUI.SetActive(false);
        _resultUI.SetActive(false);
    }
    private float nextstatHealth() 
    {
        return Mathf.Ceil(_equipmentupgrade.EquipData[_itemnum].Equipment.EquipmentHealth + _equipmentupgrade.EquipData[_itemnum].Equipment.EquipmentHealth * (Mathf.Pow(_equipmentupgrade.EquipData[_itemnum].Level+1, 2) / 2));
    }
    private float nextstatDef()
    {
        return Mathf.Ceil(_equipmentupgrade.EquipData[_itemnum].Equipment.EquipmentDef + _equipmentupgrade.EquipData[_itemnum].Equipment.EquipmentDef * (Mathf.Pow(_equipmentupgrade.EquipData[_itemnum].Level + 1, 2) / 2));
    }
    private float nextstatDmg()
    {
        return Mathf.Ceil(_equipmentupgrade.EquipData[_itemnum].Equipment.EquipmentDmg + _equipmentupgrade.EquipData[_itemnum].Equipment.EquipmentDmg * (Mathf.Pow(_equipmentupgrade.EquipData[_itemnum].Level + 1, 2) / 2));
    }
    private void setImagename()
    {
        for (int i = 0; i < 6; i++)
        {
            _equipimagelist[i].sprite = _equipmentupgrade.EquipData[i].Equipment.sprite;
            _equiptext[i].text = _equipmentupgrade.EquipData[i].Equipment.Name + "( +" + _equipmentupgrade.EquipData[i].Level + ")";
        }
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
