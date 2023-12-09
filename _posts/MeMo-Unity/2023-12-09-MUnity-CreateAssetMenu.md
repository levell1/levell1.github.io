---
title:  "[Memo-Unity] 13. ScriptableObject - CreateAssetMenu  "
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
<BR><BR>

`ScriptableObject` - `CreateAssetMenu`  

<center><H1> Design Pattern </H1></center>

<br><br><br><br><br><br>
- - - 


# 1. ScriptableObject
데이터를 저장하는 데이터 컨테이너. 
스크립트 생성 시 상속된 Monobehaviour 를 지우고 ScriptableObject를 상속받는다
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
<div class="notice--primary" markdown="1"> 

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

<div class="notice--primary" markdown="1"> 

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
Asset 에서 생성시 메뉴에 표시
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
  
fileName : 이 유형의 새로 생성된 인스턴스에서 사용되는 기본 파일 이름입니다.  
menuName : 유니티 메뉴에 표기되는 이름  
order    : 메뉴 항목의 위치입니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/0d3f80c8-fb29-47d9-9c8c-7a2a58aca14f)




<br><br><br><br><br><br>
- - - 




<br><br>
- - - 

[C#] 디자인 패턴 (Design Pattern)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
