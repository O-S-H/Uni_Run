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
        //���� ������Ʈ�� ���� ����� ������Ʈ���� ������ ������ �Ҵ�
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
            //���������� �ӵ��� ���������� ����(0,0)�� ����
            playerRigdbody.velocity = Vector2.zero;
            //������ٵ� �������� ���ֱ�
            playerRigdbody.AddForce(new Vector2(0, jumpforce));
            //����� �ҽ� ���
            playerAudio.Play();

        }
        else if (Input.GetMouseButtonUp(0) && playerRigdbody.velocity.y > 0)
        {
            //���콺 ���� ��ư���� ���� ���� ����&& �ӵ��� Y���� ������(���� ���)
            playerRigdbody.velocity = playerRigdbody.velocity * 0.5f;
        }
        //�ִϸ������� Grounded �Ķ���͸�  is Grounded������ ����
        animator.SetBool("Grounded", isGrounded); 
    }
    private void Die()
    {
        animator.SetTrigger("Die");
        //�ִϸ������� Die Ʈ���� �Ķ���͸� ��(Set)
        playerAudio.clip = deathclip; // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.Play(); //��� ȿ���� ���

        playerRigdbody.velocity = Vector2.zero;
         isDead = true; // ��� ���¸� ture�� ����
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead) 
        Die();
        //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die()����

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f) // � �ݶ��̴��� (ó��)�������, �浹ǥ���� ������ ���� ������
        {
            isGrounded = true; // is Grounded �� Ture�� �����ϰ�, ���� ����  Ƚ���� 0���� ����
            jumpCount = 0; //


        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }













}
