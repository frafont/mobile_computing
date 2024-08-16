using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    //private GameObject Player,AI;
    public GameObject[] playerPrefabs;
    
    public GameObject[] EnemyPrefabs;
    public GameObject[] NationsName;
    public GameObject Nameplayer;
    public GameObject NameEnemy;

    public static GameController instance;
    public Sprite[] Flags;
    public GameObject PlayerFlag;
    public GameObject EnemyFlag;

    public Text txt_GoalPlayer, txt_GoalEnemy;
     public static int selectedPlayerIndex = -1;
     public static int selectedEnemyIndex=-1;


    public  int scorePlayer, scoreEnemy;

    public bool isScore, EndMatch;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

      if (selectedPlayerIndex != -1 && selectedEnemyIndex!=-1 ) 
        {
            Instantiate(playerPrefabs[selectedPlayerIndex], new Vector3(0, 0, 0), Quaternion.identity);

            PlayerFlag.GetComponent<Image>().sprite =Flags[selectedPlayerIndex];
            Nameplayer.GetComponent<Text>().text=NationsName[selectedPlayerIndex].GetComponent<Text>().text;

            Instantiate(EnemyPrefabs[selectedEnemyIndex], new Vector3(1.0f, 0, 0), Quaternion.identity);

            EnemyFlag.GetComponent<Image>().sprite=Flags[selectedEnemyIndex];
            NameEnemy.GetComponent<Text>().text=NationsName[selectedEnemyIndex].GetComponent<Text>().text;
            NameEnemy=NationsName[selectedEnemyIndex];
        }
            
    }
        


    // Update is called once per frame
    void Update()
    {
        txt_GoalPlayer.text = scorePlayer.ToString();
        txt_GoalEnemy.text = scoreEnemy.ToString();
    }

}
