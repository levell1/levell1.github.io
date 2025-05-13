---
title:  "[Unity6] Custom Editor "
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-05-12 05:00

---
- - -

`TextField` `Button` `Color` `GUIContent` `GUIStyle` `GUILayoutOption`

<br>
- - - 

# Custom Editor
1.&nbsp;Editor 폴더  
Editor API 사용을 위해 유니티에서 제공하는 폴더  
Runtime에 작동하지 않는다.  
Assets 폴더 하위라면 Editor 폴더의 위치는 중요하지 않다 (여러 개 생성 가능)  
Editor가 아닌 다른 폴더에 Editor, EditorWindow 클래스를 상속받은 스크립트 저장 시 에러 발생   
&nbsp;  
2.&nbsp;Editor Default Resources 폴더  
Resources 폴더와 마찬가지로 Custrom Editor에서만 사용하는 리소스 저장 폴더.  
EditorGUIUtility.Load(string path) "sample.png"로 불러올 수 있습니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<BR><BR><BR><BR>



# 사용되는 클래스 
에디터 확장을 위한 UI 출력에 사용하는 클래스  
**GUI**, **GUILayout**, **EditorGUI**, **EditorGUILayout**  
&nbsp;  
**GUI** : 가장 오래된 GUI 시스템 주로 OnGUI() 메소드를 통해 사용  
**GUILayout** : 상대적인 레이아웃을 사용해 UI 요소를 배치할 때 사용  
Runtime(O) / button(O)  
&nbsp;  
**EditorGUI** : 에디터 윈도우 및 에디터 환경에서 사용하는 유니티 GUI 요소  
**EditorGUILayout** : EditorGUI의 레이아웃 버전 상대적인 레이아웃을 사용해 UI 배치  
Runtime(X) / button(X)  
&nbsp;  
GUI / Layout  
**GUI**, **EditorGUI** : Rect(x,y,width,heigh)를 통해 UI의 위치 설정, 넓이 높이를 직접 설정  
**GUILayout**, **EditorGUILayout** : UI 위치, 크기를 자동으로 설정, 정렬, (높이 : 18, 코드 작성 순으로 정렬)  
&nbsp; GUILayoutOption, Space(float Width)를 사용해 간격 조절  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br>



# TestEditorWindow
SetUp() : 에디터 창 제목, 크기 설정  
OnGUI() : GUI 출력  
**TextField** **Button** **Color** **GUIContent** **GUIStyle** **GUILayoutOption**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<details>
<summary>TestEditorWindow</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEditor;

public class TestEditorWindow : EditorWindow
{
    private static TestEditorWindow window;

    // 현재는 임시로 여기에 변수를 두었지만 일반적으로 데이터는 외부에서 가져와 사용
    private string textGUI = "GUI.TextField()";
    private string textGUILayout = "GUILayout.TextField()";
    private string textEditorGUI = "EditorGUI.TextField()";
    private string textEditorGUILayout = "EditorGUILayout.TextField()";

    [MenuItem("Window/Unitynote/EmptyWindow")]
    private static void Setup()
    {
        window = GetWindow<TestEditorWindow>();

        // SceneView 에 포함되도록 설정
        // window = GetWindow<TestEditorWindow>(typeof(SceneView));

        // 윈도우 제목(Title) 설정
        window.titleContent = new GUIContent("Unitynote");

        // 윈도우 최소/최대 크기 설정
        window.minSize = new Vector2(300, 300);
        window.maxSize = new Vector2(1920, 1080);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable() : 윈도우가 열릴 때 1회 호출");
    }

