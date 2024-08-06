using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputs controls;

    float direction=0;

    bool isGrounded;

    public bool canKick;

    private GameObject ball;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    public Animator anim;
    public float moveSpeed;

    public float jumpForce;

    public float kickForce;


    private void Awake()
    {
        controls = new PlayerInputs();
        controls.Enable();

        controls.Land.Move.performed += ctx => 
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
        
        controls.Land.Kick.performed +=ctx => Kick();
        
       

    
    }
    // Start is called before the first frame update
    void Start()
    {
       ball= GameObject.FindGameObjectWithTag("Ball"); 
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded= Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer);
        if(direction>0) //mi sto muovendo verso destra
        {
            anim.SetFloat("speed", moveSpeed);
        } else if(direction<0) {
            anim.SetFloat("speed", -moveSpeed);
        }
        playerRB.velocity = new Vector2(direction * moveSpeed *Time.deltaTime, playerRB.velocity.y);

        if(direction==0)
        {
            anim.SetFloat("speed", 0);
        }
    }

    void Jump()
    {   

        anim.SetTrigger("jump");
        if(isGrounded)
        {
            
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
        
    }

    void Kick()
    {
        anim.SetTrigger("kick");

        if(canKick)
        {   
            Vector2 pos= (transform.position - ball.transform.position).normalized;
            ball.GetComponent<Rigidbody2D>().AddForce(-pos * kickForce, ForceMode2D.Impulse);
        }
    }
    
}
