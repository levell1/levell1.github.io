---
title:  "[Sparta-BCamp] TIL 4 ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-11-02 20:00

---
- - -
<BR><BR>

<center><H1> 미니 프로젝트 3일차  </H1></center>

**4일차**  
2. 노말 하드(24장) 카드 배치 = 종욱님
3. 난이도 조정 = 회의
4. 최고 기록 3개 
5. 카운트 표시 = 병웅님
6. 일시정지  + UI = 원정님

추가기능
  1. 카드 배치할때 효과 
  2. 카드 뒤집히는거 = 김국민

11.02 해야할 거

- [x]  1. Start Scene 이미지 넣기
- [x]  2. 볼륨 조절하기 (비슷하게 맞추기) → 0.3
- [x]  3. +5 한 번 더 진하게 되는 부분
- [x]  4. 카드가 맞춰졌을 때 이름 중복 → 원래 있던 이름이 없어지고 이름이 새로 생기도록 변경
- [x]  5. 세부적인 난이도 설정
- [x]  6. 난이도 해금
- [x]  7. 데이터 삭제하기 (설정 버튼?)
- [x]  8. 게임 종료 버튼? - Start Scene
- [x]  9. first 카드 5초 후 null 오류 수정
- [x]  10. easy 난이도 카드 섞기
- [x]  11. hard 처음 시도횟수 확인
- [ ]  12. 카드 뒤집혔을 때 애니메이션
- [x]  13.Scene이름 바꾸기 (EasyScene, NormalScene, HardScene),이름 Easy, normal, Hard 통일
- [x]  카드 사이즈 조정
너무 피곤하다 주말에 써야겠다..
https://github.com/uhbbang33/IDLE_CardMatchGame
{: .notice}

<iframe width="894" height="503" src="https://levell1.github.io/blog/Video-Link/"
 title="Unity 2기_ IDLE Card Match" frameborder="0" 
 allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>  

# 1. 연속매칭 시 팀원명

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
