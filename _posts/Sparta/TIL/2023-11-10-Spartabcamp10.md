---
title:  "[Sparta-BCamp] TIL 10 (블랙잭, 개인과제(TextGame) ) ⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-10 20:00

---
- - -
<BR><BR>

<center><H1> 개인 공부 C# 5일차   </H1></center>

&nbsp;&nbsp; [o] 블랙잭  
&nbsp;&nbsp; [o] 개인과제(TextGame)  
&nbsp;&nbsp; [ ] 사이트 신청하기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


# 1. 블랙잭 🃞

블랙잭  
클래스 `card`,`Deck`,`Hand`,`Player`,`Dealer`,`Blackjack`
{: .notice}

<details>
<summary>전체 코드</summary>

<div class="notice--primary" markdown="1"> 

```c# 
namespace BlackJack1
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public Card(Suit s, Rank r)
        {
            Suit = s;
            Rank = r;
        }

        public int GetValue()
        {
            if ((int)Rank <= 10)
            {
                return (int)Rank;
            }
            else if ((int)Rank <= 13)
            {
                return 10;
            }
            else
            {
                return 11;
            }
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }


    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(s, r));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int j = rand.Next(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }


    public class Hand
    {
        public List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }
        
    public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetTotalValue()
        {
            int total = 0;
            int aceCount = 0;

            foreach (Card card in cards)
            {
                if (card.Rank == Rank.Ace)
                {
                    aceCount++;
                }
                total += card.GetValue();
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }
    }

    public class Player
    {
        public Hand Hand { get; private set; }

        public Player()
        {
            Hand = new Hand();
        }

        public Card DrawCardFromDeck(Deck deck)
        {
            Card drawnCard = deck.DrawCard();
            Hand.AddCard(drawnCard);
            return drawnCard;
        }
        public class Blackjack
        {
           
        }
    }

    public class Dealer : Player
    {
        
    }

    // 블랙잭 게임을 구현하세요. 
    public class Blackjack
    {
        public void PlayGame() {
            Player player = new Player();
            Player dealer = new Dealer();
            Blackjack blackjack = new Blackjack();
            Deck deck = new Deck();
            Hand phand = new Hand();
            Hand dhand = new Hand();
            phand = player.Hand;
            dhand = dealer.Hand;

            Console.WriteLine("블랙잭 시작합니다.");

            Card playerFirstCard = player.DrawCardFromDeck(deck);
            Console.WriteLine("Player First Card Draw");

            Console.ReadLine();

            Card dealerFirstCard = dealer.DrawCardFromDeck(deck);
            Console.WriteLine("Dealer First Card Draw");

            Console.ReadLine();

            Card playerSecondCard = player.DrawCardFromDeck(deck);
            Console.WriteLine("Player Second Card Draw");

            Console.ReadLine();

            Card dealerSecondCard = dealer.DrawCardFromDeck(deck);
            Console.WriteLine("Dealer Second Card Draw");

            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Dealer Cards");
            Console.ResetColor();
            Console.WriteLine(dealerFirstCard.ToString() + " , ???");
            int dTotal = dhand.GetTotalValue();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Player Cards");
            Console.ResetColor();
            Console.WriteLine(playerFirstCard.ToString() + "  ,  " + playerSecondCard.ToString() + "\n\n");
            int pTotal = phand.GetTotalValue();

            Console.WriteLine($"Dealer : " + dealerFirstCard.ToString() + "  ,  " + dealerSecondCard.ToString() + "\n합 : " + dTotal+"\n");
            Console.WriteLine($"Player : " + playerFirstCard.ToString() + "  ,  " + playerSecondCard.ToString() + "\n합 : " + pTotal);
            Console.ReadLine();

            blackjack.WinCheck(pTotal, dTotal);

            
        }
        public void WinCheck(int pTotal, int dTotal) {
            if (pTotal == 21)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"** Black Jack **\n Player의 승리입니다.\n");
                Console.ResetColor();
            }
            else if (dTotal == 21)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"** Black Jack **\n Dealer의 승리입니다.\n");
                Console.ResetColor();
                
            }
            else if (pTotal > 21 && dTotal > 21||pTotal==dTotal)
            {
                Console.WriteLine($"무승부");
            }
            else if (pTotal > 21)
            {
                Console.WriteLine($"Player의 카드가 21점이 넘었습니다.\nDealer의 승리입니다.\n");
            }
            else if (dTotal > 21)
            {
                Console.WriteLine($"Dealer의 카드가 21점이 넘었습니다.\nPlayer의 승리입니다.\n");
            }
            else if (pTotal > dTotal)
            {
                Console.WriteLine($"Player의 승리입니다.\n");
            }
            else if (dTotal > pTotal)
            {
                Console.WriteLine($"Dealer의 승리입니다.\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackjack = new Blackjack();
            blackjack.PlayGame();
            Console.ReadLine();
        }
    }
}
```
</div>

