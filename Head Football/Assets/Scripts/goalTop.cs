using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goalTop : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject ball;
    // Start is called before the first frame update

    void Awake(){
        audioManager =GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        ball= GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {   
            audioManager.PlaySFX(audioManager.bars);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }
}
