---
title:  "[Design Pattern] 7. 플라이웨이트 패턴(flyweight)"
excerpt: ""

categories:
    - Design Pattern
tags:
    - [C#, Design Pattern]

toc: true
toc_sticky: true
 
date: 2024-01-14 13:07

---
- - -
<BR><BR>
 
`flyweight`

<center><H1> flyweight패턴   </H1></center>

<br><br><br><br><br><br>
- - - 

# 플라이웨이트 패턴(flyweight)
![image](https://github.com/levell1/levell1.github.io/assets/96651722/d428dfa5-e929-4c5e-b27c-ac770f8eaed4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  

**도서관**
> - **메모리 사용을 최적화** 하기 위한 패턴
> - **객체의 공유를 촉진하는 형태**  
> - 플라이 웨이트 패턴의 상태 종류
> 객체마다 다를 수 있는 개별상태
> 변경 불가능한 공유 상태
> - 공유 상태는 객체 내부에 저장, 개별 상태는 클라이언트에 의해 관리
> - 대규모 게임 환경에서 반복되는 아이템 같은 것을 관리할 때 유용함.  
{: .notice--info} 

<details>
<summary>flyweight 코드보기</summary>

<div class="notice--primary" markdown="1"> 

```c#
// 플라이웨이트 클래스, 모든 나무가 공유하는 정보.
public class TreeModel
{
    // 공유되는 상태 (예: 모델, 텍스처)
    public string Model { get; set; }
    public string Texture { get; set; }
}

// 공유되지 않는 상태를 관리하는 클래스, 각 나무의 고유한 정보를 저장. 위치를 관리함.
public class Tree
{
    private TreeModel model;
    private float x, y; // 나무의 위치, 고유 상태

    public Tree(TreeModel model, float x, float y)
    {
        this.model = model;
        this.x = x;
        this.y = y;
    }

    public void Draw()
    {
        // 나무를 그리는 로직, model의 정보와 위치 정보를 사용
    }
}

// 플라이웨이트 팩토리, TreeModel 클래스 인스턴스를 생성하고 관리함. 
// 같은 종류의 나무가 여러번 필요할 때 매번 TreeModel 클래스가 생성하지 않도록 하는게 핵심
public class TreeFactory
{
    private Dictionary<string, TreeModel> models = new Dictionary<string, TreeModel>();

    public TreeModel GetTreeModel(string model, string texture)
    {
        if (!models.ContainsKey(model))
        {
            models[model] = new TreeModel { Model = model, Texture = texture };
        }
        return models[model];
    }
}

// 사용 예시
TreeFactory factory = new TreeFactory();

var oakModel = factory.GetTreeModel("oak", "oakTexture");
var pineModel = factory.GetTreeModel("pine", "pineTexture");

List<Tree> trees = new List<Tree>();
trees.Add(new Tree(oakModel, 10, 20));
trees.Add(new Tree(pineModel, 50, 60));

foreach (var tree in trees)
{
    tree.Draw();
}
```
</div>
</details>

<br><br><br><br><br><br>
- - - 

# 잡담, 정리
> - 디자인 패턴은 애초에 특정 문제를 해결하기 위해 고려된 것.(성능, 메모리 사용 고려)
> - 추가 내용 정리
{: .notice--success} 

<br><br>
- - - 

[C#] 디자인 패턴 (Design Pattern)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
