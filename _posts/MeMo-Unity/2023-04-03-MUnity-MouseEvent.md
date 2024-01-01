---
title:  "[Memo-Unity] 2. 마우스 클릭 이벤트"
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [Unity, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-04-3

---
- - -
마우스 클릭 이벤트, GetMouseButtonDown, GetMouseButton, GetMouseButtonUp

[고박사의 유니티 기초](https://www.inflearn.com/course/%EA%B3%A0%EB%B0%95%EC%82%AC-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EA%B8%B0%EC%B4%88/dashboard)를 정리. 
{: .notice--info}


# 마우스 클릭 이벤트 3가지


## GetMouseButtonDown()
GetMouseButton`Down` : 마우스 버튼을 클릭했을때 true값을 반환
<div class="notice--primary" markdown="1"> 

```c# 
void Update()
{
    // 마우스 왼쪽 버튼을 클릭했을때
    if (Input.GetMouseButtonDown(0)){
        Debug.Log("마우스 클릭 ");
    }
}
```

</div>

## GetMouseButton()
`GetMouseButton` : 마우스 버튼을 클릭하고 있는 동안에 true값을 반환  
<div class="notice--primary" markdown="1"> 

```c# 
void Update()
{
    //  마우스 버튼을 클릭하고 있는 동안
    if (Input.GetMouseButton(0)){
        Debug.Log("마우스 클릭 중 ");
    }
}
```

</div>

## GetMouseButtonUp()
GetMouseButton`Up` : 마우스 버튼을 클릭을 뗐을 때 true값을 반환  

<div class="notice--primary" markdown="1"> 

```c# 
void Update()
{
    // 마우스 버튼을 클릭을 뗐을 때
    if (Input.GetMouseButtonUp(0)){
        Debug.Log("마우스 뗄 때 ");
    }
}
```

</div>

<br><BR><BR>

---
# 마우스 버튼종류 3

GetMouseButtonDown(0) : 왼  쪽 버튼  
GetMouseButtonDown(1) : 가운데 버튼  
GetMouseButtonDown(2) : 오른쪽 버튼  
{: .notice--success}

<br><BR><BR>

---
# 마우스 클릭 이벤트 EX
<div class="notice--primary" markdown="1"> 

```c# 
void Update()
{
    // 마우스 왼쪽 버튼을 클릭했을때
    if (Input.GetMouseButtonDown(0)){
        Debug.Log("마우스 좌클릭 ");
    }
    // 마우스 가운데 버튼을 클릭했을때
    if (Input.GetMouseButtonDown(1)){
        Debug.Log("마우스 중간클릭 ");
    }
    // 마우스 오른쪽 버튼을 클릭했을때
    if (Input.GetMouseButtonDown(2)){
        Debug.Log("마우스 우클릭 ");
    }

    //  마우스 버튼을 클릭하고 있는 동안
    if (Input.GetMouseButton(0)){
        Debug.Log("마우스 클릭 중 ");
    }

    // 마우스 버튼을 클릭을 뗐을 때
    if (Input.GetMouseButtonUp(0)){
        Debug.Log("마우스 땔 때 ");
    }
}
```

</div>

<br><br>

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
