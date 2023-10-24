---
title:  "[2D Sparta-Unity] 3주차 Dog VS Cat  ⭐⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-06-23

---
- - -
<BR><BR>

<center><H1> 3주차 Dog VS Cat </H1></center>
고양이에게 먹이주는 게임  여러씬, 체력바, 난이도
{: .notice}

[**3주차 Dog VS Cat**](https://levell1.github.io/sparta%20game/DogCat/)
<br><br><br><br><br><br>
- - - 

# 1. 배경, 캐릭터 구성

> - 여러 씬  
> - 난이도  
> - 카메라 사이즈 25로 평소보다 큼,  배경  
> - 이미지 다운받고 저장  
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 두개 씬

> - Main, Start Scene 
> - 씬 넘기기 (씬 리로드)  SceneManager.LoadScene("MainScene");
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/8508be00-6a55-4844-8077-87233c818594){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice--info}

## 스타트 버튼(씬넘기기)

> 버튼은 sprite 가 아니라 UI 이미지에 붙여야 작동

## `startBtn.cs`

<div class="notice--primary" markdown="1"> 

`startBtn.cs`
```c# 
using UnityEngine.SceneManagement;
using UnityEngine;

public class startBtn : MonoBehaviour
{
    public void GameStart(){
        SceneManager.LoadScene("MainScene");
    }
}


```
-   씬 로드

</div>

<br><br><br><br><br><br>
- - - 

# 3. food 코딩

> - 올라가는 rigidbody -> Kinematic 
> - collider is trigger 확인
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/66f3ed53-f9e2-4853-bb93-04ac1ecb561d){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice--info}

## `food.cs`

<div class="notice--primary" markdown="1"> 

`food.cs`
```c# 
using UnityEngine;

public class food : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0.0f, 0.5f, 0.0f);
        if (transform.position.y > 26.0f)
        {
            Destroy(gameObject);
        }
    }
}

```

</div>

<br><br><br><br><br><br>
- - - 

# 4. dog

> - 마우스 포지션으로 움직이기
> - Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
{: .notice--info}

## `dog.cs`

<div class="notice--primary" markdown="1"> 

`dog.cs`
```c# 
using UnityEngine;

public class dog : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;
        if (x > 8.5f)
        {
            x = 8.5f;
        }
        if (x < -8.5f)
        {
            x = -8.5f;
        }
        transform.position = new Vector3(x, transform.position.y, 0);
    }
}

```

</div>

<br><br><br><br><br><br>
- - - 

# 5. cat

> - find 사용하여 front 의 스케일 변경
> - gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
{: .notice--info}

## `cat.cs`

<div class="notice--primary" markdown="1"> 

`cat.cs`
```c# 
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5.0f;
    float energy = 0.0f;
    bool isFull = false;
    public int type = 0;

    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30.0f;
        transform.position = new Vector3(x, y, 0);

        if (type == 1)
        {
            full = 10.0f;
        }
    }

    void Update()
    {
        if (energy < full)
        {
            if (type == 0)
            {
                transform.position += new Vector3(0.0f, -0.05f, 0.0f);
            }
            else if (type == 1)
            {
                transform.position += new Vector3(0.0f, -0.03f, 0.0f);
            }
            else if (type == 2)
            {
                transform.position += new Vector3(0.0f, -0.1f, 0.0f);
            }

            if (transform.position.y < -16.0f)
            {
                GameManager.I.gameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0.0f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            Destroy(gameObject, 3.0f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "food")
        {
            if (energy < full)
            {
                energy += 1.0f;
                Destroy(coll.gameObject);
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                //푸드를 총 6번 맞아야 실행이 되는 것 같아서 수정해 보았습니다.
                if (energy == full && isFull == false)
                {
                    GameManager.I.addCat();
                    isFull = true;
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                }
            }
        }
    }
}


```
-   고양이 타입별로 이속, full 다르게 설정

</div>

<br><br><br><br><br><br>
- - - 

# 6. GameManager

> - GameManager란? 게임 전체를 조율하는 오브젝트!  
> - 점수 / 다시 시작 / 3번 째 다시 시작에 부스터 / 광고보기 등  
> - InvokeRepeating (찍어내기)
{: .notice--info}

## `GameManager.cs`

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject food;
    public GameObject dog;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject piratecat;

    public GameObject retryBtn;
    public Text levelText;
    public GameObject levelFront;


    int level = 0;
    int cat = 0;

    void Awake()
    {
        I = this;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("makeFood", 0.0f, 0.15f);
        InvokeRepeating("makeCat", 0.0f, 1.0f);
    }

    void makeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level == 3)
        {
            float p = Random.Range(0, 10);
            if (p < 3) Instantiate(normalCat);
            Instantiate(fatCat);
        }
        else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 3) Instantiate(normalCat);
            Instantiate(fatCat);
            Instantiate(piratecat);
        }
    }
    void makeFood(){
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2.0f;
        Instantiate(food, new Vector3(x,y,0), Quaternion.identity);
    }

    public void gameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void addCat()
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);
    }
}


```
-   InvokeRepeating  ("메서드 이름", 시간 딜레이, 반복 시간 단위)메서드를 x초 후 실행하고, 매 y초마다 반복해서 실행하는 것을 의미
-   Instantiate( 이미 만들어진 게임 오브젝트를 필요할 때마다 실시간으로 만든다는 의미)
-   난이도별로 다르게 설정

</div>

<br><br><br><br><br><br>
- - - 

# 7. 고양이 나타내기

> - normalcat > Canvas render mode -> world space
> - 두개의 줄로 HP바 표현
> - Pivot 어디를 기준으로 늘어나겠는가 ex) 0.5 중앙기준     hp바는 기준 0
> - 애니메이션 녹화로 설정
{: .notice--info}

<br><br>
 
# 8. 게임 끝내기

> 전 강의들과 같이 Retry 
{: .notice--info}

<br><br><br><br><br><br>
- - - 

 
# 9. 정리

> 3주차에선 난이도에 따라 다르게 설정하는 기능이 어떻게 만들어지는지 알게 되었다.
{: .notice--info}

<br><br>
- - - 

1회 23/06/14  
2회 23 복습, 수정  
[Unity] 
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -