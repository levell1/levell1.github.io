---
title:  "[TIL] 63 UIManager ⭐⭐⭐ "
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

<center><H1>  최종 팀 프로젝트 8일차  </H1></center>

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

# UI 작업 중

## 식당
**식당메뉴 선택**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/bacf2baa-afb8-4550-bb21-9e50761acabc){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

## 타이틀 씬
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ebff5d8d-487c-4f2d-a221-a6216ea31313){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 

# UIManager

<div class="notice--primary" markdown="1"> 

```c# 

using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

    private int _canvasSortOrder = 5;
    private Stack<GameObject> _popupStack = new Stack<GameObject>();
    public Dictionary<string, GameObject> _popupDic = new Dictionary<string, GameObject>();

    public void CreateCanvas() 
    {
        GameObject uiObject = GameObject.Find("Uis");
        if (uiObject == null)
        {
            uiObject = new GameObject("Uis");
        
            var pre = Resources.LoadAll<GameObject>("UI/Canvas");
            foreach (var p in pre) 
            {
                _popupDic.Add(p.name, Object.Instantiate(p,uiObject.transform));
                _popupDic[p.name].SetActive(false);
            }
        }
    }

    public void ShowCanvas(string uiname)
    {
        _popupDic[uiname].GetComponent<Canvas>().sortingOrder = _canvasSortOrder;
        _popupStack.Push(_popupDic[uiname]);
        _popupDic[uiname].SetActive(true);
        _canvasSortOrder++;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseLastCanvas()
    {
        if (_popupStack.Count == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (_popupStack.Count == 0) 
        {
            ShowCanvas("SettingUI");
        }
        else 
        { 
            GameObject currentUi = _popupStack.Pop();
            currentUi.SetActive(false);
            currentUi = null;
            _canvasSortOrder--;
        }
    }
}

```

- CreateCanvas() : 모든 UI Instantiate 
- Popup(string uiname) : 나타내고 싶은 UI SetActive, 커서락 해제 다음ui CanvasSortOrder 증가
- CloseLastPopup() : 아무ui도 없으면 세팅창, 있으면 닫기, 
</div>

<div class="notice--primary" markdown="1"> 

```c# 
if (Input.GetKeyDown(KeyCode.Escape))
{
    Debug.Log("esc");
    GameManager.instance.UIManager.CloseLastPopup();
}

// 상호작용 시 ~~ 테스트 R 클릭 시
if (Input.GetKeyDown(KeyCode.R))
{
    GameManager.instance.UIManager.Popup("ShopUI");
}
```
</div>


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
