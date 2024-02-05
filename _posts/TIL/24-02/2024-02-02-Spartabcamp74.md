---
title:  "[TIL] 74 UI,TimeScale ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-02-02 02:00

---
- - -

``

<BR><BR>

<center><H1>  최종 팀 프로젝트 17일차  </H1></center>

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

# 발표 자료 
[중간 발표 예비 자료](https://gamma.app/docs/-1c7umk2nyh82in0?mode=doc)    
[시연 영삿](https://www.youtube.com/watch?v=T5k1utlrnFE)


<br><br><br><br><br>
- - - 

# UIManager에서 Inven, Shop 관리
관련 버그 수정.  

<br><br><br><br><br>
- - - 


# UI 활성화 시 시간, 카메라 멈춤

<div class="notice--primary" markdown="1"> 

```c# 
// 원래 캠 속도 저장
public void SaveCamSpeed()
{
    CamaraSpeed = VirtualcameraPov.m_VerticalAxis.m_MaxSpeed;
}

// UI 활성화 시 카메라, 시간 멈추기
public void DontMoveCam() 
{
    VirtualcameraPov.m_VerticalAxis.m_MaxSpeed = 0;
    VirtualcameraPov.m_HorizontalAxis.m_MaxSpeed = 0;
    Cursor.lockState = CursorLockMode.None;
    Time.timeScale = 0.01f;
    
}

// 원래 캠 속도로 되돌리기
public void ReturnCamSpeed()
{
    Time.timeScale = 1f;
    if (CamaraSpeed==0)
    {
        CamaraSpeed = GameManager.Instance.UIManager.CameraSpeed;
    }
    VirtualcameraPov.m_VerticalAxis.m_MaxSpeed = CamaraSpeed;
    VirtualcameraPov.m_HorizontalAxis.m_MaxSpeed = CamaraSpeed;
    Cursor.lockState = CursorLockMode.Locked;
}
```
</div>

Setting에서 카메라 감도 조절시 버그 발생 스크롤 변경 시 CamaraManager에 있는 CamaraSpeed로 저장  

<br><br><br><br><br>
- - - 

# 기술면접
## 스택, 힙 메모리란 무엇이며 차이  
**스택 메모리** : 잠시 사용하고 삭제하는 데이터 저장(지역변수, 매개변수) 지역이 끝나면 해제된다, 값형식, 힙보다 빠름   
**힙 메모리** : 스택보다 큰 메모리를 할당받기 위해 사용, 동적 메모리 할당 (NEW), 스택보다 느림. Delete를 이용해 객체 메모리 반환.GC가 없으면 직접 관리 해야줘야 함   
스택에는 힙의 주소가 힙메모리에는 실제 주소값이 저장된다. 
<br><br><br><br><br>
- - - 

# 잡담,정리
발표 자료 준비 트러블 슈팅, 게임 버그 픽스  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
