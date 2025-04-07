---
title:  "[Unity 강의] 뱀서라이크 강의 정리"
excerpt: ""

categories:
    - Class VamSurLike
tags:
    - [C#, Unity, VamSurLike]

toc: true
toc_sticky: true
 
date: 2025-04-01 08:00

---
- - -

`1 ~ 3 유니티 기초` `4 ~ 8 오브젝트와 데이터` `9 ~ 12 보석과 스킬 ` `13 ~ 16 보스와AI ` `17 ~ 19 마무리` `부록`

<br>
- - - 

# 1강 (유니티 기초)
✔ 게임 오브젝트 - 컴포넌트의 통신, 게임 오브젝트 - 게임 오브젝트 간의 작용  
✔ 게임 오브젝트 - 게임 오브젝트 간의 작용 (SerializeField, Find(사용 X))  
✔ 상속 활용하기.
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 2강 (컨텐츠 기초)
✔ 리소스 관리  
✔ SceneManager  
✔ 카메라 = LateUpdate  
✔ normalized 방향 정보  
✔ Prefabs 작업 시 override 체크  
✔ 배경 작업할 때 - Order in Layer 규칙 정하기.  
✔ 리소스 관리 규칙 정하기(오브젝트별, 폴더 분류)  
✔ 게임 플레이에 따라 순차적으로 작업 (플레이어 이동 -> 스킬 -> 드랍)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 3강 (조이스틱)
✔ 게임 오브젝트 - 컴포넌트의 연결 좋은 방법으로 고민하기.(Find, Manager 사용)  
✔ Canvas Scaler - UI Scale Mode -> Scale With Screen Size (화면크기에 맞게 UI 조정 )  
✔ Raycast Target 체크 확인  
✔ magnitude = vector의 크기(거리)  
✔ Static - 객체랑 무관하다. (종속X) Static에 관하여 공부.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 4강 (매니저)
✔ 설계적인 부분을 생각하며 만들자.  
✔ 오브젝트 간 연결 - 코드에서 관리   
✔ 최상위 매니저(싱글톤) - MonoBehaviour - 다른 매니저를 들고 있는  
✔ 하위 매니저 - 일반 클래스로 (MonoBehaviour X)  
✔ 델리게이트 공부하기  
✔ [Manager](https://levell1.github.io/class%20vamsurlike/VamClass04/#1-manager)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐⭐ 5강 (Addressable) ⭐⭐
[Addressable](https://levell1.github.io/class%20vamsurlike/VamClass05)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 6강 ObjectManager, Controller(충돌, 데미지) ⭐
[ObjectManager, Controller](https://levell1.github.io/class%20vamsurlike/VamClass06)  
✔ 게임에 등장하는 물체들 관리 (Player, Monster, Projectile)  
✔ 자료구조 어떤 걸로 오브젝트들을 관리할지  
✔ **Transform.Position** VS **MovePosition**
✔ ID를 string, int로 할지  
✔ 데미지관리 코드는 주는 쪽에서 코드로 관리 상황에 맞게   
✔ as T , virtual, Init
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 7강 PoolManager ⭐
[PoolManager](https://levell1.github.io/class%20vamsurlike/VamClass07)  
✔ Instantiate는 자주 사용 시 성능 문제가 발생할 수 있다.  
✔ 게임 오브젝트를 Destroy 하지 않고 비활성화하고 남겨둔다.  
✔ 필요할 때 Instantiate를 하지 않고 숨겨둔 오브젝트를 활성화시켜서 보여준다.  
✔ ObjectPool`<T>`()  
✔ ObjectPool로 몬스터 생성, 삭제 과정  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 8강 DataManager, Xml ⭐
[DataManager](https://levell1.github.io/class%20vamsurlike/VamClass08)  
✔ Data 설계 중요  (내가 생각한 대로 되려면 데이터를 어떻게 설계해야 할지 많이 생각해 보고 프로젝트에 적용하기.)  
✔ 하드코딩, AI, TemplateID 등 => 데이터로 빼서 사용  
✔ JSON XML 비교  
✔ 엑셀파일로 원본 데이터를 만든 후 json이나 xml로 변환해 사용한다.  
✔ c# - 데이터 파싱이 다른 언어 에비해 좋다.  
✔ XML 변환 과정  
✔ DataManager.Init에서 PlayerDic = `LoadXml<Data.PlayerDataLoader, int, Data.PlayerData>("PlayerData.xml").MakeDict();`  
1.&nbsp;&nbsp;✔ `LoadXml<>()`을 호출하여 PlayerData.xml을 PlayerDataLoader 객체로 변환  
2.&nbsp;&nbsp;✔ `MakeDict()`를 호출하여 `List<PlayerData>`를 `Dictionary<int, PlayerData>`로 변환  
3.&nbsp;&nbsp;✔ 최종적으로 PlayerDic에 level을 key로 데이터들 저장  
✔ Addressable로 Prefabs를 로드하는 것처럼 라델로 Data로드  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 9강 아이템 드롭
[아이템 드롭](https://levell1.github.io/class%20vamsurlike/VamClass09)  
✔ 스프라이트(드롭템) 작업 전 addressable 관리  
✔ 스프라이트 -> 어드레서블 - sprite가 아니라 png(texture2d)고 내부에 있다.  
✔ 로드 부분(LoadAsync)에서 texture2d가 아닌 sprite의 키값을 불러오기 위한 코드필요  
✔ 어드레서블 라벨을 preload로 시작 전 로드할 것을 묶어 로드   
✔ 오브젝트 풀 에러가능성  
✔ 위에서부터 순차적으로 그리기  
&nbsp;&nbsp;edit - Project Setting - Graphics - Transparency SortMode(Custrom Axis) - x: 0 y:1 z :0  
✔ extension 확인  
✔ 드롭 템 간의 order in layer 규칙 필요   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 10강 아이템 줍기(그리드) ⭐
[아이템 줍기(그리드)](https://levell1.github.io/class%20vamsurlike/VamClass10)  
✔ 메모리 효율을 위해 게임 내 모든 오브젝트를 표시하지 않고 주변 영역의 오브젝트만 표시하기 위한 최적화  
✔ Grid를 이용해 월드 좌표를 그리드 좌표로 변경하고 관리   
&nbsp;&nbsp;`Dictionary<Vector3Int, Cell> _cells = new Dictionary<Vector3Int, Cell>();`  
✔ Cell(칸)에 있는 모든 오브젝트들을 Hashset을 이용하여 관리  
&nbsp;&nbsp;`public HashSet<GameObject> Objects { get; } = new HashSet<GameObject>();`  
✔ 탐색하고자 하는 위치에서 range 범위까지의 셀들 중 물체가 있는 모든 셀 탐색  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 11강 스킬(데이터)
[스킬(데이터)](https://levell1.github.io/class%20vamsurlike/VamClass11)  
✔ 피격 판정 어떻게 할 것인가?  
✅ 싱글게임 - 스킬 쓸 때 판정 범위를 켜 범위에 있으면 대미지  
✅ 온라인게임 - 서버에서 계산해서 판정  
✔ 스킬 데이터 설계도 중요하다 (어렵다)  
✔ 정해진 규칙이 없어 게임마다 다르다.  
✔ 스킬업 시 대미지만 변경? 스킬이 업그레이드된다? nextSkillID?  
✔ 스킬에 대한 정보가 많아지면 복잡해진다 -> 계층구조로 세분화  
✔ 필요한 데이터만 받고 조립할 수 있는 데이터는 조립  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br>

# ⭐ 12강 스킬(투사체) ⭐ 
[스킬(투사체)](https://levell1.github.io/class%20vamsurlike/VamClass12)  
플레이어 생성 시 x초마다 투사체 발사 (코루틴)  
투사체 - 몬스터 충돌(Trigger), 투사체 스폰, 디스폰  
**투사체 스킬 구성**   
🔹 투사체를 발사한 객체 : _owner  
🔹 투사체의 방향 : _moveDir  
🔹 투사체 속도 : _speed  
🔹 투사체 지속시간 : _lifeTime  
✅ 초기화하는 코드 Init()  
✅ SET 코드 (정보를 세팅하는) (🔹위 4개를 세팅)  
✅ OnTriggerEnter2D 몬스터 Trigger 시 대미지, Despawn   
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 13강 스킬 맵(무한맵) 개선 ⭐ 
[스킬 맵(무한맵) 개선](https://levell1.github.io/class%20vamsurlike/VamClass13)  
✔ 코드 개선  
✔ 평타스킬 추가  
✔ 몬스터 스폰위치 설정  
✔ typeof(T).IsSubclassOf(typeof(SkillController))  
✔ **무한맵** - X(4) 개의 map을 플레이어 위치에 따라 위치 변경해서 무한처럼 만든다. (방법은 다양)  
✔ 상대에게 충돌 범위를 없애면 무적이 될 수 있다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 14강 UI ⭐ 
[UI](https://levell1.github.io/class%20vamsurlike/VamClass14)  
✔ UI배치, 몬스터 처치 시 UI변경, 경험치 Slider 변경, 레벨업 시 Popup표시  
✔ UI작업 시 주의점  
✔ UI Prefab - Script 1:1 대응되도록 하나의 스크립트로 내부 ui 관리  
✔ POP UP - Stack으로 키고 끄는 관리  
✔ UI에서 게임 중 변화되는 부분 확인, 체크 - Script 1개로 관리   
✔ UI 코드 보기  
🔹 UI 갱신 흐름  
1.&nbsp;Player,MonsterController에서 GameManager의 데이터 변경 시도.  
2.&nbsp;GameManager - 데이터의 set 부분의 구독된 이벤트들 호출  
3.&nbsp;GameScene에서 미리 구독된 Handler의 실행  
4.&nbsp;데이터에 맞게 UI 변경  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# ⭐ 15강 UI(2) ⭐ 
[UI(2)](https://levell1.github.io/class%20vamsurlike/VamClass15)  
✔ UI_SkillSelectPopup, UI_SkillCardItem 작업   
✔ Horizontal Layout Group를 이용한 UI 배치  
✔ Button - Onclick을 사용한 함수 실행.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>

# ⭐ 16강 보스 ,AI(상태패턴) ⭐
[보스 ,AI(상태패턴)](https://levell1.github.io/class%20vamsurlike/VamClass16)  
✔ 보스 추가  
✔ 코드 수정, 추가  
🔹 GameScene.cs => 조건(목표 킬 달성) -> 필드 내 몬스터 디스폰, 일반 몹 스폰 x, 보스 생성  
🔹 ObjectManager => 몬스터 소환(일반 몹 ~ 보스 몹) 수정, DespawnAllMonsters() 추가  
🔹 MonsterController => 상태 패턴 추가.  
🔹 BossController => 상태로 보스 관리 (Idle, Moving, Skill, Dead)  
✔ 애니메이션 - Sprite들을 여러 개 드래그해서 Hierarchy에 올리면 자동으로 만들어진다.  
✔ 보스 어드레서블 등록하면 포함된 애니메이션도 포함되어 등록된다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>

# ⭐ 17 스킬 개선 ⭐
[스킬 개선](https://levell1.github.io/class%20vamsurlike/VamClass17)  
✔ FireBall.cs 추가 - 파이어볼을 주기적으로 생성하는 cs  
✔ EgoSword - Rigidbody2D.simulate를 고쳐서 키고 끄던 부분 -> 파티클 시스템 옵션 변경  
&nbsp;&nbsp; Play On Awake, Stop Action으로 키고 끄는 방식  
&nbsp;&nbsp; EgoSwordChild 코드 삭제, Rigidbody2D 제거.  
🔹 PlayerController - 스킬 관련 삭제 -> Skillbook으로, init에서 스킬 생성, 스킬에서 써야 할 변수 프로퍼티  
🔹 CreatureController init() -> 스킬북 addcomponent  
🔹 SkillBook 추가 스킬들 관리, Player에 컴포넌트 추가  
🔹 RepeatSkill.cs 추가  
🔹 FireBall.cs 추가 - 파이어볼을 생성  
🔹 Egosword 수정 파티클 시스템에서 onoff , EgoswordcHILD 삭제- Egosword에서 관리  
🔹 SkillController -> SkillBase  
🔹 Define -> 스킬 타입 반복 스킬, 엑티브 스킬   
✅ **Player - Init()이 두 번 실행**  
&nbsp;&nbsp; 스킬들 2개씩 생성  
&nbsp;&nbsp; Player init 2번 => 1번으로 수정 ObjectManager - 스폰 후 init 제거  
✅ **FireProjectile 삭제 안되는 오류**  
&nbsp;&nbsp; SkillBase에서 상속받은 것을 사용하려고 하니까  
&nbsp;&nbsp; objectManager.Despawn 코드까지 실행이 되는데 ProjectileController, SkillBase 타입 관련해서 문제가 있는 것 같다.  
✅ **pool에 들어갔다가 나오면 코루틴 stop 되어서 다시 삭제가 안 되는 부분**  
&nbsp;&nbsp; oOnenable로 코루틴 실행  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>

# ⭐ 18 보스 스킬 개선 ⭐
[보스 스킬 개선](https://levell1.github.io/class%20vamsurlike/VamClass18)  
✔ Sequence 스킬 - Move, Dash 추가  
✔ SkillBook - Sequence 스킬 목록을 순서대로 발동  
✔ Move - Target을 향해 X 초 움직이는 코드  
✔ Dash - Target을 향해 돌진  
✔ BossController - 이동 부분 없애고 -> SequenceSkill로  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>

# ⭐⭐⭐ 19 UI 개선 자동화 ⭐⭐⭐
[UI개선](https://levell1.github.io/class%20vamsurlike/VamClass19)  
✔ Enum, Type, `Dictionary<Type, UnityEngine.Object[]>`를 이용해 효율적인 UI 관리  
✔ 드래그 앤 드롭 대신 Enum, Find로 자동화  
✅ Bind - UI 코드에서 Enum으로 분류된 UI 이름으로 된 정보를 가져와 _objects에 FindChild를 이용해 찾아서 추가한다.  
✅ Get - 어떤 UI를 변경하고자 할 때 그 UI를 _objects에서 가져온다.  
✅ BindEvent - EventHandler를 통해 Onclick, drag 등 이벤트를 적용한다.  
🔹 Extension - BindEvent (Button의 gameobject에BindEvent() 확장 메서드 추가 )  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br><br>

# 부록 게임서버
✔ 게임서버 - 데이터를 계속 주고 받는 양방향  
✔ Java - Spring  
✔ JS - Node.JS  
✔ C# - ASP.NET  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<br><br><br>
- - - 

# 잡담, 일기?
코드 기본 구성  
✅ 초기화하는 코드 Init()   
✅ SET 코드 (정보를 세팅하는)  
✔ 데이터 로드 더 공부    
✔ Grid 더 알아보기  
프로젝트 작업 순서.  
1.&nbsp;  
2.&nbsp;  
**투사체 스킬 구성**   
🔹 투사체를 발사한 객체 : _owner  
🔹 투사체의 방향 : _moveDir  
🔹 투사체 속도 : _speed  
🔹 투사체 지속시간 : _lifeTime  
✅ 초기화하는 코드 Init()  
✅ SET 코드 (정보를 세팅하는) (🔹위 4개를 세팅)  
✅ OnTriggerEnter2D 몬스터 Trigger 시 대미지, Despawn  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -