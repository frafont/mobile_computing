/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITeam : MonoBehaviour {
    public static UITeam instance;

    public Image selectedFlag; 
    public Text selectedTeamName;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
    }

    // Metodo chiamato al click su una bandiera
    public void OnFlagClicked(Sprite flag, string teamName) {
        selectedFlagImage.sprite = flag; // Imposta l'immagine della bandiera selezionata
        selectedTeamName.text = teamName; // Imposta il nome del team selezionato
    }
}*/
