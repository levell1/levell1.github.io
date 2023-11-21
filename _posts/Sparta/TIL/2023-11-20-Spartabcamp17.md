---
title:  "[Sparta-BCamp] TIL 17 팀 과제진행, 알고리즘 문제 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-21 02:00

---
- - -

<BR><BR>

<center><H1> 팀과제 5일차   </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제  
&nbsp;&nbsp; [O] (주) 팀 과제   
&nbsp;&nbsp; [X] 5주차 강의듣기(알고리즘).   
&nbsp;&nbsp; [X] 7시 강의 못들은거 내일 정리.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  


<br><br><br><br><br><br>
- - - 

# 1. 알고리즘 문제풀이
문제 17  
{: .notice--info}

<br><br><br><br><br>
- - - 

# 2. 팀 과제 
팀과제 던전코드 작업  
중간 정리, UI 수정 필요, 포션기능 필요, 하면서 발견하는 거 수정  
{: .notice--info}

## **Dungeon**   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b930771f-3531-4900-89fa-bfda284ca028){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


### **던전 입장 전 준비**

![image](https://github.com/levell1/levell1.github.io/assets/96651722/738afc29-8fd6-4f58-abb0-f73a4ea6f3a8){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

> - 1 -> 난이도 선택창으로  
> - 2 -> 물약사용(미구현)  
> - 0 -> 나가기(메인으로)  
 {: .notice--info}

### **1 - > 난이도 선택창**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2c87c824-294e-41bb-ab29-d99988ed9314){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br>

## **던전입장, 전투**
전투 ( 공격 할 몹 선택 -> 사용 할 스킬 선택)  
플레이어 턴 -> 몬스터 턴 반복  
방어력 높으면 데미지 1,  치명타 적용   
스킬 마나 없으면 평타로 공격.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
 {: .notice--info}
![2023-11-21-20_38_36](https://github.com/levell1/levell1.github.io/assets/96651722/68e80b02-fb9a-44b9-83aa-4bf65887d642)

### 승리
승리 시 골드,EXP 보상획득, 레벨업 계산, 정보표시   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
 {: .notice--info}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/36a83565-5133-46f2-bb54-b9479b9de151){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

### 패배
패배 시 메인으로,  
패배 후 던전 입장 불가,  
휴식 후 입장 가능.   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
 {: .notice--info}
![2023-11-21-20_27_12](https://github.com/levell1/levell1.github.io/assets/96651722/6e5633bb-4847-49f7-a2de-c5f93ab73830){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

<br><br><br><br><br>
- - - 


# 3. Dungeon 관련 코드

## DungeonMain.cs
던전 입장, 난이도 선택  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
 {: .notice--info}
<details>
<summary>DungeonMain.cs</summary>
<div class="notice--primary" markdown="1"> 

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeamProject07.Characters;
using TeamProject07.Controller;
using TeamProject07.Logic;
using TeamProject07.Shop;
using TeamProject07.Utils;
using static TeamProject07.Utils.Define;
using TeamProject07.Skills;
using System.Threading;

namespace TeamProject07.Dungeon
{
    internal class DungeonMain
    {
        Define.MainGamePhase choicePhase = Define.MainGamePhase.temp;

        DungeonEntrance Dungeon = new DungeonEntrance();
        enum DungeonEntranceSelect
        {
            exit = 0,
            EnterDungeon,
            UseItem = 2,
        }


        public Define.MainGamePhase Entrance(Player player)
        {
            Dungeon.LoadMonsters();
            if (player.IsDead==true)
            {
                Console.Clear();
                Console.WriteLine("\n\t휴식 후 다시오세요");
                Thread.Sleep(700);
                choicePhase = Define.MainGamePhase.Main;
                return choicePhase;
            }
            DungeonEntranceView();
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
                
            int input = CheckValidInput(0, 2);
            
            switch (input)
            {
                case 0:
                    Dungeon.Run();
                    Thread.Sleep(700);
                    choicePhase = Define.MainGamePhase.Main;
                    break;
                case 1:
                    Console.Clear();
                    choicePhase = Define.MainGamePhase.temp;
                    choicePhase = DungeonDifSelect(player);
                    if (choicePhase == Define.MainGamePhase.Main)
                    {
                        break;
                    }
                    Console.WriteLine();
                    Dungeon.PlayerPhase(player);
                    Console.WriteLine();
                    //Thread.Sleep(1000);  
                    break;

                case 2:
                    //포션사용
                    choicePhase = Define.MainGamePhase.Main;
                    break;
            }
            
            return choicePhase;
        }

        public Define.MainGamePhase DungeonDifSelect(Player player)
        {
            DungeonSelectView();
            Console.WriteLine();
            Console.WriteLine("입장할 던전을 선택하세요.");
            
            int input = CheckValidInput(0, 4);
            Console.Clear();
            switch (input)
            {
                case 0:
                    choicePhase = Define.MainGamePhase.Main;
                    Dungeon.Run();
                    Thread.Sleep(700);
                    Console.Clear();
                    break;
                case 1:
                    Dungeon.StartDungeon(input);
                    break;
                case 2:
                    Dungeon.StartDungeon(input);
                    break;
                case 3:
                    Dungeon.StartDungeon(input);
                    break;
                case 4:
                    Dungeon.StartDungeon(input);
                    break;
            }
            return choicePhase;
        }

        private void UseItem(Player player)
        {
            Console.WriteLine("인벤토리 출력");
            Console.WriteLine("사용할 아이템 선택");
            Console.WriteLine("아이템 효과 보여주기??");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 0:
                    break;

            }
        }

        private int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        private void DungeonEntranceView()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆ ;");
            Console.WriteLine(" |      |          └┼┐ == ");
            Console.WriteLine("|        |         ┌│  ==");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("==================");
            Console.WriteLine("= 1. 던전 입장   =");
            Console.WriteLine("= 2. 소모품 사용 =");
            Console.WriteLine("= 0. 나가기      =");
            Console.WriteLine("==================");
        }

        

        private void DungeonSelectView()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆ ;");
            Console.WriteLine(" |      |          └┼┐ == ");
            Console.WriteLine("|        |         ┌│  ==");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("======================");
            Console.WriteLine("= 1. 던전 1 (하)     =");
            Console.WriteLine("= 2. 던전 2 (중)     =");
            Console.WriteLine("= 3. 던전 3 (상)     =");
            Console.WriteLine("= 4. 보스방 (드래곤) =");
            Console.WriteLine("= 0. 나가기          =");
            Console.WriteLine("=======================");
        }
    }
}

