---
title:  "[Sparta-BCamp] TIL 3 (Coroutine) ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]
toc: true
toc_sticky: true
 
date: 2023-11-01 20:00

---
- - -
Coroutine
<BR><BR>

<center><H1> 미니 프로젝트 3일차  </H1></center>

**3일차**  
1. 연속으로 정답 시 팀원 이름이 사라지지 않는다. -> Invoke는 매개변수 전달은 할 수 없다. Coroutine을 사용하자   
2. 난이도 나누기-> start에서 클릭 시, level 변수를 지정했었다. -> 팀원분의 좋은 코드로 씬name을 불러오기.  
3. 24장 배열 -> 크기 조정 -> 부모 스케일  
4. 이미지가 12개로 늘어나면서 Substring 코드 -> 이미지 이름 변경으로 해결  
5. 카드 등장효과 -> 애니메이션? 하나씩?   -> movetowards  
{: .notice--info}

github를 사용하는데 main, 브런치를 바꾸면 바로 unity가 바뀌는게 신기하다.  
리트라이 를 IF문으로 했는데 팀원분이 한 줄로 된 좋은 코딩이 있었다.   
vector 도 리스트 가능하구나.  
{: .notice}

질문하기 time< maxtime SCALE이 0인데 왜 계속 반복??, INVOKE 하면 왜 반복 X? TIME 이 왜 0.0023? 해결법은?  
질문해 보고 -> 현재는 불리언 사용, 유니티를 더 배우면 좋은 방법이 있다.  
코드 기능을 완성 후 끝이 아닌 더 정확하고 오류가 없을만한 코딩 체크  -> 팀 프로젝트를 하면서 팀원들의 좋은 코드가 많고 배울 수 있었다.   
메인 코드에서 중복내용은 함수를 따로 만들어 하는 게 좋은 방법인가? 궁금. 물어보기   
주간 WIL  -> 총시간 표시  
{: .notice}

**TIL 강의**  
난 til 을 처음 시작하게 된 가장 큰 이유는 메모 기능으로 내가 필요한 기능을 내 블로그에서 찾아 쓰기 위해 기록을 시작하게 되었다.  
그 후 til 을 쓰고 난 후 복습하는 효과도 있었고 복습을 하다 보면 또 거기서 문제점과 더 좋은 방법을 발견하면서 발전하는 게 느껴져서 좋았다.  
추가적 쓸 거 ex) 발생했던 문제점 서로 이해할 때 좀 더 이야기를 자세하게 하기  
가장 중요한 점 문제 해결 과정  
{: .notice--info}
<br><br><br><br><br><br>
- - - 

