---
title:  "[Unity6] Custom Editor (ToggleGroup)"
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-05-14 05:00

---
- - -

`Toggle` `ChangeSkin` `ToggleGroup`

<br>
- - - 

# Toggle
Toggle : Label이 왼쪽 체크박스 오른쪽  
result = EditorGUILayout.Toggle(string label, bool value)  
&nbsp;  
ToggleLeft : Label이 오른쪽 체크박스 왼쪽  
result = EditorGUILayout.ToggleLeft(string label, bool value)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/9.png?raw=true)   

<details>
<summary>Toggle</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private bool toggleValue = false;

toggleValue = EditorGUILayout.Toggle("Toggle", toggleValue);
toggleValue = EditorGUILayout.ToggleLeft("Toggle Left", toggleValue);
```
</div>
</details>

# ChangeSkin (Button Toggle)
GUI.skin.toggle, GUI.skin.Button 을 통해 기능과 다르게 외형을 변경할 수 있다.  
GUILayout은 내부에 텍스트, 이미지 출력 가능  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}    

유니티 테스트 버튼  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/10.png?raw=true)   
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/11.png?raw=true)   

<details>
<summary>ChangeSkin</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public void ChangeSkin(GUIStyle titleStyle)
{
    EditorGUILayout.Space(18);
    EditorGUILayout.LabelField("Button Style Toggle", titleStyle);

    // Label 이지만 스타일만 토글 작동X
    GUILayout.Label("안녕하세요.", GUI.skin.toggle);

    // 버튼이지만 스타일은 토글 누르면 ON 마우스때면 OFF
    if (GUILayout.Button(new GUIContent("Button"), GUI.skin.toggle)) { Debug.Log("버튼."); }

    // 토글이지만 스타일은 버튼 
    toggleValue = EditorGUILayout.Toggle("Toggle", toggleValue, GUI.skin.button);

    // 내부에 이미지, 텍스트를 출력할 수 있기 때문에 EditorGUILayout 대신 GUILayout 사용
    toggleValue = GUILayout.Toggle(toggleValue, toggleValue ? "ON" : "OFF", GUI.skin.button);
}
```
</div>
</details>

# ToggleGroup (Toolbar, SelectionGrid)
유니티 Scene View에 Toolbar 처럼 Button외형의 Toggle을 그룹으로 관리해 그룹 소속 토글중 하나만 선택 가능합니다.  
GUILayout 클래스만 사용 가능.  
&nbsp;  
Toolbar(int, string[], GUIStyle) : 가로로 정렬되는 버튼 형태의 Toggle Group  
SelectionGrid(int, string[], int, GUIStyle) : 가로/세로 격자로 정렬되는 버튼 형태의 Toggle Group  
&nbsp; 3번째 int 로 x축에 배치되는 개수 설정  
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/12.png?raw=true)   

<details>
<summary>ToggleGroup</summary>
<div class="notice--primary" markdown="1"> 

```c# 
public void ToggleGroup(GUIStyle titleStyle)
{
    EditorGUILayout.Space(18);
    EditorGUILayout.LabelField("Toggle Group", titleStyle);

    EditorGUILayout.BeginHorizontal();
    first = GUILayout.Toggle(first, "1", EditorStyles.miniButtonLeft);
    second = GUILayout.Toggle(second, "2", EditorStyles.miniButtonMid);
    third = GUILayout.Toggle(third, "3", EditorStyles.miniButtonRight);
    EditorGUILayout.EndHorizontal();

    EditorGUILayout.LabelField("Toolbar", titleStyle);
    selected = GUILayout.Toolbar(selected, new string[] { "1", "2", "3" });
    selected = GUILayout.Toolbar(selected, new string[] { "1", "2", "3" }, EditorStyles.toolbarButton);

    EditorGUILayout.LabelField("SelectionGrid", titleStyle);
    selected = GUILayout.SelectionGrid(selected, new string[] { "1", "2", "3" }, 1);
    selected = GUILayout.SelectionGrid(selected, new string[] { "1", "2", "3" }, 3);
    selected = GUILayout.SelectionGrid(selected, new string[] { "1", "2", "3" }, 1, "PreferencesKeysElement");
}
```
</div>
</details>


<br><br><br><br>

# 이것저것 메모

## 가로정렬(BeginHorizontal)
Editor UI를 가로로 정렬하는 메소드  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>Toolbar</summary>
<div class="notice--primary" markdown="1"> 

```c# 
EditorGUILayout.BeginHorizontal();
first = GUILayout.Toggle(first, "1", EditorStyles.miniButtonLeft);
second = GUILayout.Toggle(second, "2", EditorStyles.miniButtonMid);
third = GUILayout.Toggle(third, "3", EditorStyles.miniButtonRight);
EditorGUILayout.EndHorizontal();
```
</div>
</details>

## PreferencesKeysElement
버튼 테두리없이 토글형식  
유니티 설정탭 곳곳에서 사용됨  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/13.png?raw=true)   

<details>
<summary>Toolbar</summary>
<div class="notice--primary" markdown="1"> 

```c# 
selected = GUILayout.SelectionGrid(selected, new string[] { "1", "2", "3" }, 1, "PreferencesKeysElement");
```
</div>
</details>

<br><br><br><br><br>
- - - 


# 잡담, 일기?
Toggle, ToggleGroup, Skin  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -