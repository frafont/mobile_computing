using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectTeam : MonoBehaviour
{
    public Button[] nationButtons;  // Buttons for each team
    public GameObject[] Playertarget;
    public GameObject[] Enemytarget;
    public GameObject playDis;
    public GameObject play;
    // Start is called before the first frame update
    private int IndicePrec=-1;
    void Start()
    {
        
         for (int i = 0; i < nationButtons.Length; i++)
        {

            if(GameController.selectedPlayerIndex==-1){
                 int index = i;  // Local copy to avoid closure problem in lambda
            nationButtons[i].onClick.AddListener(() => HandleFlagClick(index));
            }
            
        }
       
    }
    public enum SelectionMode{
         SelectingPlayer,
         SelectingOpponent,
    

    }

    public SelectionMode currentSelectionMode = SelectionMode.SelectingPlayer;

    // Update is called once per frame
    void Update()
    {
        if(GameController.selectedPlayerIndex!=-1 && GameController.selectedEnemyIndex!=-1 ){
          playDis.SetActive(false);
          play.SetActive(true);
        }
        
    }
     public void SelectPlayer(int playerIndex)
    {

      
        if (playerIndex >= 0 && playerIndex < nationButtons.Length )
        {
               Playertarget[playerIndex].SetActive(true);
               nationButtons[playerIndex].GetComponent<Button>().enabled=false;
       
            GameController.selectedPlayerIndex=playerIndex;
            
           

            // Instantiate the selected player prefab at a specific location or set it active
           // GameObject player = Instantiate(playerPrefabs[playerIndex], new Vector3(0, 0, 0), Quaternion.identity);
            

            // Here, add any logic that should occur right after selecting a player, such as updating UI
           
           // Debug.Log("Selected player from nation: " + player.name);
        }
        else
        {
            Debug.LogError("Invalid player index selected.");
        }
    }
  

    public void ButtonBack()
    {
        SceneManager.LoadScene("Menu");
    }

     public void ButtonPlay()
    {
        SceneManager.LoadScene("Game");
    }
    
    void HandleFlagClick(int index)
{
    switch (currentSelectionMode)
    {
        case SelectionMode.SelectingPlayer:
            SelectPlayer(index);
            currentSelectionMode = SelectionMode.SelectingOpponent; // Passa alla selezione dell'avversario
            break;
        case SelectionMode.SelectingOpponent:
        if(IndicePrec!=-1){
            Enemytarget[IndicePrec].SetActive(false);
             nationButtons[IndicePrec].GetComponent<Button>().enabled=true;
        }

            SelectOpponent(index);
            // Gestisci il passaggio alla fase successiva del gioco o altro

            break;
            

}
}

public void SelectOpponent(int index)
{
   

    if (index >= 0 && index < nationButtons.Length && index != GameController.selectedPlayerIndex)
    {
           Enemytarget[index].SetActive(true);
         nationButtons[index].GetComponent<Button>().enabled=false;
           IndicePrec= index;
        GameController.selectedEnemyIndex = index;

        Debug.Log("Opponent selected: " + nationButtons[index].name);
        // Potresti voler procedere al caricamento della scena del gioco o a un'altra preparazione
    }
    else
    {
        Debug.LogError("Invalid selection for opponent.");
    }
}



}
