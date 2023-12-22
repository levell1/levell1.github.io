---
title:  "[TIL] 39 3D 강의, 팀과제  ⭐⭐ "
excerpt: "Sparta"

categories:
    - Til
tags:
    - [Unity, Sparta, TIL]

toc: true
toc_sticky: true
 
date: 2023-12-19 02:00

---
- - -


`MaterialPropertyBlock`

<BR><BR>


<center><H1>  유니티 숙련주차 10일차, 팀과제 </H1></center>

&nbsp;&nbsp; [o] 알고리즘 문제  - 46  
&nbsp;&nbsp; [o] 강의 듣기 - 2개 복습하기  
&nbsp;&nbsp; [X] 다른반 강의 듣기    
&nbsp;&nbsp; [X] 다른반 발표 보기  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br><br><br><br>
- - - 


# 1. 팀과제 
> - 원거리 죽으면 3마리로 리스폰  
> - 체력바  
> - 버그수정   
> - 추가) hp바 커서 시 
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

# 2. MaterialPropertyBlock

<div class="notice--primary" markdown="1"> 

```c#
private MeshRenderer[] meshRenderers;

IEnumerator DamageFlash()
{

    MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
    for (int x = 0; x < meshRenderers.Length; x++) {
        meshRenderers[x].material.color = new Color(1.0f, 0.6f, 0.6f);

        /*meshRenderers[x].GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", new Color(1.0f, 0.6f, 0.6f));
        meshRenderers[x].SetPropertyBlock(propBlock);*/
    }

    yield return new WaitForSeconds(0.4f);
    for (int x = 0; x < meshRenderers.Length; x++) {
        meshRenderers[x].material.color = Color.white;

       /* meshRenderers[x].GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", Color.white);
        meshRenderers[x].SetPropertyBlock(propBlock);*/
    }
}

```
</div>


<br><br><br><br><br>
- - - 

# 잡담,정리
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice--success}  

<br><br>
- - -

<br>

참고 : [유니티](https://docs.unity3d.com/kr/)
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
