---
title:  "[TIL] 51 강의 - SavePosition ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-04 02:00

---
- - -


`SavePosition`

<BR><BR>

<center><H1>  SavePosition  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 52  
&nbsp;&nbsp; [o] 다른반 강의 듣기   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# Restart 
Restart 위치 지정 
SavePosition

<div class="notice--primary" markdown="1"> 

```c#
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    private Vector3 _startPoint; // 시작위치 설정.
    private Vector3 _firstStartPoint = new Vector3(10,10,10); // 1스테이지 시작위치 설정.
    private Vector3 _SecondStartPoint = new Vector3(94, 0, 15); // 2스테이지 시작위치 설정.

    private Vector3 _savePoint = Vector3.zero;  // 저장위치 설정.

    private GameObject _player;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        //Scene scene = SceneManager.GetActiveScene();
        
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            StartCoroutine(ReStartCo());
        }
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode arg1)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        sceneCheck(scene);
        _savePoint = _startPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(_savePoint);
        if (collision.gameObject.tag == "SaveBoard")
        {
            _savePoint = collision.transform.position + Vector3.up;
            //세이브 이펙트
            Destroy(collision.gameObject,1f);
        }
    }
    
    IEnumerator ReStartCo()
    {
        //피이펙트
        yield return new WaitForSeconds(1f);
        _player.transform.position = _savePoint;
        _savePoint = _startPoint;
    }

    private void sceneCheck(Scene scene) 
    {
        if (scene.name == "KJW")
        {
            _startPoint = _firstStartPoint;
        }
        else if (scene.name == "99.BJH")
        {
            _startPoint = _SecondStartPoint;
        }
    }
}


```
</div>

<br><br>

> - 풍선 터트리고 밟으면 1회성 세이브포인트  
> - 씬바뀌면 씬 이름별로 startPosition 바꾸기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br><br><br><br>
- - - 

# 잡담,정리
> - 내일 사운드, 파티클 하기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
