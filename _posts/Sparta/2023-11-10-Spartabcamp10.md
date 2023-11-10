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

- [x] 블랙잭
- [x] 개인과제 or 4강
- [] 사이트 신청하기
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

**게임화면**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/83bf185e-5881-4c4f-8c02-16a337f6f5c0){:style="border:1px solid #eaeaea; border-radius: 7px;"}  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b031110a-65be-4202-82d7-d15722b9b489){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

**블랙잭**  
이번 과제는 처음에 생각대로 구현 해보다가 풀이를 보며 만들어져있는 클래스의 기능을 이해, deck, drawcard 등을 이용하여  Main과 Blackjack 부분 (게임 play) 작성  

**느낀점**
코드에 승리 조건 부분을 더 깔끔하게 하지 못해서 아쉽다. 더 쉽고 간단한 코드을 생각해 봐야겠다.
시간만 많다면 카드도 형태로 표시해 보고 싶고, 딜러, 플레이어 카드 추가로 뽑기. 딜러에게 제한두기 등 추가하면 좋을 거 같다고 생각했다.  
더 급한 과제가 있어서 다음에..
{: .notice}

<br><br><br><br><br><br>
- - - 

# 2. 개인과제(textGame)

# 3. 정리, 잡담

> **오전**
> - 블랙잭, 개인과제
{: .notice}

> **오후**
> - 
{: .notice}

> **정리**
> - 다른분이 slack에 올려주신 ConsoleTables 패키지를 사용해보았다. 감사합니다.
{: .notice}

<br><br>
- - - 

[Unity] TIL 10

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
