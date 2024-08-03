using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputs controls;

    float direction=0;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    public float moveSpeed;

    public float jumpForce;


    private void Awake()
    {
        controls = new PlayerInputs();
        controls.Enable();

        controls.Land.Move.performed += ctx => 
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
        

        
       

    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded= Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer);
        Debug.Log(isGrounded);
        playerRB.velocity = new Vector2(direction * moveSpeed *Time.deltaTime, playerRB.velocity.y);

      


        
       
    }

    void Jump()
    {   
        if(isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
        
    }
    
}
