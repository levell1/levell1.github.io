---
title:  "[TIL] 30 반별 강의정리, 4시강의 정리  ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-08 02:00

---
- - -


유니티 생성주기 , 클래스, 접근제한자    
값 참조타입, 클래스 구조체 , 클래스 인터페이스, 리스코프 치환 원칙  
제네릭, 오브젝트 풀, 설계, 좋은코딩? SOLID
<BR><BR>


<center><H1>  유니티 숙련주차 1일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   42 ~ 43   
&nbsp;&nbsp; [o] 강의 듣기  
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [o] 4시 강의 듣기  
&nbsp;&nbsp; [X] 다른반 발표 보기  
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 알고리즘 문자열
<div class="notice--primary" markdown="1"> 

```c# 
public int solution(string t, string p) {
        int answer = 0;
        for(int i = 0; i < t.Length-p.Length+1; i++)
        {
            string strA = t.Substring(i, p.Length);
            int compare = strA.CompareTo(p);
            if (compare<=0) answer++;
        }
        return answer;
    }
```
> - **예) t = "123", p="2"**

**`t.Substring(i, p.Length)`**  
> - t의 i번째부터 p.Length(1) 개만큼 가져와서 strA에 저장.

<br>

**`strA.CompareTo(p)`**  
> - strA와 P를 비교한다 
> - strA가 크면 +1 
> - 같으면 0 
> - 작으면 -1

</div>

<br><br><br><br><br>
- - - 

# 2. 1반강의

## 1 ~ 3 정리
깃허브유니티 생성  
클래스 (데이터 + 메서드(기능))  
접근제한자 public private, protected  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 유니티 생성주기
생성주기 awake -> onenabel -> start ->   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/89123066-64bf-4848-a27e-f05ff8f62643){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 

# 3. 2반강의
값 참조타입, 클래스 구조체 , 클래스 인터페이스, 리스코프 치환 원칙

## 클래스 vs 구조체
![image](https://github.com/levell1/levell1.github.io/assets/96651722/58530a22-5632-40e1-9c57-ba1027c5c91b){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

## 클래스 vs 인터페이스
![image](https://github.com/levell1/levell1.github.io/assets/96651722/16fdbcef-078b-4405-970a-ae23c43b370c){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 

# 4. 3반강의
**공통역량**  
c# , 자료구조, 알고리즘  
데이터베이스, 네트워크  
운영체제, 컴터구조  
디자인 패턴의 이해  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**클라이언트 추가 역량**  
python등 생산성높은 언어  
그래픽스 렌더링, 쉐이더 프로그래밍  
AI, Navigation  
Game Physics  
게인 엔진 사용경험
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**서버 추가 역량**  
Multi Thread  
Parallel  
NetWork 
SQL, 클라우드 기반 서비스
보안, 안전성 등등
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 디자인 패턴
[디자인패턴](https://levell1.github.io/memo%20unity/Design_Pattern/)

<br><br><br><br><br>
- - - 

# 4시 강의

## 제너릭 : 마법상자
> - 다양한 타입을 담을 수 있음
> - 코드의 재사용성과 유연성, 유지보수에 효율적
> - list에 int, string / GetComponent <T(ype)>
> - return을 t로 하거나 <T> 로도 퉁치기 가능
> - 여러 데이터를 동일한 로직에 사용할 떄
> - where - 제약조건 추가
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6ccd44e7-7759-4c45-9719-a5ee84463913)
> - 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c# 
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// 사용 예시
Calculator calculator = new Calculator();
int sum1 = calculator.Add(2, 3); // int Add(int a, int b) 메소드 호출
double sum2 = calculator.Add(2.5, 3.7); // double Add(double a, double b) 메소드 호출
int sum3 = calculator.Add(2, 3, 4); // int Add(int a, int b, int c) 메소드 호출
```

</div>

<br><br>

## 오버로딩 오버라이딩
> -**`오버로딩`** : 파라미터에 따라 함수의 기능이 달라진다.  
> 같은이름 다른기능   
> -**`오버라이딩`** : 부모에 정의된 메서드를 새롭게 정의한다.  
> 재정의  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 오브젝트 풀
프리팹 -> 인스턴스화 setactive.False -> 오브젝트풀 -> 활성화 -> 실제 오브젝트 -> 사용한 오브젝트 false -> 다음에 재사용  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**이유** : 성능향상, 메모리 관리  
**활용** : 총알, 적 캐릭터  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

### 1) 미리 생성하는 방식 
문제점 오브젝트 생성할때 너무 많으면 로딩이 오래걸릴 수 있다.    
<div class="notice--primary" markdown="1"> 

```c# 
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize;

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }
}

```

</div>

오브젝트를 다 썻는데 더 필요할 때 오래된걸 지우고 가져오기.  
dequeue(오래된거 뺴기) -> enqueue(다시 pool)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

### 2) 동적 오브젝트 풀 

<div class="notice--primary" markdown="1"> 

```c# 
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize; // 100
    public int maxPoolSize; // 10000

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if (objectPool.Count < maxPoolSize)
        {
            GameObject obj = Instantiate(prefab, transform);
            objectPool.Add(obj); 
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // 풀에 더 이상 생성할 수 없음
            return null;
        }
    }
}

```

</div>

### 3) 유니티 내장 함수 
Objectpool()  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1ccfec3e-1679-477d-9c19-43006778c5bd)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**Objectpool()**  

<div class="notice--primary" markdown="1"> 

```c# 
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize; // 100
    public int maxPoolSize; // 10000

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if (objectPool.Count < maxPoolSize)
        {
            GameObject obj = Instantiate(prefab, transform);
            objectPool.Add(obj); 
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // 풀에 더 이상 생성할 수 없음
            return null;
        }
    }
}

```

</div>

**언제사용?**
오브젝트의 생성과 파괴가 계속 일어난다.  
오브젝트를 많이 생성해야된다. (30개 이상)  
생성관리를 체계적으로 하고 싶다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>

## 소프트웨어 설계와 객체지향 원칙

폭포수식 개발  
agon, mimicry, ilinx, alea  
기능별로 모두 나눈다?  
`높은 응집도(Cohesion)`과 `낮은 결합도(Coupling)`은 좋은 소프트웨어  
`응집도` : 모듈 내부에 존재하는 구성 요소들 사이의 밀접한 정도를 나타내며,  
`결합도` : 모듈과 모듈 사이의 관계에서 관련 정도를 나타낸다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**SOLID원칙**  
SRP(단일책임의 원칙) 한 클래스는 최소한의 기능만 갖는다.  
OCP(개방폐쇄의 원칙) 확장에 대해 개방, 수정 폐쇄적.  
LSP(리스코프 치환 원칙) 하위클래스는 인터페이스의 규약을 지켜야한다. 설계 많이해보기.  
ISP(인터페이스 분리 원칙) 병용 인터페이스 하나 보다는 여러개의 인터페이스 분리가 더 좋다, 다중상속으로 사용.  
DIP(의존관계 역전 원칙) 특정 클래스를 할당 X -> 부모,인터페이스를 사용하라 (편집됨)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}


<br><br><br><br><br>
- - -

# 잡담 


<br><br>
- - -

[Unity] TIL 30

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
