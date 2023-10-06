---
title:  "[C#] 2. 데이터 다루기 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-06

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


# 1. 변수

기본적인 형식  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e5d81ded-4ec3-44a1-a8ba-48243330bb99){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
>   <H4> 데이터 형식 </H4>
>   -   문자라면 String 
>   -   숫자라면 Int  
>   <H4> 변수 이름  </H4>
>   -   의미있는 이름으로 지으면 좋다
>   -   특수문자,띄워쓰기 X
{: .notice}

## &nbsp;&nbsp;&nbsp; 변수 - 생성과 저장

>   -   생성(선언) : 데이터형식과 이름을 정하고 세미콜론으로 마무리하면 변수가 만들어진다.
>   -   저장(할당) : 변수에 데이터를 저장할때는 = 을 이용 (형식에 맞게)
{: .notice--info}

<div class="notice--primary" markdown="1"> 

```c# 
String codingClub = "팀스파르타";
int year = 2023;
```

</div>

## &nbsp;&nbsp;&nbsp; 변수 - 활용

>   -   함수(내용) -> 내용부분을 변수로 대체하여 활용한다.
>   -   EX) Console.WriteLine(year);
{: .notice--info}

## &nbsp;&nbsp;&nbsp; 변수 - 수정

>   -   하나의변수를 다시 수정하여 사용할 수 있다.
{: .notice--info}

<div class="notice--primary" markdown="1"> 

