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

# SavePoint

<div class="notice--primary" markdown="1"> 

```c#

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    private Vector3 _startPoint; // 시작위치 설정.
    private Vector3 _firstStartPoint = new Vector3(0,50,50); // 1스테이지 시작위치 설정.
    private Vector3 _SecondStartPoint = new Vector3(94, 0, 15); // 2스테이지 시작위치 설정.

    private Vector3 _savePoint = Vector3.zero;  // 저장위치 설정.

    private HealthSystem HealthSystem;
    private PlayerRagdollController _playerRagdollController;

    private void Awake()
    {
        _playerRagdollController = GetComponent<PlayerRagdollController>();
        HealthSystem = GetComponent<HealthSystem>();
    }
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        sceneCheck(scene);
        _savePoint = _startPoint;
        HealthSystem.OnDied += revive;
        //SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    public void revive() 
    {
        StartCoroutine(ReStartCo());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            StartCoroutine(ReStartCo());
        }
        checkSaveBoard();
        Debug.DrawRay(transform.position, Vector3.down, Color.red, 0.3f);
    }

    /*private void LoadedsceneEvent(Scene scene, LoadSceneMode arg1)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        sceneCheck(scene);
        _savePoint = _startPoint;
    }*/

    private void checkSaveBoard() 
    {
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, Vector3.down, out _hit, 1,4))
        {
            if (_hit.transform.CompareTag("SaveBoard"))
            {
                Debug.Log("세이브보드");
                _savePoint = _hit.transform.position + Vector3.up;
                //세이브 이펙트
                Destroy(_hit.collider.gameObject, 1f);
            }
        }
    }
    
    public IEnumerator ReStartCo()
    {
        _playerRagdollController.SetRagdollState(true);
        yield return new WaitForSeconds(5.1f);
        gameObject.transform.position = _savePoint;
        _savePoint = _startPoint;
    }

    private void sceneCheck(Scene scene) 
    {
        if (scene.name == "KDH_Obstacle")
        {
            _startPoint = _firstStartPoint;
        }
        else if (scene.name == "99.BJH")
        {
            _startPoint = _SecondStartPoint;
        }
        else
        {
            _startPoint = Vector3.zero;
        }
    }
}


```
</div>

SceneManager.sceneLoaded += LoadedsceneEvent;  
    private void LoadedsceneEvent(Scene scene, LoadSceneMode arg1)  
    {  
        _player = GameObject.FindGameObjectWithTag("Player");  
        sceneCheck(scene);  
        _savePoint = _startPoint;  
    }  
씬 이동시 startpoint가 바뀌게 할려고 했다, 플레이어에 스크립트를 달았는데 그럼
씬을 이동할 때 이 스크립트는 파괴되면 안된다고 생각이 됐고, 다른 방법으로 씬별 스타트 포지션을 바꾸기로 했다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br><br><br><br><br>
- - -

# 잡담,정리

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
