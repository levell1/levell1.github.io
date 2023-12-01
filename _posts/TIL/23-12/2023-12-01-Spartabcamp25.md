---
title:  "[TIL] 25 Unity 팀과제  ⭐ "
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


<center><H1>  유니티 팀과제 2일차 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제   31 ~ 34    
&nbsp;&nbsp; [o] 팀과제   
&nbsp;&nbsp; [o] 4시 강의   
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 1. 알고리즘 문자열
string.ToCharArray() :  문자열을 문자배열(char[])에 복사합니다.  
string s = new String(문자배열) char[]   -> 'a','b' ,'c'  
s = "abc"
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
<div class="notice--primary" markdown="1"> 

`문자열 내림차순`
```c# 
public string solution(string s) {
        string answer = "";
        char[] carr= s.ToCharArray();
        
        Array.Sort(carr);
        Array.Reverse(carr);
        
        answer = new String(carr);
        return answer;
    }
```
</div>

<br><br><br><br><br>
- - - 

# 2. 강의 - 유니티  
오브젝트에 메소드 실행 메시지 전달

## 1. 게임오브젝트 찾기
**gameobject.Find 시리즈**  
GameObject.Find("이름" 혹은 경로) -> 느림  
GameObject.FindGameObjectWithType("컴포넌트명") -> 별로 안빠름  
GameObject.FindGameObjectWithTag("태그") -> 그나마 빠름  
Transform.Find("이름" 혹은 경로)  -> ~의 자식 안에서 찾을때  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
## 2. 카메라
**3D 는 원근감이 있다**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/d6d8f31a-e618-4302-83fd-4c74001c9629)


**2D 는 X**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/eaed8fa8-5573-4b17-a1e5-8c53b0f52ad2)


FildOFView : 시야각  
culling mask 내가 찍고싶은 레이어만 찍기  

Clipping Planes : 카메라 범위 0.3 ~ 1000  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6540ccc2-10ef-406d-8a35-4c61870f4d06)

<br><br><br><br><br>
- - - 

# 3 C# 강의


## 배열

배열 리사이즈  
Array.Resize(ref x, 5);  
//추가 하기


## 컬렉션
자료구조, 같은 성격을 띠는 자려들을 담는 자료구조  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/44fbc49a-38a4-4276-af37-7a589aa751cb)

List : 배열을 기반으로 만들어진 자료형  
배열과 달리 유동적으로 확장 가능하다.  
Dictionary : 해시테이블 구조로 데이터를 저장  
O(1)로 접근할 수 있는 데이터 구조. 값이 많아도 똑같은시간  
Dictionary -> 데이터를 많이 쓴다.  
더 찾아보고 공부  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

## Delegate - 대리자
숫자 객체들은 데이터처럼 쓰는데 메서드는 왜 ? -> Delegate   
행동(함수)을 넘겨주는 변수?  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**유의사항**
입력 파라미터, 리턴 타입을 유의해야 한다.(입력,리턴이 맞는 메서드들만)  
delegate += 메서드();  
함수 등록하기  
delegate?.invoke() 등록된 함수들 실행하기  
자주사용하는 Delegate  
Action, Func, 람다  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<div class="notice--primary" markdown="1"> 

`문자열 내림차순`
```c# 
func<int,int> square x-> x*x;
int x = square(5);
func<String,int> Length s -> s.Length;
MyList.FIndAll(x=> x%2 == 1) 조건에 만족하는 모든 값을 도출
MyList.Select(x=>) 
```
</div>



# 정리, 잡담

**느낀점**  
다시 정리하기
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


<br><br>
- - - 

[Unity] TIL 25

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
