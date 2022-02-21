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

    }


    private void Update()
    {

    }
    private void Die()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }













}
