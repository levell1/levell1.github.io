---
title:  "[TIL] 35 개인과제 끝, 강의  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-13 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 6일차 + 개인과제 끝 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 43  
&nbsp;&nbsp; [o] 강의 듣기 - 15강~  
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
# 계획
발제를 보고 상점까지를 목표로 대략적인 스크립트와 UI를 만들며 진행 하였습니다.  
객체지향, JSON, 강의에서 배운 내용(ScriptableObject등)을 사용하는 목표로  개인과제를 시작하였습니다.


<br>

> **`필수 과제`**  
> 1. 메인 화면 구성
> 2. Status 보기
> 3. Inventory 보기

<br>

> **`추가 과제`**  
> 1. 아이템 장착 팝업 업그레이드 


<br><br>

# 1. 필수요구사항

## 1. 메인 화면 구성

![image](https://github.com/levell1/levell1.github.io/assets/96651722/49d4bc5b-5d1c-45a6-bdcb-56d3f490f38b)   
> - 좌측 : 이름, 직업, 레벨, exp / maxexp  
> - 우측 : 스텟, 인벤 버튼


**플레이어 정보.JSON**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/efaedff8-1a9a-407c-ad80-dafb6b56f9d9)     


<br><br>

**stat**
<details>
<summary>CharacterStat.cs</summary>

<div class="notice--primary" markdown="1"> 


```c#

[System.Serializable]
public class CharacterStat
{
    public string Id;
    public string Job;
    public int Level;
    public int Gold;
    public int Exp;
    public int MaxExp;
    public int Attack;
    public int Def;
    public int HP;
    public int Cri;
}

```
</div>
</details>

<br><br>

**jsonLoad,Save**

<details>
<summary>SavePlayerData.cs</summary>

<div class="notice--primary" markdown="1"> 

```c#
using System.IO;
using UnityEngine;

public class JsonLoad
{
    public void SavePlayerData(CharacterStat player)
    {
        string jsonData = JsonUtility.ToJson(player, true);
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        File.WriteAllText(path, jsonData);
    }
    public CharacterStat LoadPlayerData(CharacterStat player, string json)
    {
        string path = Path.Combine(Application.dataPath, json);
        string jsonData = File.ReadAllText(path);
        player = JsonUtility.FromJson<CharacterStat>(jsonData);
        return player;
    }
}


```
</div>
</details>

<br><br>

## 2. Stat 보기 -> UImanager
status 클릭시 스텟 보기, 내용수정  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8da9245b-49f1-4ca4-b54a-88193ddc16c0)  

[UImanager](https://github.com/levell1/Inven_Shop?tab=readme-ov-file#managersuimoneybuttonclick)

<br><br>

## 3. Inventory 보기
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2bb50155-f0a6-4457-a343-be46914cdef7)  

**PlayerInven**  
인벤 에 아이템 추가, 제거

<details>
<summary>PlayerInven.cs</summary>
<div class="notice--primary" markdown="1"> 

```c#
public class PlayerInven
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item Item)
    {
        items.Add(Item);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item); 
    }
}

```
</div>
</details>

<br><br>

**InvenAddItem**   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/328f417d-24f4-40e5-9580-b5283970a5bf)  
ScriptableObject를 사용해 데이터 추가  

<details>
<summary>InvenAddItem.cs</summary>
<div class="notice--primary" markdown="1"> 

```c#
using UnityEngine;

public class InvenAddItem : MonoBehaviour
{
    public PlayerInven playerInven = new PlayerInven();

    public Weapon Sword;
    public Armor Ring;
    public Armor Helmet;
    public Armor Shoes;
    public Armor Belt;


    void Awake()
    {
        Sword.IsEquip = false;
        Ring.IsEquip = false;
        Helmet.IsEquip = false;
        Shoes.IsEquip = false;
        Belt.IsEquip = false;

        playerInven.AddItem(Sword); 
        playerInven.AddItem(Ring); 
        playerInven.AddItem(Helmet); 
        playerInven.AddItem(Shoes); 
        playerInven.AddItem(Belt); 
    }

    public int InvenCount() 
    {
        return playerInven.items.Count;
    }
}

```
</div>
</details>



<br><br><br><br><br>


# 2. 선택요구사항

## 1. 아이템 장착 팝업
![image](https://github.com/levell1/levell1.github.io/assets/96651722/78810541-a570-49a9-a661-483154d6e646)  
클릭한 아이템에 따라 팝업 내용 변경  
장착 시 이미지 색 변경  

<details>
<summary>Popup.cs</summary>

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
</details>

<br>

<details>
<summary>Equip.cs</summary>

<div class="notice--primary" markdown="1"> 

```c#
using UnityEngine;
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
</details>

<br><br>

# 3. manager, item

## Item Data

**item**  
<details>
<summary>item, armor, Weapon</summary>

<div class="notice--primary" markdown="1"> 

```c#
// ITEM
using UnityEngine;

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

// Armor
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 2)]
public class Armor : Item
{
    public int ItemDef;
}

