---
title:  "[C#] 7. 배열 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-13

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


<h1> 배열</h1>

<br><br><br><br><br><br>
- - - 

# 1. 기본

배열이란 여러 데이터를 한가지 변수에 저장하는 기능
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/4b6ae3e6-1fc8-41ea-a6b4-0fb69181008a){:style="border:1px solid #eaeaea; border-radius: 7px;"}

<div class="notice--primary" markdown="1"> 

```c# 
string[] game;
```

-   배열이란 여러 데이터를 한가지 변수에 저장하는 기능
</div>

<br><br><br><br><br><br>
- - - 

# 2. 생성

배열의 선언 구조  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/60de6c66-6360-4bf0-9d6f-90c2e6f74658){:style="border:1px solid #eaeaea; border-radius: 7px;"}

<div class="notice--primary" markdown="1"> 

```c# 
// 기본적인 변수 
string game;

// 변수를 만들고 바로 방을 만들기
string[] game = new string[3];

// 변수만 만들어 두고 방은 나중에 만들 수도 있습니다.
string[] game;
game = new string[3];
```

-   배열은 데이터 하나가 아닌 여러 데이터가 사는 집
-	처음배열은 0부터 game[0], game[1], game[2] 가 존재한다.
</div>

<br><br><br><br><br><br>
- - - 

# 3. 데이터 저장


<div class="notice--primary" markdown="1"> 

```c# 
// game의 1호실에 “메이플 스토리” 데이터를 저장
string[] game = new string[3];
game[0] = "Leage of Legends"
game[1] = "메이플 스토리"
```

-	![image](https://github.com/levell1/levell1.github.io/assets/96651722/c897b797-4e36-4bc7-896b-35b5a4092ee4){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
-   대괄호 [ ] 와 인덱스를 이용해 활용
</div>

<br><br><br><br><br><br>
- - - 

# 4. 데이터 활용


<div class="notice--primary" markdown="1"> 

```c# 
string[] game = new string[3];
game[0] = "Leage of Legends"
game[1] = "메이플 스토리"

//활용
Console.WriteLine(game[0]); // 출력 - League of Legends 
Console.WriteLine(game[1]); // 출력 - 메이플 스토리
```

-	배열에 데이터를 저장 / 활용 할 때 대괄호 [ ] 와 인덱스를 이용

</div>

<br><br><br><br><br><br>
- - - 

# 5. 각 타입별 배열

배열은 문자열 말고도 타입에 맞는 배열들을 생성할 수 있다.

<div class="notice--primary" markdown="1"> 

```c# 
//정수 배열
int[] year = new int[2];
year[0] = 2022;
year[1] = 2023;


Console.WriteLine(year[0]);  // 출력 - 2022
Console.WriteLine(year[1]);  // 출력 - 2023

//실수 배열
float[] height = new float[4];
height[0] = 164.5f;
height[1] = 172.7f;
height[2] = 181.2f;

Console.WriteLine(height[0]);  // 출력 - 164.5
Console.WriteLine(height[1]);  // 출력 - 172.7
Console.WriteLine(height[2]);  // 출력 - 181.2
```

-	배열의 타입이 맞지 않는 다면 에러가 발생합니다

</div>

<br><br><br><br><br><br>
- - - 

# 6. 반복처리

for 문을 이용하여 배열에 저장, 출력을 편하게 할 수 있다.

<div class="notice--primary" markdown="1"> 

```c# 
int[] year = new int[4]
for(int i = 0 ; i < 4 ; i++)
{
	year[i] = 2020 + i;			//저장
	Console.WriteLine(year[i]);	//출력
}

실행결과
2020
2021
2022
2023
```

</div>

<br><br><br><br><br><br>
- - - 

# 7. foreach

구성  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a4d8819b-a435-4068-831b-2e75299fb223){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
조건식을 쓰지 않고 해당 배열을 처음부터 끝까지 반복할때 사용

<div class="notice--primary" markdown="1"> 

```c# 
                               // 배열의 타입과 일치
string[] games = new string[3] {"League of Legends", "메이플 스토리", "디아블로"} 
foreach(string game in games)
{
		Console.WriteLine(game);
}

실행결과
League of Legends
메이플 스토리
디아블로
```

- 지정할 반복변수의 타입은 배열의 타입과 일치해야합니다.

</div>


<br><br><br><br><br><br>
- - - 

# 8. 정리, 추가

> 배열에 데이터선언후 저장하지 않으면 기본값이 있다.


<br><br>

[C#] 배열

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
