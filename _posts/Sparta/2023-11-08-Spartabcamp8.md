---
title:  "[Sparta-BCamp] TIL 8 ( 숙제, 메서드, 구조체 ) ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-08 12:00

---
- - -
<BR><BR>

<center><H1> 개인 공부 C# 3일차   </H1></center>

- [x] 2주차 강의 남은 거 듣기,숙제
- [x] 어제 코드 컨벤션 정리하기.   
- [x] 14:00 학습법 강의.  
- [x] 3주차 듣고 숙제, 시간 남으면 개인과제  
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 2주차 과제

## 숫자 맞추기 게임

1~100까지 랜덤숫자중 하나를 맞추는게임  
코드는 강의내용 보고 작성  
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/f5b51239-7639-4aed-90df-52da93ac43b5){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## 숫자 맞추기 게임

1~100까지 랜덤숫자중 하나를 맞추는게임  
코드는 강의내용 보고 작성  
{: .notice}

<details>
<summary>코드보기</summary>

<!-- summary 아래 한칸 공백 두어야함 -->
접은 내용
</details>


<div class="notice--primary" markdown="1"> 

```c# 
// BSD
if(조건)
{
    처리로직
}

// K&R
if(조건){
    처리로직
}

// 추가 GNU 코딩 스타일   : 블록 표시하여 구조가 잘 보인다
//  수평으로 많은 코드를 작성할 수 없다.
if(조건)
    {
        처리로직
    }
```
</div>

<br><br>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/f5b51239-7639-4aed-90df-52da93ac43b5){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

<br><br><br><br><br><br>
- - - 

# 2. C# 강의 내용 정리
강의 3일차 내용 정리
{: .notice}

[⭐C# 메서드와 구조체⭐](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp6/)  
메서드, 매개변수, 반환값, 오버로딩, 재귀호출, 구조체 **`struct`**
{: .notice--info}

c# 인스턴스, class, static에 대하여 공부
{: .notice--info}



<br><br><br><br><br><br>
- - - 

# 3. 코드 컨벤션 강의
어제 코드 컨벤션강의 내용 정리.  
{: .notice}

## 코드 컨벤션

> **코드 컨벤션 스타일** 
>   -   BSD,K&R이 있다.  가장큰 차이는 중괄호{}의 위치.  
>   -   BSD스타일 : 줄간격이 한눈에 들어오지만 코드가 길어진다는 단점.
>   -   K&R스타일 : 블록을 조건에 한 줄로 같은 행에 배치 코드 줄 수 절약, 한눈에 많은 코드를 작성 할 수 있다.
>   -   유니티 C# 은 BSD 스타일로 사용한다.
{: .notice}

>   -   클래스명, 변수명, 함수 모두 의미있는 이름을 지어주어야 한다.
>   -   내 코드를 다른 사람이 쉽게 이해할 수 있도록.
>   -   오랜 시간 뒤에 내가 내 코드를 알아보기 위해서
>   -   가독성. 취직.
{: .notice--success}

<div class="notice--primary" markdown="1"> 

```c# 
// BSD
if(조건)
{
    처리로직
}

// K&R
if(조건){
    처리로직
}

// 추가 GNU 코딩 스타일   : 블록 표시하여 구조가 잘 보인다
//  수평으로 많은 코드를 작성할 수 없다.
if(조건)
    {
        처리로직
    }
```
</div>

<br><br>

## 표기법, 네이밍 규칙

> - PascalCase  : 모든 단어에서 첫 글자를 대문자로 쓰는 방식
> - camelCase&nbsp;   : 첫 단어를 제외하고 나머지 첫 글자를 대문자로 쓰는 방식
> - snake_case  : 단어가 합쳐진 부분마다 중간에 언더바(_)을 사용 
> - kebab-case  : 단어가 합쳐진 부분마다 중간에 하이픈(-)을 사용 
{: .notice}


> - 유니티에서는 PascalCase사용  
> - NameSpace, Class, Struct(구조체) = PascalCase
> - 함수 Enum = PascalCase
> - Public = PascalCase
{: .notice--info}

> - nonPublic (private,protected~~~) _camelCase -> 살짝 불편 안 쓰는 케이스가 있다.
> - 함수 내부에서는 camelCase
{: .notice--info}

> - 덩치가 크거나 Public -> Pascal Case
> - ⭐ 이름 정할 때 누가 봐도 알 수 있도록 ⭐
> - ⭐ 습관처럼 만들자 ⭐
{: .notice--success}

<br><br>

## 협업 꿀팁 
### 1)주석과 Summary
협업 시 다른 개발자분들이 한눈에 보기 쉽게 주석, Summary를 활용하자.  
Summary를 써보며 튜터님에게 질문하며 Class, Static, Public, 인스턴스화 등 추가로 공부하게 되었다.  
{: .notice}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/530aefef-f988-44c9-911a-dddd0e9f75d2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br>

### 2)한글이 깨지는 현상
인코딩방식 확인법  .sc 메모장으로 열어 우측하단 에서 확인  , 한글을 지원하는 인코딩방식 -> UTF-8 로 설정
![image](https://github.com/levell1/levell1.github.io/assets/96651722/485457a5-25d0-42b5-99db-3a2ee85a57fa){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice} 

**인코딩방식 변경법**  
1.&nbsp; 기존 파일 변경  
다른이름으로 저장 -> 인코딩하여 저장 utf-8로  
{: .notice--info}

2.&nbsp; 새 파일 생성 시  
editorconfig 파일을 이용, 프로젝트 내부에 .editorconfig 파일을 생성   
Visual Studio를 열고 도구 -> 옵션 -> 텍스트 편집기 -> C# -> 코드 스타일 -> 생성된 파일에 코드 추가   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a3f5e0e9-a9d1-4f1a-9407-3c670ab83521){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice--info}

<div class="notice--primary" markdown="1"> 

```c# 
// 생성된 파일에 코드 추가  
[*]
charset = utf-8
```
- 생성된 파일에 코드 추가  
</div>

<br><br>

## List에 대하여
C#에서 List는 메모리상 1열로 존재한다 배열에 가깝다.  
list는 동적으로 크기를 조정할 수 있는 배열  
요소를 추가하거나 삭제 시 새로운 배열 생성 후, 기존의 요소들을 복사하는 작업을 수행  
{: .notice}

내부적으로 배열의 크기를 늘리거나 줄이는 작업을 수행한다.
처음 요소 추가시 4증가  DefaultCapacity = 4;
![image](https://github.com/levell1/levell1.github.io/assets/96651722/48299140-834e-40c4-aed9-a1ad1b882975){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
Capacity가 Length보다 작으면 Capacity가 2배로 증가
![image](https://github.com/levell1/levell1.github.io/assets/96651722/66563e52-f26c-4931-bae1-4415fea7f68d){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
{: .notice--info}

2배로 증가 확인
<div class="notice--primary" markdown="1"> 

```c# 
    List<int> list = new List<int>();
    Console.WriteLine("Capacity : " + list.Capacity);
    list.AddRange(new int[4] { 1, 2, 3, 4 });
    Console.WriteLine("Capacity : " + list.Capacity);
    list.Add(1);
    Console.WriteLine("Capacity : " + list.Capacity);
    list.Add(1); list.Add(1); list.Add(1); list.Add(1);
    Console.WriteLine("Capacity : " + list.Capacity);
    Console.WriteLine("Count : "+list.Count);
```
- ![image](https://github.com/levell1/levell1.github.io/assets/96651722/57ee64bc-47d4-40e4-94d1-3661088dce58){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
</div>

<br><br><br><br><br><br>
- - - 

# 4. 정리, 잡담

> **코드컨벤션 강의 내용**
> - 어제 코드컨벤션 강의 내용
 정리 List, Capacity에 대하여 더 알게 되었다.
{: .notice}


<br><br>

**잡담**  
오늘 점심시간에 소소한 행복을 느꼈다. 30분 정도 였지만 기분이 좋았다.  
월, 화요일 조퇴를 하여 12시간 공부를 하지 못했다. 주말에 시간 보고 따로 공부를 해야 할 것 같다.  
내일은 2주차 강의 메서드와 구조체 강의 들으면서 정리할 계획이다. 
{: .notice--success}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/2eb7bf00-c498-4083-8251-2b208e30cffa){:style="border:1px solid #eaeaea; border-radius: 7px;"}   
👑금주Til 왕관👑  
오늘 zep에 접속했는데👑이 있었다.. 🙌  


<br><br>
- - - 

[Unity] TIL 7

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
