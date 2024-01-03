---
title:  "[TIL] 50 강의 - AddForce player.SetParent ⭐⭐ "
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


`Addforce`, `player.SetParent`

<BR><BR>

<center><H1>  Addforce, player.SetParent  </H1></center>

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

<div class="notice--primary" markdown="1"> 

```c#

private void OnCollisionEnter(Collision collision)
{
    if(collision.collider.CompareTag("Player"))
    {
        collision.gameObject.transform.SetParent(transform);
    }
}

private void OnCollisionExit(Collision collision)
{
    if (collision.collider.CompareTag("Player"))
    {
        collision.gameObject.transform.SetParent(null);
    }
}

```
</div>

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br><br><br><br>
- - - 

# Audio

<div class="notice--primary" markdown="1"> 

```c#

public AudioSource BgSound;
public AudioClip[] Bglist;
//배경음 바꿀 때 GMTest.Instance.audioManager.

private void Start()
{
    BgSoundPlay(Bglist[0]);
}
public void SFXPlay(string sfxName, AudioClip clip) 
{
    GameObject AudioGo = new GameObject( sfxName+"Sound" );
    AudioSource audiosource = AudioGo.AddComponent<AudioSource>();
    audiosource.clip = clip;
    audiosource.Play();

    Destroy(audiosource, clip.length );
}
//GMTest.Instance.audioManager.SFXPlay("die", AudioClip);

public void BgSoundPlay(AudioClip clip) 
{
    BgSound.clip = clip;
    BgSound.loop = true;
    BgSound.volume = 0.1f;
    BgSound.Play();
}
//GMTest.Instance.audioManager.BgSoundPlay(AudioClip);

```
</div>


# 잡담,정리
오늘 처음 30분 지각했다. 열심히 하자..   
AudioManager 보기   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
