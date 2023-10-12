---
title:  "[C#] 4. 제어문 - 조건제어 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-12

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


# 1. 조건제어

<br><br><br><br><br><br>
- - - 

# 2. break 

<H3> break </h3>

break 가 실행되면 진행되고 있는 구문들이 즉시 종료
크게 2가지 경우에 사용합니다.
>   -   Switch
>   -   Case문
{: .notice}

## Switch Case문
구문을 종료할 때 break 를 넣어서 사용

<div class="notice--primary" markdown="1"> 

```c# 
int x = 5;
switch(x)
{
	case 1:
		Console.WriteLine("치킨을 주문하자.");
		break;

	case 2:
		Console.WriteLine("피자을 주문하자.");
		break;

	defualt:
		Console.WriteLine("마라탕을 주문하자.");
		break;
}
```
</div>

## For 문
반복문에서 break 가 걸리면 그 순간 반복문을 종료하고 빠져나옵니다.

<div class="notice--primary" markdown="1"> 

```c# 
for(int i = 0 ; i < 5 ; i++)
{
		if(i == 3)
		{
				break;
		}
		Console.WriteLine(i + "번째 반복입니다.");
}

실행결과
0 번째 반복입니다.
1 번째 반복입니다.
2 번째 반복입니다.
// 3 번째 반복입니다. 출력 X  <- 3 에서 break 가 걸려 for문이 종료됩니다.
// 4 번째 반복입니다. 출력 X

for(int i = 0 ; i < 5 ; i++) // <- 멀리 있는 for문은 계속 반복됩니다.
{
		for(int j = 0 ; j < 5 ; j++) // <- break 가 걸리면 가장 가까운 for문 종료
		{
				if(j == 2)
				{
						break;
				}
		}
}
```
</div>

- 반복문이 여러개가 있을때 **가장 가까지 있는 반복문만 종료**됩니다.
- 그보다 **멀리있는 반복문은 계속 동작**합니다.

<br><br><br><br><br><br>
- - - 

# 3. Continue


반복문에서 해당 반복을 넘기고 다음 반복으로 넘어갈때 사용
{: .notice}

<div class="notice--primary" markdown="1"> 

```c# 
for(int i = 0 ; i < 5 ; i++)
{
		if(i == 3)
		{
				continue;
		}
		Debug.Log(i + "번째 반복입니다.");
}
// "0 번째 반복입니다."
// "1 번째 반복입니다."
// "2 번째 반복입니다."
// "4 번째 반복입니다."

// 3 에서 continue 로 인해 해당 반복의 내용은 실행 안하고 다음으로 넘어갔습니다.

```

</div>

<br><br>

[C#] 제어문 - 조건 제어

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
