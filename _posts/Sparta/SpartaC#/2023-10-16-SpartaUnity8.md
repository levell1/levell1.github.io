---
title:  "[C#] 8. 함수 "
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


<h1> 함수</h1>

<br><br><br><br><br><br>
- - - 

# 1. 기본

함수를 생성, 사용하여 많은 기능이 있는 함수를 생성하고 불러와 사용해 편하게 사용할 수 있다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
Console.WriteLine();        // C# 에서 미리 준비해둔 기능
Console.ReadLine();         // C# 에서 미리 준비해둔 기능
Console.Clean();            // C# 에서 미리 준비해둔 기능
Conver.ToInt32();           // C# 에서 미리 준비해둔 기능

void Hello()                // 사용자가 만드는 함수
{

}
```

-   C# 에서 미리 준비해둔 기능
</div>

<br><br><br><br><br><br>
- - - 

# 2. 함수 만들기, 실행

<h3> 함수 생성 </h3> 

필요한 기능이 있을때 직접 함수를 만들어 사용할 수 있다.
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/1a3c3cd5-d34d-4ed8-89b4-f56ca734960f){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
>   반환형식 : 함수의 결과를 어떻게 반환될지   
>   함수이름 : ReadLine(), Clean() 등 함수의 이름을 부여 (의미있는 이름이 좋음)  
>   ()중괄호 : 무엇인가 기능을 실행할 때 붙이는 기호  
>   함수영역 : {} 안에 함수의 기능을 넣는다.  
{: .notice}
<div class="notice--primary" markdown="1"> 

```c# 
void MethodSample()
{
	Console.WriteLine("함수에 대해 알아보겠습니다.");
	Console.WriteLine("우선은 영역에 대해 확인해보겠습니다.");
}

MethodSample();

실행결과
함수에 대해 알아보겠습니다.
우선은 영역에 대해 확인해보겠습니다.
```

-   함수를 생성하고 실행 MethodSample(); 하기
</div>

<br><br><br><br><br><br>
- - - 

# 3. Return

>   Return 은 해당 코드 밑에 있는 모든 기능을 캔슬하고 함수를 종료한다.  
>   조건에 의해 return을 사용할 수 있다.
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int hp = 3;

Attack();    // 데미지 : 1    현재체력 : 2
Attack();    // 데미지 : 1    현재체력 : 1
Attack();    // 데미지 : 1    현재체력 : 0
Attack();    // Console X

void Attack()
{
    if (hp < 1)
    {
        return;
    }
    --hp;
    Console.WriteLine("데미지 : 1    현재체력 : " + hp);
}
```

-	hp가 1이하일때 return이 되어 함수가 종료된다.

</div>

<br><br><br><br><br><br>
- - - 

# 4. return 과 반환 형식


<div class="notice--primary" markdown="1"> 

```c# 

int testNum = Attack1();
// string testString = Attack();

int Attack1()
{
    Console.Write("return 확인");
    return 100;
}

Console.Write(testNum);
```

-	반환형식  int 와 return 100 의 형식이 일치해야 된다.
-   void 가 아니라 반환타입을 지정했다면 반드시 return 으로 반환값을 줘야한다.
-   타입에 맞는 데이터만 저장

</div>

<br><br><br><br><br><br>
- - - 

# 5. 매개변수

()소괄호 안에 변수를 만들어 사용
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
int hp = 10;
void Attack3(int damage)
{
    hp -= damage;
    if (hp < 1)
    {
        //사망코드
        return;
    }
    Console.WriteLine("데미지 : " + damage + "    현재체력 : " + hp);
}
Attack3(3);
Attack3(6);
Attack3(4); // hp 1이하
```

-	함수를 만들때 매개변수를 설정하였다면 함수 실행시 반드시 값을 입력하여야 합니다.
-   매개변수를 설정하지 않았다면 함수 실행할때 값을 입력 할 수 없습니다.
-   매개변수와 입력하는 값의 타입이 같아야 합니다.
</div>

## 여러 매개변수

()소괄호 안에 여러개의 매개변수 사용가능
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
void DisplayMyInfo(int level, string name, string job)
{
    Console.WriteLine("레벨 : " + level + "이름 : " + name + "직업 : " + job);
}
DisplayMyInfo(1, "kim", "pro");
```

-	매개변수 level, name, job 3개 사용

</div>


<br><br><br><br><br><br>
- - - 

# 6. 네이밍 규칙

>   C#에서 보편적으로 활용되는 것에는 카멜 케이스, 파스칼 케이스 가 있습니다.  
>   -   카멜 케이스 : 소문자로 시작     myPoint,  enemyName  
>   -   파스칼 케이스 : 대문자로 시작   AttackMonster,   FindCharacter  
>   -   체계적으로 함수,클래스는 파스칼   변수는 카멜로 표현 가능
>   -   공백을 포함한 이름을 만들 수 없습니다.
{: .notice} 

[microsoft 코딩 규칙](https://learn.microsoft.com/ko-kr/dotnet/csharp/fundamentals/coding-style/coding-conventions)

<br><br>

[C#] 함수

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
