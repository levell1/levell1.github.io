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

`physic Material`, `Update`, `Methf`, `Input`, `Instantiate`,  `TileMap`타일맵

<center><H1> 유니티 강의 정리  </H1></center>
유니티 강의 정리
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}

<br><br><br><br><br><br>
- - - 


# 1. 단축키, 설정
> - 비쥬얼 스튜디오 단축키 ctrl k c : 주석, ctrl k u : 주석해제  
> - ctrl R R 참조된 이름 한번에 바꾸기
> - awake 에서 GetConponent 컴포넌트들의 준비
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

<br><br><br><br><br><br>
- - - 

# 8. 타일맵 
> - 이미지 팔레트에 드래그
> - tilemap 종류별로 생성 후 그리기
> - tilemap Collider 컴포넌트 확인
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}   
[타일맵](https://levell1.github.io/go%20unity/GoUnity11/)    
[docs](https://docs.unity3d.com/kr/2022.1/Manual/Tilemap-CreatingTiles.html)  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/2da4e65c-bec4-44ae-9b32-b5e1f4a6b2de)

<br><br><br><br><br><br>
- - - 

# 9. 각도, mathf

<div class="notice--primary" markdown="1"> 

`RotaeArm`
```c# 
private void RotaeArm(Vector2 direction)
{
    float rotZ = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

    armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
    characterRenderer.flipX = armRenderer.flipY;
    armPivot.rotation = Quaternion.Euler(0,0,rotZ);
}
```
</div>

Atan2(y,x) -> y,x tan 를 이용하여 각도 값 구하기(0~3.14)    
mathf.Rad2Deg 를 곱해주면 우리가아는 0 ~ 180도 로 변환된다.    
mathf.abs -> 절대값  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

flipx => x뒤집기  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/ec509a1f-e269-482b-9691-a990b7ebb712){:style="border:1px solid #EAEAEA; border-radius: 7px;"}  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## mathf

<div class="notice--primary" markdown="1"> 

`mathf`
```c# 
// 절댓값
Mathf.Abs(float num) 

// min(최소값)과 max(최대값) 범위 안에서 value값을 반환해준다.
Mathf.Clamp(float num, float min, float max)    

// value값이 Max(최대값)에 도달하게 되면 -값이 되고 0이 되면 다시 Max(최대값)까지 +
Mathf.PingPong(float value, float Max)

// 올림 버림 반올림
Mathf.Cell(float num)
Mathf.Floor(float num)
Mathf.Round(float num)

//시작점(from)과 종료점(to) 사이의 보간값(0과 1사이의 실수값)(t)에 해당하는 값을 반환
// 값을 부드럽게 변환
Mathf.Lerp(float from, float to, float t)

//lerp와 비슷하지만 가속도가 있다.
Mathf.SmoothStep(float from, float to, float t)

```
</div>

<br><br>

# 10. Instantiate

Instantiate(prefab, transform 부모) 부모 아래에 생성  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/37fb0d34-5dd7-40a2-aaed-d3ee2d7a2f2d)    

<br>

Instantiate(prefab, Vector Position, rotation)  부모x 생성
![image](https://github.com/levell1/levell1.github.io/assets/96651722/8c53aa89-9211-446c-9469-6472909aea29)  

<br><br>
- - - 

[C#] 유니티

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)  [C#](https://learn.microsoft.com/ko-kr/dotnet/csharp/)  

[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
