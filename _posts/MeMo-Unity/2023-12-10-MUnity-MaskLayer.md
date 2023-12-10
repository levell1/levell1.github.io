---
title:  "[Memo-Unity] 13. MaskLayer  "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-10

---
- - -

`MaskLayer` , `Trail Renderer` 
<BR><BR>

<center><H1>  MaskLayer  </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. MaskLayer
**MaskLayer을 통해 충돌 조건**  
사용할 레이어를 추가 ( 6 : Enemy, 7 : Level, 8 : Player )  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8993280d-ba3c-4640-a218-20c99c2f5d9b)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<div class="notice--primary" markdown="1"> 

```c#
if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
{
    Debug.Log(levelCollisionLayer.value);           // 10000000
    Debug.Log(collision.gameObject.layer);          // 7
    Debug.Log(1 << collision.gameObject.layer);     // 10000000
    Debug.Log((levelCollisionLayer.value | (1 << collision.gameObject.layer)));
    DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestory);
}
```
</div>

## 잘못된 생각 수정


{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 

(1 << collision.gameObject.layer)  
이 코드가 collision.gameObject.layer 를 1만큼 << 한다고 잘못 생각하고 있었다.   
비트연산자에 관하여 잘 모르고 있었고, debug 를 찍어보니 알게되었다.    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   

1을 collision.gameObject.layer(7) 만큼 << 하는 거 였다.   
= 10000000 = levelCollisionLayer.value  
levelCollisionLayer.value = 128 = 10000000
collision.gameObject.layer = 7
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}   


<br><br><br><br><br><br>
- - - 

# Trail Renderer
움직이는 게임 오브젝트 뒤에 폴리곤 트레일을 렌더링 한다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 
![image](https://github.com/levell1/levell1.github.io/assets/96651722/7167ab07-416b-4fb8-965d-b89ab6ccd601)  

width, color, Materials

![image](https://github.com/levell1/levell1.github.io/assets/96651722/8f203ed1-53d5-4bf3-b21d-3769f35c1b05)  

<br><br><br><br><br><br>
- - - 

# 정리  

{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}
<br><br>
- - - 

[Unity] MaskLayer
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
