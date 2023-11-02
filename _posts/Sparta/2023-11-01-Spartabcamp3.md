---
title:  "[Sparta-BCamp] TIL 3 (Coroutine) ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-11-01 20:00

---
- - -
<BR><BR>

<center><H1> 미니 프로젝트 3일차  </H1></center>

**3일차**  
1.연속으로 정답시 팀원이름이 사라지지 않는다. -> Invoke는 매개변수 전달은 할 수 없다. Coroutine을 사용하자  
2.난이도 나누기-> start에서 클릭 시, STARTSCENE에는 게임메니저가 없기때문에 여러경우를 해보고 LEVEL은 STATIC사용  
3.24장 배열 -> 크기조정 -> 부모 스케일
3.이미지가 12개로 늘어나면서 Substring코드 -> 이미지이름 변경으로 해결  
4.처음에 카드 움직여서 배치하기 -> 애니메이션? 하나씩?   -> move
{: .notice--info}

github를 사용하는대 main, 브런치를 바꾸면 바로 unity가 바뀌는게 신기하다.  
리트라이 를 IF문으로 햇는데 팀원분이 한줄로 하신게 너무 좋았다.  1   
백터 도 리스트 가능하구나.  
{: .notice}

질문하기 time< maxtime SCALE이 0인데 왜 계속반복??, INVOKE 하면 왜 반복X? TIME 이 왜 0.0023? 해결법은?  
질문해보고 -> 현재는 불리언 사용, 유니티를 더 배우면 좋은방법이 있다.  
코드 기능을 완성후 끝이아닌 더 정확하고 오류가 없을만한 코딩 체크  -> 팀프로젝트를 하면서 팀원들의 좋은코드가 많았고 느꼈다.  
메인 코드에서 중복내용은 함수를따로 만들어 하는게 좋은방법인가?? 물어보기  
주간 WIL  -> 총시간 표시  
{: .notice}

**TIL 강의**  
난 til 을 처음 시작하게 된 가장 큰이유는 메모기능으로 내가 필요한 기능을 내 블로그에서 찾아쓰기 위해 기록을 시작하게 되었다.
그 후 til 을 쓰고난 후 복습하는 효과도 있었고 복습을 하다보면 또 거기서 문제점과 더 좋은방법을 발견하면서 발전하는게 느껴져서 좋았다.
추가적 쓸거 ex)발생했던 문제점 서로 이해할때 좀 더 이야기를 자세하게 하기
가장 중요한점 문제 해결 과정
{: .notice--info}
<br><br><br><br><br><br>
- - - 

# 1. 연속매칭 시 팀원명
연속 정답 시 팀원명이 사라지지 않는다. <span style="color:#96C85A">버그조건</span> -> (invoke 시간 내 2개) 빠르게 매칭 시 check 변수가 바뀌면서 오류가 났다.  
nActiveFalse에 매개변수를 사용하여 invoke를 하고 싶었지만 invoke는 매개변수 전달이 불가능하다고 한다 
<span style="color:#E66EAF">해결법</span> coroutine을 사용하라고 한다.
coroutine을 사용해 보았다. -> 정리글 쓰기 장 단점, 사용이유
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

# 5. 정리

>   내일 다시 써야지 피곤 ㅠ 9:25
{: .notice}

<br><br>
- - - 

[Unity] TIL 3

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
