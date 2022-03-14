using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathclip;
    public float jumpforce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigdbody;
    private Animator animator;
    private AudioSource playerAudio;



    private void Start()
    {
        //게임 오브젝트로 부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigdbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (isDead)
        {
            return;

        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            //점프직전에 속도를 순간적으로 제로(0,0)로 변경
            playerRigdbody.velocity = Vector2.zero;
            //리지드바디에 위쪽으로 힘주기
            playerRigdbody.AddForce(new Vector2(0, jumpforce));
            //오디오 소스 재생
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigdbody.velocity.y > 0)
        {
            //마우스 왼쪽 버튼에서 손을 때는 순간&& 속도의 Y값이 양수라면(위로 상승)
            playerRigdbody.velocity = playerRigdbody.velocity * 0.5f;
        }
        //애니메이터의 Grounded 파라미터를  is Grounded값으로 갱신
        animator.SetBool("Grounded", isGrounded); 
    }
    private void Die()
    {
        animator.SetTrigger("Die");
        //애니메이터의 Die 트리거 파라미터를 셋(Set)
        playerAudio.clip = deathclip; // 오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.Play(); //사망 효과음 재싱

        playerRigdbody.velocity = Vector2.zero;
         isDead = true; // 사망 상태를 ture로 변경

        Gamemanager.instance.OnplayerDead();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead) 
        Die();
        //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die()실행
       else if (other.tag == "Thorn"&& !isDead)
        {
            
                if (Gamemanager.instance.crash() == true) Die();
            

            
           
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f) // 어떤 콜라이더와 (처음)닿았으며, 충돌표면이 위쪽을 보고 있으면
        {
            isGrounded = true; // is Grounded 를 Ture로 변경하고, 누적 점프  횟수를 0으로 리셋
            jumpCount = 0; //


        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }













}
