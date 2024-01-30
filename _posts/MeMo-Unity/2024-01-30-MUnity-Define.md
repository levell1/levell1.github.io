---
title:  "[Memo-Unity] 37. 프로젝트 Define 만들기  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2024-01-30 01:21

---
- - -

`Define`
<BR><BR>

<center><H1>  Define </H1></center>
Define
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
<br><br><br><br><br><br>
- - - 


# Define  

<div class="notice--primary" markdown="1"> 

```c# 
public struct UIName
{
    public const string ControlKeyUI = "ControlKeyUI";
    public const string GoDungeonUI = "GoDungeonUI";
    public const string PlayerStatusUI = "PlayerStatusUI";
    public const string ReforgeUI = "ReforgeUI";
    public const string RestartUI = "RestartUI";
    public const string RestaurantUI = "RestaurantUI";
    public const string ResultUI = "ResultUI";
    public const string SettingUI = "SettingUI";
    public const string ShopUI = "ShopUI";
    public const string InventoryUI = "InventoryUI";
}

ex)
GameManager.instance.UIManager.ShowCanvas("InventoryUI");
GameManager.instance.UIManager.ShowCanvas(UIName.InventoryUI);
```
</div>

<br><br><br><br><br>
- - - 


# 잡담
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] UnityDocs
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