</details>

<br>

**게임화면**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/83bf185e-5881-4c4f-8c02-16a337f6f5c0){:style="border:1px solid #eaeaea; border-radius: 7px;"}   

![image](https://github.com/levell1/levell1.github.io/assets/96651722/b031110a-65be-4202-82d7-d15722b9b489){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**<u>블랙잭</u>**  
이번 과제는 처음에 생각대로 구현 해보다가 풀이를 보며 만들어져있는 클래스의 기능을 이해, deck, drawcard 등을 이용하여  Main과 Blackjack 부분 (게임 play) 작성  
{: .notice}

**느낀점**  
코드에 승리 조건 부분을 더 깔끔하게 하지 못해서 아쉽다. 더 쉽고 간단한 코드을 생각해 봐야겠다.
카드도 형태로 표시해 보고 싶고, 딜러, 플레이어 카드 추가로 뽑기. 딜러에게 제한두기 등 추가하면 좋을 거 같다고 생각했다.  더 급한 과제가 있어서 다음에..
{: .notice}

<br><br><br><br><br><br>
- - - 

# 2. 개인과제(TextGame)
11/10 
TextGame 캐릭터정보, 인벤토리, 장비착용 기능
{: .notice}
<details>
<summary>전체 코드</summary>

<div class="notice--primary" markdown="1"> 

```c# 
using ConsoleTables;
using System;
using System.Security.Claims;
using System.Xml.Linq;

namespace TextGame
{
    internal class Program
    {


        // 2 . 상점의 아이템 중에서 나만의 장비를 구성하는 부분이 포인트입니다.
        // 3 . 장비는 여러개의 데이터가 함께 있는 만큼 객체나 구조체를 활용하는 편이 효율적 입니다.
        // (이름, 가격, 효과, 설명 등…)
        // 4 . 관련된 여러 데이터를 다루는 부분은 배열이 도움이 됩니다.
        static void Main(string[] args)
        {

            ConsoleText _consoleText = new ConsoleText();

            String name;
            int _actionFirst = 0;
            int _actionIn = 0;
            bool _checkNum = true;
            bool _gamgeEnd = false;

            name = _consoleText.InputName();

            Character _player = new Character(name, "전사", 1, 10, 5, 100, 1500);
            _consoleText.StartTxt();
            // 배열부분 LIST로 변경할 생각.
            EquipmentA[] equipment = new EquipmentA[4];
            equipment[0] = new EquipmentA("무쇠갑옷", 0 ,100, 10,true);
            equipment[1] = new EquipmentA("쇠 투구", 0, 70, 7, false);
            equipment[2] = new EquipmentA("낡은 검", 2, 0, 0, true);
            equipment[3] = new EquipmentA("쇠 검", 13, 0, 0, false);
            Inventory inventory = new Inventory(equipment);
            while (_gamgeEnd == false)
            {
                _actionFirst = 0;
                _actionIn = 0;
                _checkNum = true;
                _consoleText.GoDungeonTxt();
                _actionFirst = _consoleText.SelectAction();
                switch (_actionFirst)
                {
                    case 1:
                        while (_checkNum)
                        {
                            _player.PlayerStat(equipment);
                            _actionIn = _consoleText.SelectAction();
                            if (_actionIn == 1)
                            {
                                _checkNum = false;
                            }
                        }
                        break;

                    case 2:
                        while (_checkNum)
                        {
                            inventory.InventoryTxt();
                            _actionIn = _consoleText.SelectAction();
                            if (_actionIn == 1)
                            {
                                while (_actionIn != 0)
                                {
                                    inventory.InventoryEquip(equipment);
                                    _actionIn = _consoleText.SelectAction();
                                    while (_actionIn > equipment.Length)
                                    {
                                        inventory.InventoryEquip(equipment);
                                        _actionIn = _consoleText.SelectAction();
                                        Console.WriteLine($" 다시 입력해주세요( 1 ~ {equipment.Length} )");
                                    }
                                    if (_actionIn != 0) {
                                        inventory.EquipCheck(equipment, _actionIn - 1);
                                    }
                                    
                                }
                                //장비관리
                            }
                            if (_actionIn == 2)
                            {
                                _checkNum = false;
                            }
                        }
                        break;

                    case 3:
                        _gamgeEnd = true;
                        break;
                    default:
                        Console.WriteLine("          다시 입력해주세요( 1 ~ 2 )");
                        break;
                }

            }
            Console.WriteLine("게임종료");
            Console.ReadLine();
        }


    }
    public class ConsoleText
    {

        public string Name { get; set; }
        public int ChooseAction { get; set; }
        public void StartTxt()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"       {Name}님 마을에 오신것을 환영합니다.       ");
            Console.WriteLine("==================================================\n\n\n");
        }
        public String InputName()
        {
            Console.Write("이름을 입력해 주세요\n이름 : ");
            Name = Console.ReadLine();
            Console.Clear();
            return Name;
        }
        public void GoDungeonTxt()
        {
           
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆");
            Console.WriteLine(" |      |          └┼┐ ");
            Console.WriteLine("|        |         ┌│  ");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("===============");
            Console.WriteLine("= 1. 상태보기 =");
            Console.WriteLine("= 2. 인벤토리 =");
            Console.WriteLine("===============");

        }

        public int SelectAction()
        {
            ChooseAction = int.Parse(Console.ReadLine()); // 숫자 아닐경우 예외처리 하면 좋을 거 같다.if대신 예외처리 배우면 활용
            Console.Clear();
            return ChooseAction;
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }
        public int Gold { get; set; }

        public Character(string name, string class1, int level, int atk, int def, int health, int gold) // 플레이어 초기값
        {
            Level = level;
            Name = name;
            Class = class1;
            ATK = atk;
            DEF = def;
            Health = health;
            Gold = gold;
        }

        public void PlayerStat(EquipmentA[] equip)
        {
            int[] eqiopStats = new int[7];
            String[] eqiopName = new String[7] { " (미착용) ", " (미착용) ", " (미착용) ", " (미착용) ", " (미착용) ", " (미착용)", "(미착용) "};
            for (int i = 0; i < equip.Length; i++)
            {
                
                if (equip[i].Isequip ==true)
                {
                    eqiopName[i] = equip[i].Name;
                    eqiopStats[0] += equip[i].ATK;
                    eqiopStats[1] += equip[i].DEF;
                    eqiopStats[2] += equip[i].Health;
                }
            }
            var table = new ConsoleTable($" ", $" {Name} ", $" {Class} ", "  ");
            table.AddRow(" 스텟 ", " 기본스텟 ", " 장비스텟 ", " 총스텟 ")
                 .AddRow($" 공격력 ", $"{ATK}" , $" ({eqiopStats[0]}) ", $" {ATK + eqiopStats[0]} ")
                 .AddRow($" 방어력 ", $"{DEF}", $" ({eqiopStats[1]}) ", $" {DEF + eqiopStats[1]} ")
                 .AddRow($" 체  력 ", $"{Health}", $" ({eqiopStats[2]}) ", $" {Health + eqiopStats[2]} ")
                 .AddRow($"", $" ", $" ", $" ")
                 .AddRow($" 장비 ", $" {eqiopName[0]} ", $" {eqiopName[1]} ", $" {eqiopName[2]} ")
                 .AddRow($" {eqiopName[3]} ", $" {eqiopName[4]} " , $" {eqiopName[5]} ", $" {eqiopName[6]} ")
                 .AddRow($"", $" ", $" ", $" ")
                 .AddRow($" 소지금 ", $" 골드(G) ", $" ", $" ")
                 .AddRow($"   ", $" {Gold} G ", "","");
            table.Write();
            Console.WriteLine("=============");
            Console.WriteLine("= 1. 나가기 =");
            Console.WriteLine("=============");
        }
    }
    public class Weapons
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public Weapons(string name, int aTK)
        {
            Name = name;
            ATK = aTK;
        }
    }



    public class EquipmentA
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int Health { get; set; }
        public int DEF { get; set; }

        public bool Isequip { get; set; }

        public EquipmentA(String name, int atk, int Hp, int Def,bool equip)
        {
            Name = name;
            ATK = atk;
            Health = Hp;
            DEF = Def;
            Isequip = equip;
        }
    }

    public class Inventory
    {

        public string[] Name = new string[4];
        public int[] Health = new int[4];
        public int[] DEF = new int[4];
        public int[] ATK = new int[4];

        public Inventory(EquipmentA[] equip) { 

            for (int i = 0; i < equip.Length; i++)
            {
                Name[i] = equip[i].Name;
                ATK[i] = equip[i].ATK;
                Health[i] = equip[i].Health;
                DEF[i] = equip[i].DEF;
            }
        }
        public void InventoryTxt()
        {
            var table = new ConsoleTable(" 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < Name.Length; i++)
            {
                table.AddRow($"{Name[i]}", $"{ATK[i]}", $"{Health[i]}", $"{DEF[i]}");
            }
            table.Write();

            Console.WriteLine("===============");
            Console.WriteLine("= 1. 장착관리 =");
            Console.WriteLine("= 2. 나가기   =");
            Console.WriteLine("===============");
        }
        public void InventoryEquip(EquipmentA[] equip)
        {
            string checkE = "";
            var table = new ConsoleTable(" 장비번호 ", " 이름 ", " 공격력 ", " 체력 ", " 방어력 ");
            for (int i = 0; i < Name.Length; i++)
            {
                string Ename = equip[i].Name;
                checkE = Ename.Substring(Ename.Length-2);
                if (equip[i].Isequip == true && checkE != "E")
                {
                    Ename = Ename + " [E]";
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (equip[i].Isequip == false && checkE == "E") 
                {
                    Ename = Ename.Substring(0, Ename.Length - 4);
                }
                table.AddRow($" {i+1} ",$" {Ename} ", $"{equip[i].ATK}", $"{equip[i].Health}", $"{equip[i].DEF}");
                Console.ResetColor();
            }
            table.Write();

            Console.WriteLine("==========================");
            Console.WriteLine("=       0. 돌아가기      =");
            Console.WriteLine($"=  장비번호 입력시 장착  =");
            Console.WriteLine("==========================");


        }
        public void EquipCheck(EquipmentA[] equip, int num)
        {
            equip[num].Isequip = !equip[num].Isequip;
        }
    }
}
```
</div>

</details>

<br>

**게임화면**  

**스탯창**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1c657282-c6bb-4721-8b0e-ebc49fd46cd2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**장비창 ( 장착 )**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f52168d5-9b27-4219-a2be-2f7fc2f219b1){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**느낀점**  
과제 개요, 요구사항을 보고 나의 생각을 코드로 적었다. 어려웠지만 잘 진행되었던거 같다.  
만들면서 클래스 이름, 이 메서드는 어떤 클래스에 배치되어야 될까, 만약 메서드를 옮긴다면 사용된 변수들은 어떻게 그곳에서 사용하는지 또 main에서 게임진행 while, if 조건은 어떻게 더 간단하고 보기쉽게 만들 수 있을까 에 대한 고민을 많이 했다. 다음 주는 선택 요구사항 기능들을 추가할 예정이다.
{: .notice}

<br><br><br><br><br><br>
- - - 

# 3. 정리, 잡담

> **정리**
> - 다른분이 slack에 올려주신 ConsoleTables 패키지를 사용해보았다. 감사합니다.  
> - 클래스도 배열로 사용 가능, 다음주는 4주차 강의듣고 강의내용, 상속등을 더 활용해야겠다.
> - TextGame 아이템 중복착용부분 생각, 배열-> 리스트로 변경 할 생각
{: .notice}

> **클래스 구조체 차이**  
> **구조체**
> - 함수안에서 1로 변경을 해도 외부 Main에서 값이 변경되지 않는다.  복사된 데이터는 원본 데이터가 아니기 때문에 복사된 값을 수정하면, 스택에 복사된 값을 변경하게 되는것이다.  (복사본에 입력된 값들은 함수가 끝나면 사라짐)  
{: .notice--info}
> **클래스** 
> - 클래스는 참조타입으로 힙의 주소를 전달하기 때문에 값이 아닌 같은 주소가 참조된다.
그래서 Main으로 출력했을 때, 값이 변경되지 않고 원본값을 출력한다.(변경된 데이터들은 함수가 종료되어도 남아있음)  
{: .notice--info}

> **비쥬얼 스튜디오 단축키**  
> - ctrl m+l  접기
> - ctrl m+o 펼치기
> - ctrl . -> 그 이름의 메서드 생성
{: .notice--info}

<br><br>
- - - 

[Unity] TIL 10

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
