using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text txt_GoalPlayer, txt_GoalEnemy;

    public  int scorePlayer, scoreEnemy;
    public bool isScore, EndMatch;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        txt_GoalPlayer.text = scorePlayer.ToString();
        txt_GoalEnemy.text = scoreEnemy.ToString();
    }
}
