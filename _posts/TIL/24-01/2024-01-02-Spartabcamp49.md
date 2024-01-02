---
title:  "[TIL] 49 강의 - 팀프로젝트 alt f4  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-02 02:00

---
- - -



<BR><BR>


<center><H1>  팀프로젝트 1일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 51  
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 점프대 만들기 
## 1. Addforce 

<div class="notice--primary" markdown="1"> 

```c#

private void OnCollisionEnter(Collision collision)
{
    Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
    Vector3 forwardDirection = collision.transform.up;
    if (otherRigidbody != null)
    {
        otherRigidbody.AddForce(forwardDirection * 30, ForceMode.Impulse);
    }
}

```
</div>


<br><br>

## 2. Rotation,Addforce 

<div class="notice--primary" markdown="1"> 

```c#
using System.Collections;
using UnityEngine;


public class RotationJump : MonoBehaviour
{

    private float _rotateSpeed = 1f;
    private Vector3 _stopRotate = new Vector3(80, 0, 0);
    private Vector3 _startRotate = new Vector3(0, 0, 0);
    private bool _checkRotate = true;
    private bool _collidertime = true;

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Player"&&_checkRotate && _collidertime) 
        {
            StartCoroutine(RotatePad(collision));
            _collidertime = false;
        }
    }

    IEnumerator RotatePad(Collision collision)
    {
        while (_checkRotate)
        {
            Debug.Log(_rotateSpeed);
            _rotateSpeed += 0.01f;
            transform.Rotate(Vector2.right* _rotateSpeed);
            yield return null;
            if (_stopRotate.x - transform.eulerAngles.x <= 50f)
            {
                Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 forwardDirection = collision.transform.up; 
                if (otherRigidbody != null)
                {
                    otherRigidbody.AddForce(forwardDirection*10, ForceMode.Impulse);
                }

                transform.rotation = Quaternion.Euler(_stopRotate);
                _checkRotate =false;
            }
        }

        yield return new WaitForSeconds(2f) ;

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

<div class="notice--primary" markdown="1"> 

```c#
while (!_checkRotate)
{
    transform.Rotate(Vector2.left);
    yield return new WaitForSeconds(0.5f);
    Debug.Log(transform.eulerAngles.x);
    if (Mathf.Approximately(transform.eulerAngles.x, _startRotate.x))
    {
        _checkRotate = true;
    }

    //-> if (transform.eulerAngles.x - _startRotate.x <= 1.1f)
}
```
</div>

> - rotation 이 1-> 0으로 될 때 0이 아닌 360이 되어서  
> - Mathf.Approximately(transform.eulerAngles.x,startRotate.x)로 원하는대로 멈출 수 없었다.  
> - if (transform.eulerAngles.x - _startRotate.x <= 1.1f) 로 바꿔서 작동.   
> - 1 -> 1.333971E-05 -> 359  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5ab7fb31-8391-4ca8-b031-5524fcf96e11){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br><br><br><br>
- - - 

# 공중 그네에서 이동
> - 팀원 장애물 중 공중 그네에착지 후 그네를 따라 플레이어가 움직여야 됐다.  
> - 그네에 착지 시 그네를 플레이어 부모로 만들고 그네에서 떨어지면 따로 분리 하는 방법이 있는 거 같았다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br><br><br><br>
- - - 

# 잡담,정리
> - 문제 : 플레이어가 점프, 충돌이 일어나지 않는다. startasset에 뭔가가 있는건지,  
> - 플레이어관련해서 처리해야 될 게 있는건지 알아보기.  
> - 할일 : 가시, 문제, 틀린문제 문닫기, 열기,  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

[Dictionary](https://iden351.tistory.com/55)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
