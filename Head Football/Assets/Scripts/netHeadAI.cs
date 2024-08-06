using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netHeadAI : MonoBehaviour
{

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
       ball=GameObject.FindGameObjectWithTag("Ball"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }
}