    private void OnGUI()
    {
        Color defaultContentColor = GUI.contentColor;
        GUI.contentColor = Color.red;

        // 아래와 같이 new로 메모리를 할당하지 않고 참조해서 사용하면 유니티 에디터 스타일 전체가 변경된다.
        // GUIStyle customLabelStyle	= EditorStyles.label;
        GUIStyle customLabelStyle = new GUIStyle(EditorStyles.label);
        customLabelStyle.alignment = TextAnchor.MiddleCenter;
        customLabelStyle.fontStyle = FontStyle.BoldAndItalic;
        customLabelStyle.fontSize = 20;

        GUIStyle customLabelStyle2 = new GUIStyle(GUI.skin.label);
        customLabelStyle2.fontStyle = FontStyle.Bold;

        GUIContent LabelContent = new GUIContent("GUI.Label()", "[GUIContent Hover]");

        GUI.Label(new Rect(0, 130, 300, 20), LabelContent, customLabelStyle);
        GUILayout.Label("GUILayout.Label()", customLabelStyle2);
        EditorGUI.LabelField(new Rect(0, 150, 300, 20), "EditorGUI.LabelField()");
        EditorGUILayout.LabelField("EditorGUILayout.LabelField()");

        GUI.contentColor = defaultContentColor;

        Color defaultBackgroundColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.blue;


        textGUI = GUI.TextField(new Rect(0, 170, 300, 20), textGUI);
        textGUILayout = GUILayout.TextField(textGUILayout, GUILayout.Height(50), GUILayout.MaxWidth(500));
        textEditorGUI = EditorGUI.TextField(new Rect(0, 190, 300, 20), "EditorGUI : ", textEditorGUI);
        textEditorGUILayout = EditorGUILayout.TextField("EditorGUILayout : ", textEditorGUILayout);

        GUI.backgroundColor = defaultBackgroundColor;

        GUIContent btnContent = new GUIContent("GUI.Button()", "[GUIContent Hover]");

        if (GUI.Button(new Rect(0, 210, 300, 20), btnContent))
        {
            Debug.Log("GUI.Button() Click");
        }

        if (GUILayout.Button("GUILayout.Button()"))
        {
            Debug.Log("GUILayout.Button() Click");
        }
    }
}


/* Editor Default Resources
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class TestEditorWindow
{
	static TestEditorWindow()
	{
		var tex = EditorGUIUtility.Load("SampleTex.png");
		Debug.Log(tex);
	}
}*/

/* GUIContent
GUILayout.Label("출력 내용");

GUIContent content = new GUIContent("출력 내용", "마우스를 Hover했을 때 출력할 설명");
GUILayout.Label(content);
*/
```
</div>
</details>

<br><br><br><br>

## Label
Lable, LabelField  
GUI.Label(Rect rect,string text)  
GUILayout.LabelField(string text)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/1.png?raw=true)   

<details>
<summary>Label</summary>
<div class="notice--primary" markdown="1"> 

```c# 
GUI.Label(new Rect(0, 130, 300, 20), "GUI.Label()", customLabelStyle);
GUILayout.Label("GUILayout.Label()", customLabelStyle2);
EditorGUI.LabelField(new Rect(0, 150, 300, 20), "EditorGUI.LabelField()");
EditorGUILayout.LabelField("EditorGUILayout.LabelField()");
```
</div>
</details>

<br><br>

## TextField
string result = **GUI**.TextField(Rect rect, string text);  
입력 필드 출력, 필드에 입력한 내용이 반환된다.   
&nbsp;  
private string textGUI = "**GUI**.TextField()";  
textGUI = GUI.TextField(new Rect(0, 170, 300, 20), textGUI);  
&nbsp;  
&nbsp;  
string result = **GUILayout**.TextField(Rect rect, string label, string text);  
Label과 입력 필드 출력, 필드에 입력한 내용이 반환된다.   
&nbsp;  
private string textGUILayout = "**GUILayout**.TextField()";  
textGUILayout = GUILayout.TextField(textGUILayout, GUILayout.Height(50), GUILayout.MaxWidth(500));  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/2.png?raw=true)   

<details>
<summary>TextField</summary>
<div class="notice--primary" markdown="1"> 

```c# 
textGUI = GUI.TextField(new Rect(0, 170, 300, 20), textGUI);
textGUILayout = GUILayout.TextField(textGUILayout, GUILayout.Height(50), GUILayout.MaxWidth(500));
textEditorGUI = EditorGUI.TextField(new Rect(0, 190, 300, 20), "EditorGUI : ", textEditorGUI);
textEditorGUILayout = EditorGUILayout.TextField("EditorGUILayout : ", textEditorGUILayout);
```
</div>
</details>

<br><br>

## Button
GUI만 가능 Editor(x)  
bool isClick = Button(Rect rect, string text)  
버튼 출력 버튼 입력 여부가 반환됩니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/3.png?raw=true)   

<details>
<summary>Button</summary>
<div class="notice--primary" markdown="1"> 

```c# 
GUIContent btnContent = new GUIContent("GUI.Button()", "[GUIContent Hover]");

if (GUI.Button(new Rect(0, 40, 300, 20), btnContent))
{
    Debug.Log("GUI.Button() Click");
}

