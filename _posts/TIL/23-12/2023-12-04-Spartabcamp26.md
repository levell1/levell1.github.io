---
title:  "[TIL] 26 Unity 팀과제  ⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-01 02:00

---
- - -


<BR><BR>


<center><H1>  유니티 팀과제 3일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   31 ~ 34    
&nbsp;&nbsp; [o] 팀과제   
&nbsp;&nbsp; [o] 4시 강의   
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 알고리즘 문자열
> 다차원 배열  
> GetLength(n - 1)은 n차원 배열의 길이를 리턴합니다  
> - &nbsp;&nbsp;array.GetLength(0) : 2차 배열에서 행(row)의 길이를 리턴
> - &nbsp;&nbsp;array.GetLength(1) : 2차 배열에서 열(column)의 길이를 리턴
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
<div class="notice--primary" markdown="1"> 

`행렬의 덧셈`
```c# 
 public int[,] solution(int[,] arr1, int[,] arr2) {
        int row = arr1.GetLength(0);
        int col = arr1.GetLength(1);
        int[,] answer = new int[row,col];
        for(int i = 0; i<row;i++)
        {
            for(int j = 0; j<col;j++)
            {
                answer[i,j] = arr1[i,j]+arr2[i,j];
            }
            
        }
        return answer;
    }
```
</div>


<br><br><br><br><br>
- - - 

# 2. 2D Raycast
<div class="notice--primary" markdown="1"> 

`gameobject 배열에 다른 오브젝트 자식 넣기`
```c# 
public void SelectPlayer()
{
    if (Input.GetMouseButtonDown(0))
    {
        // 카메라 - 마우스를 직선으로 이은 선
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);    
        
        // 클릭한 오브젝트
        RaycastHit hit;     

        if (Physics.Raycast(ray, out hit))
        {
            playerNum = hit.transform.GetComponent<PlayerNum>().SelectNum;
            foreach (var p in playerNumList)
            {
                animator = gameObjects[p - 1].GetComponent<Animator>();
                playerNum = int.Parse(hit.transform.name.Substring(hit.transform.name.Length - 1));
                animator.SetBool("Iswalk", playerNum == p);

                if (playerNum == p)
                {
                    PlayerPrefs.SetInt("PlayerSelect", p);
                    int a = PlayerPrefs.GetInt("PlayerSelect");
                }
            }
        }
    }
}

```
</div>

# 3. 유니티 자식오브젝트 가져오기

![image](https://github.com/levell1/levell1.github.io/assets/96651722/3aa5944d-577a-4ced-b6d2-955146c84db5)


<div class="notice--primary" markdown="1"> 

`gameobject 배열에 다른 오브젝트 자식 넣기`
```c# 
public GameObject[] gameObjects;

for (int i = 0; i < _playerPrefebs.transform.childCount; i++)
{
    GameObject[i] = _playerPrefebs.transform.GetChild(i).gameObject;
}

```
</div>

# 4. 강의정리


# 정리, 잡담

**느낀점**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


<br><br>
- - - 

[Unity] TIL 26

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
