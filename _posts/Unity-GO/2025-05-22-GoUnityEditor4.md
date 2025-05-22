---
title:  "[Unity6] Custom Editor (그룹정렬, Scrollview, fold ...)"
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-05-21 05:00

---
- - -

`Horizontal`, `Vertical`, `ScrollView`, `DisabledGroup`, `ChangeCheck`, `Foldout`,  `FoldoutHeaderGroup`

<br>
- - - 

# Begin, End
UI를 그룹으로 관리해 가로, 세로로 정렬하거나 활성, 비활성 등의 제어  
**Horizontal**(가로), **Vertical**(세로), **ScrollView**(정렬, 스크롤 바)  
&nbsp;  
**DisabledGroup** : 상호작용 활성/비활성화   
**ChangeCheck** : UI가 상호작용했을 때 End 메소드가 True를 반환  
&nbsp;  
**Foldout** : 열고 닫기  
**FoldoutHeaderGroup** : 메뉴 작동 가능한 폴드 아웃  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<bR><br><br><br><br>
- - - 

# Horizontal, Vertical
**GUILayout, EditorGUILayout**제공  
Rect BeginHorizontal(), void EndHorizontal()  
Rect BeginVertical(), void EndVertical()  
begin ~ end 사이 UI를 가로, 세로 정렬 | Rect는 해당 범위의 위치, 크기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}    

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/21.png?raw=true)  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/22.png?raw=true)  

<details>
<summary>Horizontal, Vertical</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private void Horizontal(GUIStyle titleStyle)
{
	EditorGUILayout.LabelField("Begin/End Horizontal", titleStyle);

	var mainOptions = new GUILayoutOption[] { GUILayout.Width(256), GUILayout.Height(64) };
	var subOptions = new GUILayoutOption[] { GUILayout.Width(32), GUILayout.Height(32) };

	GUILayout.BeginHorizontal("", GUI.skin.box, mainOptions);
	GUILayout.Button("1", subOptions);
	GUILayout.Button("2", subOptions);
	GUILayout.Button("3", subOptions);
	GUILayout.EndHorizontal();

	Rect rect = EditorGUILayout.BeginHorizontal(GUI.skin.box, mainOptions);
	if ( GUILayout.Button("Rect", subOptions) )	{ Debug.Log(rect); }
	if ( GUILayout.Button("1", subOptions) )	{ Debug.Log("Play"); }
	if ( GUILayout.Button("2", subOptions) )	{ Debug.Log("Pause"); }
	if ( GUILayout.Button("3", subOptions) )	{ Debug.Log("Stop"); }
	EditorGUILayout.EndHorizontal();
}

private void Vertical(GUIStyle titleStyle)
{
	EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
	EditorGUILayout.LabelField("Begin/End Vertical", titleStyle);

	var options = new GUILayoutOption[] { GUILayout.Width(32), GUILayout.Height(32) };

	EditorGUILayout.BeginVertical();
	if ( GUILayout.Button("1", options) )	{ Debug.Log("Push 1"); }
	if ( GUILayout.Button("2", options) )	{ Debug.Log("Push 2"); }
	if ( GUILayout.Button("3", options) )	{ Debug.Log("Push 3"); }
	EditorGUILayout.EndVertical();
}
```
</div>
</details>

<br><br>
- - - 

# ScrollView 
**GUILayout, EditorGUILayout**제공  
Vector2 BeginScrollView(Vector2)  
void EndScrollView()  
UI를 ScrollView에 세로로 정렬  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/23.png?raw=true)  

<details>
<summary>ScrollView</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private void ScrollView(GUIStyle titleStyle)
{
	EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
	EditorGUILayout.LabelField("Begin/End ScrollView", titleStyle);

	var options = new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(100) };

	scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, true, true, options);

	for ( int i = 0; i < 100; ++ i )
	{
		EditorGUILayout.LabelField($"{i}");
	}
	EditorGUILayout.EndScrollView();
}
```
</div>
</details>

<br><br>
- - - 

# DisabledGroup 
**EditorGUI**제공  
void BeginDisabledGroup(bool)  
void EndDisabledGroup()  
UI의 상호작용 활성, 비활성 설정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/24.png?raw=true)  