if (GUILayout.Button("GUILayout.Button()"))
{
    Debug.Log("GUILayout.Button() Click");
}
```
</div>
</details>

<br><br>

## Color
기본 색상 저장 - GUI 색상 변경 - 변경된 색상으로 출력 - GUI 기본 색상으로 복구  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/4.png?raw=true)   

<details>
<summary>Color</summary>
<div class="notice--primary" markdown="1"> 

```c# 
// 글 색상 변경
Color defaultContentColor = GUI.contentColor;   // 기본 색상 저장  
GUI.contentColor = Color.red;                   // GUI 색상 변경  

GUI.Label(new Rect(0, 0, 300, 20), "GUI.Label()", customLabelStyle);  // 변경된 색상으로 출력

GUI.contentColor = defaultContentColor;         // GUI 기본 색상으로 복구 

// 배경 색 변경
Color defaultBackgroundColor = GUI.backgroundColor;
GUI.backgroundColor = Color.blue;

textGUI = GUI.TextField(new Rect(0, 30, 300, 20), textGUI);

GUI.backgroundColor = defaultBackgroundColor;
```
</div>
</details>

<br><br>

## GUIContent
UI에 마우스를 hover 했을 때 출력할 설명 설정  
Label, TextField 등과 같이 텍스트를 출력하는 모든 메소드에서 string, GUIContent를 선택해서 사용 가능  
GUIContent textandhovertext = new GUIContent("Text", "HoverText");  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/5.png?raw=true)   

<details>
<summary>GUIContent</summary>
<div class="notice--primary" markdown="1"> 

```c# 
GUIContent LabelContent = new GUIContent("GUI.Label()", "[GUIContent Hover]");
GUI.Label(new Rect(0, 130, 300, 20), LabelContent, customLabelStyle);

GUIContent btnContent = new GUIContent("GUI.Button()", "[GUIContent Hover]");
if (GUI.Button(new Rect(0, 210, 300, 20), btnContent))
{
    Debug.Log("GUI.Button() Click");
}
```
</div>
</details>

<br><br>

## GUIStyle
특정 style을 설정하고 원하는 UI에 적용해 변경   
new로 메모리를 할당하지 않고 참조해서 사용하면 유니티 에디터 스타일 전체가 변경된다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/6.png?raw=true)   

<details>
<summary>GUIStyle</summary>
<div class="notice--primary" markdown="1"> 

```c# 
// 아래와 같이 new로 메모리를 할당하지 않고 참조해서 사용하면 유니티 에디터 스타일 전체가 변경된다.
// GUIStyle customLabelStyle	= EditorStyles.label;
GUIStyle customLabelStyle = new GUIStyle(EditorStyles.label);
customLabelStyle.alignment = TextAnchor.MiddleCenter;
customLabelStyle.fontStyle = FontStyle.BoldAndItalic;
customLabelStyle.fontSize = 20;

GUIStyle customLabelStyle2 = new GUIStyle(GUI.skin.label);
customLabelStyle2.fontStyle = FontStyle.Bold;

GUI.Label(new Rect(0, 30, 300, 20), "GUI.Label()", customLabelStyle);
GUILayout.Label("GUILayout.Label()", customLabelStyle2);
```
</div>
</details>

<br><br>

## GUILayoutOption
Layout의 최소, 최대 크기 등을 설정할 때 사용  
Width, minWidth, MaxWidth  
Height, minHeight, maxHeight  
ExpandWidth  남는 공간만큼 UI를 채워서 출력  
ExpandHeight  남는 공간만큼 UI를 채워서 출력  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/7.png?raw=true)   

<details>
<summary>Color</summary>
<div class="notice--primary" markdown="1"> 

```c# 
textGUILayout = GUILayout.TextField(textGUILayout);
textGUILayout = GUILayout.TextField(textGUILayout, GUILayout.Height(50), GUILayout.MaxWidth(500));
```
</div>
</details>

<br><br><br><br>

# 이것저것 메모

기본적으로 Layout을 사용하고 상황에 맞게 GUI/Editor, 기본/Layout 결정해서 쓰면 될 거 같다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br><br>
- - - 

text
![Image](https://github.com/user-attachments/assets/ef3a2698-da78-44a8-ae41-e6f36fcffe6f)  

# 잡담, 일기?
Custom Editor로 개발 효율성을 높일 수 있다.  
**TestEditorWindow** Editor 화면  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/8.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -