---
title:  "[Sparta-BCamp] 미니 프로젝트 2일차(깃 허브, Substring) ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-10-31 20:00

---
- - -
<BR><BR>

<center><H1> 미니 프로젝트 2일차  </H1></center>
2일차  
2:00 깃허브 강의  
카드 매칭 시 팀원 이름 표시 --> 문자열 자르기 활용
고난도 24장 카드 크기 조절 -> 애니메이션 때문에 scale 1.3으로 고정 -> 부모의 크기를 줄인다??  
{: .notice}
<br><br><br><br><br><br>
- - - 

# 1. 깃(Git)에 관하여  
깃 = VCS(Version Control System) 중 하나
버전을 관리하기 위한 협업 플레이어
{: .notice}

> - 협업 시 코드 충돌 시 편하다.
> - 유니티 asset, 오브젝트 추가는 직접 조정이 필요하다.
> - 충돌을 피하기 위한 노력이 필요하다.
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 사용법
**init, commit**
{: .notice}

>   <span style="color:#96C85A">저장소 만들기</span>  
>   - Create new repository  
>   - 이름 설정, ignore -> Unity 확인
{: .notice--info}

>   <span style="color:#E66EAF">유니티 저장하기</span>  
>   - 유니티 asset -> show in exploler -> 유니티 폴더 열기
>   - 깃허브 show in explolor           -> 깃허브 저장 폴더 열기
>   - 1 -> 2로 파일 옮기기 (init)
>   - Commit : 로컬(컴)에 저장하기
{: .notice--info}
<br><br>

## 로컬에 올리기전 확인
**amend, undo, Discard**
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/d2e20064-646e-463c-a4af-deadd24de8ef){:style="border:1px solid #eaeaea; border-radius: 7px;" }  

>   <span style="color:#96C85A">amend</span>  
>   - 설명을 수정하고 싶을 때 사용
>   - History-> commit 부분 우클릭 -> amend
{: .notice--info}

>   <span style="color:#E66EAF">undo</span>  
>   - commit 되돌리기
>   - History-> commit 부분 우클릭 -> undo 
{: .notice--info}


>   <span style="color:#96C85A">Discard</span>  
>   - 수정한 한 개의 파일 되돌리기
{: .notice--info}
<br><br>

## 로컬 -> 원격
**Push**
{: .notice}

>   <span style="color:#96C85A">Push</span>  
>   - 로컬에서 원격으로 Push 해준다.
>   - github 프로젝트에 올라간다. -> 공유 가능
>   - Push 하기 전 체크하고, 조심히 실행
>   - Push 하기 전 모두 undo 가능
{: .notice--info}
<br><br>

## 원격 -> 로컬
**Pull**
{: .notice}

>   <span style="color:#E66EAF">Pull</span>  
>   - 원격에서 수정된 내용을 로컬로 받아온다
{: .notice--info}
<br><br>

## Branch
**Branch, Merge**
{: .notice}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b0faab22-56d2-4bd3-998c-338ffb68f6a4){:style="border:1px solid #eaeaea; border-radius: 7px;" }  

> <span style="color:#E66EAF">Branch</span>  
>   - 생성 : Main -> new branch 
>   - branch, main 따로 작업가능
{: .notice--info}

>   <span style="color:#96C85A">Merge</span>  
>   - Main 과 Banch를 똑같은 상태로 만들어준다
>   - Main -> 밑에 MERGE INTO MAIN
{: .notice--info}

>   <span style="color:#E66EAF">Check Out Commit</span>  
>   - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/1b410f04-cc7a-4f3e-86ba-55f670377d65){:style="border:1px solid #eaeaea; border-radius: 7px;" }  
>   - 시간대로 되돌아가서 다시 시작가능하다.
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 3. 카드 매칭 시 팀원 표시
>   -   매칭시 Active False 였던 오브젝트 true 로 바꾸어 표시 후 사라짐.
>   -   ismatched 부분 수정
>   -   처음에 if, for , swich case 문으로 고민하다 변경
{: .notice}

## `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 

string info = firstCard.GetComponentInChildren<SpriteRenderer>().sprite.name;   // sprite의 이름 rtanx info에 저장
check = int.Parse(info.Substring(info.Length - 1)) -1;  // rtanx 의 x부분 자르기, int 로 변형
// 배열은 0부터 시작하므로 -1

//check = firstCard.GetComponent<Card>().spriteNum;

namelist[check].SetActive(true);            // Active True
Invoke("nActiveFalse", 1.0f);               // 1초 후 false

