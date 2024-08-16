using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.EnhancedTouch;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    AudioManager audioManager;

    public GameObject[] playerPrefabs;
    
    public GameObject[] EnemyPrefabs;
    public GameObject[] NationsName;
    public GameObject Nameplayer;
    public GameObject NameEnemy;

    public Sprite[] Flags;
    public GameObject PlayerFlag;
    public GameObject EnemyFlag;

    public static int selectedPlayerIndex = -1;
    public static int selectedEnemyIndex=-1;


    public Text txt_GoalPlayer, txt_GoalEnemy, txt_timeMatch;

    public static int scorePlayer, scoreEnemy;

    public bool isScore, EndMatch;

    public bool isInPause= false;
    private bool isGameStarted = false;

    private GameObject ball, player, enemy;

    public GameObject panelPause;

    public GameObject panelAudio;
    public float timeMatch;

    void Awake()
    {
        Inizializza();
        
        Debug.Log("inizio caricamento palla e giocatori");
        ball = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

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

        
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        enemy.GetComponent<Rigidbody2D>().isKinematic = true;

        // Disabilita gli Animator inizialmente
        player.GetComponent<Animator>().enabled = false;
        enemy.GetComponent<Animator>().enabled = false;

    }

    private void Inizializza()
    {
        if (instance == null) {
            instance = this;
        }
    
    }

    

    void Start()
    {   
        ResetGame();
    }

    public void ResetGame()
    {
        // Resetta tutte le variabili di stato
        scorePlayer = 0;
        scoreEnemy = 0;
        isScore = false;
        EndMatch = false;
        isGameStarted = false;
        timeMatch = 90;

        if (ball != null && player != null && enemy != null)
        {
            ball.transform.position = new Vector3(0, 0, 0);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball.GetComponent<Rigidbody2D>().isKinematic = true;

            player.transform.position = new Vector3(-5, -2, -1);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<Rigidbody2D>().isKinematic = true;

            enemy.transform.position = new Vector3(5, -2, -1);
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            enemy.GetComponent<Rigidbody2D>().isKinematic = true;
        } 
    }
    

    

    public void GameStart()
    {
        GameObject.FindGameObjectWithTag("ButtonStart").SetActive(false);

        isGameStarted = true;
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        enemy.GetComponent<Rigidbody2D>().isKinematic = false;

        player.GetComponent<Animator>().enabled = true;
        enemy.GetComponent<Animator>().enabled = true;

        if (isGameStarted)
        {
            GameStarted();
        }
    }

    public void GameStarted()
    {
        timeMatch = 90;
        StartCoroutine(BeginMatch());
    }

    void Update()
    {
        txt_GoalPlayer.text = scorePlayer.ToString();
        txt_GoalEnemy.text = scoreEnemy.ToString();
        txt_timeMatch.text = timeMatch.ToString();
    }

    IEnumerator BeginMatch()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (timeMatch > 0)
            {
                timeMatch--;
            }
            else
            {
                StartCoroutine(waitEndMatch());
                EndMatch = true;
                break;
            }
        }
    }

    public void ContinueMatch(bool hasScored)
    {
        StartCoroutine(WaitContinueMatch(hasScored));
    }

    IEnumerator WaitContinueMatch(bool hasScored)
    {
        yield return new WaitForSeconds(2f);
        isScore = false;
        if (!EndMatch)
        {
            ball.transform.position = new Vector3(0, 0, 0);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            enemy.transform.position = new Vector3(5, -2, -1);
            player.transform.position = new Vector3(-5, -2, -1);

            if (hasScored)
            {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
            }
            else
            {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 200));
            }
        }
    }

    public void ButtonPause()
    {   
        isInPause=true;
        audioManager.GetAudioSource().Pause();
        panelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ButtonResume()
    {
        panelPause.SetActive(false);
        audioManager.GetAudioSource().Play();
        isInPause= false;
        Time.timeScale = 1;
        
        
    }

    public void ButtonLose()
    {
        scoreEnemy = 3;
        scorePlayer = 0;
        timeMatch = 0;
        panelPause.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(waitEndMatch());
    }

    public void ButtonSelectTeam()
    {
        SceneManager.LoadScene("Select Team");
    }

    public void ButtonAudio()
    {
        panelAudio.SetActive(true);
    }

    public void ButtonConfirm(){
        panelAudio.SetActive(false);
    }

    IEnumerator waitEndMatch()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End Game");
    }
}
