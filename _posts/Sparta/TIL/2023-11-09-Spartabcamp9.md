---
title:  "[Sparta-BCamp] TIL 9 (뱀, 객체지향, 제너릭, ref out ) ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta]

toc: true
toc_sticky: true
 
date: 2023-11-09 09:00

---
- - -
<BR><BR>

<center><H1> 개인 공부 C# 4일차   </H1></center>

- [x] 3주차 강의 정리
- [x] 3주차 숙제 하기(뱀)
- [x] 2시, 7시 발표, 특강
- [] 사이트 신청하기
{: .notice}

<br><br><br><br><br><br>
- - - 

# 1. C# 강의 내용 정리
4일차 내용 정리  
3주차강의
{: .notice}


[C# 객체 지향 (클래스와 객체) ](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp7/)  
객체지향, 클래스, 프로퍼티 **`Public`** **`Private`** **`Protected`**  
[C# 객체 지향 (상속과 다형성)](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp8/)  
상속, 가상메서드, 추상 클래스와 메서드, 오버라이딩 오버로딩 의미 확인  
[C# 문법 제너릭, out, ref](https://levell1.github.io/sparta%20c%20sharp/SpartaCsharp9/)   
매개변수, 반환값
{: .notice--info}



<br><br><br><br><br><br>
- - - 


# 2. 뱀🐍

1.&nbsp; 뱀은 매 턴마다 자신의 앞으로 이동합니다.  
2.&nbsp; 사용자는 방향키를 이용하여 뱀의 이동 방향을 제어할 수 있습니다.  
3.&nbsp; 뱀은 맵에 무작위로 생성되는 음식을 먹을 수 있습니다. 뱀이 음식을 먹으면 점수가 올라가고, 뱀의 길이가 늘어납니다.  
4.&nbsp;뱀이 벽이나 자신의 몸에 부딪히면 게임이 끝나고 'Game Over' 메시지를 출력합니다.   
{: .notice}

<details>
<summary>전체 코드</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using System;
using System.Drawing;

namespace Snake
{
    class Snack
    {
        const int map_X = 30;
        const int map_Y = 20;

        char bodyS = '+';
        char foodS = '=';

        Random rand = new Random();
        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            int score = 0;
            _drawMap();

            // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
            Point p = new Point(7, 7, '+');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // 음식의 위치를 무작위로 생성하고, 그립니다.
            FoodCreator foodCreator = new FoodCreator(map_X, map_Y, '=');
            Point food = foodCreator.CreateFood(map_X, map_Y);
            food.Draw();

            // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
            while (true)
            {
                // 키 입력이 있는 경우에만 방향을 변경합니다.
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo;
                    keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.UP;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.DOWN;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.RIGHT;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.LEFT;
                            break;
                    }
                    food.Draw();
                }
                // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
                if (snake.Eat(food))
                {
                    score++;
                    food.Draw();
                    food = foodCreator.CreateFood(map_X, map_Y);

                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.

                if (snake.IsHitTail() || snake.IsHitWall())
                {
                    break;
                }

                Thread.Sleep(100); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)

                Console.SetCursorPosition(0, 23);
                Console.WriteLine($"먹이 : {score}");
                Console.WriteLine($"길이 : {score+4}");
            }
            Console.Clear();

            Console.SetCursorPosition(27, 4);
            Console.WriteLine($"게임오버");
            Console.SetCursorPosition(26, 5);
            Console.WriteLine($"점수 : {score}점 ");
            Console.ReadLine();


            void _drawMap()
            {
                for (int i = 1; i < (map_X + 2); i++)
                {
                    Console.SetCursorPosition(i, 1);
                    Console.Write("*");
                }
                for (int i = 1; i < (map_X + 2); i++)
                {
                    Console.SetCursorPosition(i, map_Y + 2);
                    Console.Write("*");
                }
                for (int i = 1; i < (map_Y + 2); i++)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write("*");
                }
                for (int i = 1; i < (map_Y + 2); i++)
                {
                    Console.SetCursorPosition(map_X + 2, i);
                    Console.Write("*");
                }
            }

        }

        class Snake
        {
            char bodyS = '+';
            public List<Point> Body = new List<Point>();
            public Direction Direction;
            // 뱀의 상태와 이동, 음식 먹기, 자신의 몸에 부딪혔는지 

            public Snake(Point p, int count, Direction d)
            {
                Direction = d;
                for (int i = 0; i < count; i++)
                {
                    Point point = new Point(p.x, p.y, bodyS);
                    Body.Add(point);
                    p.x += 1;
                }
            }
            public void Move()
            {
                Point tail = Body.First();
                Body.Remove(tail);
                Point head = NextMove();
                Body.Add(head);

                tail.Clear();   
                head.Draw();
            }
            public Point NextMove()
            {
                Point head = Body.Last();
                Point nextPoint = new Point (head.x, head.y,head.sym);
                switch (Direction)
                {
                    case Direction.LEFT:
                        nextPoint.x -= 1;
                        break;
                    case Direction.RIGHT:
                        nextPoint.x += 1;
                        break;
                    case Direction.UP:
                        nextPoint.y -= 1;
                        break;
                    case Direction.DOWN:
                        nextPoint.y += 1;
                        break;
                }
                return nextPoint;
            }
            public bool IsHitTail()
            {
                var head = Body.Last();
                for (int i = 0; i < Body.Count - 2; i++)
                {
                    if (head.IsHit(Body[i]))
                        return true;
                }
                return false;
            }

            public bool IsHitWall()
            {
                var head = Body.Last();
                if (head.x <= 1 || head.x >= 31 || head.y <= 1 || head.y >= 21)
                    return true;
                return false;
            }

            public void Draw()
            {
                foreach (Point p in Body)
                {
                    p.Draw();
                }
            }

            public bool Eat(Point food)
            {
                Point head = NextMove();
                if (head.IsHit(food))
                {
                    food.sym = head.sym;
                    Body.Add(food);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class FoodCreator
        {
            int Max_X;
            int Max_Y;
            char foodS = '=';
            public FoodCreator(int a, int b, char c)
            {
                this.Max_X = a;
                this.Max_Y = b;
                this.foodS = c;
            }
            public Point CreateFood(int Max_X, int Max_Y)
            {
                
                Random rand = new Random();
                int x = rand.Next(2, Max_X-2);
                int y = rand.Next(2, Max_Y-2);
                Point point = new Point(x, y, foodS);

                return point;
            }

            public void Draw(Point p)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                p.Draw();
                Console.ResetColor();
            }

        }

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public char sym { get; set; }

            // Point 클래스 생성자
            public Point(int _x, int _y, char _sym)
            {
                x = _x;
                y = _y;
                sym = _sym;
            }

            // 점을 그리는 메서드
            public void Draw()
            {
                Console.SetCursorPosition(x, y);
                Console.Write(sym);
            }

            // 점을 지우는 메서드
            public void Clear()
            {
                sym = ' ';
                Draw();
            }

            // 두 점이 같은지 비교하는 메서드
            public bool IsHit(Point p)
            {
                return p.x == x && p.y == y;
            }
        }
        // 방향을 표현하는 열거형입니다.
        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }
    }
}
```
</div>

</details>

**게임화면**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/cd13cb8b-9c1c-47a5-a126-864444aced6b){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**종료화면**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/fa15444a-b91f-4ca3-a8d9-b5e0c42eaa93){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**느낀점**  
이번 과제는 생각대로 구현 해보고, 풀이를 보며 코드의 부분을 공부하고 이해 후 사용하는 방식으로 하였다.  
뱀의 몸에서 food가 나타날 경우 푸드위치에 몸이 겹쳐 빈칸으로 나오는 버그가 있다.  
기능을 추가하지 못하고 넘어갔다. 다른 중요한 과제를 먼저 할 생각이다.
{: .notice}
<br><br><br><br><br><br>
- - - 

# 3. 정리, 잡담

> **오전**
> - 어제 3강 듣고 정리 못한 부분 정리
{: .notice}

> **오후**
> - 뱀게임, 특강, 발표듣기 
{: .notice}

> - 제너릭 써보기  
> - ref, out 많이 써보기  
{: .notice}


<br><br>
- - - 

[Unity] TIL 9

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
