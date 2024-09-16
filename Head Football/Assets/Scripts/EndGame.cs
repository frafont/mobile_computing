using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    public  Image flagPlayer, flagEnemy;
    public  Text nationPlayer, nationEnemy;
    public MetchData metch;
    public Text result, goals;


      

    // Start is called before the first frame update
    void Start()
    {
          
        
    
        goals.text = GameController.scorePlayer + "-" + GameController.scoreEnemy;
    
        
        
      /*  flagPlayer=GameController.PFlag;
        flagEnemy=GameController.EFlag;
        nationPlayer=GameController.Nplayer;
        nationEnemy=GameController.Nenemy;
        */


         if(flagPlayer==null){
            Debug.Log("Stampa");
        }

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
      public void inizializzaRis(){
        flagPlayer=GameController.instance.PlayerFlag.GetComponent<Image>();
        flagEnemy=GameController.instance.EnemyFlag.GetComponent<Image>();
        nationPlayer=GameController.instance.Nameplayer.GetComponent<Text>();
        nationEnemy=GameController.instance.NameEnemy.GetComponent<Text>();

      }

}
