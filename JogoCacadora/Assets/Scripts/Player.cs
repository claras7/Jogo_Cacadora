using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    
    private Rigidbody2D rig;
    private Animator anim;
    public AudioSource audioSourceJump;
    public AudioSource audioSourceWalk;
    public AudioSource audioSourceAttack;

    
    void Start()
    {
      rig = GetComponent<Rigidbody2D>();  
      anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
        Jump();
        Attack();
        
    }
     // Método andar
    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
        Debug.Log("Andando!");
        if (!audioSourceWalk.isPlaying) audioSourceWalk.Play();
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
        }

         if(Input.GetAxis("Horizontal") < 0f)
        {
        Debug.Log("Andando!");
        if (!audioSourceWalk.isPlaying) audioSourceWalk.Play();
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,180f,0f);
        }

         if(Input.GetAxis("Horizontal") == 0f)
        {
        anim.SetBool("walk", false);
        }
    }

    // Método Pulo
    void Jump()
{
    if (Input.GetButtonDown("Jump"))
    {
        if (!isJumping) 
        {
            Debug.Log("Pulo!");
            audioSourceJump.Play();
            rig.velocity = new Vector2(rig.velocity.x, JumpForce);
            isJumping = true;
            
            anim.SetBool("jump", true);
        }
        
    }
}
    // Método ataque
    void Attack()
{
    if(Input.GetKeyDown(KeyCode.Z))
    {
    Debug.Log("Ataque!");
    anim.SetBool("attack", true);
    Invoke("PlayAttackSound", 0.49f);
    Invoke("ResetarAtaque", 1.3f);
    
    }
}

    // Atrasar o audio ataque
    void PlayAttackSound()
{
    audioSourceAttack.Play();  
}

    // Resetar ataque
    void ResetarAtaque()
{
    anim.SetBool("attack", false);
}

// Resetar isJumping quando tocar no chão
void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) 
    {
        isJumping = false;
        anim.SetBool("jump", false);
    }
}
    
        
    void OnCollisionExit2D (Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;

        }
    }

}