---
title:  "[C#] 9. 클래스와 객체 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-16

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


<h1> 클래스와 객체</h1>

<br><br><br><br><br><br>
- - - 

# 1. OOP에 대해서

C# 은 객체 지향 프로그래밍 OOP(Object Oriented Programming) 언어  
객체들을 유기적으로 연결해서 개발해 나가는것  
EX)객체 : 캐릭터, 상점, 건물, 아이템등등  
{: .notice}

<h3>객체 지향 특징 </h3>

>   -   캡슐화  :   데이터와 코드를 외부에서 알 수 없게
>   -   추상화  :   객체들의 공통적인 특징을 추려냄
>   -   상속    :   하위 클래스가 상위 클래스의 모든 것을 활용가능
>   -   다형성  :   
{: .notice--info}

<h3>객체 지향 장점 </h3>

>   - 재사용 가능한 코드가 많다.
>   - 코드 생산성이 높아진다.
>   - 유지보수에 용이하다
{: .notice--info}


<br><br><br><br><br><br>
- - - 

# 2. class에 대해서

만약 캐릭터 를 만들다가 많은캐릭터가 생성된다고 예를든다면 코드가 너무 길어져 class를 만들어 공통된 부분을 추상화 할 수 있다.
{: .notice}

<h3>클래스 생성 </h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/ed24fbb7-7310-4ab6-9b14-c13473e817aa){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
>   -   이 클래스의 영역안에서는 **변수**를 만들거나 **함수**를 만들 수 있습니다.  
>   -   **함수의 호출**이나 **계산** 등 의 동작은 할 수 없습니다.  
>   -   이러한 경우 함수를 하나 만들어서 그 안에서 필요한 내용을 작성하면 됩니다.  
{: .notice-info}

<div class="notice--primary" markdown="1"> 

```c# 
string userName1 = "Chad";
string job1 = "전사";
int level1 = 50;

string userName2 = "MelonG";
string job2 = "마법사";
int level2 = 23;

string userName3 = "Dtail";
string job3 = "도적";
int level3 = 100;

class Character
{
	string userName;
	string job;
	string level;

	public void IntroduceCharacter()  <- 함수를 만들어서 실행
	{
			Console.WriteLine("제 이름은 " + userName + "입니다");
	}
}

```
-   클래스 사용을 위해선 객체를 생성해야한다. [객체](#3-객체에-대해서)

</div>

<br><br><br><br><br><br>
- - - 

# 3. 객체에 대해서

생성된 클래스를 사용하기 위해 객체를 생성해야 한다.
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/80a3463e-c0b4-4346-918a-04ce57c2634a){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
Character myCharacter = new Character();
myCharacter.userName = "chad";
myCharacter.job = "전사";
myCharacter.level = 20;

myCharacter.IntroduceCharacter();


class Character
{
    static string userName;
    static string job;
    static int level;

    public void IntroduceCharacter()
    {
        Console.WriteLine("레벨 : " + level + "  이름 : " + userName + "  직업 : " + job);
    }
}
```

-	각 변수나 함수에 접근할 때는 이 객체를 통해 접근을 해야합니다.
-   객체의 속성을 접근하려면 .  을 눌러서 접근할 수 있습니다.
-   클래스 안의 변수 static 확인
</div>

<br><br><br><br><br><br>
- - - 

<br><br>

[C#] 클래스와 객체

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
