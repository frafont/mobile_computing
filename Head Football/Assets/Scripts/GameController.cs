using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text txt_GoalPlayer, txt_GoalEnemy, txt_timeMatch;

    public  int scorePlayer, scoreEnemy;
    public bool isScore, EndMatch;

    private GameObject ball, player, enemy;

    public float timeMatch;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        timeMatch = 90;
        ball=GameObject.FindGameObjectWithTag("Ball");
        player=GameObject.FindGameObjectWithTag("Player");
        enemy=GameObject.FindGameObjectWithTag("Enemy");
        StartCoroutine(BeginMatch());
    }

    // Update is called once per frame
    void Update()
    {
        txt_GoalPlayer.text = scorePlayer.ToString();
        txt_GoalEnemy.text = scoreEnemy.ToString();
        txt_timeMatch.text = timeMatch.ToString();
    }

    IEnumerator BeginMatch()
    {
    while(true)
        {
            yield return new WaitForSeconds(1f);
            if(timeMatch >0)
            {

                timeMatch--;
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
