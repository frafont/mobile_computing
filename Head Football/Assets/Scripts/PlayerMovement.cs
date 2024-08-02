using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputs controls;

    PlayerInputs jump;

    float direction=0;

    float vertical=0;

    public Rigidbody2D playerRB;
    public float moveSpeed;

    public float jumpForce;

    public bool canJump;

    private void Awake()
    {
        controls = new PlayerInputs();
        controls.Enable();

        controls.Land.Move.performed += ctx => 
        {
            direction = ctx.ReadValue<float>();
        };

        jump = new PlayerInputs();
        jump.Enable();

        jump.Land.Jump.performed += cty =>
        {
            vertical= cty.ReadValue<float>();
        };

    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(direction * moveSpeed *Time.deltaTime, playerRB.velocity.y);

      


        if(Input.GetKeyDown(KeyCode.Space))
        {
             playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
        }
        
          
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump= true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            canJump= false;
        }
    }
    
}
