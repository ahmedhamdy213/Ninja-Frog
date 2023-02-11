using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D Coll;
    private SpriteRenderer Sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;  
    private float driX = 0f;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpforce = 14f;
    private enum MovmentState { idle,running,jumping,falling }
    [SerializeField] private AudioSource jumpSoundeffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Coll = GetComponent<BoxCollider2D>();
        Sprite = rb.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    private void Update()
    {
        driX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(driX * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")&& IsGrounded()) 
        {
            jumpSoundeffect.Play();
           rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        
        }
      UpdateAnimationUpdate();
    }
    private void UpdateAnimationUpdate()
    {
        MovmentState state;
        if (driX > 0f)
        {
            state = MovmentState.running;
            Sprite.flipX = false;
        }
        else if (driX < 0f)
        {
            state = MovmentState.running;
            Sprite.flipX= true;
        }
        else
        {
            state = MovmentState.idle;
        }
        if (rb.velocity.y > .1f) 
        {
            state = MovmentState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovmentState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
        private bool IsGrounded()
        {
          return Physics2D.BoxCast(Coll.bounds.center, Coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }
}
