---
title:  "[Unity] 유니티 강의 정리 ⭐⭐⭐ "
excerpt: "Sparta"

categories:
    - Sparta Unity
tags:
    - [C#, Sparta, Unity]

toc: true
toc_sticky: true
 
date: 2023-11-27 02:00

---
- - -
<BR><BR>

<center><H1> 유니티 강의 정리  </H1></center>
유니티 강의 정리
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


# 1. 단축키, 설정
> - 비쥬얼 스튜디오 단축키 ctrl k c : 주석, ctrl k u : 주석해제  
> - 유니티 씬뷰 단축키 Q W E R T   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/3d7748a0-3837-4ac6-8992-548af346a6e8){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 오브젝트 생성 시 리셋하기 습관  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/07b9ffb4-31a8-4df0-8daf-5a9194b04ba9){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
> - 텍스트 생성 시 text canvas scaler - screen size  확인   
![image](https://github.com/levell1/levell1.github.io/assets/96651722/5f7547d4-5726-413d-84f8-ec632cc7c720){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}

<br><br><br><br><br><br>
- - - 

# 2. 유니티 실행순서
> - [유니티 함수 실행 순서](https://docs.unity3d.com/kr/2021.3/Manual/ExecutionOrder.html) awake, start, fixedUpdate update ...
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br><br><br>
- - - 

# 3. Physic Material
> - rigidbody의 재질은 실질적인 재질 (보여지는 재질 x)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/9c4cdf72-980f-40ad-9a55-301399bbd2e4){:style="border:1px solid #EAEAEA; border-radius: 7px;"}
> - dynamic friction : 이미 움직이고 있을 때 마찰 0 ~ 1
> - static friction : 정지 시 마찰 0 ~ 1
> - bounciness : 1이면 에너지 손실 없이 바운스
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}
<br><br><br><br><br><br>
- - - 

# 4. Update
> - update는 프레임 단위. 다른 프레임의 화면마다 한프레임의 초가 달라진다.
> - Time.deltaTime = 1/프레임 초
> - update에서 코드에 * Time.deltaTime 로 다른 프레임의 환경에서도 동일하게 실행.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  
<br><br><br><br><br><br>
- - - 

# 5. 좌표, 벡터
> - 월드 좌표 : 전체적 좌표 기준 .Position  
> - 로컬 좌표 : 부모의 좌표 기준 .LocalPosition   
> - Vector2.normalized 크기 1로 반환 -> 대각선 움직임 시 동일한 속도로 움직이기 위해 사용
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
<br><br><br><br><br><br>
- - - 

# 6. 직렬화

> - [Header("제목")]  `제목정하기`  
> - [SerializeField] -> private일 때 인스펙터 뷰에 보이게  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/83fca96d-923e-4232-bda8-e30c2bfb36bc){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
<div class="notice--primary" markdown="1"> 

```c# 
[Header("헤더 사용")]
public int a = 0;
public int b = 0;
[Header("seriallizefield, private")]
[SerializeField] private int c = 0;
```
</div>
<br><br><br><br><br><br>
- - - 

# 7. 이동 INPUT 패키지
> - input 패키지 사용해서 캐릭터 이동 코드 event Action 구독 호출 패턴 캡처  
> - MOVE -> 키보드 W A S D 로 INPUT을 받아 OnMove 실행
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  
<div class="notice--primary" markdown="1"> 

```c# 
public void OnMove(InputValue value) // 
{       
    Vector2 moveInput = value.Get<Vector2>();
    CallMoveEvent(moveInput);
    
}
```
</div>

![input](https://github.com/levell1/levell1.github.io/assets/96651722/e0adebd0-ee00-4445-8521-7c65009fe3ce)

<br><br>
- - - 

[C#] 유니티

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)  [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
