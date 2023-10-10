---
title:  "[C#] 3. 연산자 "
excerpt: "C Sharp"

categories:
    - Sparta C Sharp
tags:
    - [Unity, Sparta, C#]

toc: true
toc_sticky: true
 
date: 2023-10-10

---
- - -
<BR><BR>

<center><H1> C# 사전 문법 기초</H1></center>

<BR><BR>


# 1. 연산자(Operator)



<br><br><br><br><br><br>
- - - 

# 2. 산술연산

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8a1ff8e4-ef9d-49b0-8930-0aa2c784e9a7){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<div class="notice--primary" markdown="1"> 

```c# 
int x = 10;
int result;

result = x + 3; // result : 13      더하기

result = x - 5; // result : 5       빼기

result = x * 2; // result : 20      곱하기

int result_1;
int result_2;

result_1 = x / 4; // result_1 : 2   몫
result_2 = x % 4; // result_2 : 2   나머지

x++;    // x : 11                   증가 +1

int y = 10;
y--;    // y : 9                    감소 -1

```
-   연산을 하는 것 보다 * 연산을 하는게 빠릅니다. 가능하면 *를 이용
-   x = 10 / 2          ->      x = 10 * 0.5f ( 더 빠르다.)
-   ++x ( 더한 후 출력 ), x++ ( 출력 후 더하기 ) 은 조금다르다

</div>


## &nbsp;&nbsp;&nbsp; 산술연산 - 문자열

문자열에는 +연산을 활용할 수 있다.
<h3>숫자,문자열 +연산</h3>
<div class="notice--primary" markdown="1"> 

```c# 
string hello = "안녕";
string academy = "하세요!";

string result  = hello + academy;       //안녕하세요!
string result  = hello + "하세요!";     //안녕하세요!

int year = 2023;

string result  = year + "년 입니다.";   //2023년 입니다.

Console.WriteLine(result);

```
- 문자열 + 문자열, 숫자 + 문자열 예시
</div>


<br><br><br><br><br><br>
- - - 

# 3. 논리 연산
논리적으로 판단하는 연산자

>   <h4>같음 연산자, 비교 연산자</h4>
>   -   두 값이 <span style="color:blue">같은지</span>  ( == )  
>   -   두 값이 <span style="color:green">다른지</span>         ( != )  
>   -   두 값이 <span style="color:yellow">큰지, 작은지</span>  ( >, >=, <, <=)  
>   를 체크하는 연산자. 결과는 bool 형태  
{: .notice}


<div class="notice--primary" markdown="1"> 

```c# 
int num = 10;
bool isSame = num == 10;    //  true
bool isSame1 = num != 10;   //  false
int age = 23;
bool isAdult = age > 19;    //   true
bool isKid = age < 19;      //   false

```
-   결과는 bool 형태  

</div>


## &nbsp;&nbsp;&nbsp; 논리연산 정리표


![image](https://github.com/levell1/levell1.github.io/assets/96651722/a81146b4-9722-4faa-833e-5275e7ac1577){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice--info} 


<br><br><br><br><br><br>
- - - 

# 3. 비트연산자

![image](https://github.com/levell1/levell1.github.io/assets/96651722/839af753-ba0c-4e23-9854-68619c85dd6d){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br><br><br><br><br>
-   -   -

# 4. 연습문제

<div class="notice--primary" markdown="1"> 

```c# 
{
    // 1. 숫자의 사칙연산
    int ten = 10;
    
    int result = ten + 7;           // 7 더하기
    int result1 = ten - 3;          // 3 빼기
    int result2 = ten * 2;          // 2 곱하기
    float result3 = ten * 1.5f;     // 1.5 곱하기
    float result4 = ten / 3;        // 3 으로 나누기
    float result5 = ten % 4;        // 4 로 나눴을때 나머지

    Console.WriteLine(result);      //~5


    // 2. 문자의 계산
    string name = "김종욱"; 
    int year = 2023;

    string introduce = "안녕하세요. 제 이름은 "+ name +" 입니다"; // 안녕하세요. 제 이름은 "chad" 입니다.
    string thisYear = "올해는 " + year +"년 입니다."; // 올해는 '2023년' 입니다.

    Console.WriteLine(introduce);
    Console.WriteLine(thisYear);


    // 3. 논리 연산
    ten = 10;

    bool result_1 = ten == 10;    // ten 이 10 이랑 같다
    bool result_2 = ten != 11;    // ten 이 11 이랑 같지 않다
    bool result_3 = ten <  20;    // ten 이 20 보다 작다
    bool result_4 = ten >   5;    // ten 이 5 보다 크다
    
    Console.WriteLine(result_1);    // ~4

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
