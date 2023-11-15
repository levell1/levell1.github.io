---
title:  "[Sparta-BCamp] TIL 13 (Simple Text Rpg) ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-15 02:00

---
- - -


<BR><BR>

<center><H1> 개인 공부 C# 8일차   </H1></center>

&nbsp;&nbsp; [o] 4주차 강의 복습, 정리   
&nbsp;&nbsp; [ ] 4주차 과제 .  
&nbsp;&nbsp; [ ] 2시 발제 듣고 정하기 .  
&nbsp;&nbsp; [ ] 5주차 강의듣기(알고리즘) .  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. C# 강의 내용 정리
7일차 내용 정리  
4주차강의

[C# 델리게이트(Delegate), 람다(Lambda), Func,Action, LINQ](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp12/)  
델리게이트(**`Delegate`**), 람다(**`Lambda`**), **`Func`**, **`Action`**, **`LINQ`**   
{: .notice--info}

[C# Nullable, 문자열 빌더(StringBuilder)](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp13/)  
 **`Nullable`**, 문자열 빌더(**`StringBuilder`**) 
{: .notice--info}

<br><br><br><br><br><br>
- - - 


# 2. 개인과제(TextGame) 피드백, 개선
[깃허브 Readme](https://github.com/levell1/Practice_Csharp/blob/main/README.md)

## 피드백
<details>
<summary>피드백 내용</summary>
<div class="notice--primary" markdown="1"> 

```
필수기능과 추가기능에 대한 요청사항을 잘 이해하고 적절히 구현하였습니다.  
기능을 최대한 스스로 해결하려 한 모습이 느껴져서 좋습니다. 또한 기능개발에 따른 자료구조에 대한 고민까지 나아간 점이 좋습니다.  
Class에 필요한 정보(Data)와 기능(Function)을 적절하게 사용하셨습니다.  
코드에 필요한 클래스를 잘 생성하였지만 별도의 파일로 만들고 분리해보시길 추천드립니다.  
Items 클래스의 경우 상속을 이용해 부모-자식 클래스 관계로 재설계 해보세요. 해당 내용은 개인과제 설명의 예시 코드를 참고해보세요.  
swith문은 Enum을 활용해서 작성하면 가독성 측면에서 더 나은 코드가 됩니다.  
깃 커밋의 내용을 직관적이고 명확하게 적는 연습을 해보세요. Git commit message 규칙 이라는 키워드를 통해 학습하고 적용시켜보세요.  
ex)  
[ADD] 인벤토리 기능 추가  
[FIX] 정보출력 기능 버그 수정  
Readme 작성은 해당 프로젝트를 전반적으로 파악하기 양호하게 잘 작성하셨습니다.  
```
</div>

</details>

<br>

**개선점, 느낀점**  

> **개선점**  
&nbsp;&nbsp; [o] **1.&nbsp;Class 파일 나누기**  
&nbsp;&nbsp; [o] **2.&nbsp;EquipMent 경우 상속 재설계**  
&nbsp;&nbsp; [o] **3.&nbsp;깃 커밋 설명 잘 적기**  
&nbsp;&nbsp; [o] **4.&nbsp;switch enum 사용하기**   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice}

> **개선**  
**1.&nbsp;Class 파일 나누기** ( 팀장님이 알려주셨다. 🙇 )   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/683eb753-04e1-435c-8aa1-06579ba12052){:style="border:1px solid #EAEAEA; border-radius: 7px;"} &nbsp;&nbsp;
![image](https://github.com/levell1/levell1.github.io/assets/96651722/db76d506-d5fe-4fe5-9240-4cde375f62d6){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice--info}

**2.&nbsp;EquipMent 경우 상속 재설계**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/a92c4bfd-23db-46fe-841f-48db4d8f3cda){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice--info}

**3.&nbsp;깃 커밋 설명 잘 적기**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/0668936c-cbfb-4554-bed3-3cd5cfd8f1f9){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice--info}

**4.&nbsp;switch enum 사용하기**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/39da54db-0cf6-4d83-bfbf-ca9cc827a6f5){:style="border:1px solid #EAEAEA; border-radius: 7px;"} &nbsp;&nbsp;
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9cfb272a-78c5-41dc-ab32-da4ef4cba574){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/83038e83-14c9-4c7b-be49-abbf46343c25){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice--info}

