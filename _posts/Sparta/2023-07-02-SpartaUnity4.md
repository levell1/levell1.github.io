---
title:  "[2D Sparta-Unity] 4주차 FindRtan  ⭐⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-07-02

---
- - -
<BR><BR>

<center><H1> 4주차 FindRtan 같은그림 찾기 </H1></center>
 로직 중요, 게임메니저⭐
{: .notice}

[**4주차 FindRtan**](https://levell1.github.io/sparta%20game/FindRtan/)
<br><br><br><br><br><br>
- - - 

# 1. card

> - 카드 뒤집기, 없애기 등등
{: .notice--info} 

## `card.cs`

<div class="notice--primary" markdown="1"> 

`card.cs`
```c# 
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    public void openCard()
    {
        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if (gamemanager.I.firstCard == null)
        {
            gamemanager.I.firstCard = gameObject;
        }else
        {
            gamemanager.I.secondCard = gameObject;
            gamemanager.I.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 0.5f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 0.5f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
```

</div>

<br><br><br><br><br><br>
- - - 

# 2. GameManager

> - list 사용, list 랜덤 정렬 OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
> - for문을 사용해서 카드 알맞게 배치
> - 카드 모두완성 or 30초 후 게임종료
> - card.cs에서 불러와서 사용  GetComponent<card>().destroyCard();
{: .notice--info} 

## `GameManager.cs`

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    
    public Text timeTxt;
    public GameObject endTxt;
    public GameObject card;
    float time = 0.0f;
    public GameObject firstCard;
    public GameObject secondCard;

    public static gamemanager I;

    void Awake()
    {
        I = this;
    }

    void Start() {
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
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time>=30)
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
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

             int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
                //Invoke("GameEnd",1f);
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd(){
        endTxt.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
```
-   Instantiate( 이미 만들어진 게임 오브젝트를 필요할 때마다 실시간으로 만든다는 의미)

</div>

<br><br><br><br><br><br>
- - - 
 
# 3. 게임 끝내기

> 전 강의들과 같이
{: .notice--info}

## `endtxt.cs`

<div class="notice--primary" markdown="1"> 

`endtxt.cs`
```c# 
using UnityEngine;
using UnityEngine.SceneManagement;

public class endtxt : MonoBehaviour
{
    public void Regame(){
        SceneManager.LoadScene("MainScene");
    }
}
```
-   씬 로드

</div>

<br><br><br><br><br><br>
- - - 
 
# 4. 정리

> 4주차에선 이전강의를 포함하고 for문을 활용한 게임.
{: .notice--info}

<br><br>
- - - 

1회 23/06/14  
2회 복습, 수정  
[Unity] 
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -