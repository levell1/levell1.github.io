---
title:  "[Memo-Unity] 12. ScriptableObject - CreateAssetMenu  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-09

---
- - -

`ScriptableObject` - `CreateAssetMenu`  
<BR><BR>

<center><H1>ScriptableObject - CreateAssetMenu  </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. ScriptableObject
> - 스크립터블 오브젝트는 Unity에서 데이터를 저장하고 관리하는 유연한 데이터 컨테이너입니다.  
> - 게임에서 재사용 가능한 데이터 또는 설정을 저장하는 데 사용
> - 코드와 데이터를 분리  
> - 스크립트 생성 시 상속된 Monobehaviour 를 지우고 ScriptableObject를 상속받는다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

`AttackSO` 무기 데이터  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
<div class="notice--primary" markdown="1"> 

`AttackSO`

```c#

[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("Knock Back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;
}
```
</div>

## RangedAttackData
`RangedAttackData` 원거리 무기 데이터    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}   
<div class="notice--primary" markdown="1"> 

`RangedAttackData`

```c#
[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberofProjectilesPerShot;
    public float multipleProjectilesAngel;
    public Color projectileColor;
}
```
</div>

<br><br><br><br><br><br>
- - - 

# 2. CreateAssetMenu
`CreateAssetMenu` Asset 에서 생성시 메뉴에 표시  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c#
AttackSO
[CreateAssetMenu(fileName = "DefaultAttackData", menuName = "TopDownController/Attacks/Default", order = 0)]

RangedAttackData
[CreateAssetMenu(fileName = "RangedAttackData", menuName = "TopDownController/Attacks/Ranged", order = 1)]

```
</div>
  
> - `fileName` : 이 유형의 새로 생성된 인스턴스에서 사용되는 기본 파일 이름입니다.  
> - `menuName` : 유니티 메뉴에 표기되는 이름  
> - `order`    : 메뉴 항목의 위치입니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/0d3f80c8-fb29-47d9-9c8c-7a2a58aca14f)

<br><br><br><br><br><br>
- - - 

# 3. CharacterStatsHandler
`CharacterStatsHandler` Player 캐릭터 정보, 무기SO 정보  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

`CharacterStatsHandler`

```c#
public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStates { get; private set; }
    //나중에 많은 다른 데이터들을 사용할 때 List
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStates = new CharacterStats { attackSO = attackSO };
        // TODO
        CurrentStates.statsChangeType = baseStats.statsChangeType;
        CurrentStates.maxHealth = baseStats.maxHealth;
        CurrentStates.speed = baseStats.speed;
    }
}
```
</div>

## CharacterStat
`CharacterStats` 플레이어의 정보  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<div class="notice--primary" markdown="1"> 

```c#
using System;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}
// 클래스 Serializabel 적용시키기
[Serializable]  
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}
```
</div>

클래스 Serializabel 적용시키기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a7e14bdc-e68b-4509-a9e7-b3647ce9c40f)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br><br>
- - - 

# 정리  
ScriptableObject : 데이터를 저장 관리하기 위해 사용하는 데이터 컨테이너  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/72e70883-f9b8-41cc-8d52-3bf4671263f3)
<br><br>
- - - 

[Unity] SO (ScriptableObject) 
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
