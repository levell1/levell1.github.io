---
title:  "[Memo-Unity] 2. 조이스틱(JoyStick)"
excerpt: "조이스틱"

categories:
    - MeMo Unity
tags:
    - [Unity, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-04-9

---
- - -
조이스틱(JoyStick)

[고박사의 유니티 기초](https://www.inflearn.com/course/%EA%B3%A0%EB%B0%95%EC%82%AC-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B8%B0%EC%B4%88/dashboard)를 정리. 
{: .notice--info}


# Joystick
![image](https://user-images.githubusercontent.com/96651722/230782176-c8e73e8a-c029-4431-804e-4f3bb7170a37.png){:style="border:1px solid #eaeaea; border-radius: 7px;" }  

# 이미지
1. 조이스틱으로 사용 할 이미지 생성 ( UI- IMAGE)
2. Canvas 에서 해상도 설정 ex) scale with screen size , 1600:1000 , 0.5  
![joysticimage](https://user-images.githubusercontent.com/96651722/230780307-d89b0267-86c4-44f0-b322-c5ba181a164e.png){:style="border:1px solid #eaeaea; border-radius: 7px;" }  
3. ui 이미지 사이즈 조정  
![image](https://user-images.githubusercontent.com/96651722/230780491-6ab81170-c158-43cd-ada5-ab74b595b6de.png){:style="border:1px solid #eaeaea; border-radius: 7px;" }   
4. 컨트롤러로 사용될 이미지 추가 , 배경의 자식으로 설정 

<br><br>

---
# C스크립트
using.UnityEngine.EventSystems 

## 1. MoveTouch.CS
조이스틱 터치시 발생하는 이벤트

<div class="notice--primary" markdown="1"> 

`MoveTouch.cs`
  ```c# 
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class MoveTouch : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image imageBackground;
    private Image imageController;
    private Vector2 TouchPosition;
    private void Awake() {
        imageBackground = GetComponent<Image>();
        imageController = transform.GetChild(0).GetComponent<Image>();
    }

    //터치시 1회 
    public void OnPointerDown(PointerEventData eventData){
    }

    //터치후 드래그 매프레임
    public void OnDrag(PointerEventData eventData){
        
        TouchPosition = Vector2.zero;

        // 조이스틱의 위치가 어디에 있든 동일한 값을 연산하기 위해
        // touchPosition의 위치 값은 이미지의 현재 위치를 기준으로 얼마나 떨어져 있는지에 따라 다르게 나온다.
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageBackground.rectTransform, eventData.position,eventData.pressEventCamera,out TouchPosition ))
        {   //이미지의 teansform정보, 화면터치좌표, 현재 화면에 대한 카메라, 연산된 좌표를 저장

            // touchposition값 정규화 이미지 크기로 나눔  [값 : 0~1 ]
            // 배경밖으로 나가면 이상의 값이 나온다 -2 ~ 2
            TouchPosition.x = (TouchPosition.x / imageBackground.rectTransform.sizeDelta.x);
            TouchPosition.y = (TouchPosition.y / imageBackground.rectTransform.sizeDelta.y);
            
            //normalized를 이용해 터치 좌표값을 -1 ~ 1로 제한
            TouchPosition = (TouchPosition.magnitude > 1) ? TouchPosition.normalized : TouchPosition;
            
            // 컨트롤러 움직임을 제한
            imageController.rectTransform.anchoredPosition = new Vector2(
                TouchPosition.x * imageBackground.rectTransform.sizeDelta.x/2,
                TouchPosition.y * imageBackground.rectTransform.sizeDelta.y/2
            );
        }    
    }

    //터치종료시 1회
    public void OnPointerUp(PointerEventData eventData){
        //종료시 위치,방향 초기화
        imageController.rectTransform.anchoredPosition =Vector2.zero;
        TouchPosition = Vector2.zero;
    }

    public float Horizontal(){
        return TouchPosition.x;
    }
    
    public float Vertical(){
        return TouchPosition.y;
    }
}

  ```
-  OnPointerDown , OnDrag , OnPointerUp등의 함수를 사용하기 위해
-  IPointerDownHandler, IDragHandler, IPointerUpHandler를 사용
-  조이스틱으로 오브젝트 움직이기.

</div>

<br><br><BR>

---
## 2. Movement.CS
조이스틱으로 인해 움직이는 오브젝트 코드

<div class="notice--primary" markdown="1"> 

`Movement.cs`
  ```c# 
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
   private MoveTouch movetouch;
   private float movespeed = 10 ;

    void Update()
    {
        float x = movetouch.Horizontal();
        float y = movetouch.Vertical();
        if (x!=0||y!=0)
        {
            transform.position += new Vector3(x,y,0)*movespeed*Time.deltaTime;
        }
    }
}

  ```

</div>

<br><br><BR>

---

<br><br>

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
