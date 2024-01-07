---
title:  "[TIL] 53 강의 디버깅(CodeCoverage) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2024-01-06 02:00

---
- - -


`Debugging`,`CodeCoverage`

<BR><BR>

<center><H1>  Debugging  </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 52  
&nbsp;&nbsp; [o] 다른반 강의 듣기   
&nbsp;&nbsp; [x] 심화주차 강의 듣기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 디버깅(Debugging), CodeCoverage

패키지 Code Coverage ->  
enable Code Coverage  
assemblies -> c#  
녹화버튼 누르고 실행하면 - 분석  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/379d05cf-673d-4aef-9475-5cba1b4e9bcf){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/6f89e6fd-1011-49f4-b1f4-2979758f1cb6){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - included Paths 에 검사 할 cs  
> - Report Option에 검사하고싶은 항목 체크   

<br><br><br><br><br>
- - - 

# 게임개발 Tip 20

&nbsp;&nbsp;1. 가능한 빨리 주요한 게임의 요소를 기반으로 `프로토타입`을 만들어라.  
&nbsp;&nbsp;2. `점진적으로 게임을 구축`, 큰 디자인 문서를 만들지 마라.  
&nbsp;&nbsp;3. 만들어 가면서 `강점은 더 강하`게, 약점은 잘라내라.  
&nbsp;&nbsp;4. 예상치 못한 것에도 열린 마음을 가지고 우연을 활용하라.  
&nbsp;&nbsp;5. 플레이어는 항상 `목표가 있음을 명심`하라. 목표가 무엇인지 `알고 있어야한다.`  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

&nbsp;&nbsp;6. `목표에 가까워지는지 알 수 있도록` 피드백 제공.  
&nbsp;&nbsp;7. 때로는 값싼 트릭이 비싼 기술보다 낫다. (선택).  
&nbsp;&nbsp;8. 처음 플레이순간 기대보다 재미없어도 놀라지 마라.  
&nbsp;&nbsp;9. `비판적 의견을 수용`하라. 그것은 항상 옳으며 어떤 방식으로든 `해결`해라.  
&nbsp;&nbsp;10. `원래의 목표을 신성시 하지 말라`. 그것은 대략적인 초안이다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


&nbsp;&nbsp;11. 얼만큼 잘라내도, 더 일찍 잘라 냈어야 했다고 생각할 것이다.  
&nbsp;&nbsp;12. 큰 변화를 고려하는 것을 `두려워 하지 마라`.  
&nbsp;&nbsp;13. 모든순간 `영감을 얻어라`  
&nbsp;&nbsp;14. 한걸음 물러나서` 전체 그림을 보는` 개인적 습관을 개발하라.  
&nbsp;&nbsp;15. 모니터에서만 하지 말고 `종이로도 작업`하라.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

&nbsp;&nbsp;16. `제약은 당신의 친구`이다. (제약은 창의성을 찾게 하고, 더 멋진 해결책을 찾도록 강요한다.)  
&nbsp;&nbsp;17. 게임의 `핵심이 무엇인지 발견`하면 전부 재구성하고 투자하라.  
&nbsp;&nbsp;18. `자부심은 옆으로 내려두라`.  
&nbsp;&nbsp;19. `개발일지`를 기록하라.  
&nbsp;&nbsp;20. 무엇이 대박 날지 `아무도 모른다`.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

[출처](https://www.jordanmechner.com/downloads/library/20tips.pdf)

<br><br><br><br><br>
- - - 


# 리소스 관리

ACC0001 악세사리 설명  
ACC0002 악세사리 설명  

Resources.Load("/Texture/Acc/ACC0001);   

리소스의 이름을 팀원과 정한 이름으로 맞추어서 관리.  

<br><br><br><br><br>
- - - 

# 빌더
빌더 패턴은 객체의 초기화를 체계적으로 하도록 도와주는 패턴  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/acd76f04-303b-441d-8fcf-165a9e075331){:style="border:1px solid #EAEAEA; border-radius: 7px;"}    


**탐색방법**  
[탐색방법 DFS,BFS, A* 시각화](https://www.youtube.com/watch?v=aW9kZcJx64o)  

## 깊이 우선(DFS)
`Depth-First Search`  
![dfs](https://github.com/levell1/levell1.github.io/assets/96651722/b4fd178e-dd32-4aa1-85ca-adaa2b235184){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 

class Graph
{
    int[,] adj = new int[6, 6]
    {
            { 0, 1, 0, 1, 0, 0},
            { 1, 0, 1, 1, 0, 0},
            { 0, 1, 0, 0, 0, 0},
            { 1, 1, 0, 0, 1, 0},
            { 0, 0, 0, 1, 0, 1},
            { 0, 0, 0, 0, 1, 0},
    };
    bool[] visited = new bool[6];

    //1) now부터 방문
    //2) now와 연결된 정점들을 하나씩 확인해서 [아직 미방문 상태라면]방문
    public void DFS(int now)
    {
        Console.WriteLine(now);
        visited[now] = true; //1) now부터 방문

        for (int next = 0; next < 6; next++)
        {
            if (adj[now, next] == 0)//연결된 정점이라면 스킵
                continue;
            if (visited[next])//이미 방문한 곳이라면 스킵
                continue;

            DFS(next);
        }
    }
}
```
</div>


## 너비 우선(BFS)
`Breadth-First Search`  
![bfs](https://github.com/levell1/levell1.github.io/assets/96651722/d82d5315-cdde-4b82-b657-4803252301af){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
class Program
    {
        static void Main(string[] args)
        {
            int[,] adj = new int[6, 6]
            {
                { 0, 1, 0, 1, 0, 0},
                { 1, 0, 1, 1, 0, 0},
                { 0, 1, 0, 0, 0, 0},
                { 1, 1, 0, 0, 1, 0},
                { 0, 0, 0, 1, 0, 1},
                { 0, 0, 0, 0, 1, 0},
            };

            BFS bfs = new BFS();
            bfs.Initurlize(adj);
            var resault = bfs.Search(0);

            foreach (var dic in resault)
            {
                foreach (var value in dic.Value)
                    Console.WriteLine($"{dic.Key} - {value}");
            }
        }
    }
    public class BFS
    {
        int[,] _graph;
        public void Initurlize(int[,] graph)
        {
            _graph = graph;
        }

        public Dictionary<string, int[]> Search(int start)
        {
            if (_graph == null)
                return null;

            int num = _graph.GetLength(0);//정점 총수

            Queue<int> queue = new Queue<int>();
            bool[] found = new bool[num];//경유 유무
            List<int> sequence = new List<int>();//경유 순서
            int[] parent = new int[num];//정점의 부모
            int[] distance = new int[num];//start정점과 각 정점사이거리

            queue.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                sequence.Add(now);

                for (int next = 0; next < num; next++)
                {
                    if (_graph[now, next] == 0)
                        continue;

                    if (found[next])
                        continue;

                    queue.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;
                }
            }

            Dictionary<string, int[]> answer = new Dictionary<string, int[]>()
            {
                {"sequence",sequence.ToArray() },
                {"parent",parent },
                {"distance",distance },
            };

            return answer;
        }
    }
```
</div>

<br><br><br><br><br>
- - - 

# 잡담,정리
게임 기획 -> 처음기획 너무 크게x, 처음기획에 집착, 점진적으로 아이디어 추가  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}


<br><br>
- - -