```
</div>
</details>

<br><br>

## Dungeon.cs
**주요 코드**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/813974cd-04d5-416f-8699-0ee6652e61f4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - LoadMonsters : CSV 파일의 몬스터 정보 Dictionary로 저장하기
> - StartDungeon : 던전 시작 시 몬스터수 랜덤, 랜덤몬스터 List에 저장
> - PlayerPhase  : 플레이어 턴 
> - monsterPhase : 몬스터 턴
> - StageMonsterView : 위험 몬스터 등장 시 효과
> - viewMonster : Stage MonsterView 에 사용될 출력부분
> - WinBoard : 승리 시 보상, 화면 출력
> - LevelUp : 승리 후 경험치 계산, 능력치 UP
{:style="border:1px solid #000000; border-radius: 7px;"}
{: .notice--info}  



**TEXT**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/6b278753-9219-4fce-a606-0667e6463580){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  


> - Text, View :  Run, DungeonEntrance View  
> - RedText : 빨간글씨(WriteLine), RedTextNo : 빨간글씨(Write)   
> - BlueText : 파란글씨(WriteLine), BlueTextNo : 파란글씨(Write)   
> - 다쓰고나서 메서드를 만들어 사용 할 생각이 나서 너무 아쉬웠다.    
{:style="border:1px solid #000000; border-radius: 7px;"}
{: .notice--info}  

<details>
<summary>Dungeon.cs</summary>
<div class="notice--primary" markdown="1"> 

```c#

using TeamProject07.Characters;
using static TeamProject07.Utils.Define;
namespace TeamProject07.Controller
{
    enum DungeonEntranceSelect
    {

        exit = 0,
        EnterDungeon,
        UseItem = 2,
    }
    
    internal class DungeonEntrance
    {
        
       
        public List<Monster> CreateMonsters { get; set; }
        public Dictionary<int, Monster> monsterData;
        int MonsterNumber;

        public void LoadMonsters()
        {

            string path = MonsterPath;
            monsterData = new Dictionary<int, Monster>();
            monsterData.Clear();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] data = line.Split(',');

