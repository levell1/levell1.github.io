---
title:  "[C#] 탐색 알고리즘, 그래프 (Graph) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta C Sharp
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-24 01:00

---
- - -
<BR><BR>

<center><H1> 탐색 알고리즘  </H1></center>
탐색 알고리즘, 그래프 (Graph)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


# 1. 탐색 알고리즘
**주어진 데이터 집합에서 특정 항목을 찾는 방법을 제공**
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

## 선형 탐색(Linear Search)
**배열의 각 요소를 하나씩 차례대로 검사**
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c# 
int SequentialSearch(int[] arr, int target)
{
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == target)
        {
            return i;
        }
    }

    return -1;
}
```
</div>

## 이진 탐색 (Binary Search)
**배열에서 빠르게 원하는 항목을 찾는 방법**  
중간 요소와 찾고자 하는 항목을 비교하여 대상이 중간 요소보다 작으면 왼쪽을, 크면 
오른쪽을 탐색
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

<div class="notice--primary" markdown="1"> 

```c# 
int BinarySearch(int[] arr, int target)
{
    int left = 0;
    int right = arr.Length - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (arr[mid] == target)
        {
            return mid;
        }
        else if (arr[mid] < target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }

    return -1;
}
```
</div>


# 2. 그래프 (Graph)

정점(Vertex)과 간선(Edge)으로 이루어진 자료 구조  
방향 그래프(Directed Graph)와 무방향 그래프(Undirected Graph)로 나뉨  
가중치 그래프(Weighted Graph)는 간선에 가중치가 있음
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

**탐색방법**
## 깊이 우선(DFS)
`Depth-First Search`  
![dfs](https://github.com/levell1/levell1.github.io/assets/96651722/b4fd178e-dd32-4aa1-85ca-adaa2b235184){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

## 너비 우선(BFS)
`Breadth-First Search`  
![bfs](https://github.com/levell1/levell1.github.io/assets/96651722/d82d5315-cdde-4b82-b657-4803252301af){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


## 그래프, DFS, BFS 예제
<details>
<summary>Graph, DFS, BFS</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System;
using System.Collections.Generic;

public class Graph
{
    private int V; // 그래프의 정점 개수
    private List<int>[] adj; // 인접 리스트

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[V];
        DFSUtil(v, visited);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write($"{v} ");

        foreach (int n in adj[v])
        {
            if (!visited[n])
            {
                DFSUtil(n, visited);
            }
        }
    }

    public void BFS(int v)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[v] = true;
        queue.Enqueue(v);

        while (queue.Count > 0)
        {
            int n = queue.Dequeue();
            Console.Write($"{n} ");

            foreach (int m in adj[n])
            {
                if (!visited[m])
                {
                    visited[m] = true;
                    queue.Enqueue(m);
                }
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        Graph graph = new Graph(6);

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 5);

        Console.WriteLine("DFS traversal:");
        graph.DFS(0);
        Console.WriteLine();

        Console.WriteLine("BFS traversal:");
        graph.BFS(0);
        Console.WriteLine();
    }
}
```

</div>
</details>

<br><br><br><br><br>
- - - 

# 3. 최단 경로 알고리즘 (Sortest path problem)
다익스트라 알고리즘  
벨만 포드 알고리즘  
A*알고리즘  등 많은 알고리즘이 존재한다.
{: .notice} 

<br><br><br><br><br>
- - - 

# 4. 고급 알고리즘 
**`문제를 푸는 방법들`**   
**`문제를 풀 때 첫시작점`**  

<br>

## 1. 동적 프로그래밍
**`작은 문제 단위로 쪼개서 반복`**  
동적 프로그래밍은 큰 문제를 작은 하위 문제로 분할하여 푸는 접근 방식입니다.  
동적 프로그래밍은 중복되는 하위 문제들을 효율적으로 해결하기 위해 사용됩니다.  
동적 프로그래밍은 최적 부분 구조와 중복 부분 문제의 특징을 가진 문제들을 효과적으로 해결할 수 있습니다.  
{: .notice} 

<br><br>

## 2. 그리드 알고리즘
**`현재에 집중하는`**  
그리디 알고리즘은 각 단계에서 가장 최적인 선택을 하는 알고리즘입니다.  
각 단계에서 가장 이익이 큰 선택을 하여 결과적으로 최적해에 도달하려는 전략을 따릅니다.  
동적 프로그래밍은 최적 부분 구조와 중복 부분 문제의 특징을 가진 문제들을 효과적으로 해결할 수 있습니다.  
{: .notice} 

<br><br>

## 3. 분할 정복
**`작은 부분부터 착실히 해결`**  
재귀적인 구조를 가지므로 문제 해결 방법의 설계가 단순하고 직관적  
{: .notice} 
<br><br><br><br><br>
- - - 


# 5. 문제 해결 전략
&nbsp;&nbsp; 1. **`문제이해`**  
&nbsp;&nbsp; 2. **`예제와 테스트 케이스`**  
&nbsp;&nbsp; 3. **`알고리즘 설계`**  
&nbsp;&nbsp; 4. **`코드 작성`**  
&nbsp;&nbsp; 5. **`효율성`**  
&nbsp;&nbsp; 6. **`디버깅과 테스트`**  
&nbsp;&nbsp; 7. **`시간 관리`**  
&nbsp;&nbsp; 8. **`연습과 경험`**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

연습문제 - 백준, 프로그래머스

## 문제종류
&nbsp;&nbsp; 1. **탐색과 정렬**  
&nbsp;&nbsp; 2. **그래프**  
&nbsp;&nbsp; 3. **동적 프로그래밍**  
&nbsp;&nbsp; 4. **그리디 알고리즘**  
&nbsp;&nbsp; 5. **분할 정복**  
&nbsp;&nbsp; 6. **동적 그래프**  
&nbsp;&nbsp; 7. **문자열 처리**   
&nbsp;&nbsp; 8. **기타**  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br><br><br><br><br><br><br><br><br><br>
- - - 


<br><br>
- - - 

[C#] 탐색 알고리즘

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)  [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
