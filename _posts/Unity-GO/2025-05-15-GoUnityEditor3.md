---
title:  "[Unity6] Custom Editor (Slider, HelpBox, Knob, ProgressBar)"
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-05-15 05:00

---
- - -

`Slider`, `HelpBox`, `Knob`, `IndentLevel`, `ProgressBar`

<br>
- - - 

# Slider
**EditorGUILayout**  
int EditorGUILayout.IntSlider(string, int, int, int) : int 타입의 변수를 사용하는 Slider  
float EditorGUILayout.FloatSlider(string, float, float, float) : float 타입의 변수를 사용하는 Slider  
void EditorGUILayout.MinMaxSlider(string, ref float, ref float, float, float) : min ~ max 범위의 값을 선택할 수 있는 Slider  
&nbsp;  
**GUILayout**  
float GUILayout.HorizontalSlider(float, float, float) : float 타입 가로 Slider  
float GUILayout.VerticalSlider(float, float, float) : float 타입 세로 Slider  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/14.png?raw=true)  

<details>
<summary>Slider</summary>
<div class="notice--primary" markdown="1"> 

```c# 
intValue = EditorGUILayout.IntSlider("Int Slider", intValue, 0, 100);
floatValue = EditorGUILayout.Slider("Float Slider", floatValue, 0f, 10f);
EditorGUILayout.MinMaxSlider("MinMax Slider", ref minValue, ref maxValue, 0f, 10f);

floatValue = GUILayout.HorizontalSlider(floatValue, 0f, 10f);
floatValue = GUILayout.VerticalSlider(floatValue, 0f, 10f, GUILayout.Height(64));
```
</div>
</details>

<br><br>

# HelpBox
Console View에 로그를 출력하는 것과 같이 정보, 경고, 에러 로그를 출력하는 박스 생성  
EditorGUILayout.HelpBox(string message, MessageType type);  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}    


![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/15.png?raw=true)  

<details>
<summary>HelpBox</summary>
<div class="notice--primary" markdown="1"> 

```c# 
EditorGUILayout.HelpBox("Info", MessageType.Info);
EditorGUILayout.HelpBox("Warning", MessageType.Warning);
EditorGUILayout.HelpBox("Error", MessageType.Error);
```
</div>
</details>

<br><br>

# Knob 
Drag로 조절 가능한 원형 게이지  
float result = EditorGUILayout.knob(Vector2 knobSize, float value, float minValue, float MaxValue, strin unit, Color backgroundColor, Color activeColor, bool showValue);  
knobSize - 게이지 크기  
unit - 출력할 텍스트  
showValue - 게이지 수치를 출력할 지 여부  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/16.png?raw=true)  

<details>
<summary>Knob</summary>
<div class="notice--primary" markdown="1"> 

```c# 
floatValue = EditorGUILayout.Knob(Vector2.one * 64, floatValue, 0f, 10f, "게이지", Color.black, Color.red, true);
```
</div>
</details>

<br><br>

# ProgressBar 
0.0 ~ 1.0 사이의 float 데이터로 진행도 출력.  
ProgressBar 중앙에 text 내용 출력  
EditorGUI로 사용 가능  
void EditorGUI.ProgressBar(Rect position, float value, string text)  
showValue - 게이지 수치를 출력할 지 여부  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/18.png?raw=true)  

<details>
<summary>ProgressBar</summary>
<div class="notice--primary" markdown="1"> 

```c# 
Rect rect = new Rect(0, 400, 300, EditorGUIUtility.singleLineHeight);
EditorGUI.ProgressBar(rect, (float)intValue / 100, $"체력 {intValue}/100");
```
</div>
</details>

<br><br><br><br><br>

# 이것저것 메모
## IndentLevel 
UI 들여쓰기  
int EditorGUI.indentLevel{set; get;}  
showValue - 게이지 수치를 출력할 지 여부  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/17.png?raw=true)  

<details>
<summary>IndentLevel</summary>
<div class="notice--primary" markdown="1"> 

```c# 
EditorGUI.indentLevel++;
EditorGUILayout.HelpBox("Info", MessageType.Info);
EditorGUI.indentLevel += 10;
EditorGUILayout.HelpBox("Warning", MessageType.Warning);
EditorGUI.indentLevel -= 11;
EditorGUILayout.HelpBox("Error", MessageType.Error);
```
</div>
</details>

<br><br><br><br><br>
- - - 


# 잡담, 일기?
`Slider`, `HelpBox`, `Knob`, `IndentLevel`, `ProgressBar`  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Editor/20.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -