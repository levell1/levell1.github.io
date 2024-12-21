---
title:  "[자료구조] 2. 연결 리스트(Linked_List) -> deque"
excerpt: "Data Structure"

categories:
    - Data Structure
tags:
    - [Unity, Data Structure]

toc: true
toc_sticky: true
 
date: 2024-01-14 14:02
update: 2024-12-20 09:00

---
- - -

<br><br>

<center><H1>  연결 리스트(Linked_List)  </H1></center>

`연결 리스트(Linked_List)` `deque`


<br><br><br><br><br>
- - - 

# 연결 리스트

## 특징, 장단점
**특징**  
&nbsp;&nbsp; 1. 노드 기반 구조 : 데이터 , 포인터  
&nbsp;&nbsp; 2. 비연속적 메모리 할당  
&nbsp;&nbsp; 3. 동적 크기 조정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**장점**  
&nbsp;&nbsp; 1. 동적인 메모리 관리  
&nbsp;&nbsp; 2. 데이터 삽입. 삭제 편함   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**단점**  
&nbsp;&nbsp; 1. 메모리 오버헤드 : 각 노드가 데이터, 포인터를 저장, 메모리 많이 사용  
&nbsp;&nbsp; 2. 순차 탐색 접근 : 배열과 달리 특정 요소에 접근하기 위해서는 리스트를 순차적으로 탐색해야함.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--warning}  

<br><br>

## 게임 개발 활용

**활용 상황**  
&nbsp;&nbsp; 1. 데이터가 자주 추가되거나 제거 상황   
&nbsp;&nbsp; 2. 접근하는게 순차적일때  
&nbsp;&nbsp; 3. 크기가 불확실할 때   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

**활용 예시**  
&nbsp;&nbsp; 1. 동적 인벤토리 시스템  
&nbsp;&nbsp; 2. npc 행동 관리(순차적)  
&nbsp;&nbsp; 3. 레벨 내 동적 객체 관리(맵에서 적, 아이템 장애물 등 추가 제거)  
&nbsp;&nbsp; 4. 멀티플레이어 게임에서 플레이어 관리(접속해제 빈번, 플레이어 관리 용이)  
&nbsp;&nbsp; 5. 타이머 이벤트 관리(시간 순서 이벤트, 예전된 이벤트 실행, 제거에 편리)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br>

<details>
<summary>GameObject(enemy) LinkedList 예시</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private LinkedList<GameObject> enemies;

    void Start()
    {
        enemies = new LinkedList<GameObject>();

        // 적 캐릭터들을 연결 리스트에 추가
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.AddLast(enemy);
        }
    }

    // 적 캐릭터 제거 함수
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy);
    }
}
```
</div>
</details>

<br><br>

<details>
<summary>Linked List 로 Deque</summary>
[Deque 문제](https://www.acmicpc.net/problem/10866)

<div class="notice--primary" markdown="1"> 

```c# 
class Program
{
    static void Main()
    {
        {
            var sw = new StreamWriter(Console.OpenStandardOutput());

            int input =Convert.ToInt32(Console.ReadLine());
            //int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(" "), Convert.ToInt32);
            
            LinkedList<int> deque = new LinkedList<int>();

            while (input-- > 0) 
            {
                string[] comarr = Console.ReadLine().Split(" ");
                string com = comarr[0];
                int num=0;
                if (comarr.Length ==2)
                {
                    num = Convert.ToInt32(comarr[1]);
                }

                commend(deque,com,num);
            }

            void commend(LinkedList<int> deque, string com, int num) 
            {
                if (com == "push_front")
                {
                    deque.AddFirst(num);
                }
                else if (com == "push_back")
                {
                    deque.AddLast(num);
                }
                else if (com == "pop_front")
                {
                    if (deque.Count>0)
                    {
                        sw.WriteLine(deque.First());
                        deque.RemoveFirst();
                    }
                    else
                    {
                        sw.WriteLine(-1);
                    }
                }
                else if (com == "pop_back")
                {
                    if (deque.Count > 0)
                    {
                        sw.WriteLine(deque.Last());
                        deque.RemoveLast();
                    }
                    else
                    {
                        sw.WriteLine(-1);
                    }
                }
                else if (com == "size")
                {
                    sw.WriteLine(deque.Count);
                }
                else if (com == "empty")
                {
                    if (deque.Count > 0)
                    {
                        sw.WriteLine(0);
                    }
                    else
                    {
                        sw.WriteLine(1);
                    }
                }
                else if (com == "front")
                {
                    if (deque.Count > 0)
                    {
                        sw.WriteLine(deque.First());
                    }
                    else
                    {
                        sw.WriteLine(-1);
                    }
                }
                else if (com == "back")
                {
                    if (deque.Count > 0)
                    {
                        sw.WriteLine(deque.Last());
                    }
                    else
                    {
                        sw.WriteLine(-1);
                    }
                }
            }

            sw.Flush(); sw.Close();
        }
    }
}

```
</div>
</details>

<br><br><br><br><br>
- - - 


[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