```
</div>

>   -   처음에 if 문, switch case 문 등 많은 시도를 하였습니다.
>   -   하는도중 spriterenderer 부분에 rtan1,2,3 rtanx 부분에서 x부분을 활용하여 해보았습니다.
>   -   마지막 x부분만 자르고 list namelist[x] 로 오브젝트를 찾아 active true 를하여 나타냈습니다.
>   -   Invoke("nActiveFalse", 1.0f);   1초 후 안보이게
{: .notice}

<br><br><br><br><br><br>
- - - 

# 4. 24장 배열
처음에 스케일을 바꾸어 크기 조정을했지만 애니메이션 부분에 스케일이 1.3 으로 고정이라  
모든카드가 들어있는 cards라는 부모의 스케일을 바꾸어 해결하였습니다.
{: .notice}

## `gamemanager.cs`

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 

int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11};
//랜덤정렬
rtans = rtans.OrderBy(item => UnityEngine.Random.Range(-1.0f, 1.0f)).ToArray();

for (int i = 0; i < 24; i++)
{
    GameObject newCard = Instantiate(card);
    newCard.transform.parent = GameObject.Find("cards").transform;
    newCard.transform.parent.localScale = new Vector3(0.7f, 0.7f, 1f);  // 24장 -> 화면에 맞게 크기조절
    float x = (i / 6) * 1.2f - 1.8f;
    float y = (i % 6) * 1.0f - 4.1f;
    newCard.transform.position = new Vector3(x, y, 0);
    string rtanName = "rtan" + rtans[i].ToString();
    newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
}
```
</div>

>   -   Start부분 수정
>   -   newCard.transform.parent.localScale = new Vector3(0.7f, 0.7f, 1f);  // 24장 -> 화면에 맞게 크기조절
{: .notice--info}

# 5. 정리

>   9~14시까지 매칭 시 팀원 표시, 24장 카드 배열하기
>   -   Substring 공부
>   -   애니메이션이 포함된 오브젝트는 부모 오브젝트의 scale의 변화로 크기를 조절할 수 있다.
{: .notice}

>   14~21시 깃허브 시작 전
>   -   팀원 중 문원정님이 6명의 작업들을 합쳐주시는 작업을 하셨다. 정말 힘드셨을 텐데 감사합니다!
>   -   코드를 다 합쳐서 그런가 조금씩 오류가 생겼다. 완벽하게 해결이 되지 않았다..
>   -   내 생각으로 해결해 보았을 때 완벽하게 오류가 1도 없는 해결 방법이 떠오르지 않아 너무 답답했다..
>   -   오후 시간은 계속 좀 더 나은 방법을 찾아보다 끝이 났다. 못 찾았지만..

# 6. 씻은 후 
노래가 여러 번 재생되는 코드를 생각해 보았다. debug.log로 maxtime이 50이라면 time은 50.0011~으로 조금 더 높아서 계속 실행된다?? 처음엔 이렇게 생각했다.  
그래서 첫 방법으로 GameEnd() 부분에 time=0을 넣자. 라고 생각했다. gameend()가 한번 실행되면서 노래가 1번 실행됐다. 그렇지만 마지막 화면에 timetext가 0으로 나와 불편했다.  
그 후 팀원분이 GameEnd(); 대신 Invoke("ActiveFalse", 0.5f);를 넣으니 여러 번은 아니지만 3~4번 실행되었다. (왜 전과 다르게 여러 번이 아닌 3~4번일까? 궁금했다.)  이 경우 플레이 타임보다 0.5초 +되었다.  
그다음 bool을 써보았고 안됐다.  
씻으면서 그냥 생각이 났다. gameEnd() 마지막에 if (time > maxTime) -> time=maxtime 을 넣어 기록이 maxtime을 넘기지 않으면서, 마지막 화면에도 time이maxtime으로 나오게 했다. 해결은 한 거 같지만 먼가 찝찝하다. 더 좋은 방법이 있지 않을까?
{: .notice}

<div class="notice--primary" markdown="1"> 

`gamemanager.cs`
```c# 
Update
if (time > maxTime)
    GameEnd();

void GameEnd()
{
    Time.timeScale = 0f;
    isRunning = false;
    endPanel.SetActive(true);
    if (time > maxTime)
        time = maxTime;
    thisScoreText.text = time.ToString("N2");

    //endTxt.SetActive(true);

    if (PlayerPrefs.HasKey("bestscore") == false)
    {
        // 게임종료시 베스트 스코어면 나오는 노래
        audioSource.PlayOneShot(bestscore);
        PlayerPrefs.SetFloat("bestscore", time);

    }
    else if (time < PlayerPrefs.GetFloat("bestscore"))
    {
        // 게임종료시 베스트 스코어보다 낮으면 나오는 노래
        audioSource.PlayOneShot(bestscore);
        PlayerPrefs.SetFloat("bestscore", time);
    }
    else
    {
        // 게임종료시 베스트 스코어보다 낮으면 나오는 노래
        audioSource.PlayOneShot(lowscore);
    }

    float maxScore = PlayerPrefs.GetFloat("bestscore");
    maxScoreText.text = maxScore.ToString("N2");
    EndGameBgmStop();
}

```
</div>




<br><br>
- - - 

[Unity] 미니 프로젝트 2일차
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