<details>
<summary>DisabledGroup</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private void DisabledGroup(GUIStyle titleStyle)
{
	EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
	EditorGUILayout.LabelField("Begin/End DisabledGroup", titleStyle);

	string text = isDisabled ? "ON" : "OFF";
	isDisabled = EditorGUILayout.Toggle($"볼륨조절 {text}", isDisabled);

	EditorGUI.BeginDisabledGroup(!isDisabled);
	volume = EditorGUILayout.Slider(volume, 0f, 100f);
	EditorGUI.EndDisabledGroup();

	// GUI.enabled = true, false;로 설정해도 된다.
	GUI.enabled = isDisabled;
	volume = EditorGUILayout.Slider(volume, 0f, 100f);
	GUI.enabled = true;
}
```
</div>
</details>

<br><br>
- - - 

# ChageCheck 
**EditorGUI**제공  
void BeginChageCheck()  
void EndChageCheck()  
UI가 상호작용했을 때 End 메소드가 True를 반환  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/25.png?raw=true)  

<details>
<summary>ChageCheck</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private void ChangeCheck(GUIStyle titleStyle)
{
	EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
	EditorGUILayout.LabelField("Begin/End ChangeCheck", titleStyle);

	toggleValue = EditorGUILayout.Toggle("Don't Change Check", toggleValue);

	EditorGUI.BeginChangeCheck();
	toggleValue = EditorGUILayout.Toggle("Change Check", toggleValue);
	if ( EditorGUI.EndChangeCheck() )
	{
		Debug.Log("Change Check Toggle키 상호작용");
	}
}
```
</div>
</details>

<br><br>
- - - 

# Foldout 
**EditorGUI, EditorLayout**제공  
bool Foldout(bool, string, bool)  
내용을 열고 닫기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/26.png?raw=true)  

<details>
<summary>Foldout</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private	GameObject	gameObject = null;

private void Foldout(GUIStyle titleStyle)
{
	EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
	EditorGUILayout.LabelField("Foldout", titleStyle);

	isExpanded = EditorGUILayout.Foldout(isExpanded, "오브젝트 등록 활성/비활성", true);
	if ( isExpanded == true )
	{
        gameObject = EditorGUILayout.ObjectField(gameObject, typeof(GameObject), true) as GameObject;
	}
}

```
</div>
</details>

<br><br>
- - - 

# FoldoutHeaderGroup 
**EditorGUI, EditorLayout**제공  
bool beginFoldoutHeaderGroup(bool, stirng, System.Action`<Rect>`)  
void EndFoldoutHeaderGroup()  
기본 구조는 Foldout과 동일하지만 우측에 메뉴 버튼이 추가된 형태  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/27.png?raw=true)  

<details>
<summary>FoldoutHeaderGroup</summary>
<div class="notice--primary" markdown="1"> 

```c# 
private void FoldoutHeaderGroup(GUIStyle titleStyle)
{
	EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
	EditorGUILayout.LabelField("FoldoutHeaderGroup", titleStyle);

	isExpanded = EditorGUILayout.BeginFoldoutHeaderGroup(isExpanded, "아이디/비밀번호", menuAction:ShowHeaderContextMenu);
	if ( isExpanded == true )
	{
		EditorGUILayout.BeginVertical();
		id	 = EditorGUILayout.TextField("아이디", id);
		pass = EditorGUILayout.PasswordField("패스워드", pass);
		EditorGUILayout.EndVertical();
	}
	EditorGUILayout.EndFoldoutHeaderGroup();
}

private void ShowHeaderContextMenu(Rect position)
{
	GenericMenu menu = new GenericMenu();
	menu.AddItem(new GUIContent("Clear"), false, () =>
	{
		id	 = string.Empty;
		pass = string.Empty;
	});
	menu.AddItem(new GUIContent("Default"), false, () =>
	{
		id	 = "포스트잇";
		pass = "Unity";
	});

	menu.DropDown(position);
}
```
</div>
</details>

<br><br><br><br><br>
- - - 

# 이것저것 메모

<br><br><br><br><br>
- - - 


# 잡담, 일기?
`Horizontal`, `Vertical`, `ScrollView`, `DisabledGroup`, `ChangeCheck`, `Foldout`,  `FoldoutHeaderGroup`
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -