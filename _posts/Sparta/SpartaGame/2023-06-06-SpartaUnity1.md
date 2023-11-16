---
title:  "[2D Sparta-Unity] 1주차 Unity , 빗방울게임  ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-10-19

---
- - -
<BR><BR>

<center><H1> 1주차 빗방울게임 </H1></center>
빗방울 먹고 점수 얻기  
{: .notice}

[**1주차 빗방울게임**](https://levell1.github.io/sparta%20game/RainRtan/)
<br><br><br><br><br><br>
- - - 

# 1. 배경, 캐릭터 구성

> - 배경, 캐릭터 생성후  
> - Order in Layer 확인하기  
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 애니메이션 입히기

>   - Animation 생성  
>   - Loop Time(반복)확인  
>   - 두개의 그림을 반복  
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 3. 캐릭터 움직이기

> - Edit → Preferences → External Tools → Vs Code 등록  
> - 코드 작성  
{: .notice--info}

## `rtan.cs`

<div class="notice--primary" markdown="1"> 

`rtan.cs`
```c# 
using UnityEngine;

public class rtan : MonoBehaviour
{
    [SerializeField]
    float direction = 0.05f;
    float toward = 1.0f;

    void Update()
    {
         if (transform.position.x > 2.8f)
        {
            direction = -0.05f;
            toward = -1.0f;
        }
        if (transform.position.x < -2.8f)
        {
            direction = 0.05f;
            toward = 1.0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            toward *= -1;
            direction *= -1;
        }

        transform.localScale = new Vector3(toward, 1, 1);          // x값을 + - 로 좌우 반전하기
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(direction, 0, 0);        // direction =>스피드
    }
}

```

-   클릭시 방향이 바뀌는 움직임, 맵 끝으로가면 방향이 자동으로 바껴서 움직인다.
</div>

<br><br><br><br><br><br>
- - - 

# 4. 빗방울 코딩

## `rain.cs`
<div class="notice--primary" markdown="1"> 

`rain.cs`
```c# 
using UnityEngine;

public class rain : MonoBehaviour
{
    int type;
    float size;
    int score;
    
    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        
        type = Random.Range(1, 5);   // 1~4
        
        if (type == 1)
        {
            size = 1.2f;
            score = 3;
            GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 2;
            GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (type == 3)
        {
            size = 0.8f;
            score = 1;
            GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (type == 4)
        {
            size = 0.8f;
            score = -5;
            GetComponent<SpriteRenderer>().color = new Color(255 / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f);
        }
        transform.position = new Vector3(x, y, 0);
        transform.localScale = new Vector3(size, size, 0);
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D Coll) {
        if (Coll.gameObject.tag =="ground")     //충돌한 물체의 태그가 ground    ground에 태그 설정을 미리 해두어야된다.
        {
            Destroy(gameObject);
        }
        if (Coll.gameObject.tag =="rtan")
        {
            Destroy(gameObject);
            GameManager.I.addScore(score);
        }
    }
}

```

-   일정 범위안에서 4타입중 랜덤빗방울을 생성, 플레이어 충돌시 스코어 보기(종료)
-   GameManager 에서 makeRain() Instantiate(rain); 에서 rain 코드가 있는 prefeb를 생성하여 활용
</div>

## 랜덤 빗방울
>   GameManager 오브젝트를 만들고 → 빗방울을 Prefabs로 틀을 만들고 → Instantiate 복제합니다!  

<br><br><br><br><br><br>
- - - 

# 5. GameManager

> - GameManager란? 게임 전체를 조율하는 오브젝트!  
> - 점수 / 다시 시작 / 3번 째 다시 시작에 부스터 / 광고보기 등  
{: .notice--info}

<br>

## `GameManager.cs`

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject rain;
    public GameObject Panel;
    public static GameManager I;    //싱글톤 패턴 ()
    int totalScore = 0;
    public Text scoreText;
    public Text timeText;
    float limit = 30.0f;
    

    //싱글톤 화
    void Awake() 
    {
        I = this;
    }

    void Start()
    {
        //0.5초마다 makeRain 실행
        InvokeRepeating("makeRain", 0, 0.5f);
        initGame();
    }
    void initGame()
    {
        //다시시작 후 시간, 점수 초기화
        Time.timeScale = 1.0f;
        totalScore = 0;
        limit = 30.0f;
    }
    void Update()
    {
        limit -= Time.deltaTime;
        if (limit < 0)
        {
            Time.timeScale = 0.0f; // 시간의 크기 0 = 정지
            Panel.SetActive(true);
            limit = 0.0f;
        }
        timeText.text = limit.ToString("N2"); //N2 - 소수점 2자리까지 짤라서 문자열로
    }

    void makeRain()
    {
        //rain 프리팹 복제
        Instantiate(rain);
    }
    
    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }
    
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
```
-   InvokeRepeating  ("메서드 이름", 시간 딜레이, 반복 시간 단위)메서드를 x초 후 실행하고, 매 y초마다 반복해서 실행하는 것을 의미
-   Instantiate( 이미 만들어진 게임 오브젝트를 필요할 때마다 실시간으로 만든다는 의미)
-   ![image](https://github.com/levell1/levell1.github.io/assets/96651722/1602beb8-2ed2-4fff-a280-edc5704a5524){:style="border:1px solid #eaeaea; border-radius: 7px;" }  
-   싱글톤 패턴 : 어떤 오브젝트가 프로그램에 단 하나만 존재하며 어느곳에서도 쉽게 접근 가능해야 할때 사용
-   [싱글톤 패턴 정리](https://levell1.github.io/memo%20unity/MUnity-singleton/)
</div>


<br><br><br><br><br><br>
- - - 

# 6. 점수 시스템 

> - Canvas 생성, Text 생성(점수) 설정
> - GameManager - 싱글톤
> - 맞으면 점수 올라가고, 표시
{: .notice--info}
<br><br><br><br><br><br>
- - - 

# 7. 게임 끝내기

> - Retry 판넬 만들기(Canvas)
> - Active 로 종료시 보이게 하기
> - 판넬에 버튼추가 클릭시 retry 함수 다시시작(Main Scene을 새로고침 한다.)
> - onclick -> panel.retry
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

// gamemanager의 retry
public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
```

-   클릭시 retry함수가 불린다.
-   ![image](https://github.com/levell1/levell1.github.io/assets/96651722/255f49c3-65ff-4ce4-9081-20ba8233f2ef){:style="border:1px solid #eaeaea; border-radius: 7px;" }   
</div>

<br><br><br><br><br><br>
- - - 

# 8. 정리

기본적인 게임의 구성, 만들기에 대해 알게되었다.  
이동, gamemanager 활용방법, 재시작 등 기본적인 것에 대해 알게 되었다.
{: .notice--info}


<br><br>
- - - 

1회 23/06/06  
2회 23/10/19 복습, 수정  
[Unity] 빗방울 게임
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
