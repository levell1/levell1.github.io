---
title:  "[Unity6] 2D Behavior Tree 1( Patrol, Wait ) "
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-04-28 05:00

---
- - -


<br>
- - - 

# Behavior Tree
[Behaviour Tree Manual](https://docs.unity3d.com/Packages/com.unity.behavior@1.0/manual/index.html)  
-&nbsp;Behaviour Tree - AI 캐릭터의 행동 제어나 상태 관리를 위해 사용합니다.  
-&nbsp;Behaviour Tree는 게임 개발에서 비선형적이고, 복잡한 AI 의사 결정을 간단하게 모듈화하여 구현할 수 있게 해줍니다.  
-&nbsp;Unity6부터 Built-in으로 지원, 노드 기반으로 관리할 수 있게 제공합니다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## Node
✔ Action Node : 실제 행동을 수행하는 노드  
&nbsp;&nbsp; 트리의 하단에 위치, 에이전트가 해야 할 구체적인 작업 정의  
&nbsp;  
✔ Modifier Node : 트리의 흐름이나 실행 조건을 수정  
&nbsp;&nbsp; 특정 조건을 확인, 실행 결과를 반환  
&nbsp;  
✔ Sequencing Node : 해당 노드가 아닌 자식 노드들을 **특정 조건**에 따라 실행  
&nbsp;&nbsp; 모든 자식 노드가 성공해야 자신도 성공 상태 반환  
&nbsp;  
✔ Join Node : 여러 노드에서 발생한 결과를 결합해 행동을 결정하는 데 사용  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## 사용법
1.&nbsp;Package Manager - Behavior install  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior1.png?raw=true)  
&nbsp;  
2.&nbsp;Project - Behavior Graph 생성  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior2.png?raw=true)  
&nbsp;  
3.&nbsp;Behavior Graph 더블클릭 - 우클릭-> 노드 추가    
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## Behavior Graph
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior3.png?raw=true)  
**BlackBoard** : 사용하는 변수 목록, 기본적으로 자기 자신을 나타내는 Self 변수 생성  
&nbsp;BlackBoard에 선언한 변수는 외부에서 접근 가능하기 때문에 Insspector View에 출력되며, 스크립트에서 Get/Set 가능  
&nbsp;  
**노드 생성** : 우클릭 - Add  
&nbsp;Action -> Navigation -> Nav To Target(목표에게 이동), To Location, Patrol(순찰)을 제공  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior4.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## 순찰(Patrols)
1.&nbsp; 노드 생성 : Add -> Action -> Navigation -> Patrol  
2.&nbsp; Agent - Self 드래그  
3.&nbsp; WayPoint 설정(PatrolPoints)  
BlackBoard에 List - GameObject List 추가, 드래그  
&nbsp;  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior5.png?raw=true)  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior5_2.png?raw=true)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br>

## 대기(Patrols)
1.&nbsp; Add -> Flow -> Sequence  
2.&nbsp; Add -> Action -> Delay - Wait(Range)  
3.&nbsp; Add -> Flow -> TimeOut   
&nbsp;  
1~3초 대기 10초 순찰 반복  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior6.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  


<br><br><br><br>

# 코드

## EnemyFSM
**Prefab**  
Behavior Agent 컴포넌트 추가  
Behavior Agent Graph 등록  
&nbsp;  
**EnemyFSM**  
behaviorAgent.SetVariableValue("PatrolPoints", wayPoints.ToList());  
Behavior Graph의 Blackboard에 선언한 변수 값을 설정 (변수명 똑같이)  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior7.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<details>
<summary>EnemyFSM</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Unity.Behavior;

public class EnemyFSM : MonoBehaviour
{
	private	Transform			target;
	private	NavMeshAgent		navMeshAgent;
	private	BehaviorGraphAgent	behaviorAgent;

	public void Setup(Transform target, GameObject[] wayPoints)
	{
		this.target = target;

		navMeshAgent	= GetComponent<NavMeshAgent>();
		behaviorAgent	= GetComponent<BehaviorGraphAgent>();
		navMeshAgent.updateRotation = false;
		navMeshAgent.updateUpAxis = false;

		behaviorAgent.SetVariableValue("PatrolPoints", wayPoints.ToList());
	}
}
```
</div>
</details>

<br><br>

## EnemySpawner
EnemySpawner WayPoint 설정  
EnemySpawner 적의 스폰 가능 위치 스폰, WayPoint(순찰구역)을 정하여 Enemy 스폰.  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior8.png?raw=true)
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info} 

<details>
<summary>EnemySpawner</summary>
<div class="notice--primary" markdown="1"> 

```c# 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private	Tilemap			tilemap;
	[SerializeField]
	private	GameObject		enemyPrefab;
	[SerializeField]
	private	Transform		target;
	[SerializeField]
	private	int				enemyCount = 10;

	private	Vector3			offset = new Vector3(0.5f, 0.5f, 0);
	private	List<Vector3>	possibleTiles = new List<Vector3>();

	[System.Serializable]
	private struct WayPointData
	{
		public GameObject[] wayPoints;
	}
	[SerializeField]
	private	WayPointData[]	wayPointData;

	private void Awake()
	{
		// Tilemap의 Bounds 재설정 (맵을 수정했을 때 Bounds가 변경되지 않는 문제 해결)
		tilemap.CompressBounds();
		// 타일맵의 모든 타일을 대상으로 적 배치가 가능한 타일 계산
		CalculatePossibleTiles();

		// 임의의 타일에 enemyCount 숫자만큼 적 생성
		for ( int i = 0; i < enemyCount; ++ i )
		{
			int index	 = Random.Range(0, possibleTiles.Count);
			int wayIndex = Random.Range(0, wayPointData.Length);
			GameObject clone = Instantiate(enemyPrefab, possibleTiles[index], Quaternion.identity, transform);
			clone.GetComponent<EnemyFSM>().Setup(target, wayPointData[wayIndex].wayPoints);
		}
	}

	private void CalculatePossibleTiles()
	{
		BoundsInt	bounds	 = tilemap.cellBounds;
		// 타일맵 내부 모든 타일의 정보를 불러와 allTiles 배열에 저장
		TileBase[]	allTiles = tilemap.GetTilesBlock(bounds);

		// 외곽 라인을 제외한 모든 타일 검사
		for ( int y = 1; y < bounds.size.y-1; ++ y )
		{
			for ( int x = 1; x < bounds.size.x-1; ++ x )
			{
				// [y * bounds.size.x + x]번째 방의 타일 정보를 불러옴
				TileBase tile = allTiles[y * bounds.size.x + x];
				// 해당 타일이 비어있지 않으면 적 배치 가능 타일로 판단
				if ( tile != null )
				{
					Vector3Int	localPosition	= bounds.position + new Vector3Int(x, y);
					Vector3		position		= tilemap.CellToWorld(localPosition) + offset;
					position.z = 0;
					possibleTiles.Add(position);
				}
			}
		}
	}
}
```
</div>
</details>

<br><br><br>

# 이것저것 메모

## BehaviorGraph 정렬  
노드 위 우클릭 - Align - All Children (노드 정렬)  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/Behavior9.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 


<br><br><br>
- - - 

# 잡담, 일기?
유니티6 NavMesh, BehaviorTree  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -