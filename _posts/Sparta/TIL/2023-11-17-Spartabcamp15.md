---
title:  "[Sparta-BCamp] TIL 15 팀 과제진행, 알고리즘 문제 ⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-17 02:00

---
- - -

<BR><BR>

<center><H1> 개인 공부 C# 10일차 | 팀과제 3일차   </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제  
&nbsp;&nbsp; [O] (주) 팀 과제   
&nbsp;&nbsp; [X] 5주차 강의듣기(알고리즘) .   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  
사진!

<br><br><br><br><br><br>
- - - 

# 1. 알고리즘 정리
알고리즘 문제풀이 1일차  
[깃허브-프로그래머스](https://github.com/levell1/Algorithm-Programmers/tree/main/%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EC%8A%A4)   
[알고리즘 문제풀이 1일차](https://levell1.github.io/algorithm/Algorithm2/)문제 1~13  
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 팀 과제 회의
[팀노션](https://www.notion.so/7-be1b6c78efb24cf59fd06bcbe1c35027#6a28c4f0417e4403b206e3bcf9800ded)  
팀 과제 1~3일차 진행사항 정리   
오늘 시간이 나서 글을 적으며 정리.  
1일차 -> 전체적인 구성에 대한 이야기, 깃허브 사용해보기.  
2일차 -> 팀장님의 의견으로  MVC 패턴로 Model, View, Controller 나눈 후 작업
-> 1.Main 2.Item,Inven 3.Dungeon 크게 3가지로 인원 나누어서 작업 진행  
3일차 -> 새로 시작
{: .notice}

<BR><BR>

## 데이터 저장, 불러오기 
팀 과제중 새로 알게 된 것.

<details>
<summary>데이터 저장, 불러오기</summary>
<div class="notice--primary" markdown="1"> 

```c#
internal class LoginController
{
    public string _id = "bus";
    private string _password = "123";
    
    private LoginView _loginView = new LoginView();
    public Player PlayerData = new Player();

    public string path = "PlayerData.csv"; // 파일명
    // 파일 위치 : team-textrpg\bin\Debug\net6.0
    public void Load()
    {
       
        PlayerData = new Player();

        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                string line = sr.ReadLine();
                string[] data = line.Split(',');
                PlayerData = new Player(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]));
                sr.Close();
            }
        }
    }

    public void Save()
    {
        StreamWriter writer = new StreamWriter(path);
        writer.Write(PlayerData.Name+","+PlayerData.Class+","+ PlayerData.Level + "," + PlayerData.Attack + "," + PlayerData.Defence + "," + PlayerData.Hp + "," + PlayerData.Gold + "," +
            PlayerData.CritRate + "," + PlayerData.MissRate);
        writer.Close();
    }
}
```
</div>
</details>

> -  public string path = "PlayerData.csv";  
파일 위치 : team-textrpg\bin\Debug\net6.0\PlayerData.csv
> - load에서 ,로 split 해서 문자열 읽고 배열에 저장후 사용
> - save에서 원하는 값 PlayerData.csv에 저장
> - Bin에 저장하면 깃허브에 commit이 안돼서경로지정
> - public static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\CSV\\ItemData.csv
CSV파일을 만들어서 거기에 저장
{: .notice--info}


<div class="notice--primary" markdown="1"> 

```c#
PlayerData.csv

   버스타조,직업,1,10,5,100,1500,5,5

```
</div>

<br><br><br><br><br><br>
- - - 

# 3. 게임 개발자와 업계 직무
강의 내용  
<BR><bR>

**게임 개발 프로세스**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/dfad2a30-5cc1-4945-a01c-b1ab4898622e){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

![image](https://github.com/levell1/levell1.github.io/assets/96651722/bb5bbbb7-9fb6-49c8-92b5-d74d3795d457){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

**클라이언트 프로그래머**  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/996f6e7a-110c-4625-9ac8-6c959eb80724){:style="border:1px solid #EAEAEA; border-radius: 7px;"}   

<br><br><br><br><br><br>
- - - 

# 4. 정리, 잡담

> **잡담**  
MVC에대해 의미만 알고있었지 이렇게 나누어서 작업하는건 처음해보았다.
처음에는 Controller, View 어떤 게 가야할 지 햇갈렸지만 진행하다보니 익숙해진 거 같다.  
나중에 완성하고 보면 굉장히 보기편하고 내용수정시에도 더 효율적인 작업이 가능 할 거 같다.  
오늘 아주 작은 이슈가 있어서 프로젝트를 약간 새로 시작하는 마음으로 다시? 할 거 같다.
mvc에 대해 이해할 수 있는 기회가 되었고, 이제 간편화 될 거 같다. 뭔가 했던게 없어지는 느낌이라 이상했지만 잘해보자.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - - 

[Unity] TIL 15

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
