using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject player, enemy;
    // Start is called before the first frame update
    void Start()
    {
       player= GameObject.FindGameObjectWithTag("Player"); 
       enemy= GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            player.GetComponent<PlayerMovement>().canKick = true;
        }

        if(collision.gameObject.tag =="Enemy")
        {
            enemy.GetComponent<AI>().canKick_AI = true;
        }

        if(collision.gameObject.tag =="canHeadAI")
        {
            enemy.GetComponent<AI>().canHead_AI = true;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            player.GetComponent<PlayerMovement>().canKick = false;
        }
        if(collision.gameObject.tag =="Enemy")
        {
            enemy.GetComponent<AI>().canKick_AI = false;
        }
        if(collision.gameObject.tag =="canHeadAI")
        {
            enemy.GetComponent<AI>().canHead_AI = false;
        }
    }
}