# 1. 연속매칭 시 팀원명
연속 정답 시 팀원명이 사라지지 않는다.  
<span style="color:#96C85A">버그조건</span> -> (invoke 시간 내 2개) 빠르게 매칭 시 check 변수가 바뀌면서 오류가 났다.   
nActiveFalse에 매개변수를 사용하여 invoke를 하고 싶었지만 invoke는 매개변수 전달이 불가능하다고 한다  
<span style="color:#E66EAF">해결법</span> coroutine을 사용하라고 한다.  
coroutine을 사용해 보았다. -> [코루틴](https://levell1.github.io/memo%20unity/MUnity-Coroutine/)
{: .notice--info}

## `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 
string info = firstCard.GetComponentInChildren<SpriteRenderer>().sprite.name;   // sprite의 이름 rtanx info에 저장
check = int.Parse(info.Substring(info.Length - 1)) -1;  // rtanx 의 x부분 자르기, int 로 변형

namelist[check].SetActive(true);            // Active True
StartCoroutine(nActiveFalse(check));

IEnumerator nActiveFalse(int check)
{
    yield return new WaitForSeconds(1.0f);      //1초 딜레이
    namelist[check].SetActive(false);
}

```
</div>

<br><br><br><br><br><br>
- - - 

# 2.난이도 나누기
변수하나로 스타트에서 클릭시 LEVEL=X 사용  
STARTSCENE에는 게임메니저가 없기때문에 (gamemanager.i.level)여러경우를 해보고 LEVEL은 STATIC사용  
<span style="color:#E66EAF">해결법</span> LEVEL은 STATIC사용   
{: .notice--info}

이후 retry 게임을 변경할 일이 있었는데 if,switch를 사용했는대 팀원분의 코드가 한줄로 되었다.
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
{: .notice}

## `Startbtn.cs`

<div class="notice--primary" markdown="1"> 

`Startbtn.cs`
```c# 

public void GameStartE()
{
    SceneManager.LoadScene("EasyScene");
}

public void GameStartN()
{
    SceneManager.LoadScene("NormalScene");
}

public void GameStartH()
{
    SceneManager.LoadScene("HardScene");
}

```
- 버튼 클릭 시 난이도에 맞는 씬으로 이동
</div>

<br><br><br><br><br><br>
- - - 

# 3. 24장 배열 -> 크기 조정 -> 부모 스케일
 
{: .notice--info}

이후 retry 게임을 변경할 일이 있었는데 if,switch를 사용했는대 팀원분의 코드가 한줄로 되었다.
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
{: .notice}


## `GameManager.cs`

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 

void Start()
{
    isShuffle = false;
    tempSprite = sprites[0];
    tempSpriteNum = 0;
    //PlayerPrefs.DeleteAll();

    transaddtxt = addTxt.GetComponent<RectTransform>();
    Time.timeScale = 1.0f;
    cardList = new List<GameObject>();
    //namelist = new List<GameObject>();

    // 12개의 카드 생성
    // 카드 sprite를 순차적으로 넣어줌
    if (scene.name == "EasyScene")
    {
        for (int i = 0; i < 12; ++i)
        {
            // 카드는 12개 생성되어야 하는데 sprite는 6개
            // 2개의 카드는 같은 카드여야 하므로
            if (i % 2 == 0)     // 0, 2, 4, 6, 8, 10 일때만 sprite가 바뀜
            {
                tempSprite = sprites[i / 2];
                tempSpriteNum = i / 2;
            }

            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i / 3) * 1.4f - 2.1f;
            float y = (i % 3) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 1);
            points.Add(new Vector3(x, y, 1));

            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = tempSprite;
            newCard.GetComponent<Card>().spriteNum = tempSpriteNum; // card에 spriteNum 넣어주기
            cardList.Add(newCard);  // List에 생성한 카드 넣어주기
        }
    }
    else
    {
        for (int i = 0; i < 24; ++i)
        {
            // 카드는 12개 생성되어야 하는데 sprite는 6개
            // 2개의 카드는 같은 카드여야 하므로
            if (i % 2 == 0)     // 0, 2, 4, 6, 8, 10 일때만 sprite가 바뀜
            {
                tempSprite = sprites[i / 2];
                tempSpriteNum = i / 2;
            }

            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;
            newCard.transform.parent.localScale = new Vector3(0.8f, 0.8f, 1f);
            newCard.transform.position = new Vector3(0, -1.5f, 1);

            float x = (i / 6) * 1.4f - 2.1f;
            float y = (i % 6) * 1.1f - 4.2f;
            points.Add(new Vector3(x, y, 1));
            

            newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = tempSprite;
            newCard.GetComponent<Card>().spriteNum = tempSpriteNum; // card에 spriteNum 넣어주기
            cardList.Add(newCard);  // List에 생성한 카드 넣어주기
        }
    }

    // 카드 섞기

    for (int i = 0; i < cardList.Count; i++)
    {
        int randomNum = Random.Range(0, cardList.Count);
        // swap
        Vector3 tempPosition = points[i];
        points[i] = points[randomNum];
        points[randomNum] = tempPosition;
    }

    if (scene.name == "EasyScene")
        for (int i = 0; i < cardList.Count; ++i)
            cardList[i].transform.position = points[i];
}

```
- newCard.transform.parent.localScale = new Vector3(0.8f, 0.8f, 1f); 부모 스케일 변경
- 이지, (노말,하드) 카드 배치에 따라 따로 구성
</div>

<br><br><br><br><br><br>
- - - 

# 4. 이미지가 12개로 늘어나면서 Substring 코드 
이미지가 1~6 에서 1~12로 늘어나서 substring 에서 중복이 일어나서  
이미지 파일들이름을 수정했습니다.  
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/eab5a43b-d51f-4d00-9304-696489528450){:style="border:1px solid #eaeaea; border-radius: 7px;" }  
## `Gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`Gamemanager.cs`
```c# 

 namelist[check].SetActive(false);
 check = int.Parse(info.Substring(info.Length - 1)) - 1;  // rtanx 의 x부분 자르기, int 로 변형
                                                          // 배열은 0부터 시작하므로 -1
 
 namelist[check].SetActive(true);            // Active True
 StartCoroutine(nActiveFalse(check));

```
</div>