```c# 
int year = 2023;
Console.WriteLine(year);
year = 2024;
Console.WriteLine(year);
```
![image](https://github.com/levell1/levell1.github.io/assets/96651722/16d0ae06-53ca-449c-a2e9-df409f83b91c){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

</div>

<br><br><br><br><br><br>
- - - 

# 2. 자료형

>   -   자료의 종류에 따라 그리고 표현가능한 범위에 따라 다양한 자료형을 제공합니다
>   -   정수,실수,문자열,논리형, 십진형, 문자열형등 많은 자료형이 있다.
{: .notice}


## &nbsp;&nbsp;&nbsp; 자료형 - 숫자(int, float, double)

<h3>int(integer) 정수</h3>
소수점이 없는 숫자
<div class="notice--primary" markdown="1"> 

```c# 
int age = 15;
int amount = 4;
int level = 100;
```
</div>


<h3>int(integer) 실수</h3>
소수점이 있는 숫자 
<div class="notice--primary" markdown="1"> 

```c# 
float exp = 56.5f;
float speed = 3.2f;
double lenght = 10.245d;
```


- float 를 사용하는지 double을 사용하는지 표시해야된다.
- float 소수점 7자리 까지 표시가능 , 뒤에 f표시
- double 소수점 15~16 자리 까지 표시가능    뒤에 d표시
</div>


## &nbsp;&nbsp;&nbsp; 자료형 - 문자열과 문자(String, char)

>   -   문자(char)들이 합쳐진 데이터 -> 문자열(string)
{: .notice--info}


<div class="notice--primary" markdown="1"> 

```c# 
string codingClub = "팀스파르타";

char team_1 = "팀";
char team_2 = "스";
char team_3 = "파";
char team_4 = "르";
char team_5 = "타";
```

</div>

## &nbsp;&nbsp;&nbsp; 자료형 - 정리표

> ![image](https://github.com/levell1/levell1.github.io/assets/96651722/92a13d8f-a49c-4355-ac7b-423fd804abba){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
> - 크기가 큰만큼 메모리에 더 비싸게 저장
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 3. 형변환(Casting)

>   <span style="color:blue">숫자</span>를 다른 형태의 <span style="color:blue">숫자</span>로 변환  
>   <span style="color:green">다른 자료형</span>을 <span style="color:yellow">문자</span>로 변환  
>   <span style="color:yellow">문자</span>을 <span style="color:green">다른 자료형</span>로 변환  
{: .notice}


## &nbsp;&nbsp;&nbsp; 숫자 -> 숫자

<div class="notice--primary" markdown="1"> 

```c# 
int x = 10;
float y = 10.0f;

int z = x + (int)y; // 사용하고 싶은 변수 앞에 변경하고 싶은 괄호하고 자료형 명시
float z = (float)x + y; 

```
-   사용하고 싶은 변수 앞에 변경하고 싶은 괄호하고 자료형 명시
-   float 1.5f 를 int 1 로 바꾸려면 0.5 의 값이 사라지기 때문에 명시해야합니다.
-   int 1 을 float 1.0f 으로 바꾸려면 누락될 값이 없어 그냥 사용해도 됩니다.

</div>


## &nbsp;&nbsp;&nbsp; 다른 자료형 → 문자


> 숫자나 bool을 문자로 바꾸는 방법
{: .notice--info} 
<div class="notice--primary" markdown="1"> 

```c# 
int x = 10;
string xStr = x.ToString(); // "10"

float y = 10.5f;
string yStr = y.ToString(); // "10.5"

bool myBool = true;
string boolStr = myBool.ToString(); // "true"

```
-   간단하게 뒤에 .ToString()을 붙이면 변환할 수 있습니다.

</div>


## &nbsp;&nbsp;&nbsp; 문자 → 다른 자료형


> 문자를 다른 다료형으로 바꾸는 방식은 조금 복잡하고 다양합니다. (3가지 방법)
>   -   Convert클래스 이용
>   -   Parse()함수 이용
>   -   TryParse()함수 이용


### &nbsp;&nbsp;&nbsp; Convert 클래스 이용

<div class="notice--primary" markdown="1"> 

```c# 
string iStr = "10";
int x;
x = Convert.ToInt32(iStr); // x : 10

string bStr = "true";
bool b;
b = Convert.ToBoolean(bStr); // b : true

```
-   ![image](https://github.com/levell1/levell1.github.io/assets/96651722/2b456c41-077f-4cba-b5bf-03d62eea6b52)
-   네임스페이스 Using System 
</div>


### &nbsp;&nbsp;&nbsp; Parse() 함수 이용

<div class="notice--primary" markdown="1"> 

```c# 
string iStr = "10";
int x;
x = int.Parse(iStr); // x : 10

string bStr = "true";
bool b;
b = bool.Parse(bStr); // b : true

```
-   Convert 와 Parse() 함수를 이용하면 변환한 값을 받아올 수 있습니다.
-   문제는 변환할 수 없는 값일때 문제가 생깁니다. -> TryParse() 사용
</div>


### &nbsp;&nbsp;&nbsp; TryParse() 함수 사용

위와 같은 의도하지 않은 상황에 대처하기 위해 TryParse 가 있습니다.  
out 개념이 들어가는데 어려운 개념이므로 이후 메모리 부분을 확인
{: .notice--info} 
<div class="notice--primary" markdown="1"> 

```c# 
string iStr = "10";
int x;
int.TryParse(iStr, out x); // x : 10

string bStr = "true";
bool b;
bool.TryParse(bStr, out b); // b : true


string iStr = "10"; // int 로 변활 할 수 있으니 성공
int x;
bool isSuccess;
isSuccess = int.TryParse(iStr, out x); // isSuccess : true


string bStr = "testtest"; // bool 로 변활 할 수 없으니 실패
bool b;
bool isSuccess;
isSuccess = int.TryParse(bStr, out b); // isSuccess : false

```
-   기존 방법과 다른 점은 반환값으로 캐스팅한 값을 받지 않습니다.
-   반환값은 bool 만 받으며 캐스팅이 성공했는지 알려줍니다.
</div>

<br><br><br><br><br><br>
- - - 

# 4. 연습문제

<div class="notice--primary" markdown="1"> 

```c# 
{
    //연습문제 1

    //1-1,2
    int level   = 50;         //레벨
    int count   = 7;          //갯수

    float percentage    = 70.0f;   //확률
    float speed         = 2.1f;    //속도

    string nickname     = "Post";      //별명
    string description  = "설명글";    //설명


    //1-3 숫자를 숫자로
    int iTen = 10;
    float fTen; // iTen 을 저장해보세요

    fTen = (float)iTen;
    fTen = iTen;

    float fFive = 5.5f;
    int iFive; // fFive 을 저장해보세요

    iFive = (int)fFive;

    //1-4   숫자를 문자로
    int n = 10;
    float f = 0.5f;

    string strN = n.ToString();
    string strF = f.ToString();

    //1-5 문자를 숫자로
    string strTen = "10";
    string strSix = "6.2";

    int Ten = Convert.ToInt32(strTen);
    float Six = float.Parse(strSix);
    int.TryParse(strTen, out Ten); 

}
```

</div>
<br><br>
 
..

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
