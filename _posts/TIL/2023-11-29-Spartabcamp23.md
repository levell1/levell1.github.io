---
title:  "[TIL] 23 Unity 개인과제(TopDown)끝 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-11-28 02:00

---
- - -


<BR><BR>



<center><H1>  개인공부, 유니티 5일차 개인과제 끝 </H1></center>

&nbsp;&nbsp; [o] 9시 ~ 10시 알고리즘 문제      
&nbsp;&nbsp; [o] 개인과제   
&nbsp;&nbsp; 주말에 알고리즘 과제 풀어보기.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 

# 싱글톤 패턴
게임의 전범위에서 동작하는 중요한기능들을 싱글톤 패턴으로 만들곤한다.  
접근성. 유일성.   
씬전환시 모두 파괴 -> 싱글톤 dondestroy로 파괴 x  
단점 static으로 메모리를 많이 사용할 수도 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}
<div class="notice--primary" markdown="1"> 

```c#
private static GameManager instance = null;

    public static GameManager Instance
    {
        get 
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else { 
            Destroy(this.gameObject);
        }
        
    }
```
</div>

<br><br><br><br><br>
- - - 

# 스크립트적용 오브젝트 찾기
스크립트 적용된 오브젝트 쉽게찾기
스크립트 우클릭 -> Find References In Scene
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}
![image](https://github.com/levell1/levell1.github.io/assets/96651722/b7503f09-2582-4842-9210-223f98f89b38)

<br><br><br><br><br>
- - - 
    
# 여러개의 player
player 을만들고 maincamera를 player마다 배치해서 많은 문제가 있었다.
하나의 player안에서 스프라이트, 애니메이션 변경으로 개선해보기.

<br><br><br><br><br>
- - - 

# 애니메이터 컨트롤러 

<br><br><br><br><br>
- - - 

# GameManager 
1번째 씬에서 GameManager를 생성하고  
2번째 씬에서 gamemanager에 필요한 오브젝트를 넣어주는 방식을 사용하였다.  
SceneSetting이라는 오브젝트,스크립트를 만들고 awake에서 gamemanager에 접근
![image](https://github.com/levell1/levell1.github.io/assets/96651722/f769c403-1106-4678-9fcb-890aae481220)
<div class="notice--primary" markdown="1"> 

```c#
public class SceneSetting : MonoBehaviour
{
    [SerializeField] private GameObject zep;
    [SerializeField] private GameObject postit;
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.Instance.zep = zep;
        GameManager.Instance.postit = postit;
    }

}
```
</div>
지금상황의 개선이고 처음부터 더 좋은 방법이 있다고 하였다. 좀 더 생각해보기.

<br><br><br><br><br>
- - - 

![TopDown1](https://github.com/levell1/levell1.github.io/assets/96651722/1fc33cba-8373-4509-a8bf-7ad31907ffaf)


<br><br><br><br><br>
- - - 

# 정리, 잡담

**느낀점**  
유니티 첫 개인과제로 하나의 게임? 을 만들면서 많은 생각이 들었다.  
스크립트 관리는 잘 된 건지.  
이 메서드가 이 스크립트에 들어있는 게 맞는지.  
게임매니저의 주 역할은 무엇인지  
싱글톤? 디자인 패턴?  
막히는 게 있을 때 내가 선택한 방법이 좋은 방법인지  
public private, [SerializeField] 에 대한 정확한 사용하는 이유.  
가장 큰 걱정은 내가 잘 하고 있는지에 대한 의심? 인 거 같다.  
제출 후 개선시간에 조금씩 확인해 볼 생각이다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

**잡담**  
하나씩 하면서 중간에 다른 방법으로 하면 좋았을 거 같다고 생각이 들때
수정한다면, 깔끔하고 빠르게 해결할 능력이 있나?, 지금은 없다고 생각해서 바꾸지 못했다.   
다음 프로젝트에서 이번에 새로운 방법들을 시도해 볼 생각이다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}


<br><br>
- - - 

[Unity] TIL 23

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
