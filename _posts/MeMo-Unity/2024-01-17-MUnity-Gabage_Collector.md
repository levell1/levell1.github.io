---
title:  "[Memo-Unity] 36. GC(Garbage Collection)  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2024-01-17 01:21

---
- - -

`Garbage Collection`
<BR><BR>

<center><H1>  Garbage Collection  </H1></center>
Garbage Collection
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
<br><br><br><br><br><br>
- - - 


# 가비지 컬렉터(Garbage Collection)
**미사용 메모리를 파악하고 해제하는 프로세스**  
처리할 정보의 공간이 필요하다 (메모리)  
변수들 함수들, 객체들이 메모리를 차지하는 요소  
메모리를 치워주지않으면 메모리 누수(memory leak)가 생긴다  
새로운 언어들에서는 가비지 컬렉터를 도입  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## C# 가비지 컬렉터
c# 힙에 할당한 객체는 CLR이 자동으로 수거  
CLR은 더 이상 사용하지 않는 객체는 쓰레기(Garbage)로 판단  
이 메모리 Garbage를 수거(Collection)하는 것이 **가비지 컬렉션**  
EX) 스택영역의a가 참조하는 힙의 A가 있다, 스택영역의 a가 사라지면 힙의 A는 안쓰는 메모리(Garbage)가 된다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


### GC 루트
루트 : 힙에 있는 객체를 붙드는 참조 EX)a 스택또는 힙에 생성  
컴파일러는 루트 목록을 생성  
CLR은 이 루트 목록을 관리하며 상태 갱신  
루트목록은 가비지컬렉터가 참조하는 중요 자료  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**과정1**  
초기에 모든 객체가 쓰레기라고 가정  
루트 목록을 순회하며 각 루트가 참조하는 힙 객체와의 관계 조사  
관계없는 루트는 쓰레기, 참조하는 힙 객체는 유지  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**과정1**  
수거 후 비어있는 공간  으로 인접 객체들을 이동해서 정리  
가비지컬렉션 세대 : 가비지 컬렉션을 겪은 횟수  
X세대가 가비지 컬렉션이 일어나면 X이하 세대가 모두 가비지 컬렉션이 일어난다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/4ae41970-acf2-4ec3-8522-1a97ad3e8c6c)

<br><br><br>

## 유니티 가비지 컬렉션
유니티에서는 Unity Mono 엔진과 같은 런타임 시스템이 자동으로 메모리 관리를 수행한다.  
유니티는 Boehm-Demers-Weiser 가비지 컬렉션을 사용한다. 알고리즘 Mark-Sweep 을 사용  
가비지 컬렉터가 눈에 보이지는 않지만, 필요 이상으로 실행되도록 막는 것이 프로그래머의 중요한 역할 중 하나  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

### 작은 힙과 빠르고 빈번한 가비지 컬렉션.(주기적으로 GC를 행하라.)
<div class="notice--primary" markdown="1"> 

```c# 
if (Time.frameCount % 30 == 0)
{
   System.GC.Collect();
}
```
</div>

### 큰 힙과 느리지만 덜 빈번한 가비지 컬렉션
충분히 큰 힙을 확보하면 게임플레이 중 일시정지가 발생할 때까지 완전히 힙이 차버려서 가비지 컬렉션이 일어나는 일은 발생하지 않습니다. 일시정지가 발생하면 명시적으로 가비지 컬렉션을 요청할 수 있습니다.  

### 오브젝트 풀
오브젝트 풀의 사용은 새로 생성되고 제거되는 오브젝트의 수를 줄이는 것으로 간단하게 가비지 생성을 줄일 수 있습니다.   

[**유니티 가비지 컬렉션**](https://docs.unity3d.com/kr/2018.4/Manual/UnderstandingAutomaticMemoryManagement.html)  

<br><br><br><br><br>
- - - 
<br><br><br><br><br>
- - - 



# 잡담
유니티 공식 문서 잘 사용하기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] UnityDocs
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
