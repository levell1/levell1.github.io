---
title:  "[Sparta-BCamp] 미니 프로젝트 1일차(시간추가 기능) ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-10-30 08:00

---
- - -
<BR><BR>

<center><H1> 미니 프로젝트 1일차  </H1></center>
오늘은 캠프 첫 팀 프로젝트 날이다. 미니 프로젝트이지만 처음 팀 단위로 프로젝트가 진행되었다.  
첫날 대부분의 시간은 프로젝트에 대한 회의, 대화로 많은 시간을 보냈다. 다들 좋은 분인 것 같았다.  
회의 후 각자 한 부분씩 진행하였고 나는 시간 추가 기능을 맡게 되었다.
실패할 때마다 시간 감소 기능 추가  
기능 추가 부분은 간단하다고 생각했다. 한 줄이면 되었다.  
매칭 실패 시 플레이어가 시간이 추가된 걸 알 수 있게 시각적인 효과를 추가해 보기로 했다.
{: .notice}
<br><br><br><br><br><br>
- - - 

# 1. 시간추가, 감소 효과 넣어보기

> - 매칭 실패 시 시간 추가
> - 게임매니저 부분 수정   [기본gamemanager.cs](https://levell1.github.io/sparta%20unity/SpartaUnity4/#gamemanagercs)
> - Hierarchy에 addtime라는 text 추가
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/462ccbdd-d41a-46f3-86b6-b876df723108){:style="border:1px solid #eaeaea; border-radius: 7px;"}   
{: .notice--info}

