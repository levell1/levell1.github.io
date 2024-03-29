---
title:  "[2D Sparta-Unity] 5주차 게임 런칭을 위한 준비  ⭐⭐⭐ "
excerpt: "2D / Sparta"

categories:
    - Sparta Unity
tags:
    - [Unity, Sparta, 2D]

toc: true
toc_sticky: true
 
date: 2023-10-27

---
- - -
<BR><BR>

<center><H1> 5주차 FindRtan +  </H1></center>
 로직 중요, 게임메니저⭐  시작화면, 스플래시 이미지, 소리,광고, 에셋스토어
{: .notice}
<br><br><br><br><br><br>
- - - 

# 1. 시작화면

> - 새로운 Scene 만들기 (StartScene)
> - 시작화면으로 설정
> - UI 꾸미고 버튼 추가 -> MainScene으로 넘어가게 버튼컴포넌트 추가
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 스플래시 이미지 

<h3> Edit -> Project Settings -> Player  </h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/0ca19c74-9748-431b-9df8-cbbbac199e48){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<H3> 이미지다운 mesh -> full rect (여백설정)  </h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/83c83c9a-e5c3-44c8-81e3-5fa4c901d1cb){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<h3> 스플래시 이미지로 추가하기</h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/08708794-a81f-4021-bbf5-8a4fd5911302){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

Preview로 미리보기 가능

<br><br><br><br><br><br>
- - - 
 
# 3. 소리 음악 넣기

> 1. 배경음악 : 게임이 시작하면 배경음악 
> 2. 뒤집을 때 : 카드 뒤집을 때 뒤집는 소리
> 3. 맞췄을 때 : 카드 두 장이 같을 때 소리

> <h2> 효과음 </h2>
>   -   public AudioClip flip;              어떤 오디오인지
>   -   public AudioSource audioSource;     어디서 재생하는지
>   -   audioSource.PlayOneShot(flip);      flip 오디오 재생
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ca8600fe-1e29-4549-aa50-15b8a1d18f01){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

> <h2> 배경음 </h2>
>   -   public AudioClip bgmusic;
>   -   public AudioSource audioSource;
>   -   audioSource.clip = bgmusic;
>   -   audioSource.Play();

## `audiomanager.cs`

<div class="notice--primary" markdown="1"> 

`audiomanager.cs`
```c# 
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioClip bgmusic;
    public AudioSource audioSource;
    
    void Start() {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }
}
```
-   배경음악 설정

</div>

<br><br><br><br><br><br>
- - - 

# 4. 빌드

## 1) 마켓에 올리기 전 세팅

<h3> Edit → Preference → External Tools 체크</h3>

<h3> Edit → Project Settings → Player </h3>
Conpany ,Product Name, Version

![image](https://github.com/levell1/levell1.github.io/assets/96651722/4144af17-808a-4400-881b-bd28e2a78ba2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<h3> Player -> Icon </h3>

![image](https://github.com/levell1/levell1.github.io/assets/96651722/5223c314-5992-4538-8204-6559d43af974){:style="border:1px solid #eaeaea; border-radius: 7px;"} 

<h3> Resolution and Presentation  </h3>

>   -   Portrait - 디바이스 홈버튼이 아래에 있는 세로 모드로 고정   
>   -   PortraitUpsideDown - 디바이스 홈 버튼이 위에 있는 세로 모드로 고정  
>   -   LandscapeLeft - 디바이스 홈 버튼이 오른쪽에 있는 가로모드로 고정   
>   -   LandscapeRight - 디바이스 홈버튼이 왼쪽에 있는 가로모드로 고정   
>   -   AutoRotation - 휴대폰 방향에 따라 화면이 변경됩니다   -> 체크해제로 가로모드, 세로모드 만 설정 가능하다.
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e0b1d580-baf8-4523-a8f5-2a8d81585302){:style="border:1px solid #eaeaea; border-radius: 7px;"} 
{: .notice}


<h3> ohter settings </h3>

안드로이드 마켓에 배포하려면 64 bit 지원이 필수가 되었기 때문에 Scripting Backend 를 IL2CPP 로 변경합니다  
Target Architectures 에서 ARM64 를 체크하도록 합니다.  

![image](https://github.com/levell1/levell1.github.io/assets/96651722/13fde9ed-ca50-4294-a5d7-65c0bd808c25){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

<h3> Publishing Settings </h3>
(Keystore란? 안드로이드에서 이 앱을 배포할 수 있는 권리)

![image](https://github.com/levell1/levell1.github.io/assets/96651722/32f6a298-68bc-4297-972a-cc3d4cba5d78){:style="border:1px solid #eaeaea; border-radius: 7px;"}    


![image](https://github.com/levell1/levell1.github.io/assets/96651722/a7cf041c-39c9-473e-8118-257254b85180){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

## 2) 원하는 OS 대상으로 Switch Platform 하고 빌드하기
scene 확인  
Switch Platform 을 하면 unity 제작화면이 그 platform 으로 변경된다.

![image](https://github.com/levell1/levell1.github.io/assets/96651722/bede0c89-6f68-4d13-a24c-46f74ba5f33e){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

화면 사이즈   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9c71e56b-736d-48c5-bcb3-9be2b1d32201){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

빌드하기 -> ~~~ .apk 파일로 생성된다.

## 3)배포

구글플레이에는 누구나 올릴 수 있다  
참고: $25 (1회)의 개발자 등록 비를 내야 한다

[참고자료](https://levell1.github.io/categories/memo-unity/googleapp.pdf)
깃허브 pdf 파일 참고

<br><br><br><br><br><br>
- - - 

# 5. 광고 붙이기

<h3>Unity 에디터 내에서 Unity Ads 추가하기</h3>

Windows → General → Services 후 General Settings 클릭
organizations 드롭다운 해서 선택 → Create Project ID 클릭

![image](https://github.com/levell1/levell1.github.io/assets/96651722/7f401856-b34e-40b4-9749-643caaf3cc1d){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

ads ON  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/10e9e921-1485-41fc-a05a-937eabc6ebe2){:style="border:1px solid #eaeaea; border-radius: 7px;"}  

## `adsmanager.cs`

<div class="notice--primary" markdown="1"> 

`adsmanager.cs`
```c# 
using UnityEngine;
using UnityEngine.Advertisements;

public class adsmanager : MonoBehaviour
{
    public static adsmanager I;
    string adType;
    string gameId;
    
    void Awake()
    {
        I = this;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adType = "Rewarded_iOS";
            gameId = "5339708";
        }
        else
        {
            adType = "Rewarded_Android";
            gameId = "5339709";
        }

        Advertisement.Initialize(gameId, true);
    }

    public void ShowRewardAd()
    {
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show(adType, options);
        }
    }

    void ResultAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("광고 보기에 실패했습니다.");
                break;
            case ShowResult.Skipped:
                Debug.Log("광고를 스킵했습니다.");
                break;
            case ShowResult.Finished:
                // 광고 보기 보상 기능 
                gamemanager.I.retryGame();
                Debug.Log("광고 보기를 완료했습니다.");
                break;
        }
    }
}
```
-   gamemanager.I.retryGame();
    <div class="notice--primary" markdown="1"> 

    `Gamemansger.cs -> retryGame()`
    ```c# 
    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    ```
    </div>
</div>

## `endtxt.cs`

<div class="notice--primary" markdown="1"> 

`endtxt.cs`
```c# 
using UnityEngine;
using UnityEngine.SceneManagement;

public class endtxt : MonoBehaviour
{
    public void Regame(){
        adsmanager.I.ShowRewardAd();
        // SceneManager.LoadScene("MainScene");
    }
}

```

</div>


## ID 확인
### 1. 사이트 -> Dashboard 클릭  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/e9466fd0-38f2-40a9-847e-da1412532b03){:style="border:1px solid #eaeaea; border-radius: 7px;"}   

### 2. Monetization (수익화)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/984009e8-8a14-4bd5-8d65-802801d9fd4d){:style="border:1px solid #eaeaea; border-radius: 7px;"}   
ad units 에 Android, ios ID 를 스크립트에 확인  

<br><br><br><br><br><br>
- - - 

# 6. 에셋 스토어

<h3> 무료 에셋 스토어</h3>

[무료 에셋 스토어](https://opengameart.org/)
Browse → 2D Art → CCO  
→ CC-BY , GPL , ... ⇒ 사용에 뭔가 조건이 있음  
→ CC0 ⇒ 사용에 아무런 조건이 없음  

[무료 에셋 스토어2](https://assetstore.unity.com/2d?category=2d&free=true&orderBy=1&rows=264)  

<br><br><br><br><br><br>
- - - 

# 7. 정리

[5주차정리](https://teamsparta.notion.site/5-ed804e30554b49cb834ccae4d37f1375)

<br><br>
- - - 

1회 23/06/14  
2회 23/10/27 복습, 수정  
[Unity] 게임 런칭, 광고
<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
