---
title:  "[Blog Github.io] 영상 추가"
excerpt: " Video"

categories:
  - Blog 
tags:
  - [Blog, Minimal Mistakes, Video]

toc: true
toc_sticky: true

date: 2023-02-26
---
- - -
<br><br>

# Blog 사용법 3


## 유튜브 영상 삽입하기.

### 1.  HTML 태그 사용  
iframe태그 : 유튜브 영상에 마우스 우클릭 후 소스 코드 복사 후  
포스트 파일에 붙여넣기. HTML의 iframe태그로 이루어진 코드가 나온다.
{: .notice}
![image](https://user-images.githubusercontent.com/96651722/226311210-e292c8b7-653e-4419-a603-dbc6585de8fb.png){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

 
```
복사한 코드 :  
<iframe width="894" height="503" src="https://www.youtube.com/embed/73V3xrfiYMo"
 title="[MV] YOUNHA(윤하) _ 사건의 지평선(Event Horizon)" frameborder="0" 
 allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>  

```

<iframe width="894" height="503" src="https://www.youtube.com/embed/73V3xrfiYMo"
 title="[MV] YOUNHA(윤하) _ 사건의 지평선(Event Horizon)" frameborder="0" 
 allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>  

<br><br><br><br>


### 2.  minimal-mistake 테마를 사용  
video helper 사용하기


![image](https://user-images.githubusercontent.com/96651722/221397616-f8dae90f-8eae-4e78-a122-e83c0c5a8571.png)  


**<u>_include </u>** 폴더에 있는 **<u>vidio </u>** 파일은 영상을 포스트에 embeding 할 수 있도록 소스를 제공한다. 
이를 include 해주자. id 속성 값에 유튜브의 짧은 url 중 뒷부분을 넣어주면 끝.
{: .notice--primary}


![image](https://user-images.githubusercontent.com/96651722/226312039-b7c7dd59-798e-46ef-afa3-cfb624c98724.png)


{% include video id="HTm2Llo4esk" provider="youtube" %}


<br>

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
