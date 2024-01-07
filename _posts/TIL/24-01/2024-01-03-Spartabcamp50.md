---
title:  "[TIL] 50 AddForce player.SetParent ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-03 02:00

---
- - -


`Addforce`, `player.SetParent`

<BR><BR>

<center><H1>  2일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 51  
&nbsp;&nbsp; [o] 다른반 강의 듣기   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 점프대 만들기 

## 2. Rotation,Addforce 

<div class="notice--primary" markdown="1"> 

```c#
    [SerializeField]
    private float _jumpforce = 30f;
    private float _rotateSpeed = 0.5f;
    private Vector3 _stopRotate = new Vector3(60, 0, 0);
    private Vector3 _startRotate = new Vector3(0, 0, 0);
    private bool _checkRotate = true;
    private bool _collidertime = true;
    private bool _onPad = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && _checkRotate && _collidertime)
        {
            StartCoroutine(RotatePad(collision));
            _collidertime = false;
            _onPad = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _onPad = false;
    }

    IEnumerator RotatePad(Collision collision)
    {
        PlayerJump(collision, Vector3.left);

        yield return new WaitForSeconds(0.1f);
        while (_checkRotate)
        {
            _rotateSpeed += 0.01f;
            transform.Rotate(Vector2.right * _rotateSpeed);
            yield return null;
            if (_stopRotate.x - transform.eulerAngles.x <= 10f)
            {

                Vector3 forwardDirection = transform.up;
                
                //Rigidbody Addforce 에서 다른 방법으로 변경 (y는 힘을 받는데 z 힘을 못받음)
                Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                if (otherRigidbody != null&& _onPad)
                {
                    Debug.Log("addforce 방향 : " + forwardDirection * _jumpforce);
                    otherRigidbody.AddForce(forwardDirection * _jumpforce, ForceMode.Impulse);
                }

                transform.rotation = Quaternion.Euler(_stopRotate);
                _checkRotate = false;
            }
        }

        yield return new WaitForSeconds(2f);

        while (!_checkRotate)
        {
            transform.Rotate(Vector2.left);
            yield return null;

            if (transform.eulerAngles.x - _startRotate.x <= 1.1f)
            {
                transform.rotation = Quaternion.Euler(_startRotate);
                _checkRotate = true;
            }
        }
        _collidertime = true;
        _rotateSpeed = 1f;
    }
}
```
</div>

<br><br>

addforce 가 y축은 되는데 z축이 이상하게 된다. 내일 생각해보기.

![image](https://github.com/levell1/levell1.github.io/assets/96651722/0a4c52e6-073a-4b0e-8706-6c1ca6547d89){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br><br><br><br>
- - - 

# setParent
플레이어 부모set,null
팀원분 코드 다음에 참고할 때 보기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

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


<br><br><br><br><br>
- - - 


# 잡담,정리

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
