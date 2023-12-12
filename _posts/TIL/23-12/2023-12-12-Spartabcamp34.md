---
title:  "[TIL] 34 개인과제 인벤,장착  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-12 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 5일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 43  
&nbsp;&nbsp; [o] 강의 듣기 - 15강~  
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 아이템들 ScriptableObject
Item, weapon, armor

## 1). Item
<div class="notice--primary" markdown="1"> 

```c#
public enum ItemType
{
    None,
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Default", order = 0)]
public class Item : ScriptableObject
{
    public ItemType type = 0;
    public string Name;
    public string info;
    public int ItemGold;
    public bool IsEquip = false;
    public Sprite sprite;
}
```
</div>

## 2). weapon
<div class="notice--primary" markdown="1"> 

```c#
[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : Item
{
    public int ItemAttack;
}
```
</div>

## 3). armor
<div class="notice--primary" markdown="1"> 

```c#
[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 2)]
public class Armor : Item
{
    public int ItemDef;
}
```
</div>

<br><br><br><br><br>
- - - 

# 2. 장착
장비 클릭시 팝업창 뜨기.  
팝업창에서 장착/해제 누르면 장착OR해제  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
equip, popup  

## Equip
<div class="notice--primary" markdown="1"> 

```c#
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    
    public UiManager Uimanager;

    Weapon weapon;
    Armor armor;

    // 장비를 장착하는 함수
    public void Equipa(Item item, Image image)
    {
        if (item.IsEquip == true)
        {
            image.color = new Color(238 / 255f, 216 / 255f, 191 / 255f);
            Unequip(item);
            statUpdate(item);
            Uimanager.StatView();
        }
        else if (item.IsEquip == false)
        {
            image.color = Color.gray;
            item.IsEquip = true;
            statUpdate(item);
            Uimanager.StatView();
        }
    }

    public void Unequip(Item item)
    {
        item.IsEquip = false;
    }

    public void statUpdate(Item item) 
    {
        weapon = item as Weapon;
        armor = item as Armor;
        if (item.IsEquip == true)
        {
            if (item.type == ItemType.Weapon) 
            {
                Uimanager.playerstats.Attack += weapon.ItemAttack;
            }
            else if(item.type == ItemType.Armor)
            {
                Uimanager.playerstats.Def += armor.ItemDef;
            }
        }
        else if(item.IsEquip == false)
        {
            if (item.type == ItemType.Weapon)
            {
                Uimanager.playerstats.Attack -= weapon.ItemAttack;
            }
            else if (item.type == ItemType.Armor)
            {
                Uimanager.playerstats.Def -= armor.ItemDef;
            }
        }
    }
}
```
</div>

## Popup

<div class="notice--primary" markdown="1"> 

```c#
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    GameObject Clickobject;
    Image image;
    Sprite selectimage;
    Item selectItem;

    Weapon weapon;
    Armor armor;

    Equip equip;

    public InvenAddItem Inven;

    public GameObject popup;
    public Image PopupImage;

    public TMP_Text Name;
    public TMP_Text Info;
    public TMP_Text ATKorDef;
    public TMP_Text Itemstat;

    private void Awake()
    {
        equip= GetComponent<Equip>();
    }
    public void popupView()
    {
        Clickobject = EventSystem.current.currentSelectedGameObject;
        image = Clickobject.GetComponent<Image>();                              // 장착 시 색변경을 위한 image
        selectimage = image.transform.GetChild(0).GetComponent<Image>().sprite; // 인벤 장비 클릭시 sprite 값 

        //selectimage = image.GetComponentsInChildren<Image>()[0];
        /*selectimage = image.GetComponentsInChildren<Image>()[1];
        selectimage = image.GetComponentsInChildren<Image>()[2];*/
        foreach (var item in Inven.playerInven.items)
        {
            if (Clickobject.name == item.name)
            {
                selectItem = item;
            }
        }
        popup.SetActive(true);
        PopUpreset(selectItem);
    }

    public void PopUpreset(Item selectItem)
    {
        PopupImage.sprite = selectimage;
        Name.text = selectItem.name;
        Info.text = selectItem.info;

        if (selectItem.type == ItemType.Weapon)
        {
            weapon = selectItem as Weapon;
            ATKorDef.text = "공격력";
            Itemstat.text = weapon.ItemAttack.ToString();
        }
        else if (selectItem.type == ItemType.Armor)
        {
            armor = selectItem as Armor;
            ATKorDef.text = "방어력";
            Itemstat.text = armor.ItemDef.ToString();
        }
    }

    public void popupConfirm()
    {
        equip.Equipa(selectItem, image);
        popup.SetActive(false);
    }
}
```
</div>

<br><br><br><br><br>
- - - 

# 잡답
오늘은 코드 리펙토링?? 을 하였다 PLAYER코드에 있던 UI부분의 코드를 UIMANAGER을 만들어서 따로 분리했고 EQUIP에 있던 popup에 분리해서 넣었다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

그리고 오늘은 조립식 컴퓨터 시킨게 왔고, ssd만 부착하면 될 줄 알았는데 메인보드가 달라서 윈도우를 다시 깔고 해서 3시간 정도 걸렸다. 공부를 많이 못했지만 기분이 좋다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

지금 한 유니티 inven 의 UI 가 코드의 item 과 연관이 없다. 상점을 생각하지 못한 설계였고, 다음을 생각하지않는 설계였다. 고 생각한다.  
볼륨이 작으니까 편하게하자. 라는 마인드였을까 생각을 하지 못한걸까.

{: .notice--info}  

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
