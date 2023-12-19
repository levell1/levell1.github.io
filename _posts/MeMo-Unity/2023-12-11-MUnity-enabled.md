---
title:  "[Memo-Unity] 15. setActive , enabled 차이 "
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-11 09:02

---
- - -

`SetActive`  `enabled`
<BR><BR>

<center><H1>  SetActive, enabled  </H1></center>

<br><br><br><br><br><br>
- - - 

# 1. enabled

GameObject.`SetActive` : 오브젝트를 활성화, 비활성화를 하는 역할을 합니다.  
오브젝트를 비활성화 시키면 오브젝트 자체가 씬, 게임뷰에서 사라지고 작동하지 않습니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/5dac7cc9-57a5-41e9-8785-2171c5c3c425)

Behaviour.`enabled` : 오브젝트에 추가되어 있는 컴포넌트를 활성화 및 비활성화시킵니다.  
특정 기능을 만들 때 지정한 컴포넌트만 비활성화 시켜서 기능을 잠시 정지시키는 용도로 사용 가능합니다.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}

![image](https://github.com/levell1/levell1.github.io/assets/96651722/fb9e4c38-fe8f-4ddf-bff7-042e1c877c94)

<br><br>
- - - 

[Unity] SetActive, enabled
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
