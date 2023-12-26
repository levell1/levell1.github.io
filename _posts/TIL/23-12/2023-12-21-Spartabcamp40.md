---
title:  "[TIL] 40. 3D 강의, 팀과제 끝  ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-21 02:00

---
- - -

<BR><BR>


<center><H1>  유니티 숙련주차 11일차, 팀과제 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 47  
&nbsp;&nbsp; [x] 강의 듣기 - 2개 복습하기  
&nbsp;&nbsp; [X] 다른반 강의 듣기    
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 팀과제 끝.
[피그마](https://www.figma.com/file/JtZ5fogrFyykLoIp1S7SrX/5%EC%A1%B0?type=whiteboard&node-id=0-1&t=wmQbr5l2QQ2HEhRT-0)  
[깃허브](https://github.com/levell1/05Anti_Freeze)  
[영상](https://www.youtube.com/watch?v=nn0iaOlcNOk)  
[PPT](https://gamma.app/docs/Anti-Freeze--43pwpo5rajctipl?mode=doc#card-3luht4hrrfgglge)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

# 트러블 슈팅?
눈사람이 3개로 나뉠 때 효과를 주고 싶었고, 그 상황에서 navmeshagent 와 snowmonster.cs 가 문제가 되는 상황이 있었습니다.  
그래서 3초간 rigidbody로 자연스럽게 죽는 장면을 보여주고, 필요한 컴포넌트를 활성화 시켜서 다시 몬스터의 역할을 하게 해 주는 과정이 있었습니다.  
<div class="notice--primary" markdown="1"> 

```c#
IEnumerator InitObject(GameObject gameObject)
    {
        
        yield return new WaitForSeconds(3f);
        Debug.Log(gameObject);
        _spawnQueue.Enqueue(gameObject);
        gameObject.GetComponent<SnowMonster>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<SnowMonster>().player = Player;
        //Destroy(gameObject.GetComponent<Rigidbody>());
    }

```
</div>


<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
