---
title:  "[TIL] 42 반별강의(Memory), 심화주차  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-24 02:00

---
- - -

![image](https://github.com/levell1/levell1.github.io/assets/96651722/be5b3949-04ed-4081-8cc8-3609a99d7a18)
`Memory`

<BR><BR>


<center><H1>  유니티 심화주차 2일 , 개인공부 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 47   
&nbsp;&nbsp; [o] 다른반 강의 듣기  
&nbsp;&nbsp; [x] ui 2회차 듣기  
&nbsp;&nbsp; [x] 전 강의 복습.      
&nbsp;&nbsp; [x] 심화주차 강의 듣기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

<h2> 반별강의 </h2>

# 1. 메모리
> - **코드 영역** : 실행할 프로그램의 코드  
> - **데이터 영역**  : 데이터 영역  
> - **힙 영역**  : 사용자의 동적 할당  
> - **스택 영역**  : 지역 변수, 매개 변수  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/bf15370d-bef1-4f96-acf7-10bb3507d4ce){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

## 스택 메모리
> - 지역변수, 매개변수  
> - 값형식(value)  
> - c#에서 스택 영역 용량이 작다(1mb?)  
> - 0으로 초기화 되는 자료형  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

**메모리의 할당, 해제 : 지역(클래스,함수)가 끝나면 해제된다.**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/c82130dc-4468-4f69-b695-8aaa2409a90d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br>

## 힙 데이터  
> - 동적으로 관리
> - 참조형식()  
> - c#에서 스택 영역 용량이 작다(1mb?)  
> - 0으로 초기화 되는 자료형  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

**스택에는 주소가 힙메모리에는 실제값이**  
스택 영역 용량이 작다 -> 주소값만(int) -> 실제 데이터(long,~~)는 힙에  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/c21c692c-7dcb-4e10-908d-70464a56c0fc){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br>

### GC(Garbage Col)
> - 힙 메모리를 관리해줌  
> - 많은 가비지를 생성해 프레임 드랍이 발생 -> 관리  
> - new로 만드는 자료구조 Dispose()필요  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br>

### boxing , unboxing
> - 성능에 좋은 역할을 하지 않는다.  
> - 계산량이 많아 GC가 자주 일어난다.
> - Arraylist는 boxing,unboxing 이 일어난다    
> - GENERIC.LIST (T)는 Boxing이 안일어남  
> - Debug.Log 도 매개변수 자료형이 object로 boxing이 일어난다.  
> - var, T 를 사용. 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/fc7a6011-f0b1-4e48-8d6b-c5ebc054936b)

<div class="notice--primary" markdown="1"> 

```c#
int i =123;     // a value type  
object o = i;   // boxing  
int j = (int)o; // unboxing  

// X 박싱할 때 INT값도 같이 저장된다.
int i =123;     // a value type  
object o = i;   // boxing  
float j = (float)o; // unboxing  
```
</div>


<br><br><br><br><br>
- - - 

# 2. Ref, Out
ref : 선언된 변수를 매개변수로 함수내에서 값을 변경  
out : 초기화 되지 않은 변수도 out은 정상 작동 한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

[out,ref](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp9/#2-ref-out)  
 

<br><br><br><br><br>
- - - 

# 3. Ref, Out
ref : 선언된 변수를 매개변수로 함수내에서 값을 변경  
out : 초기화 되지 않은 변수도 out은 정상 작동 한다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

[out,ref](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp9/#2-ref-out)  


# 잡담,정리
csv - 맵생성, 대화형식 데이터
**알고리즘**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9d876df3-e807-480c-8415-aed69164264d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
Simulator gameView 에서 simulator 로 변경하면 폰화면 미리보기 가능.  
Window -> Analysis -> Profiler : 프레임,cpu, gpu, 메모리 등 사용량을 체크할 수 있다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

**리더**  
좋은 리더란 무었인가? 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
