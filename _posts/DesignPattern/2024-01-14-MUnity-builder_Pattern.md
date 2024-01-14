---
title:  "[Memo-Unity] 6. `builder`패턴,"
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:06

---
- - -
<BR><BR>
 
`builder`, 

<center><H1> builder패턴   </H1></center>

<br><br><br><br><br><br>
- - - 

# 빌더 패턴 (builder)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/7517e86f-622e-40a6-af6b-18da5053334d){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**샌드위치**
> - 복잡한 객체의 생성 과정을 단계별 분리
> - 객체의 생성과 표현을 분리
> - 생성하는 과정에서 서로 다른 표현을 가진 객체를 만드는 것
> - 복잡한 게임오브젝트, 난이도조절할 때 사용(맵형태, 몹수)
{: .notice--info} 

<details>
<summary>builder 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 빌더 인터페이스
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    GameObject GetResult();
}

// 빌더 클래스
public class ConcreteBuilder : IBuilder
{
    private GameObject gameObject = new GameObject();

    public void BuildPartA()
    {
        // 객체의 일부분 A를 구축 (예: 캐릭터 모델 추가)
    }

    public void BuildPartB()
    {
        // 객체의 일부분 B를 구축 (예: 캐릭터 애니메이션 설정)
    }

    public void BuildPartC()
    {
        // 객체의 일부분 C를 구축 (예: 캐릭터 능력치 설정)
    }

    public GameObject GetResult()
    {
        return gameObject;
    }
}

// 게임 오브젝트 클래스
public class GameObject
{
    // 게임 오브젝트 관련 속성 및 메소드
}

// 빌더 사용
IBuilder builder = new ConcreteBuilder();
builder.BuildPartA();
builder.BuildPartB();
builder.BuildPartC();
GameObject player = builder.GetResult();
```
</div>
</details>

<br><br><br><br><br><br>
- - - 


# 잡담, 정리
> - 디자인 패턴은 애초에 특정 문제를 해결하기 위해 고려된 것.(성능, 메모리 사용 고려)
> - 추가 내용 정리
{: .notice--success} 

<br><br>
- - - 

[C#] 디자인 패턴 (Design Pattern)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
