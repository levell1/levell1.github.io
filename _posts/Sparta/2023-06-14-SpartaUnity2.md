---
title:  "[2D Sparta-Unity] 2주차 Unity , 풍선 지키기  ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-10-24

---
- - -
<BR><BR>

<center><H1> 2주차 풍선 지키기</H1></center>
풍선 지키면서 점수 얻기.  마우스 제어, 베스트 스코어, 애니메이션
{: .notice}

[**2주차 풍선 지키기**](https://levell1.github.io/sparta%20game/MyShield/)
<br><br><br><br><br><br>
- - - 

# 1. 배경, 캐릭터 구성

> - 화면 비율 수정(760 x 1280)
> - 배경, 풍선 생성후  
> - Order in Layer 확인하기  
> - Time Text 추가
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 애니메이션

>   - Animation 생성  
>   - Loop Time(반복)확인  
>   - 평상시 색 변화(Idle),  사망(DIE)
>   - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/7b093a2d-e100-4d68-8af5-0941e9cc3f10){:style="border:1px solid #eaeaea; border-radius: 7px;"}     
>   - 애니메이션 파라미터(isDie)를 이용하여 게임오버시 isDie =true 가 되면 Die애니메이션 재생
{: .notice--info}

>   - 녹화 버튼으로 색변화 애니메이션 생성
>   -   ![image](https://github.com/levell1/levell1.github.io/assets/96651722/f63567a2-4c08-4343-8d41-6f6713e00301){:style="border:1px solid #eaeaea; border-radius: 7px;"}   
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 3. 쉴드 움직이기

> 마우스로 쉴드 위치 변경

## `shield.cs`

<div class="notice--primary" markdown="1"> 

`shield.cs`
```c# 
using UnityEngine;

public class shield : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
}
```
-   쉴드 마우스 포인터 따라가기코드

</div>

<br><br><br><br><br><br>
- - - 

# 4. Squre 코딩

## `square.cs`

<div class="notice--primary" markdown="1"> 

`square.cs`
```c# 
using UnityEngine;

public class square : MonoBehaviour
{
    void Start()
    {
        float x = Random.Range(-3.0f,3.0f);
        float y = Random.Range(3.0f,5.0f);
        transform.position = new Vector3(x,y,0);

        float size = Random.Range(0.5f,1.5f);
        transform.localScale = new Vector3(size,size,1);
    }

    private void Update() {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Balloon")
        {
            GameManager.I.gameOver();
        }
    }
}
```

</div>

## 반복 랜덤 square
>   GameManager 오브젝트를 만들고 → 빗방울을 Prefabs로 틀을 만들고 → Instantiate 복제합니다!  

<br><br><br><br><br><br>
- - - 

# 5. GameManager

> - GameManager란? 게임 전체를 조율하는 오브젝트!  
> - 점수 / 다시 시작 / 3번 째 다시 시작에 부스터 / 광고보기 등  
{: .notice--info}

## `GameManager.cs`

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    
    public GameObject square;
    public Text timeTxt;
    public GameObject endPanel;
    public Text thisScoreTxt;   
    public Text maxScoreTxt;
    public Animator anim;

    float alive = 0f;
    bool isRunnig = true;  

    void Awake()
    {
        I = this;
    }
    
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }
    
    void Update()
    {
        if (isRunnig)
        {
        alive += Time.deltaTime;
        timeTxt.text = alive.ToString("N2");    //N2 소수점 2자리
        }
    }
    
    void makeSquare(){
        Instantiate(square);
    }

    public void gameOver()
    {
        anim.SetBool("isDie", true);
        isRunnig=false;
        Invoke("timeStop",0.5f);
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString("N2");

        if (PlayerPrefs.HasKey("bestScore") == false)
        {
            PlayerPrefs.SetFloat("bestScore", alive);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") < alive)
            {
                PlayerPrefs.SetFloat("bestScore", alive);
            }
        }
        maxScoreTxt.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
    }
    
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    void timeStop(){
        Time.timeScale = 0.0f;
    }
}
```
-   InvokeRepeating  ("메서드 이름", 시간 딜레이, 반복 시간 단위)메서드를 x초 후 실행하고, 매 y초마다 반복해서 실행하는 것을 의미
-   Instantiate( 이미 만들어진 게임 오브젝트를 필요할 때마다 실시간으로 만든다는 의미)

</div>


<br><br><br><br><br><br>
- - - 
 
# 6. 게임 끝내기

> - Retry 판넬 만들기(Canvas)  
> - Active 로 종료시 보이게 하기  
> - 판넬에 버튼추가 클릭시 retry 함수 다시시작(Main Scene을 새로고침 한다.)  
> - onclick -> panel.retry  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/06d46123-8ee2-432c-87e8-d4815f713a2f){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
> - Button target Graphic (클릭 가능한 느낌 주기)  
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/7951d356-d182-4123-8bd7-1f889b47a9c0){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice--info}

## `panel.cs`

<div class="notice--primary" markdown="1"> 

`panel.cs`
```c# 
using UnityEngine;

public class panel : MonoBehaviour
{
    public void retry()
    {
        GameManager.I.retry();
    }
}
```

</div>

<br><br><br><br><br><br>
- - - 
 
# 7. 데이터 보관 (Playerprefs)
앱을 껐다 켜도 데이터가 유지되게 - 유니티에서 데이터를 보관하는 방법
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b2df9199-8c6c-4c7a-b57f-ca228fe0920a){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
// 데이터 저장하기 Set~~~~
Playerprefs.SetFloat("bestScore", 어떤숫자값);
Playerprefs.SetString("bestScore", 어떤문자열);

// 데이터 불러오기 get~~~~
Playerprefs.getFloat("bestScore");
Playerprefs.getString("bestScore");

// 저장하고 있는지 확인
Playerprefs.HasKey("bestScore") //"bestScore" 라는 이름으로 저장하고 있는지 확인

// 모두 지우기
Playerprefs.DeleteAll();
```
</div>

[데이터 보관 메모](https://levell1.github.io/memo%20unity/MUnity-Data/)
<br><br><br><br><br><br>
- - - 

# 8. 정리


<br><br>
- - - 

1회 23/06/14  
2회 23/10/24 복습, 수정  
[Unity] 풍선지키기
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