<br><br><br><br><br><br>
- - - 

# 5. 카드 등장 효과 
카드 등장효과 -> 애니메이션? 하나씩? -> movetowards  
생각하는 카드 등장 효과 : 트럼프카드 처럼 한 점에서 모든카드가 나눠지는 그림.  
-> 코드로 구현해보자 -> 검색 -> movetowards 현재위치에서 목표위치까지 이동 Update 에서 사용  
위치값이 start에서 정해진다. -> vector 도 list로 가능할까? (가능) -> 위치값을 vector[i] 에 저장   
->이동하는 함수 movetowards
{: .notice}

## `GameManager.cs`

<div class="notice--primary" markdown="1"> 

`GameManager.cs`
```c# 

void Start()
{
    for (int i = 0; i < 24; ++i)
    {
        // 카드는 12개 생성되어야 하는데 sprite는 6개
        // 2개의 카드는 같은 카드여야 하므로
        if (i % 2 == 0)     // 0, 2, 4, 6, 8, 10 일때만 sprite가 바뀜
        {
            tempSprite = sprites[i / 2];
            tempSpriteNum = i / 2;
        }

        GameObject newCard = Instantiate(card);
        newCard.transform.parent = GameObject.Find("Cards").transform;
        newCard.transform.parent.localScale = new Vector3(0.8f, 0.8f, 1f);
        newCard.transform.position = new Vector3(0, -1.5f, 1);

        float x = (i / 6) * 1.4f - 2.1f;
        float y = (i % 6) * 1.1f - 4.2f;
        points.Add(new Vector3(x, y, 1));
        

        newCard.transform.Find("Front").GetComponent<SpriteRenderer>().sprite = tempSprite;
        newCard.GetComponent<Card>().spriteNum = tempSpriteNum; // card에 spriteNum 넣어주기
        cardList.Add(newCard);  // List에 생성한 카드 넣어주기
    }
     for (int i = 0; i < cardList.Count; i++)
    {
        int randomNum = Random.Range(0, cardList.Count);
        // swap
        Vector3 tempPosition = points[i];
        points[i] = points[randomNum];
        points[randomNum] = tempPosition;
    }  
}

void Update()
{
    if (isRunning)
    {
        float addy = transaddtxt.anchoredPosition.y;         // addtxt 위치
        addy += 0.5f;                                        // addtxt y값 상승
        transaddtxt.anchoredPosition = new Vector2(0, addy); // addtxt y값 상승

        //Vector3 speed = Vector3.zero;
        
        if (scene.name != "EasyScene" && !isShuffle)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (cardList[i])
                {
                    cardList[i].transform.position =
                    //Vector3.MoveTowards(cardList[i].transform.position, points[i], 0.01f);
                    //Vector3.SmoothDamp(cardList[i].transform.position, points[i], ref speed, 0.05f);
                    Vector3.Lerp(cardList[i].transform.position, points[i], 0.05f);
                    //Vector3.Slerp(cardList[i].transform.position, points[i], 0.01f);
                }
            }
        }

        if (time > 2)
        {
            isShuffle = true;
        }
    }
}

```
- **특정 지점으로 오브젝트 이동**
- Vector3.MoveTowards(현재 위치, 목표 위치, 속력)
- SmoothDamp (현재위치, 목표위치, 참조 속력, 소요 시간) 
- Lerp (현재 위치, 목표 위치, 보간 후 위치) 는 선형보간을 이용한 이동 함수
- Slerp (현재 위치, 목표 위치, 보간 간격) 은 구면 보간을 이용

</div>

![GIFMaker_me](https://github.com/levell1/levell1.github.io/assets/96651722/f6c796af-1d38-414a-a586-9dca0f50ec44){:style="border:1px solid #eaeaea; border-radius: 7px;" }  

<br><br><br><br><br><br>
- - - 

# 6. 정리

> Coroutine 더 깊게 알아보기.  
> 난이도 나누는 정답에 가까운 방법은 무었일까?  
> 24장 배열 -> 크기 조정 -> 애니메이션에서 scale 1.3 고정 -> 부모 스케일에서 scale 변화
> 이미지가 12개로 늘어나면서 Substring 코드 -> 이미지 이름 변경으로 해결  
> 카드 등장효과 -> movetowards  
{: .notice}

<br><br>
- - - 

[Unity] TIL 3

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