<br>

> **느낀점**  
**<u>파일을 나누니까</u>** 개발 도중 원하는 내용을 보고 싶을 때 기존 방식에 비해 너무 편하고 쉬웠습니다.  
(저희조 팀장님이 이해하기 쉽게 설명해 주셨습니다. 감사합니다.🙇)  
**<u>상속</u>**의 경우 코드 기획? 설계부분이 미숙해 아직 완벽하게 이해하지 못하고 사용해 보았습니다, 많이 사용해 보며 확실하게 알 수 있게 하는 게 목표입니다.  
**<u>깃 커밋</u>** 설명을 적고 협업 시 원활한 소통이 가능할 거 같다고 느꼈습니다.  
**<u>switch enum 사용</u>** 후 가독성이 좋아진 거 같다, case 1~4보단 무슨 기능을 하는지 보기 좋았다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice--info}

과제에 대한 피드백을 받고 잘 하고있는지, 부족한부분, 수정하면 좋은부분을 알게되어 좋았습니다.  [README](https://github.com/levell1/Practice_Csharp#readme)  
튜터님 감사합니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{: .notice--success}

<br><br><br><br><br><br>
- - - 

# 3. 정리, 잡담

> **정리**  
델리게이트(**`Delegate`**), 람다(**`Lambda`**), **`Func`**, **`Action`**, **`LINQ`**, 
 **`Nullable`**, 문자열 빌더(**`StringBuilder`**)  
델리게이트 개념 복습, 설명이 가능할 정도로 개념 확인.  
람다, func, Action, LINQ 많이 사용해보기 LINQ  
4주차강의 복습
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

> **잡담**  
처음으로 개인적인 과제에 대한 피드백을 받았다. 잘 하고 있는지, 부족한 게 뭔지, 많은 부분에서 무언가 해소된 느낌이 들었다.  🙇
아직 4주차 강의 내용을 완벽하게 이해하지 못했다. 조금 더 하고 배운 내용들을 생각하며 4주차 과제를 진행해 볼 생각이다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>

체크리스트 강의 1-3주차  
[o] C#에서 사용되는 기본 자료형에 대해 이해합니다.  
[o] 변수를 선언하고 초기화하는 방법을 이해합니다.  
[o] 산술, 관계, 논리 연산자의 사용법을 이해합니다.  
[o] 문자열 처리 기능과 문자열 메서드의 사용법을 이해합니다.  
[o] C#에서 클래스와 객체를 이해하고 사용하는 방법을 활용할 수 있습니다.  
[o] 생성자와 소멸자, 접근 제한자, Properties 등 클래스의 주요 요소를 이해합니다.  
[o] C#에서 상속과 다형성의 개념을 이해하고 활용할 수 있습니다.  
[o] 추상 클래스의 개념과 사용법을 이해하고 활용할 수 있습니다.  
[△] C#의 제너릭과 out, ref 키워드의 개념을 이해하고 활용할 수 있습니다.  
제너릭 out, ref 확실하게 이해하기. 
{: .notice--success}  

> - 제너릭 : 기능중 다양한 형이 들어갈 경우.  
> - return을 쓰면 되지않나? -> return대신 ref out을 쓰는 이유  
> - return은 1개의 값만 반환가능  
> - ref out은 여러개 값을 상황에 따라 반환가능
> - return대신 ref out 많이 써보기  
{: .notice}  
<details>
<summary>out, ref 연습</summary>
<div class="notice--primary" markdown="1"> 

```c#
    void swap(ref int a, ref int b)
    {
        int mid;
        mid = a;
        a = b;
        b = mid;
    }
    void add(int a , int b , out int c) {
        c = a + b;
    }
    int num1 = 10;
    int num2 = 20;
    int num3;
    swap(ref num1, ref num2);
    Console.WriteLine(num1 + " " + num2);
    add(num1, num2, out num3);
    Console.WriteLine(num1 + " " + num2 + " " + num3);
```
</div>

</details>

<br><br>
- - - 

[Unity] TIL 12

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
