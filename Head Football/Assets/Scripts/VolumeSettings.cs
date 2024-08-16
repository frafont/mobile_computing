using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Slider SFXSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()
    {
        float volume= musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume)*20);

        /* per memorizzare la scelta del volume anche per le prossime partite */
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume= SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume)*20);

        /* per memorizzare la scelta del volume anche per le prossime partite */
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value= PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value= PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
}
