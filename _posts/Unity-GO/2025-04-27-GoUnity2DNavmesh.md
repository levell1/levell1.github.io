---
title:  "[Unity6] 2D Navmesh"
excerpt: ""

categories:
    - Go Unity
tags:
    - [Unity, 고박사]

toc: true
toc_sticky: true
 
date: 2025-04-27 05:00

---
- - -


<br>
- - - 

# 2D Navmesh
[2D Navmesh 깃](https://github.com/h8man/NavMeshPlus#master)다운로드 후 프로젝트에 Import  
빈 오브젝트 NavgationSurface, NavigationCollectSources2D 컴포넌트 추가  
유니티 내장AI는 3D용으로 XZ평면이기에 NavigationCollectSources2D - Lotate Surface to XY 로 축을 변경  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/1.png?raw=true)  
&nbsp;  
BackGround(타일맵 땅 )은 이동 가능한 상태로 설정하기 위해 NavigationModifier 컴포넌트 추가  
Override Area - Area "Walkable"로 설정.  
Wall(타일맵 벽 ) 은 이동불가로 Area "Not Walkable"로 설정.  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/2.png?raw=true)  
&nbsp;  
NavgationSurface - Bake
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/3.png?raw=true)  
&nbsp;  
Enemy 오브젝트에 NavmeshAgent 컴포넌트 추가  
적들이 길을 찾아 Player를 추격합니다.  
![Image](https://github.com/levell1/levell1.github.io/blob/main/Image/Unity6_AiNav/4.png?raw=true)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--info}  

<br><br><br><br>

# 이것저것 메모

## AINav  
AI Navigation에 있는 NavMeshAgent와 자동으로 연동해 작동  
없으면 transform을 이용해 이동.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice} 


<br><br><br>
- - - 

# 잡담, 일기?
유니티6 NavMesh
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  


<br><br>
- - -