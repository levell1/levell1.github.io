---
title:  "[TIL] 79 UI 최적화 강의 ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-13 02:00

---
- - -

``

<BR><BR>

<center><H1>  최종 팀 프로젝트 22일차  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 53  
&nbsp;&nbsp; [o] 면접 문제 풀기 - 5     
&nbsp;&nbsp; [o] 1,2반 마무리정리  챌~   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.   
&nbsp;&nbsp; [x] 디자인 코드 패턴 이해,정리하기.   
&nbsp;&nbsp; [x] 자료구조 디자인패턴 강의 다시 듣기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# UI 최적화 강의

## 1.Frame Debugger
window -> analysis -> Frame Debugger -> enable
![image](https://github.com/levell1/levell1.github.io/assets/96651722/4f900f1b-acf4-4a05-8739-fc1d68357b96){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> - 왼쪽에 UI를 그리는 순서가 나온다.
> - 드로우 콜 : CPU - > GPU에게 그리라고 시키는 것
> - 드로우 콜을 줄이면 최적화에 도움이 된다.
> - batches :  모든 드로우를 합친 숫자
> - ![image](https://github.com/levell1/levell1.github.io/assets/96651722/621e691d-7530-43dc-80a4-a57d91f75b35){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## Batches 줄이는 법 
> - 스프라이트 아틀라스 오브젝트 패킹에 이미지들을 넣는다  폴더를 통째로 넣는다
> - 한 장에 모든 이미지가 들어감 -> ui를 그릴 때 한 번에 그려줌 -> 배치가 줄어듦
> - UI에 해당하는 모든 내용을 아틀라스에 묶어 배치 수, 드로우콜 수를 줄인다
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

> - 아틀라스에 많은 ui를 넣게 되면 1024 1024-> 2048로 늘어나면서 힘들어질 수 있다.
> - 캔버스별로 묶거나 / 버튼, 이미지 별로 묶는 방법이 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 카메라 끄기
> - 메인 카메라를 꺼도 배치 수가 줄어든다.
> - 카메라 끄고 뒤에 캡쳐한 이미지를 넣는 방법도 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## UI 애니메이션
> - UI에서는 애니메이션을 안 쓰는 게 좋다.
> - 자식 캔버스에 애니메이션을 쓰는 방법이 있다.
> - UI 스프라이트 에디터에서 조절을 해서 깨진 UI를 잘 볼 수 있게 할 수 있다
> - 이미지타입 -> 슬라이스로
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 이미지 레이케스트 타겟 
> - 이미지 레이케스트 타겟 헤제
> - 클릭 안 받아 도 되는 UI는 레이케스트 타겟 체크 다 해제하기
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<br><br><br><br><br>
- - - 

# 기술면접
## 오버로딩과 오버라이딩의 차이점을 설명해주세요.
오버로딩 : 파라미터에 따라 함수의 기능이 달라진다, 같은 이름 다른 기능을 가능하게 해준다.
오버라이딩 : 부모에 정의된 메서드를 새롭게 정의하여 사용한다. 상속받아도 다른 기능을 사용하고자 하는 경우 사용한다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 


<br><br><br><br><br>
- - - 

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
