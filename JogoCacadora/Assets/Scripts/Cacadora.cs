using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacadora : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    private Animator anim;
    
    void Start()
    {
      rig = GetComponent<Rigidbody2D>();  
      anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Move();
        Jump();
        
    }
    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
        }

         if(Input.GetAxis("Horizontal") < 0f)
        {
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,180f,0f);
        }

         if(Input.GetAxis("Horizontal") == 0f)
        {
        anim.SetBool("walk", false);
        }
    }
    void Jump(){
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        anim.SetBool("jump", true);
        isJumping = true; 
                
        }
        
}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;

        }
    }
}
