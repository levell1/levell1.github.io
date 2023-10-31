---
title:  "[Sparta-BCamp] 미니 프로젝트 2일차(깃 허브, 문자열 자르기) ⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-10-31 08:00

---
- - -
<BR><BR>

<center><H1> 미니 프로젝트 2일차  </H1></center>
2일차  
2:00 깃허브 강의  
시도 : 카드 매칭 시 팀원 이름표시  
고난이도 24장 카드 크기조절 -> 애니메이션 때문에 scale 1.3으로 고정 -> 부모의 크기를 줄인다??,  
{: .notice}
<br><br><br><br><br><br>
- - - 

# 1. 깃(Git)에 관하여  
깃 = VCS(Version Control System)중 하나
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
>   - 유니티 **asset** -> show in exploler -> 유니티 폴더 열기
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


## 로컬 -> 원격
**Push**
{: .notice}

>   <span style="color:#96C85A">Push</span>  
>   - 로컬에서 원격으로 Push 해준다.
>   - github 프로젝트에 올라간다. -> 공유 가능
>   - Push 하기 전 체크 하고, 조심히 실행
>   - Push 하기 전 모두 undo 가능
{: .notice--info}

## 원격 -> 로컬
**Pull**
{: .notice}

>   <span style="color:#E66EAF">Pull</span>  
>   - 원격에서 수정된 내용을 로컬로 받아온다
>   - 
{: .notice--info}

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

# 4. 정리
>   -   깃 허브에 관하여 복습, 추가학습.
{: .notice}

<br><br>
- - - 

[Unity] 미니 프로젝트 1일차
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
