using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class AI : MonoBehaviour
{
    AudioManager audioManager;    
    public float rangerDefence, moveSpeed, kickForce, jumpForce;
    public Transform defence;

    bool isGrounded;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private GameObject ball, player;
    private Rigidbody2D rb_AI;

    public bool canKick_AI, canHead_AI;

    public Animator anim;

    void Awake(){
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ball= GameObject.FindGameObjectWithTag("Ball");
        rb_AI =GetComponent<Rigidbody2D>();

        player= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if(GameController.instance!=null){

        
        if(GameController.instance.isScore == false && GameController.instance.EndMatch== false)
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
        else {
            anim.SetFloat("speed", 0);
        }  
        }  
    }
    

    public void Move()
    {
        if(ball.transform.position.x > transform.position.x){
            anim.SetFloat("speed", -moveSpeed);
            rb_AI.velocity= new Vector2(Time.deltaTime * moveSpeed, rb_AI.velocity.y);
        }
        else if(Mathf.Abs(ball.transform.position.x - transform.position.x) < rangerDefence)
        {
            if( Mathf.Abs(transform.position.x - ball.transform.position.x ) <= Mathf.Abs(ball.transform.position.x - player.transform.position.x)
            && ball.transform.position.y < -1f)
            {

                rb_AI.velocity= new Vector2(-Time.deltaTime *moveSpeed, rb_AI.velocity.y);
                anim.SetFloat("speed", moveSpeed);   
            }
            else 
            {
                if(ball.transform.position.x > transform.position.x && ball.transform.position.y < -2f )
            {   
               

                rb_AI.velocity= new Vector2(Time.deltaTime *moveSpeed, rb_AI.velocity.y);
                anim.SetFloat("speed", -moveSpeed);   
            }
            else if(ball.transform.position.y >= -2f && transform.position.x <= defence.position.x) {
                rb_AI.velocity= new Vector2(0, rb_AI.velocity.y);
            }
            else {
                anim.SetFloat("speed", moveSpeed);
                rb_AI.velocity= new Vector2(-Time.deltaTime *moveSpeed, rb_AI.velocity.y);
                
            }
            }
            
        }
        else
        {
            if(transform.position.x > defence.transform.position.x)
            {   
                 
                anim.SetFloat("speed",-moveSpeed);
                rb_AI.velocity= new Vector2(Time.deltaTime *moveSpeed, rb_AI.velocity.y);
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
        audioManager.PlaySFX(audioManager.kick);
        Vector2 pos= (transform.position - ball.transform.position).normalized;
        ball.GetComponent<Rigidbody2D>().AddForce(-pos * kickForce, ForceMode2D.Impulse);
        //Debug.Log("Forza AI: " + (-pos * kickForce));
        //Debug.Log("Velocità finale palla (dopo calcio IA): " + ball.GetComponent<Rigidbody2D>().velocity);
        
    }

    public void Jump()
    {
        
        if(isGrounded){
            audioManager.PlaySFX(audioManager.jump);
            anim.SetTrigger("jump");
            rb_AI.velocity = new Vector2(rb_AI.velocity.x, jumpForce);
        }
        
    }
}
