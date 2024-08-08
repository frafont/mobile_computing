using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.EnhancedTouch;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text txt_GoalPlayer, txt_GoalEnemy, txt_timeMatch;

    public  int scorePlayer, scoreEnemy;

    //public Image flagPlayer, flagEnemy;
    // public Text nationPlayer, nationEnemy;
    public bool isScore, EndMatch;

    private bool isGameStarted=false;

    private GameObject ball, player, enemy;
    public float timeMatch;

    void Awake()
    {
        ball=GameObject.FindGameObjectWithTag("Ball");
        player=GameObject.FindGameObjectWithTag("Player");
        enemy=GameObject.FindGameObjectWithTag("Enemy");
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        enemy.GetComponent<Rigidbody2D>().isKinematic = true;

        // Disabilita gli Animator inizialmente
        player.GetComponent<Animator>().enabled = false;
        enemy.GetComponent<Animator>().enabled = false;
    }
    private void Inizializza()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GameStart()
    {   
        Debug.Log("pulsante premuto");
        GameObject.Find("TouchStart").SetActive(false);
        isGameStarted=true;
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        enemy.GetComponent<Rigidbody2D>().isKinematic = false;
        
        player.GetComponent<Animator>().enabled = true;
        enemy.GetComponent<Animator>().enabled = true;
        Inizializza();
        if(isGameStarted){
            GameStarted();
        }
    }
    public void GameStarted()
    {
        Debug.Log("gameStarted partito");
        timeMatch = 90;
        StartCoroutine(BeginMatch()); 
    }
        // Update is called once per frame
    void Update()
    {
        txt_GoalPlayer.text = scorePlayer.ToString();
        txt_GoalEnemy.text = scoreEnemy.ToString();
        
    }

    IEnumerator BeginMatch()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if(timeMatch >0)
            {

                timeMatch--;
                txt_timeMatch.text = timeMatch.ToString();
            }
            else 
            {   
                EndMatch = true;
                break;
            }
        }
    }

    public void  ContinueMatch(bool hasScored)
    {   
        StartCoroutine(WaitContinueMatch(hasScored));
    }
    IEnumerator WaitContinueMatch(bool hasScored)
    {
        yield return new WaitForSeconds(2f);
        isScore= false;
        if(!EndMatch)
        {
            ball.transform.position = new Vector3(0,0,0);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            enemy.transform.position = new Vector3(5,-2,-1);
            player.transform.position = new Vector3(-5,-2,-1);

            if(hasScored)
            {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100,200));
            }
            else {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100,200));
            }
        }
    }
}
