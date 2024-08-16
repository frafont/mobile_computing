using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    AudioManager audioManager;
    private GameObject player, enemy;

    public GameObject goal;
    void Awake(){
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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
        
        if(collision.gameObject.tag =="GoalEnemy")
        {   
            
            if(GameController.instance.isScore ==false && GameController.instance.EndMatch == false)
            {
                Instantiate(goal, new Vector3(-5,1,0), Quaternion.identity);
                audioManager.PlaySFX(audioManager.goal);
                GameController.scorePlayer++;
                GameController.instance.isScore= true;
                GameController.instance.ContinueMatch(true);
                
            }
        }

        if(collision.gameObject.tag =="GoalPlayer")
        {
        if(GameController.instance.isScore ==false && GameController.instance.EndMatch == false)
            {
                Instantiate(goal, new Vector3(-5,1,0), Quaternion.identity);
                audioManager.PlaySFX(audioManager.goal);
                GameController.scoreEnemy++;
                GameController.instance.isScore= true;
                GameController.instance.ContinueMatch(false);
                
            }
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
