---
title:  "[TIL] 64 UI 에 PLAYER 정보  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-21 02:00

---
- - -

`UI`

<BR><BR>

<center><H1>  최종 팀 프로젝트 10일차  </H1></center>

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

# 상태창
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9d33ce4b-2de2-4d3e-a98a-83a1058826fe){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

## StatusUI

<div class="notice--primary" markdown="1"> 

```c# 
using TMPro;
using UnityEngine;

public class StatusUI : BaseUI
{
    private PlayerSO _playerData;

    [Header("기본스탯")]
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _playerLevel;
    [SerializeField] private TMP_Text _maxHealth;
    [SerializeField] private TMP_Text _maxStamina;
    [SerializeField] private TMP_Text _Attack;
    [SerializeField] private TMP_Text _defence;

    [Header("장비 정보")]
    [SerializeField] private TMP_Text[] _equipmentName= new TMP_Text[5];
    [SerializeField] private Sprite[] _equipmentSprite= new Sprite[5];
    [SerializeField] private TMP_Text _weaponName;
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private TMP_Text _equipmentHealth;
    [SerializeField] private TMP_Text _equipmentDef;
    [SerializeField] private TMP_Text _weaponDmg;


    [Header("스킬정보")]
    [SerializeField] private TMP_Text _qSkillName;
    [SerializeField] private TMP_Text _qSkillDmg;
    [SerializeField] private TMP_Text _qSkillCool;
    [SerializeField] private TMP_Text _qSkillStamina;
    [SerializeField] private TMP_Text _eSkillName;
    [SerializeField] private TMP_Text _eSkillDmg;
    [SerializeField] private TMP_Text _eSkillCool;
    [SerializeField] private TMP_Text _eSkillStamina;

    private void Awake()
    {
        if (_playerData == null)
        {
            _playerData = GameObject.FindWithTag("Player").GetComponent<Player>().Data;
        }
    }

    private void OnEnable()
    {
        _playerName.text = _playerData.PlayerData.GetPlayerName();
        _playerLevel.text = _playerData.PlayerData.GetPlayerLevel().ToString();
        _maxHealth.text = _playerData.PlayerData.GetPlayerMaxHealth().ToString();
        _maxStamina.text = _playerData.PlayerData.GetPlayerMaxStamina().ToString();
        _Attack.text = _playerData.PlayerData.GetPlayerAtk().ToString();
        _defence.text = _playerData.PlayerData.GetPlayerDef().ToString();

        Debug.Log(_playerData.PlayerData.GetPlayerLevel().ToString());

        Debug.Log(_playerData.PlayerData.GetPlayerMaxHealth().ToString());

        /*for (int i = 0; i < _equipmentName.Length; i++)
        {
            _equipmentName[i] = data.name+data.강화수치
            _equipmentsprite[i] = data.sprite
        }*/
        //_WeaponName.text = .ToString();

        //_equipmentHealth.text = .ToString();
        //_equipmentDef.text = .ToString();
        // _weaponDmg.text = .ToString();

        _qSkillName.text = _playerData.SkillData.SkillInfoDatas[0].GetSkillName()+"(Q)";
        _qSkillDmg.text = _playerData.SkillData.SkillInfoDatas[0].GetSkillDamage().ToString();
        _qSkillCool.text = _playerData.SkillData.SkillInfoDatas[0].GetSkillCoolTime().ToString();
        _qSkillStamina.text = _playerData.SkillData.SkillInfoDatas[0].GetSkillCost().ToString();

        _eSkillName.text = _playerData.SkillData.SkillInfoDatas[1].GetSkillName() + "(E)";
        _eSkillDmg.text = _playerData.SkillData.SkillInfoDatas[1].GetSkillDamage().ToString();
        _eSkillCool.text = _playerData.SkillData.SkillInfoDatas[1].GetSkillCoolTime().ToString();
        _eSkillStamina.text = _playerData.SkillData.SkillInfoDatas[1].GetSkillCost().ToString();
    }

}
```
</div>

<br><br><br><br><br>
- - - 

# RestartUI
**재시작**  
<div class="notice--primary" markdown="1"> 

```c# 
using System.Collections;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartUI : BaseUI
{
    [SerializeField] private Image _backimage;
    [SerializeField] private GameObject _text;
    Color color;

    //죽으면 보이기
    private void OnEnable()
    {
        _text.SetActive(false);
        _backimage.color= new Color(0f, 0f, 0f, 0f);
        Color color = _backimage.color;
        StartCoroutine(backblur());
    }

    IEnumerator backblur() 
    {
        while (_backimage.color.a < 1f) 
        {
            yield return new WaitForSeconds(0.1f);
            color.a = color.a+0.05f ;
            _backimage.color = color;

        }
        _text.SetActive(true);
        yield return new WaitForSeconds(3f);
        
        base.CloseUI();
        //씬이동,초기화는 다른 스크립트에서.
    }
}

```
</div>

<br><br><br><br><br>
- - - 

# 레벨, 골드, 스킬 쿨 체크

## 스킬 쿨 체크
<div class="notice--primary" markdown="1"> 

```c# 
    IEnumerator CoolTime(float cool) 
    {
        float cooltime=cool;
        while (cooltime > 0.1f) 
        {
            cooltime -= Time.deltaTime;
            _coolTimeImage.fillAmount = cooltime/cool;
            yield return null;
        }
        _coolTimeImage.fillAmount = 0;
        _isPlaying=false;
    }
```
</div>

<br><br><br><br><br>
- - - 

# 잡담,정리
씬 전환 시 맵 이름 바뀌는지 체크
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
