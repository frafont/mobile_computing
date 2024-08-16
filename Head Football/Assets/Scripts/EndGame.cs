using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    public Image flagPlayer, flagEnemy;
    public Text nationPlayer, nationEnemy;

    public Text result, goals;

    // Start is called before the first frame update
    void Start()
    {
        /* codice per inizializzare le bandiere e i nomi delle Nazioni*/

        goals.text = GameController.scorePlayer + "-" + GameController.scoreEnemy;

        if(GameController.scoreEnemy > GameController.scorePlayer)
        {
            result.text= "YOU LOSE";
        } else if(GameController.scoreEnemy < GameController.scorePlayer)
        {
            result.text= "YOU WIN";
        } else {
            result.text= "DRAW";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonHome()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ButtonRematch()
    {
        SceneManager.LoadScene("Game");
    }

}