// Weapon
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : Item
{
    public int ItemAttack;
}


```
</div>
</details>

<br><br>

## Managers(UI,MONEY,BUTTONCLICK)


**UI**  
첫화면 초기화
스텟화면 VIEW  
인벤아이템 개수체크  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/51b5327e-b09a-4ba8-9b39-3ed7b6c1d064)  

<details>
<summary>UIManager</summary>

<div class="notice--primary" markdown="1"> 

```c#
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Player player;
    GoldManager goldManager = new GoldManager();
    public TMP_Text Id;
    public TMP_Text Job;
    public TMP_Text Level;
    public TMP_Text Gold;
    public TMP_Text Exp;
    [SerializeField] private Slider ExpBar;

    public TMP_Text Attack;
    public TMP_Text Def;
    public TMP_Text HP;
    public TMP_Text Cri;

    public InvenAddItem Inventory;
    public TMP_Text InvenCountTxt;

    public CharacterStat playerstats;

    void Start()
    {
        playerstats = player.playerstats;
        StatView();
        FirstViewInit();
        InvenCountView();
    }

    public void StatView()
    {
        Attack.text = playerstats.Attack.ToString();
        Def.text = playerstats.Def.ToString();
        HP.text = playerstats.HP.ToString();
        Cri.text = playerstats.Cri.ToString();
    }

    void FirstViewInit()
    {
        Job.text = playerstats.Job;
        Id.text = playerstats.Id;
        Level.text = "LV. " + playerstats.Level;
        string gold = goldManager.AbbreviateGold(playerstats.Gold);
        Gold.text = gold;
        ExpBar.value = playerstats.Exp / playerstats.MaxExp;
        Exp.text = playerstats.Exp + " / " + playerstats.MaxExp;
    }

    public void InvenCountView() 
    {
        InvenCountTxt.text = Inventory.InvenCount().ToString();
    }
}


```
</div>
</details>

<br><BR>

**ButtonClickManager**  
스텟, 인벤, 뒤로가기버튼 클릭 시  
보이고 안보일 오브젝트 관리  

<details>
<summary>ButtonClickManager</summary>

<div class="notice--primary" markdown="1"> 

```c#
using UnityEngine;

public class ButtonClickManager : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject Stats;
    public GameObject Inven;
    public GameObject Shop;
    public GameObject Exitbutton;

    private void ButtonsSetFalse()
    {
        Buttons.SetActive(false);
    }
    private void ButtonsSetTrue()
    {
        Buttons.SetActive(true);
    }
    public void StatView() 
    {
        ButtonsSetFalse();
        Stats.SetActive(true);
        Exitbutton.SetActive(true);
    }
    public void InvenView()
    {
        ButtonsSetFalse();
        Inven.SetActive(true);
        Exitbutton.SetActive(true);
    }
    public void ShopView()
    {
        ButtonsSetFalse();
        Shop.SetActive(true);
        Exitbutton.SetActive(true);
    }

    // 뒤로가기 버튼
    public void ExitButtonClick() 
    {
        Exitbutton.SetActive(false);
        Shop.SetActive(false);
        Inven.SetActive(false);
        Stats.SetActive(false);
        ButtonsSetTrue();
    }

}


```
</div>
</details>

<br><BR>

**GoldManager**  
재화 축약 표시  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e010a01e-776b-454e-8457-d10726664982)  

<details>
<summary>ButtonClickManager</summary>

<div class="notice--primary" markdown="1"> 

```c#
public class GoldManager
{
    public string AbbreviateGold(int goldAmount)
    {
        if (goldAmount >= 1000)
        {
            string gold = string.Empty;
            float value = goldAmount;

            if (goldAmount >= 1000 && goldAmount < 1000000)
            {
                value = goldAmount / 1000f;
                gold = "K";
            }

            string sum = value.ToString() + gold;
            return sum;
        }
        return goldAmount.ToString();
    }
}
```
</div>
</details>

<br><br><br><br><br>



# 느낀점

**문제점**  
상점까지 계획은 했지만 INVEN에 장비를 표시하는 게 코드, 데이터로 정보를 추가한 게 아닌 유니티 쪽에서 하는 방식이라고 느꼈습니다. shop을 시작할 때 문제를 느꼈고, Shop은 구현을 못하였습니다.  
Inven 부분의 UI 도 다 만들고나서 Scoll View 가 있다는 것을 알게 되어서 다음에 사용해 봐야겠습니다. 수정을 하고 싶었지만, 밀린강의가..

**궁금한 점**
> - Script를 나누는게 잘 되고 있는건지?
> - json, SO 의 데이터구조, 방식이 잘 되고 있는건지?
> - 이번과제에 대한 부족한점 에 대하여 알고싶습니다.


**봐주셔서 감사합니다.**


<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