## `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 
public void isMatched()
{
    string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
    string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
    if (firstCardImage == secondCardImage)
    {
        audioSource.PlayOneShot(match);
        firstCard.GetComponent<card>().destroyCard();
        secondCard.GetComponent<card>().destroyCard();
        int cardsLeft = GameObject.Find("cards").transform.childCount;
        if (cardsLeft == 2)
        {
            Debug.Log(cardsLeft);
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
            //Invoke("GameEnd",1f);
        }
    }
    else
    {
        firstCard.GetComponent<card>().closeCard();
        secondCard.GetComponent<card>().closeCard();
        // 추가 1 줄
        time += 5;
    }
```
-   **time += 5;**
-   기능적으로 else 부분 (매칭 실패 시) 5초 증가 

</div>

<br><br><br><br><br><br>
- - - 

# 2. 시각적인 효과 보여주기

기능만 추가 시 심심한 느낌이 들어서 시각적인 효과를 넣어보려고 하였다.  
처음 막힌 부분은 text도 오브젝트처럼 이동이 될까? 였다. 
{: .notice}
>   생각한 방법으로는   
>   - 1.빈 오브젝트 안에 text를 넣고 오브젝트를 이동할까?
>   - 2.text의 위치를 나타내고 이동시킬 수 있을까? 가능하면 해보자  
> 2번을 선택하여 찾아보았다.
{: .notice--info}

> - 게임매니저 부분 수정   [gamemanager.cs](https://levell1.github.io/sparta%20unity/SpartaUnity4/#gamemanagercs)
> - 주석 추가한 부분 = 수정부분
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/462ccbdd-d41a-46f3-86b6-b876df723108){:style="border:1px solid #eaeaea; border-radius: 7px;"}   
{: .notice--info}

## 1) 선언, Update 부분

### `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{

    public Text addTxt;                                         // addtxt 위치
    private RectTransform transaddtxt;                          // addtxt 위치
    byte c;                                                     // 색상 byte 변수

    void Start() {
        transaddtxt = addTxt.GetComponent<RectTransform>();     // 매칭 실패 시 시간 추가
    }

      void Update()
   {
       float addy = transaddtxt.anchoredPosition.y;         // addtxt 위치
       addy += 0.5f;                                        // addtxt y값 상승
       transaddtxt.anchoredPosition= new Vector2(0, addy);  // addtxt y값 상승

       c -= 1;                                              // 글자 색상 투명하게
       addTxt.color = new Color32(255, 0, 0, c);            // 글자 색상 투명하게

       time += Time.deltaTime;
       timeTxt.text = time.ToString("N2");
       if (time>=60)
       {
           Invoke("GameEnd",0);
       }
   }
}

```
</div>

>   <span style="color:#96C85A"> 변수, 선언 </span>  
>   -   public Text addTxt; 텍스트
>   -   private RectTransform transaddtxt; 텍스트의 위치값을 사용하기 위한 RectTransform
>   -   byte c; 글자 색상 투명도변경 변수 -> byte
{: .notice--info}

>   <span style="color:#E6DC6E"> Update 부분 </span>  
>   -   float addy = transaddtxt.anchoredPosition.y;            addy -> text의 y값 위치
>   -   addy+= 0.5f;                                            addy -> text의 y값을 계속 증가시키기 위로 이동                                                  
>   -   transaddtxt.anchoredPosition= new Vector2(0, addy);     update 부분에 추가하여 text의 y값이 계속 증가한다.
>   -   c -= 1;             addTxt.color = new Color32(255, 0, 0, c);         글자 점점 투명하게
{: .notice--info}


<br><br><br><br>

## 2) ismatched

### `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{    
        public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                Debug.Log(cardsLeft);
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
                //Invoke("GameEnd",1f);
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();

            // 시간 추가 기능
            time += 5;
            addTxt.color = new Color32(255, 0, 0, 255);             // 글자색 RED
            c = 0;                                                  // 투명도 초기화
            transaddtxt.anchoredPosition = new Vector2(0, 450);     // 글자 위치 초기화 (진행시간 위)
            addTxt.gameObject.SetActive(true);                      // addTXT 활성화
            Invoke("ActiveFalse", 1.0f);                            // 1초 후 ActiveFalse 실행
        }

        firstCard = null;
        secondCard = null;
    }

    void ActiveFalse() {
        addTxt.gameObject.SetActive(false);                          // addtxt 비활성화 하기
    }
}
```
</div>

>   <span style="color:#96C85A">isMached ->else</span>  
>   -   addTxt.color = new Color32(255, 0, 0, 255); 글자 색상 RED로 변경
>   -   c = 0; 투명도 초기화
>   -   addtime text를 추가 후 비활성화 -> addTxt.gameObject.SetActive(true); 활성화 시키기
>   -   Invoke("ActiveFalse", 1.0f); 1 초 후 ActiveFalse 실행
{: .notice--info}

>   <span style="color:#E66EAF">ActiveFalse()</span>  
>   -   addTxt.gameObject.SetActive(false); -> 비활성화 시키기.
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 3. GameManager 

## `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public static gamemanager I;
    public GameObject endTxt;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public Text timeTxt;    
    public AudioClip match;
    public AudioSource audioSource;
    public Text addTxt;

    float time = 0.0f;
    byte c;                                                     // 색상 byte 변수

    private RectTransform transaddtxt;                          // addtxt 위치

    void Awake()
    {
        I = this;
    }

    void Start() {
        transaddtxt = addTxt.GetComponent<RectTransform>();     // addtxt 위치
        Time.timeScale = 1.0f; 
        

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        //랜덤정렬
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
            
        for (int i = 0; i < 16; i++)
        {
            
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    void Update()
    {
        float addy = transaddtxt.anchoredPosition.y;         // addtxt 위치
        addy += 0.5f;                                        // addtxt y값 상승
        transaddtxt.anchoredPosition= new Vector2(0, addy);  // addtxt y값 상승

        c -= 1;                                              // 글자 색상 투명하게
        addTxt.color = new Color32(255, 0, 0, c);            // 글자 색상 투명하게

        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time>=60)
        {
            Invoke("GameEnd",0);
        }
    }
    
    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                Debug.Log(cardsLeft);
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
                //Invoke("GameEnd",1f);
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();

            // 시간 추가 기능
            time += 5;
            addTxt.color = new Color32(255, 0, 0, 255);             // 글자색 RED
            c = 0;                                                  // 투명도 초기화
            transaddtxt.anchoredPosition = new Vector2(0, 450);     // 글자 위치 초기화 (진행시간 위)
            addTxt.gameObject.SetActive(true);                      // addTXT 활성화
            Invoke("ActiveFalse", 1.0f);                            // 1초 후 ActiveFalse 실행
        }

        firstCard = null;
        secondCard = null;
    }

    void ActiveFalse() {
        addTxt.gameObject.SetActive(false);                          // addtxt 비활성화 하기
    }

    void GameEnd(){
        endTxt.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}

```
</div>

<br><br><br><br><br><br>
- - - 

# 4. 정리
>   -   기능 추가는 time += 5; 한 줄로 간단한 거 같다.
>   -   오늘 배운 건 text의 위치는 anchoredPosition를 사용하여 이동시킬 수 있다는 걸 배웠다.
>   -   hex코드 색상 변경 new Color32(x, x, x, x); 로 가능하다. x값은 byte 로 사용한다.
>   -   오늘 처음 팀원분들과 회의, 대화해 보았고. 다 좋으신 분 같다. 나만 캠이 없어서 죄송했고 열심히 참여해 팀에 도움이 되고 싶다.
{: .notice}

<br><br>
- - - 

[Unity] 미니 프로젝트 1일차
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
