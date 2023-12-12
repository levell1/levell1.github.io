---
title:  "[Memo-Unity] 18. JsonSaveLoad "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-10 09:07

---
- - -

`JsonSaveLoad` 
<BR><BR>

<center><H1>  JsonSaveLoad  </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. JsonSaveLoad

<div class="notice--primary" markdown="1"> 

`JsonLoad`

```c#
public class JsonLoad
{
    public void SavePlayerData(CharacterStat player)
    {
        string jsonData = JsonUtility.ToJson(player, true);
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        File.WriteAllText(path, jsonData);
    }
    public CharacterStat LoadPlayerData(CharacterStat player)
    {
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        string jsonData = File.ReadAllText(path);
        player = JsonUtility.FromJson<CharacterStat>(jsonData);
        return player;
    }
}
```
</div>

# 2. Player

<div class="notice--primary" markdown="1"> 

`JsonLoad`

```c#
public class Player : MonoBehaviour
{
    [SerializeField]
    CharacterStat player = new CharacterStat();
    JsonLoad json = new JsonLoad();

    void Start()
    {
        //SavePlayerData();
        player = json.LoadPlayerData(player);
        Debug.Log(player._level);
    }
}
```
</div>


<br><br>
- - - 

[Unity] JsonSaveLoad
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
