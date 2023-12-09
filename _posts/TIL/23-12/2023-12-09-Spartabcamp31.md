---
title:  "[TIL] 31 숙련과정 강의  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-08 02:00

---
- - -


<BR><BR>


<center><H1>  유니티 숙련주차 2일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 43
&nbsp;&nbsp; [o] 강의 듣기  
&nbsp;&nbsp; [X] 다른반 발표 보기  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 스탯 만들기

# 1. ScriptableObject
> - 스크립터블 오브젝트는 Unity에서 데이터를 저장하고 관리하는 유연한 데이터 컨테이너입니다.  
> - 게임에서 재사용 가능한 데이터 또는 설정을 저장하는 데 사용
> - 코드와 데이터를 분리  
> - 스크립트 생성 시 상속된 Monobehaviour 를 지우고 ScriptableObject를 상속받는다 . 
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


<br><br><br><br><br>
- - -

# 잡담 


<br><br>
- - -

[Unity] TIL 30

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
