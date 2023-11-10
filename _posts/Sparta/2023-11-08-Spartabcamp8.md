---
title:  "[Sparta-BCamp] TIL 8 ( 틱택토, 메서드, 구조체 ) ⭐⭐⭐ "
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

- [x] 2주차 강의 남은 거 듣기,숙제( 숫자맞추기, 틱택톡 )  
- [x] 어제 코드 컨벤션 정리하기.   
- [x] 14:00 학습법 강의.  
- [x] 3주차 듣고 숙제, 시간 남으면 개인과제  
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. 2주차 과제

## 1)숫자 맞추기 게임

1~100까지 랜덤숫자중 하나를 맞추는게임  
코드는 강의내용 보고 작성  
{: .notice}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/f5b51239-7639-4aed-90df-52da93ac43b5){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br><br>

## 2)틱택토 게임

![2023-11-08-16_24_54](https://github.com/levell1/levell1.github.io/assets/96651722/5fdf310e-1baf-4752-9373-bc6d3e8beb44){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**틱택토게임**  
어제 들었던 컨벤션강의 내용, Summary도 사용하려 노력해 보았습니다.  
TicTacToc Class 에 2차 배열 map , DrawMap, DoOX 메서드
PlayGame(), CheckWin(), CheckPostion(int position) 
13X13 2차원배열 
{: .notice}

<details>
<summary>전체 코드 보기</summary>

<!-- summary 아래 한칸 공백 두어야함 -->
<div class="notice--primary" markdown="1"> 

```c# 
using System.Numerics;

namespace SecondWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            int position;       //1~9 위치
            int user = 2;       // player 1, 2
            int player = 50;    // 50 = O , 51 = X
            bool checkPosition = true;
            bool gameend = true;

            TicTacToc tic = new TicTacToc();    // 인스턴스화 
            tic.DrawMap();                      // 맵그리기   

            // player1 = 50  
            // player2 = 51  

            while (gameend)
            {
                PlayGame();
                CheckWin();
            }
            
            void PlayGame()     // 게임 플레이.
            {
                if (user == 1) { user = 2; } else if (user == 2) { user = 1; }
                if (user == 1) { player = 50; } else if (user == 2) { player = 51; }
                Console.Write("자리를 정해주세요.(1 ~ 9) \nPlayer" + user + " : ");
                position = int.Parse(Console.ReadLine());
                CheckPosition(position);
                tic.DoOX(position, player);
                Console.Clear();
                tic.DrawMap();
            }

            void CheckWin() {
                int[] playercheck = { 50, 51 };
                foreach (int ox in playercheck)
                {
                    if (((tic.map[2, 2] == ox) && (tic.map[2, 6] == ox)&&(tic.map[2, 10] == ox))
                       || ((tic.map[6, 2] == ox) && (tic.map[6, 6] == ox) && (tic.map[6, 10] == ox))
                       || ((tic.map[10, 2] == ox) && (tic.map[10, 6] == ox) && (tic.map[10, 10] == ox))
                       || ((tic.map[10, 2] == ox) && (tic.map[6, 2] == ox) && (tic.map[2, 2] == ox))
                       || ((tic.map[2, 6] == ox) && (tic.map[6, 6] == ox) && (tic.map[10, 6] == ox))
                       || ((tic.map[2, 10] == ox) && (tic.map[6, 10] == ox) && (tic.map[10, 10] == ox))
                       || ((tic.map[2, 2] == ox) && (tic.map[6, 6] == ox) && (tic.map[10, 10] == ox))
                       || ((tic.map[2, 10] == ox) && (tic.map[6, 6] == ox) && (tic.map[10, 2] == ox)))
                    {
                        if (user == 1)
                        {
                            Console.WriteLine("Player 1가 승리하였습니다!");
                            gameend = false;
                        }
                        else 
                        {
                            Console.WriteLine("Player 2가 승리하였습니다!");
                            gameend = false;
                        }
                        break;
                    }
                }
            }

            void CheckPosition(int position){
                if (0 < position && position > 10)
                {
                    Console.WriteLine("\n1~9 숫자를 입력해주세요\n");
                    if (user == 1) { user = 2; } else if (user == 2) { user = 1; }
                    PlayGame();
                }
                int[] playercheck = { 50, 51 };
                foreach (int ox in playercheck)
                {
                    if ((position == 1 && tic.map[2, 2] == ox)
                        || (position == 2 && tic.map[2, 6] == ox)
                        || (position == 3 && tic.map[2, 10] == ox)
                        || (position == 4 && tic.map[6, 2] == ox)
                        || (position == 5 && tic.map[6, 6] == ox)
                        || (position == 6 && tic.map[6, 10] == ox)
                        || (position == 7 && tic.map[10, 2] == ox)
                        || (position == 8 && tic.map[10, 6] == ox)
                        || (position == 9 && tic.map[10, 10] == ox))
                    {
                        Console.WriteLine("\n잘못된 자리입니다 다시 입력해 주세요\n");
                        if (user == 1) { user = 2; } else if (user == 2) { user = 1; }
                        PlayGame();
                    }
                }
            }
            Console.WriteLine("게임이 종료되었습니다.");
        }
    }

    /// <summary>
    /// 맵에 테두리, OX표시
    /// </summary>
    public class TicTacToc 
    {
        // 배치 자리
        // map[2, 2],  map[2, 6],  map[2, 10]
        // map[6, 2],  map[6, 6],  map[6, 10]
        // map[10, 2], map[10, 6], map[10, 10]

        // 1~9 배치 자리
        // 21~31 맵 테두리
        // 50,51 player, com 배치위치
        public int[,] map = new int[13, 13]
            {
                    { 22, 28, 28, 28, 23, 28, 28, 28, 23, 28, 28, 28, 24 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 21, 0, 1, 0, 21, 0, 2, 0, 21, 0, 3, 0, 21 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 25, 28, 28, 28, 26, 28, 28, 28, 26, 28, 28, 28, 27 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 21, 0, 4, 0, 21, 0, 5, 0, 21, 0, 6, 0, 21 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 25, 28, 28, 28, 26, 28, 28, 28, 26, 28, 28, 28, 27 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 21, 0, 7, 0, 21, 0, 8, 0, 21, 0, 9, 0, 21 },
                    { 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21 },
                    { 31, 28, 28, 28, 29, 28, 28, 28, 29, 28, 28, 28, 30 },
            };


        /// <summary>
        /// 맵 그리기 
        /// </summary>
        public void DrawMap()
        {
            for (int i = 0; i < 13; i++)
            {

                for (int j = 0; j < 13; j++)
                {
                    if (map[i, j] == 21)
                    {
                        Console.Write("│ ");
                    }
                    else if (map[i, j] == 22)
                    {
                        Console.Write("┌ ");
                    }
                    else if (map[i, j] == 23)
                    {
                        Console.Write("┬ ");
                    }
                    else if (map[i, j] == 24)
                    {
                        Console.Write("┐ ");
                    }
                    else if (map[i, j] == 25)
                    {
                        Console.Write("├ ");
                    }
                    else if (map[i, j] == 26)
                    {
                        Console.Write("┼ ");
                    }
                    else if (map[i, j] == 27)
                    {
                        Console.Write("┤ ");
                    }
                    else if (map[i, j] == 28)
                    {
                        Console.Write("─");
                    }
                    else if (map[i, j] == 29)
                    {
                        Console.Write("┴ ");
                    }
                    else if (map[i, j] == 30)
                    {
                        Console.Write("┘ ");
                    }
                    else if (map[i, j] == 31)
                    {
                        Console.Write("└ ");
                    }
                    else if (0 < map[i, j] && map[i, j] < 10)
                    {
                        Console.Write(map[i, j]);
                    }
                    else if (map[i, j] == 50)       //Player 1
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == 51)       //Player 2
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 자리에 OX 표시하기
        /// </summary>
        /// <param name="position"></param>
        /// <param name="player"></param>
        public void DoOX(int position,int player) 
        {

            // 배치 자리
            // map[2, 2],  map[2, 6],  map[2, 10]
            // map[6, 2],  map[6, 6],  map[6, 10]
            // map[10, 2], map[10, 6], map[10, 10]

            switch (position) 
            {
                case 1:
                    map[2, 2] = player;
                    break;
                case 2:
                    map[2, 6] = player;
                    break;
                case 3:
                    map[2, 10] = player;
                    break;
                case 4:
                    map[6, 2] = player;
                    break;
                case 5:
                    map[6, 6] = player;
                    break;
                case 6:
                    map[6, 10] = player;
                    break;
                case 7:
                    map[10, 2] = player;
                    break;
                case 8:
                    map[10, 6] = player;
                    break;
                case 9:
                    map[10, 10] = player;
                    break;
            }
        }
    }
}
```
</div>
</details>

**하고나서 느낀점**  
 많이 부족하다. 전체적인 코드, 클래스, 메서드, 변수 사용에 많이 미숙했고, 맵 크기를 좀 더 작게 했으면 좋았을까. 라는 후회를 조금 했었고, 또 1~9 의 배열의 위치가 1~9와 연관이 있는 무언가 였으면 하기 쉬웠겠다고 생각했다.
{: .notice}

DrawMap, DoOX, 코드가 너무 길어지는대 단축할 방법이 없을까 고민하고 만들고 나서 후회했다..   
13X13한 이유는 빈공간이 있으면 보기 좋을 거 같아서 했지만 잘못된 선택이었다.
{: .notice--warning}

**풀이를 보고나서**  
고쳐야 될, 하지 않아도 될 코드가 너무 많았다. 더 간단하게, 쉽게 할 수 있는 것들이었고,
Player 를 나타낼 때 % 쓰는것, 조건문들도 생각하면 더 간단하게 할 수 있었다.  
게임판을 배열을 안써도 됐고, Write로 해도 됐다. 1~9부분에 새로운 배열을 사용하였고 그렇게하면 유저가 입력한 값이랑 배열의 값이 같아져서 더 효율적이고 간단하게 코딩이 가능하다고 생각한다. 많은부분이 필요가 없다. 왜 배열을 쓸 생각을 못 한 걸까? 처음 굳이 맵을 배열로 한다는 생각부터 잘못된 게 아닐까? 배운 걸 사용하고 싶어서 사용했던 걸까? 생각을 못 했던 걸까?  
지금 공부법에 문제가 있다고 느꼈다. 다양한 코드를 보고 이해하고 사용하는 느낌으로 가면 좋을 거 같다.
{: .notice--success}


<br><br><br><br><br><br>
- - - 

# 2. C# 강의 내용 정리
3일차 내용 정리
2주차 들은 강의 정리 3주차 강의는 내일 TIL에
{: .notice}

[⭐C# 메서드와 구조체⭐](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp6/)  
 **`struct`**
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
### 1) 주석과 Summary
협업 시 다른 개발자분들이 한눈에 보기 쉽게 주석, Summary를 활용하자.  
Summary를 써보며 튜터님에게 질문하며 Class, Static, Public, 인스턴스화 등 추가로 공부하게 되었다.  
{: .notice}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/530aefef-f988-44c9-911a-dddd0e9f75d2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<br>

### 2) 한글이 깨지는 현상
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
> - 어제 코드컨벤션 강의 내용, 협업 꿀팁
> - 정리 List, Capacity에 대하여 더 알게 되었다.
{: .notice}


> **콘솔 커서 위치**  
> - Console.SetCursorPosition: 이 함수는 콘솔 창에서 커서의 위치를 설정합니다. 
> - 출력의 정확한 위치를 제어하고 싶을 때 사용됩니다.   
> - exConsole.SetCursorPosition(10, 5);
{: .notice}


> - 오버로딩 : 매개변수의 **개수, 타입, 순서가 다른** 동일한이름의 여러 메서드 
> - 구조체 : **`struct`** 키워드
{: .notice--info}

<br><br>

**잡담**  
오늘 1시쯤 컴터가 꺼졋다. 저장은 되어 있어서 다행이었다.  
2주차 공부 중 클래스, static이 궁금해서 튜터님에게 물어보러 갔다. 이해를 못 해서 죄송했다. 3강을 듣고 갔다면 더 좋았을 거 같았다. 그렇지만 2강 숙제를 안 한 상태라 3강을 못 들었고 3강에 클래스가 있는지도 보지 못했었다. 너무 아쉽다.  
{: .notice}

이번 틱택톡을 하고 풀이를 본 후 느낀 게 많다. 많이 부족할 걸 느꼈고, 어떻게 하면 더 코드를 잘 짤 수 있을까? 그냥 내 생각을 그대로 코드로 만들고 풀이를 보는 게 나에게 도움이 될까? 아니면 구글링해서 좋은 코드들을 보고 하는 게 좋지 않을까? 전자는 너무 시간 낭비가 아닐까? 방법이 잘못된 걸까? 완성했다고 끝이아닌 리팩터링 생각을 하자, 조건을 만들 때 좀 더 단축해서. 생각을 하자. 생각이 많은 날이었다. 
{: .notice}

공부한 지 오래돼서 조금씩 생각은 나지만 정확하게 모르는 상황이다. 지금 강의가 다 했던거고 머리에 들어오고 이해는 된다. 시간이 많으니 기본을 탄탄하게 다지는 시간이라 생각하고 천천히 자세하게 배우고싶다.
{: .notice}

항상 하나의 숙제, 프로젝트 등을 하고 나면 느끼는 거지만 지금 잘 하고 있는 건지,  어느 부분이 어떻게 수정되면 좋은지 궁금하고 답답하다.. 하나씩 할 때마다 얻어 가는 게 많지만, 놓치는 부분도 있을 거라 생각한다. 항상 아쉽지만 생각한 대로 나오면 기분이 좋으면서 다른 좋은 코드들을 보면 또 많이 부족하다고 느낀다.
{: .notice--success}

<br><br>
- - - 

[Unity] TIL 8

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
