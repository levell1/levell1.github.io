---
title:  "[TIL] 21 탐색알고리즘. 그래프(Graph), 유니티 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-27 02:00

---
- - -


<BR><BR>



<center><H1>  개인공부, 유니티 3일차  </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제   25~27   
&nbsp;&nbsp; [o] c# 5강듣기  
&nbsp;&nbsp; [o] 유니티 강의 듣기   1-6부터 다시 듣기  
&nbsp;&nbsp; [o] 2시 객체지향 강의  
&nbsp;&nbsp; [o] 4시 반 OT    
&nbsp;&nbsp; [o] 강의 못들은거 1 정리, 1개 다시듣기.  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
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

<br><br><br><br><br>
- - - 

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

# 6. 유니티 강의 메모

<br>

## 단축키, 설정
> - 비쥬얼 스튜디오 단축키 ctrl k c : 주석, ctrl k u : 주석해제  
> - 유니티 씬뷰 단축키 Q W E R T   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/3d7748a0-3837-4ac6-8992-548af346a6e8){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 오브젝트 생성 시 리셋하기 습관  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/07b9ffb4-31a8-4df0-8daf-5a9194b04ba9){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 텍스트 생성 시 text canvas scaler - screen size  확인   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5f7547d4-5726-413d-84f8-ec632cc7c720){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br>

## 유니티 실행순서
> - [유니티 함수 실행 순서](https://docs.unity3d.com/kr/2021.3/Manual/ExecutionOrder.html) awake, start, fixedUpdate update ...
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br>

## Physic Material
> - rigidbody의 재질은 실질적인 재질 (보여지는 재질 x)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9c4cdf72-980f-40ad-9a55-301399bbd2e4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}
> - dynamic friction : 이미 움직이고 있을 때 마찰 0 ~ 1
> - static friction : 정지 시 마찰 0 ~ 1
> - bounciness : 1이면 에너지 손실 없이 바운스
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br>

## Update
> - update는 프레임 단위. 다른 프레임의 화면마다 한프레임의 초가 달라진다.
> - Time.deltaTime = 1/프레임 초
> - update에서 코드에 * Time.deltaTime 로 다른 프레임의 환경에서도 동일하게 실행.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br>

## 좌표, 벡터
> - 월드 좌표 : 전체적 좌표 기준 .Position  
> - 로컬 좌표 : 부모의 좌표 기준 .LocalPosition   
> - Vector2.normalized 크기 1로 반환 -> 대각선 움직임 시 동일한 속도로 움직이기 위해 사용
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

<br>

## 직렬화

> - [Header("제목")]  `제목정하기`  
> - [SerializeField] -> private일 때 인스펙터 뷰에 보이게  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5f7769cb-06b2-4602-8390-e494d7ef5b28){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
<div class="notice--primary" markdown="1"> 

```c# 
[Header("헤더 사용")]
public int a = 0;
public int b = 0;
[Header("seriallizefield, private")]
[SerializeField] private int c = 0;
[Range (0.5f, 1.5f)] //슬라이더 형식
public float d = 0;
```
</div>

<br>


## 이동 INPUT 패키지
> - input 패키지 사용해서 캐릭터 이동 코드 event Action 구독 호출 패턴 캡처  
> - MOVE -> 키보드 W A S D 로 INPUT을 받아 OnMove 실행
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  
<div class="notice--primary" markdown="1"> 

```c# 
public void OnMove(InputValue value) // 
{       
    Vector2 moveInput = value.Get<Vector2>();
    CallMoveEvent(moveInput);
    
}
```
</div>

![input](https://github.com/levell1/levell1.github.io/assets/96651722/e0adebd0-ee00-4445-8521-7c65009fe3ce)

<br><br>

## 타일맵 
> - 이미지 팔레트에 드래그
> - tilemap 종류별로 생성 후 그리기
> - tilemap Collider 컴포넌트 확인
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
[타일맵](https://levell1.github.io/go%20unity/GoUnity11/)    
[docs](https://docs.unity3d.com/kr/2022.1/Manual/Tilemap-CreatingTiles.html)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2da4e65c-bec4-44ae-9b32-b5e1f4a6b2de)

<br><br>

## 각도, mathf

<div class="notice--primary" markdown="1"> 

`RotaeArm`
```c# 
private void RotaeArm(Vector2 direction)
{
    float rotZ = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

    armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
    characterRenderer.flipX = armRenderer.flipY;
    armPivot.rotation = Quaternion.Euler(0,0,rotZ);
}
```
</div>

Atan2(y,x) -> y,x tan 를 이용하여 각도 값 구하기(0~3.14)    
mathf.Rad2Deg 를 곱해주면 우리가아는 0 ~ 180도 로 변환된다.    
mathf.abs -> 절대값  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

flipx => x뒤집기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ec509a1f-e269-482b-9691-a990b7ebb712){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br>

### mathf

<div class="notice--primary" markdown="1"> 

`mathf`
```c# 
// 절댓값
Mathf.Abs(float num) 

// min(최소값)과 max(최대값) 범위 안에서 value값을 반환해준다.
Mathf.Clamp(float num, float min, float max)    

// value값이 Max(최대값)에 도달하게 되면 -값이 되고 0이 되면 다시 Max(최대값)까지 +
Mathf.PingPong(float value, float Max)

// 올림 버림 반올림
Mathf.Cell(float num)
Mathf.Floor(float num)
Mathf.Round(float num)

//시작점(from)과 종료점(to) 사이의 보간값(0과 1사이의 실수값)(t)에 해당하는 값을 반환
// 값을 부드럽게 변환
Mathf.Lerp(float from, float to, float t)

//lerp와 비슷하지만 가속도가 있다.
Mathf.SmoothStep(float from, float to, float t)

```
</div>

<br><br>

## Instantiate

Instantiate(prefab, transform 부모) 부모 아래에 생성  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/37fb0d34-5dd7-40a2-aaed-d3ee2d7a2f2d)    

<br>

Instantiate(prefab, Vector Position, rotation)  부모x 생성
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8c53aa89-9211-446c-9469-6472909aea29)  

<br><br><br><br><br>
- - - 

# 7. 객체지향

**객체지향 강의 정리**
추상화 - 객체의 공통적인 속성과 기능을 추출하여 정의하는것.  
상속 - 기존 클래스를 재활용 해 새로운 클래스 만듬, 반복코드 최소화.  
다형성 - 메서드 오버라이딩과 메서드 오버로딩.  
캡슐화 - private, public 등을 이용해 정보보호.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

## SOLID원칙

SRP(단일책임의 원칙) 한 클래스는 최소한의 기능만 갖는다.  
OCP(개방폐쇄의 원칙) 확장에 대해 개방, 수정 폐쇄적.  
LSP(리스코프 치환 원칙) 하위클래스는 인터페이스의 규약을 지켜야한다. 설계 많이해보기.  
ISP(인터페이스 분리 원칙) 병용 인터페이스 하나 보다는 여러개의 인터페이스 분리가 더 좋다, 다중상속으로 사용.  
DIP(의존관계 역전 원칙) 특정 클래스를 할당 X -> 부모,인터페이스를 사용하라 (편집됨)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br><br><br><br><br>
- - - 


# 정리, 잡담

**C# 알고리즘 강의**  
생각하고 코드에 활용은 못할 거 같다.   
이런 게 있구나 하고 넘어가야겠다.   
다음에 또 보면 다시 이해 해보자.  
주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**객체지향**  
클래스 사이에서 값 주고받고, 클래스의 중심으로 생각하기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

**1120강의**  
메타인지  
악에 받친 사람  
오늘 할 일은 오늘 하자.   
메타인지 -> 질문  
업무의 전문성을 키우자.  
기능이 아닌 서비스를 개발하는 사람.  
커뮤니케이션 - 겸손   
코드 : SOLID, 코드컨벤션, 예측가능코드, 변수명 (좋은코드를 짜자)  
나의 무기를 단련해 나가야 한다.  
책 타이탄의 도구들  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - - 

[Unity] TIL 21

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
