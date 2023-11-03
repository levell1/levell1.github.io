---
title:  "[Sparta-BCamp] TIL 4 (또Invoke?) ⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-02 20:00

---
- - -
<BR><BR>

<center><H1> 미니 프로젝트 4일차  </H1></center>
09:00 ~ 20:00까지 해야 할 작업 화면공유로 팀원들과 같이 작업
{: .notice}

> **4일차**  
- [x] 1. 노말 하드(24장) 카드 배치  
- [x] 2. 난이도 조정  
- [x] 3. 최고 기록 3개  
- [x] 4. 카운트 표시  
- [x] 5. 일시정지  + UI  
{: .notice}

> **추가기능**
- [x] 1. 카드 배치할 때 효과  
- [x] 2. 카드 뒤집히는 거  
{: .notice}

> **해야할 거**
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
- [x]  11. hard 처음 시도 횟수 확인
- [x]  12. Scene이름 바꾸기 (EasyScene, NormalScene, HardScene),이름 Easy, normal, Hard 통일
- [x]  13. 카드 사이즈 조정
{: .notice}



<iframe width="1100" height="619" src="https://www.youtube.com/embed/OXB477_D4LE" title="Unity 2기_ IDLE Card Match" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

<br><br><br><br><br><br>
- - - 

# 1. 11.03
화면공유로 같이 작업을 했다. 많은 부분 수정하면서 내 코드 부분에 고칠 부분이 많았다. 팀원분들 덕에 배워가는 게 엄청 많았다. 아침부터 저녁까지..  
오늘 추가 작업, 오류수정하면서 느낀 점이 많다.  
깃허브 부분 브랜치로 pull 하는 부분 익숙해지기  
Invoke를 사용할 때 조심할 점이 많았다, CancelInvoke(); =실행 중인 Invoke 함수를 중지
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 또 Invoke
<span style="color:#E66EAF">Invoke...</span>  
조원분들과 함께 튜터님에게 질문하러 갔었다. 인보크 버그에 대해 질문하러 갔었는데 우리가 생각하는 부분이 아닌 다른 부분에서 문제였었다.  
튜터님이 버그를 찾아내는 과정을 직접 봤고 엄청 많이 배웠다. 지금 코드가 어디서 멈췄는지 어느 부분이 실행이 되지 않는지.  
또 지금 현 게임 상황을 전채적으로 볼 수 있는 기능도 있었고 거기서 time이 흐르지 않는 걸 알 수 있었던 거 같다.   
그 후 time scale =0 에서 문제가 발생하였고 1로 변경해 해결되었다.  
<span style="color:#96C85A">결과.</span>  
정리하면 time scale = 0이기 때문에 invoke(1.5)에서 1.5초라는 시간이 흐르지 않아 버그 확인이 되었다.  
그 후 time scale = 1로 변경해 해결을 하였다.  
<span style="color:#E66EAF">배운점</span>  
모든 코드를 짤 때 추적이 가능하게 설정 awake에서 component<> 미리 설정, 변수로 사용  
코드에서 time.scale를 조정하지 말고 bool ispause get set으로 해보기 -> 튜터님이 보여주셨는데 코드가 어떻게 작동하는지 몰랐다.. 좀 더 공부해 보기  
<span style="color:#96C85A">잡담</span>  
코드 오류 시 Time에 대해 한 번 더 생각해 봐야겠다..
화면공유를 하면서 같이하며 배운게 많았다..  용어, 단축키,코드  
와이어 프레임 = 앱의 UI, 기능을 단순한 도형, 선으로 보기 쉽게 만드는 것.  
리팩토링 = 결과의 변경 없이 코드의 구조를 재조정함.
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 3. 와이어 프레임
**와이어 프레임 원정님이 만드신 와이어 프레임 (감사합니다.)**  
<br>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/1fae3b60-7236-4286-9c20-e8a90c64d77c){:style="border:1px solid #eaeaea; border-radius: 7px;" }  

<br><br><br><br><br><br>
- - - 

# 4. 프로젝트 설명
**준형님이 만드신 프로젝트 설명 (감사합니다.)**  
[프로젝트 설명](https://github.com/uhbbang33/IDLE_CardMatchGame/blob/main/Readme.md)



<br><br>
- - - 

[Unity] TIL 4

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