                        Monster monster = new Monster(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9]);
                        monsterData.Add(monster.Id, monster);

                    }
                }
            }
        }
        public void StartDungeon(int stage)
        {

            int monsternum = 101;
            if (stage == 2) { monsternum = 201; }            //난이도
            else if (stage == 3) { monsternum = 301; }
            else if (stage == 4) { monsternum = 400; }

            CreateMonsters = new List<Monster>();
            CreateMonsters.Clear();
            Random rand = new Random();
            MonsterNumber = rand.Next(3, 5);    // 3마리~4마리
            int MonsterType;
            Monster m;
            for (int i = 0; i < MonsterNumber; i++)
            {
                if (monsternum == 400)
                {
                    MonsterType = 400;
                    MonsterNumber = 1;
                    Monster monsterinfo = monsterData[MonsterType];
                     m = new Monster(monsterinfo);
                } else { 
                MonsterType = rand.Next(monsternum, monsternum + 3);   //몬스터 데이터 보고 조정   
                Monster monsterinfo = monsterData[MonsterType];

                m = new Monster(monsterinfo);
                }

                CreateMonsters.Add(m);
                //Console.WriteLine($"LV.{monsterinfo.Level} \t {monsterinfo.Name} \t HP : {monsterinfo.Hp} \t ATK : {monsterinfo.Attack},");
            }
        }
        public void PlayerPhase(Player player)
        {
            Console.Clear();
            
            StageMonsterView();
            Console.WriteLine("\n\t전투가 시작됩니다!!");

            int killMonsterNum = 0;
            while (!player.IsDead)
            {
                Console.WriteLine($"\n\t   {player.Name} 체력 :{player.Hp} \n");
                for (int i = 0; i < CreateMonsters.Count; i++)
                {
                     
                    if (CreateMonsters[i].IsDead == true)
                    {
                        RedText($"{CreateMonsters[i].Name} 사망");
                    }
                    else
                        Console.WriteLine($"{i + 1}. LV.{CreateMonsters[i].Level} \t {CreateMonsters[i].Name} \t HP : {CreateMonsters[i].Hp} \t ATK : {CreateMonsters[i].Attack}");
                }
                Console.WriteLine("\n공격할 몬스터를 선택하세요.");
                Console.WriteLine("0.도망가기");
                int monsterChoice = CheckValidInput(0, MonsterNumber);
                Console.Clear();
                if (monsterChoice == 0) {
                    Run();
                    Thread.Sleep(200);
                    Console.Clear();
                    break;
                }
                Console.WriteLine($"\n\t   {player.Name} 체력 :{player.Hp} \n");
                //선택된 몬스터의 글자 색이 바뀌는 코드가 추가되면 좋겠어요
                for (int i = 0; i < MonsterNumber; i++)
                {
                    if (CreateMonsters[i].IsDead == true)
                    {
                        RedText($"{i + 1}. {CreateMonsters[i].Name} 사망");
                    }
                    else if (monsterChoice == i+1)
                    {
                        Bluetext($"{i + 1}. LV.{CreateMonsters[i].Level} \t {CreateMonsters[i].Name} \t HP : {CreateMonsters[i].Hp} \t ATK : {CreateMonsters[i].Attack}");
                    }
                    else
                    {
                        Console.WriteLine($"{i+1}. LV.{CreateMonsters[i].Level} \t {CreateMonsters[i].Name} \t HP : {CreateMonsters[i].Hp} \t ATK : {CreateMonsters[i].Attack}");

                    }

                }
                Console.WriteLine("\n공격할 스킬을 선택하세요.\n");
                Console.WriteLine($"\n\t   {player.Name} 체력 :{player.Hp} 마나 : {player.Mp}\n");
                Console.WriteLine($"번호 \t이름\t기본데미지\t소모MP");
                for (int i = 1; i <= player.Skills.Count; i++) { 
                
                Console.WriteLine($"{i}. \t{player.Skills[i].Name} \t{player.Skills[i].Damage}          \t{player.Skills[i].Mp}");

                }
                int skillChoice = CheckValidInput(1, player.Skills.Count);
                Console.Clear();
                if(player.Mp <player.Skills[skillChoice].Mp) 
                {
                    Console.WriteLine("MP가 부족합니다. 평타로 공격합니다.");
                    Thread.Sleep(1500);
                    skillChoice = 1;
                }
                Console.WriteLine($"\n\t   {player.Name} 체력 :{player.Hp} \n");
                if (CreateMonsters[monsterChoice-1].IsDead == false)
                {
                    player.Mp -= player.Skills[skillChoice].Mp;
                    BluetextNo($"\n{player.Name} "); Console.Write("가 공격합니다. ");
                    int damageValue =CreateMonsters[monsterChoice - 1].TakeDamage(player, player.Skills[skillChoice].Damage);
                    RedTextNo($"\n{CreateMonsters[monsterChoice - 1].Name} "); Console.Write("가 ");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {damageValue} "); Console.ResetColor(); Console.Write($"의 피해를 받았습니다!\n\n");
                    Thread.Sleep(1700);
                    Console.Clear();
                    if (CreateMonsters[monsterChoice-1].IsDead==true)
                    {
                        killMonsterNum++;
                    }
                    if (MonsterNumber == killMonsterNum)
                    {
                        WinBoard(CreateMonsters, player);
                        
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다. 턴이 소모됩니다.");
                }
                monsterPhase(player);
            }

            
        }
        public void monsterPhase(Player player)
        {
            RedTextNo($"\n몬스터 "); Console.Write("가 공격합니다. ");
            for (int i = 0; i < CreateMonsters.Count; i++)
            {
                if (!player.IsDead)
                {
                    if (!CreateMonsters[i].IsDead)
                    {
                        int damageValue = player.TakeDamage(CreateMonsters[i], 0);
                        BluetextNo($"\n{player.Name} "); Console.Write("이/가");
                        RedTextNo($" {CreateMonsters[i].Name} "); Console.Write("에게");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {damageValue} "); Console.ResetColor(); Console.WriteLine($"의 피해를 받았습니다!\n\n");

                        Console.WriteLine($"\t   {player.Name} 체력 :{player.Hp} \n");
                        Thread.Sleep(300);

                    }
                }
                if (player.IsDead)
                {
                    Console.Clear();
                    Console.Write($" {player.Name} 가 치명상을 입었습니다. 휴식이 필요합니다. ");
                    //비석 그림
                    Thread.Sleep(1000);
                    break;
                }
            }
            Thread.Sleep(500);
            Console.Clear();

        }
        public void StageMonsterView()
        {
            if ( CreateMonsters == null ) { return; }
                viewMonster();
                viewMonster();
        }
        private void viewMonster()
        {
            for (int i = 0; i < CreateMonsters.Count; i++)
            {
                if (CreateMonsters[i].Name == "슬라임")
                {
                    RedText("\t강한 몬스터가 등장합니다.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                                                  \r\n                                                  \r\n                                                  \r\n                                                  \r\n                                          +#***   \r\n                                         +#+++*%  \r\n                       ..=@@@@@@..       +#+++*%  \r\n                       @%        =@:.....+-       \r\n   :   :.              %                :+.=-     \r\n  +-+:+:-            .%@@@+.          ..=@:#+..   \r\n   +. +.          ..*++++++%@:.       ::::.::::   \r\n  -:=% +.       -@%+++++++++++*@*     @@@@:#@@@   \r\n             .@*+++++++++++++++++#+.    -@:#=     \r\n           :#*+++++++++++++++++++++%+             \r\n         :**+##+++++++++++++++++%%+++@.           \r\n         #*+++#@#++++++++++++%%@*++++*@           \r\n         %++++++#@#+++++++#@**+++++++++#          \r\n       .@++++++++++++++++++++++++++++++#          \r\n       .%*+++++++++***%*++++++++++++++*#          \r\n         #*+++++**##+++*%%**+++++++++*#           \r\n          :##*++++++++++++++++++++*##*.           \r\n             =###################*-               \r\n                                                  ");
                    Console.ResetColor();
                    Thread.Sleep(400);
                }
                else if (CreateMonsters[i].Name == "고스트")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t강한 몬스터가 등장합니다.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("       .=-                                \r\n      :=%                                 \r\n     .-=##                                \r\n   :=+-==.                                \r\n   *--==.                                 \r\n .-#---+.                                 \r\n.+=-=+-+:       ..:=--:..                 \r\n.*++..++#     .:=+:.  .+++..              \r\n.+=+*%===    .*-.*%*:  ..:*:              \r\n  -****:   .=*.%@@@@- +@@*.+.             \r\n          .=- :@@@@+  *@@@=.%.       .:.  \r\n          =:     ..***:.*#:.==       -*.  \r\n         -=    .=%@@@@@.    .*      .*=+- \r\n        .+-    .=#@@%@@.    .*     =+-+=  \r\n        -+            ..    .*    .:*-+:  \r\n       -:                   .*    -+--=+. \r\n      :=.                   .*    :=--+=  \r\n     .=+.                   .*   .*=***++:\r\n     :+.                    .*   .+=+=++=.\r\n    -=                      .*    .:---.  \r\n   :#:                      .*            \r\n   -* ..-%=-:.              .*            \r\n   +#===. ..+.              .*            \r\n            .#+   .*#*=*=   .*            \r\n              .=++.     .+=..*            \r\n                         .=++=            ");
                    Console.ResetColor();
                    Thread.Sleep(400);
                }
                else if (CreateMonsters[i].Name == " 골램  ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t강한 몬스터가 등장합니다.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                                          \r\n                                          \r\n                                          \r\n              ..............              \r\n          .:==+************@=+.           \r\n        ..=%*----++++++++----#*=.         \r\n       .:##---*@*--------*@*---##         \r\n       :*#=--=%------------@---=#:        \r\n       :*+----%%----------=@----+*        \r\n       :*%=----%%=------=%------+*        \r\n        :*+------=%%%%%%%=-----=#         \r\n         :*=-------------------@*         \r\n          :#=-----------------@%          \r\n        .:#@@@%-------------@@@%.         \r\n       :*@@%-----+@@@@@@@@#***@@@*        \r\n     :*%+=#=-------+%*********#%-*@+      \r\n   .+%+-=%@@@@@@@@@@@@@@@@@@@@@@#-+@@-    \r\n  .+*=#@%#*****#@+++++++++@-----+@#--#-   \r\n .+#---=##*****#@+++++++++@-----+#---=%:  \r\n .+*--=#%##%+++++++++#%*******#@*#*---#:  \r\n +@%#+=##*#%---------*#+++++++*@+##--*%@: \r\n +*-=+*##*#%---------*#+++++++*@+#%#*+-%: \r\n-*=---=#*+++*@*******##%%########%#----+*.\r\n:==+####+---=%+++++++++%#********#%###+==.\r\n  ....:*#####@%%%%%%%%%@%%%%%%%%%@*....   \r\n      :*#++++++++*#----------@+++#*       \r\n      :**++++++++*#----------@+++#*       \r\n      .=+++++++++++++++++++++*++++-       ");
                    Console.ResetColor();
                    Thread.Sleep(400);

                }
                else if (CreateMonsters[i].Name == "드래곤")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30);
                    Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30); Console.WriteLine("\t보스(드래곤) 출현"); Thread.Sleep(30);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("                                                  \r\n                                                  \r\n                         @@     @@                \r\n                    @   @@      @##%              \r\n                  %@%%%@%@   @%##%@@              \r\n                 %*## @ @@%@%#*%%@      @@        \r\n               %#%**%     %*#*%#%@     #%         \r\n             ##%#*#%*    ******%%@    %*#%        \r\n          %##%%**#      #*#*###%%%  @#*#%%@       \r\n        %##%%%***@     *****@ @#%@@@@ #*%%%       \r\n        #%%%%#****%% @***#***# %%@   #*%%%%%      \r\n      %#%%%%%%##*********##****####%#*%%%%%%%     \r\n      #%%%%%%%%%%%%%#***********#**##%%%%%%%%     \r\n     #%%%%%%%%%%%%%%%%**#*****#*#%%%%%%%%%%%%     \r\n    ##%%%%%%%%%%%%%%%%%#********%%%%%%%%%%%%%     \r\n    %%%%%%%%%%%%@@     @********#@@%%%%%%%%%%     \r\n    %%%%%%%%%%@@ %#*************@   @%%%%%%%%     \r\n    %%%%%%%%@%##********##*****%    @  @%%%#      \r\n    %%%%%%@ %#********#******#%        @%%%%      \r\n    %%%@    #**#***********##%           %%       \r\n    %%%    @*******##*###****##         @@        \r\n     %%     #****%%       %***#         @@        \r\n     @@    @**#*##@      @**#@                    \r\n      @    #**%%%%%%%%%@@#*#%@%                   \r\n          @*++*++@       #####*@                  \r\n            %                                     \r\n                                                  ");
                    Console.ResetColor();
                    Thread.Sleep(1000);

                }

                Console.Clear();
                if (CreateMonsters[i].Name == "슬라임")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t강한 몬스터가 등장합니다.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                                           =+.    \r\n                                        =#%*+#=.  \r\n      -    .-                    -=**==.%*++++@:  \r\n    *=:*-.=+.-                 -+.     +*#####*.  \r\n      *-:*.=*                 =:                  \r\n    .-* :.*:                 %*                   \r\n    *.-%:#::#:              .*=                   \r\n    :%    :*          .*#::#+                     \r\n                   .:*@=:.                        \r\n                ..:#+++++%@-.                     \r\n             ..=@+++++++++++#-.            . .    \r\n           .:%++++++++++++++++#:.        ..% %..  \r\n           :@++++++++++++++++++@+                 \r\n          :@++++++++++++++++++++*%-      .:% %::  \r\n        :%**@%+++++++++++++++%#+++%:       : :    \r\n        #*+++#@#+++++++++++%@#*++++@-             \r\n        @+++++*@%++++++++#%#*+++++++%:            \r\n      .*#++++++*##+++++#%%#+++++++++%:            \r\n      :@++++++++++++++++++++++++++++%:            \r\n      .*#++++++++*###*+++++++++++++#*.            \r\n        @+++++++*%+++#%*+++++++++++@-             \r\n        :#*++++*%++++++#%*+++++++*#:              \r\n          :%*+++++++++++++++++*%%:                \r\n            :@@@@@@@@@@@@@@@@@+                   \r\n                                                  ");
                    Console.ResetColor();
                    Thread.Sleep(400);
                }
                else if (CreateMonsters[i].Name == "고스트")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t강한 몬스터가 등장합니다.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("                                          \r\n                              .*.         \r\n                             .#**:        \r\n                             .:*-*.       \r\n                             .:+-=..      \r\n                             .+*-+*-.     \r\n                ..::::.        *+:%==.    \r\n              .**.   .:++:.   .+=+==.     \r\n             -*:... .+#*----.             \r\n.--.        :=.+@@@.:%@@@#.:=.            \r\n  -%%-      -:-@@@@.   =*:  -=.           \r\n .+=#.      +.#@%:.:%@@#.   ..*.          \r\n .==-=.     *     +@@@@@%:   .-:          \r\n.-#=-+:     *    :#%#+....     ++.        \r\n.=+--*-     *:                  =:        \r\n :+--+%*.   -:                  :#:.      \r\n.++#+=+-*   -:                   .@-      \r\n.*=+++*+-   -:                    .+:     \r\n .-*##*.    -:.                    :=.    \r\n            :=.                     :#.   \r\n            :=.                      :+   \r\n            :=.             .:*+===#=:#:  \r\n            :+.  :*=-+=.   .++.    ....   \r\n            .+- -*.   .:###*..            \r\n             .+=:.                        ");
                    Console.ResetColor();
                    Thread.Sleep(400);
                }
                else if (CreateMonsters[i].Name == " 골램  ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t강한 몬스터가 등장합니다.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  .========:.                 .:========:.\r\n .++=-----*+.                 .+*------#*:\r\n :#-------++.                 .++-------#-\r\n :#-------++.-*+++++++++++*%*+.++-------#-\r\n :##%#####%%*=---*#######=---++%#+######+.\r\n .=+-----+#=--*%*--------+%#---#+------#-.\r\n  -*----=#=---#*----------=%---*%=-----#-.\r\n  :*=---=#=---=#*--------=*#----#%+===+#-.\r\n   =*++**%#----=**++++++##=----=*+==+#%=. \r\n   .**=--=#*------=======------##----=#-. \r\n    +#=---##=-----------------#*+*++*%=.  \r\n    .*+-+*+-*@#=------------*@#----*+..   \r\n     -%#---**--+*#%#*****%%%%%%=-+@+.     \r\n       =%##*-------+%*********#%%-.       \r\n         -%%*******#%%%%%%%###%@=.        \r\n        .*#*****%*+++++++*%----=*:..:.    \r\n      ..:#######%#********%=====#=.....   \r\n      ..*##%#+=======*%*******#%*@: ...   \r\n       .##*%*--------+#+++++++##+%:       \r\n       .%##%#++++++++#%*******#%*@:       \r\n       .#=---##++++++++##********@::.     \r\n       .#=---##++++++++##********@:       \r\n       .%%%%%%%%%%%##########@%%%@:       \r\n       .#*+++++++*#=--------=%+++%:       \r\n       .###########**********%###%:       ");
                    Console.ResetColor();
                    Thread.Sleep(400);
                }
                Console.Clear();
            }
        }

        public void WinBoard(List<Monster> monster, Player player)
        {
            int rewardGold= 0;
            int rewardExp= 0;
            for (int i = 0; i < monster.Count; i++)
            {
                rewardGold = rewardGold + monster[i].Gold ;
                rewardExp = rewardGold + monster[i].RewardExp;
            }
            player.Gold += rewardGold;
            player.LevelUpExp += rewardExp;
            Console.WriteLine($"\n\t\t{player.Name}님 승리하셨습니다!\n");
            
            Console.Write($"\t획득한 골드 : "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"{rewardGold}\n"); Console.ResetColor();
            Console.Write($"\t획득한 EXP  : "); Console.ForegroundColor = ConsoleColor.Blue; Console.Write($"{rewardExp}\n\n"); Console.ResetColor();
            LevelUp(player);
            Console.WriteLine($"\n\t{player.Name} 정보");
            Console.WriteLine($"\tGold  : {player.Gold}");
            Console.WriteLine($"\tLevel : {player.Level} , EXP : {player.LevelUpExp}");
            Console.WriteLine("\n\n\t\t0.돌아가기");
            switch (CheckValidInput(0, 0))
            {
                case 0
                :
                    //dungeonEnter();
                    break;
            }
            // stage++;
        }
        public void LevelUp(Player player) {
            int levelUpPoint = player.Level* player.Level * 100;
            int UpHp;
            int UpDefence ;
            int UpAttack;
            while (player.LevelUpExp > levelUpPoint)
            {
                player.Level++;
                // 수치 조정
                UpHp = player.Level * 10;
                UpDefence = player.Level * 1;
                UpAttack =  player.Level * 2;
                player.MaxHp += UpHp;
                player.Hp = player.MaxHp;
                player.Defence += UpDefence;
                player.Attack += UpAttack;

                player.LevelUpExp -= levelUpPoint;
                Console.WriteLine($"레벨업! Level : {player.Level} 가 되었습니다.");
                Console.WriteLine($"체력 + {UpHp}  공격력 + {UpAttack} 방어력 + {UpDefence}");
                Thread.Sleep(400);
                levelUpPoint = player.Level * player.Level * 100;
            }
        }

        
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("===================== RUN ========================");
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓           ; ◆ ");
            Console.WriteLine(" |      |        ==┌┼┘  ");
            Console.WriteLine("|        |       == │┒  ");
            Console.WriteLine("==================================================");
        }
        public void DungeonEntranceView()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("  ┏   ┓             ◆ ;");
            Console.WriteLine(" |      |          └┼┐ == ");
            Console.WriteLine("|        |         ┌│  ==");
            Console.WriteLine("==================================================");
            Console.WriteLine("======== 던전에 가기 전 준비를 해주세요. =========\n\n");
            Console.WriteLine("==================");
            Console.WriteLine("= 1. 던전 입장   =");
            Console.WriteLine("= 2. 소모품 사용 =");
            Console.WriteLine("= 0. 나가기      =");
            Console.WriteLine("==================");
        }
        public int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        public void RedText(String s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{s}");
            Console.ResetColor();
        }
        public void RedTextNo(String s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{s}");
            Console.ResetColor();
        }
        public void Bluetext(String s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{s}");
            Console.ResetColor();
        }
        public void BluetextNo(String s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{s}");
            Console.ResetColor();
        }
    }
}


```
</div>
</details>


<br><br><br><br><br><br>
- - - 

# 4. 정리, 잡담

> **잡담**  
오늘 던전코드 전체적인 부분을 잡고 완성되어간다. 오늘은 view부분에 시간을 많이 쓴 거 같은데 기능하는 거 보다 보이는게 있어서 재밌었다... 민지님이 픽셀로 그려주신 거 넣었는데 슬라임귀엽다. 용가리는 무섭다. view부분에서 재밌게 작업할 수 있었다.  
내일 마무리 작업하고 팀 프로젝트 이후 밀린강의, 개인공부를 해야겠다.
{:style="border:1px solid #000000; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - - 

[Unity] TIL 16

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
