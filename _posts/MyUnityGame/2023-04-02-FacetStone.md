---
title:  "[My-Unity] 1. 돌세공 "
excerpt: ""

categories:
    - My Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2023-04-02

---
- - -
<br>

#   돌세공
기본 화면  
![image](https://user-images.githubusercontent.com/96651722/229372515-89137c7e-5407-4a95-b2e5-8c4ad2e57ca7.png){:style="border:1px solid #eaeaea; border-radius: 7px; padding: 0px;"}  


#   1.오브젝트 클릭시 반응
오브젝트 클릭시 오브젝트 확인 후 오브젝트 색 변경, 이벤트   
<div class="notice--primary" markdown="1"> 

`FacetController.cs`
  ```c# 
using UnityEngine;

public class FacetController : MonoBehaviour
{
    // 클릭 시 오브젝트 확인 rayCast
    public Camera getCamera;
    private RaycastHit2D hit;
    private Vector2 pos;

    // 색 변경
    private SpriteRenderer spriteRenderer;

    // 각각 오브젝트 확인용
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;

    void Start(){
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //마우스 왼쪽 버튼 클릭 시
        if (Input.GetMouseButtonDown(0))
        {   
            //클릭 시 오브젝트 위치 확인
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(pos,Vector2.zero);
            
            if (hit.collider != null)
            {
                spriteRenderer = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(0,0,0,0.2f);
            }
        }
        //마우스 왼쪽 버튼을 뗄 때
        if (Input.GetMouseButtonUp(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(pos,Vector2.zero,0f);

            if (hit.collider != null)
            {
                //오브젝트 이름 확인
                GameObject obname = hit.transform.gameObject;
                if (obname == gameObject1){ //1번째 버프 줄 이벤트
                    spriteRenderer.color = new Color(0.7f,0.8f,0.9f,0.2f);
                    Debug.Log("1줄 이벤트");
                }
                if (obname == gameObject2){ //2번째 버프 줄 이벤트
                    spriteRenderer.color = new Color(0.7f,0.8f,0.9f,0.2f);
                    Debug.Log("2줄 이벤트");
                }
                if (obname == gameObject3){ //디버프 줄 이벤트
                    spriteRenderer.color = new Color(0.9f,0.5f,0.4f,0.2f);
                    Debug.Log("3줄 이벤트");
                }
            }
        }
    }
}
  ```
- Raycast를 이용해 오브젝트 위치 파악 후 오브젝트 파악
- 그 오브젝트의 spriteRenderer를 이용하여 색 변경.
- 마우스에서 손을 뗄 때 이벤트 

</div>


# 2. 텍스트 변경
이벤트 후 텍스트 변경 
<div class="notice--primary" markdown="1"> 

`FacetText.cs`
  ```c# 
using UnityEngine;
using UnityEngine.UI;

public class FacetText : MonoBehaviour
{
    private Text PercentageText;
    int Percentage = 0 ;

    void Start() {
        PercentageText = GetComponent<Text>();
        Percentage = 75;
        if (PercentageText.name== "Debuff PercentageText")
        {
            PercentageText.text = "균열 확률 : "+ Percentage +"%";
        }else{
            PercentageText.text = "성공 확률 : "+ Percentage +"%";
        }
    }
    void Update() {
        
    }     
}

```
</div>

<br>

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -

