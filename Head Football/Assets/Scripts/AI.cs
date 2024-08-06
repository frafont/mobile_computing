using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float rangerDefence, moveSpeed, kickForce, jumpForce;
    public Transform defence;

    bool isGrounded;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private GameObject ball;
    private Rigidbody2D rb_AI;

    public bool canKick_AI, canHead_AI;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ball= GameObject.FindGameObjectWithTag("Ball");
        rb_AI =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(canKick_AI){
            Kick();
        }
        isGrounded= Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer);
        if(canHead_AI){
            Jump();
        }
    }
    

    public void Move()
    {
        if(Mathf.Abs(ball.transform.position.x - transform.position.x) < rangerDefence)
        {
            if(ball.transform.position.x > transform.position.x)
            {
                rb_AI.velocity= new Vector2(Time.deltaTime *moveSpeed, rb_AI.velocity.y);
                anim.SetFloat("speed", -moveSpeed);   
            }
            else {
                anim.SetFloat("speed", moveSpeed);
                rb_AI.velocity= new Vector2(-Time.deltaTime *moveSpeed, rb_AI.velocity.y);
                
            }
        }
        else
        {
            if(transform.position.x > defence.position.x)
            {   
                anim.SetFloat("speed",moveSpeed);
                rb_AI.velocity= new Vector2(-Time.deltaTime *moveSpeed, rb_AI.velocity.y);
            }
            else {
                rb_AI.velocity= new Vector2(0, rb_AI.velocity.y);
                anim.SetFloat("speed", 0);
            }
        }
    }

    public void Kick()
    {
        anim.SetTrigger("kick");
        Vector2 pos= (transform.position - ball.transform.position).normalized;
        ball.GetComponent<Rigidbody2D>().AddForce(-pos * kickForce, ForceMode2D.Impulse);
        
    }

    public void Jump()
    {
        anim.SetTrigger("jump");
        if(isGrounded){
            rb_AI.velocity = new Vector2(rb_AI.velocity.x, jumpForce);
        }
        
    }
}
