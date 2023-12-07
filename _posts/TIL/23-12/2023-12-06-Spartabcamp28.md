---
title:  "[TIL] 28 Unity 팀과제  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-06 02:00

---
- - -


<BR><BR>


<center><H1>  유니티 팀과제 5일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   40   
&nbsp;&nbsp; [o] 팀과제  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 보스 총알 버그
다른팀원이 작성한 코드를 보고 버그를 찾는 과정이 있었습니다.
1. 우선 `코드 전체를 이해`하는 과정이 있었고
2. 콘솔에뜨는 `오류를 시작으로` 하나씩 `확인`하며 진행했고
3. `오류점을 발견` 후 이유를 찾고 그 점을 `해결`하고
4. 코드에서 변경할 부분을 찾아 `작은 수정`을 하는작업을 했습니다.  
저의 생각으로는 기능구현에 대해 코드에는 문제가 없을정도로 작은부분 변경했었고,    유니티에서의 컴포넌트 등록 등 유니티적인 문제가 있었다고 생각했습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br>
- - - 

# 2. Retry 창
재시작 창을 만들며 겪었던 문제는 timescale로 0을 줬을때 invoke 가 실행이 안된점이였고 timescale 을 0.1로 하여 일단 실행은 되게 하였습니다.    
다른 방법으로는 캐릭터, 적의 이동을 멈추고 timescale은 1로 하는 방법이 있다고 했습니다. 
다음에는 이 방법으로 해 봐야 겠습니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br>
- - - 

# 3. 카메라 플레이어 따라가기

<div class="notice--primary" markdown="1"> 

```c# 
Transform playerTransform;

void LateUpdate()
{
    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    this.transform.position = playerTransform.position + new Vector3(0,0,-15);
}
```
</div>

<br><br><br><br><br>
- - - 

# 4. 컴터 바꾸기
cpu i5-4690, gpu 750ti? 로 하고있는데 zep과 Unity,  
화면공유를 하니까 렉이 너무걸려서 진행이 어려웠다. 컴을 바꾸기로 했다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br>
- - - 

# 5. 피그마 칠판

![image](https://github.com/levell1/levell1.github.io/assets/96651722/cf29dfd3-6802-4e18-a44e-1647876babf3){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 



[Unity] TIL 28

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
