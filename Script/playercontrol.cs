using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{

    Rigidbody2D Rg;
    public float jumpfallgravity = 2f;
    public Animator anim;
     SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    void Awake()
    {
        Rg = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
         //Jump();
        if(Input.GetButtonDown("Jump"))
        {
             Rg.velocity = Vector2.up * 7.0f;
        }
        else if (Rg.velocity.y < 0)
        {
                   Rg.velocity += Vector2.up * Physics2D.gravity.y * (jumpfallgravity - 1) * Time.deltaTime;
        }
        else if (Rg.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            Rg.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
            
        

    }

    void Jump()
    {
 
    }

    void Movement()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * 5.0f,Rg.velocity.y);
        if(movement.x < - 0.01f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        Rg.velocity = movement;
        anim.SetFloat("magnitude",Rg.velocity.magnitude);
    }

    void FixedUpdate()
    {

    }
}
