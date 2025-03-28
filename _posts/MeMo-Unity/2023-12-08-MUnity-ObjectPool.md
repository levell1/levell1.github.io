---
title:  "[Memo-Unity] 10. 오브젝트 풀(ObjectPool)"
excerpt: ""

categories:
    - MeMo Unity
tags:
    - [C#, MeMo Unity]

toc: true
toc_sticky: true
 
date: 2023-12-08 02:11

---
- - -
<BR><BR>

오브젝트 풀(ObjectPool)

<center><H1> 오브젝트 풀(ObjectPool) </H1></center>

<br><br><br><br><br><br>
- - - 

# 오브젝트 풀
프리팹 -> 인스턴스화 setactive.False -> 오브젝트풀 -> 활성화 -> 실제 오브젝트 -> 사용한 오브젝트 false -> 다음에 재사용  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**이유** : 성능향상, 메모리 관리  
**활용** : 총알, 적 캐릭터  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 1) 미리 생성하는 방식 
문제점 오브젝트 생성할때 너무 많으면 로딩이 오래걸릴 수 있다.    
<div class="notice--primary" markdown="1"> 

```c# 
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize;

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }
}

```

</div>

오브젝트를 다 썻는데 더 필요할 때 오래된걸 지우고 가져오기.  
dequeue(오래된거 뺴기) -> enqueue(다시 pool)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

## 2) 동적 오브젝트 풀 

<div class="notice--primary" markdown="1"> 

```c# 
public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize; // 100
    public int maxPoolSize; // 10000

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if (objectPool.Count < maxPoolSize)
        {
            GameObject obj = Instantiate(prefab, transform);
            objectPool.Add(obj); 
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // 풀에 더 이상 생성할 수 없음
            return null;
        }
    }
}

```

</div>

## 3) Objectpool() 유니티에서 제공하는 클래스
Objectpool()  
![image](https://github.com/levell1/levell1.github.io/assets/96651722/1ccfec3e-1679-477d-9c19-43006778c5bd)  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

**Objectpool()**  

<div class="notice--primary" markdown="1"> 

```c# 
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolExample : MonoBehaviour
{
    public GameObject bulletPrefab;

    private ObjectPool<GameObject> bulletPool;

    private void Start()
    {
        bulletPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(bulletPrefab), // 오브젝트 생성 방법
            actionOnGet: (obj) => obj.SetActive(true),   // 오브젝트를 풀에서 가져올 때 실행할 액션
            actionOnRelease: (obj) => obj.SetActive(false), // 오브젝트를 풀에 반환할 때 실행할 액션
            actionOnDestroy: (obj) => Destroy(obj),     // 오브젝트를 파괴할 때 실행할 액션
            defaultCapacity: 10,                        // 초기 용량
            maxSize: 20                                 // 최대 용량
        );
    }

    public GameObject GetBullet()
    {
        return bulletPool.Get();
    }

    public void ReturnBullet(GameObject bullet)
    {
        bulletPool.Release(bullet);
    }
}
```

</div>

**언제사용?**  
오브젝트의 생성과 파괴가 계속 일어난다.  
오브젝트를 많이 생성해야된다. (30개 이상)  
생성관리를 체계적으로 하고 싶다.  
{:style="border:1px solid #EAEAEA; border-radius: 7px;"}
{: .notice}  

<br><br>
- - - 

[Unity] 오브젝트 풀(ObjectPool)  
[TOP](#){: .btn .btn--info .btn--small }{: .align-right}
<br>
- - -
