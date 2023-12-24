---
title:  "[Memo-Unity] 26. MemoryStructure 메모리 구조 "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-24 01:11

---
- - -

`MemoryStructure` 
<BR><BR>

<center><H1>  MemoryStructure  </H1></center>
MemoryStructure  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
<br><br><br><br><br><br>
- - - 


## 메모리
> - **코드 영역** : 실행할 프로그램의 코드  
> - **데이터 영역**  : 데이터 영역  
> - **힙 영역**  : 사용자의 동적 할당  
> - **스택 영역**  : 지역 변수, 매개 변수  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/bf15370d-bef1-4f96-acf7-10bb3507d4ce){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

### 스택 메모리
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

### 힙 데이터  
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

#### GC(Garbage Col)
> - 힙 메모리를 관리해줌  
> - 많은 가비지를 생성해 프레임 드랍이 발생 -> 관리  
> - new로 만드는 자료구조 Dispose()필요  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success} 

<br>

#### boxing , unboxing
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

# 잡담
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] MemoryStructure
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
