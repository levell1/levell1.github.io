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
EditorGUIUtility.Load(string path) "sample.png" 로 불러올 수 있습니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br>


## TestEditorWindow
SetUp()
MenuItem : window - Unitynote 탭에서 윈도우 생성 가능  
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

    [MenuItem("Window/Unitynote/EmptyWindow")]
    private static void Setup()
    {
        window = GetWindow<TestEditorWindow>();

        //SceneView 에 포함되도록 설정
        //window = GetWindow<TestEditorWindow>(typeof(SceneView));

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
        Debug.Log("OnGUI() : Repaint()가 호출될 때마다 호출");
    }
}
```
</div>
</details>


<br><br><br><br><br>


# 이것저것 메모

## EditorWindow.Show
EditorWindow.Show() : 에디터 화면에 윈도우 출력  
EditorWindow.ShowUtility() : 탭 윈도우 없이 출력  
EditorWindow.ShowPopup() : 타이틀, 닫기버튼이 없는 윈도우 ( 스크립트 내부에서 Close로 닫기)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br><br>
- - - 


# 잡담, 일기?
Behavior 마무리  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior.png?raw=true)   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -