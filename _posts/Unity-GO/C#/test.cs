using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //처음
    private void Awake(){
        Debug.Log("오브젝트가 처음실행될 때");
    }
    private void Start(){
        Debug.Log("오브젝트속 스크립트 첫 실행");
    }
    private void Onenable(){
        Debug.Log("오브젝트가 실행될 때마다");
    }

    //초기화
    private void Update(){
        Debug.Log("프레임마다 호출");
    }
    private void LateUpdate(){
        Debug.Log("update 이후 실행");
    }
    private void FixedUpdate(){
        Debug.Log("프레임영향을 받지않고 일정간격 호출");
    }

    //파괴,종료
    private void OnDestroy(){
        Debug.Log("오브젝트 파괴될 때 호출");
    }
    //
    private void OnApplicationQuit(){
        Debug.Log("게임이 종료될 때 1회 (오브젝트가 활성화 되어있어야)");
    }
    private void OnDisable(){
        Debug.Log("컴포넌트가 비활성화 될 때마다 ");
    }
}
