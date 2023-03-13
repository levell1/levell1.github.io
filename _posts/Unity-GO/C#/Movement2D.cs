using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private float               moveSpeed = 3;      //속도
    [SerializeField]
    private float               junpForce = 8.0f;   //점프 힘
    [HideInInspector]
    public bool                 isLongJump = false; //점프높이구분
    [SerializeField]
    private LayerMask           groundLayer;        //바닥 체크를 위한 충돌레이어
    private CircleCollider2D    circleCollider2D;   //오브젝트의 충돌 범위 컴포넌트
    private bool                isGrounded;         //바닥체크
    private Vector3             footposition;       //발의 위치

    [SerializeField]
    private int                 maxJumpCount = 2;
    private int                 currentJumpCount= 0;
    

    private Rigidbody2D rigid2D;
    private void Awake() {
        rigid2D             = GetComponent<Rigidbody2D>();
        circleCollider2D    = GetComponent<CircleCollider2D>();
    }
    private void FixedUpdate() {
        if(transform.position.y < -4){
            transform.position = new Vector3(0,0,0);
        }
        // 플레이어 오브젝트의 collider2d min, center, max 위치 정보
        Bounds bounds   = circleCollider2D.bounds;
        // 플레이어의 발 위치 설정
        footposition    = new Vector2(bounds.center.x,bounds.min.y);
        // 플레이어의 발 위치에 원을 생성하고, 원이 바닥과 닿아있으면 isGrounded = true
        isGrounded      = Physics2D.OverlapCircle(footposition,0.1f, groundLayer);
        
        // 땅에 있고, y축 속도가 0이하이면 점프 횟수 초기화
        // velocity.y <= 0을 추가 하지 않으면 점프키를 누르는 순간에도 초기화가 되어
        // 최대 점프 횟수를 2로 설정하면 3번까지 점프한다.
        if (isGrounded ==true && rigid2D.velocity.y<=0)
        {
            currentJumpCount = maxJumpCount;
        }
        // 낮은 점프, 높은 점프 구현을 위한 중력 계수(gravityScale) 조절 (jump up일 때만 적용)
        // 중력 계수가 낮은 if문은 높은 점프가 되고, 중력 계수가 높은 else 문은 낮은 점프가 된다
        if ( isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }
    private void Update() {
        
        // //transform.position = transform.position + new Vector3(1,0,0)*speed;
        // //transform.position += Vector3.right * speed * Time.deltaTime;
        // float x = Input.GetAxisRaw("Horizontal");   //좌우      이동
        // // Negative Left , a : -1
        // // Positive Right , d : 1
        // // Non : 0

        // float y = Input.GetAxisRaw("Vertical");     //위아래    이동
        // // Negative Donw , S : -1
        // // Positive UP , W : 1
        // // Non : 0

        // // 이동방향 설정
        // //moveDirection = new Vector3(x,y,0);

        // // 새로운위치 = 현재 위치 + (방향 * 속도)
        // // transform.position += moveDirection* moveSpeed * Time.deltaTime;
        // //rigid2D.velocity = new Vector3(x,y,0) * moveSpeed;
    }
    public void Move(float x){
        // x축은 속도, y축은 기존 속력 값(중력)
        rigid2D.velocity = new Vector2(x*moveSpeed,rigid2D.velocity.y);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footposition, 0.1f);
    }
    
    public void jump(){
        //if (isGrounded == true)
        if (currentJumpCount > 0)
            {
            // jump force의 크기만큼 위쪽 방향으로 속력 설정
            rigid2D.velocity = Vector2.up * junpForce;
            currentJumpCount --;
            }
        }
}