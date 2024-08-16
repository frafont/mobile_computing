using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

    [Header("----------Audio Clip----------")]
    public AudioClip background;
    public AudioClip bars;
    public AudioClip jump;
    public AudioClip kick;
    public AudioClip goal;

    // Start is called before the first frame update
    private void Start()
    {   
        musicSource.clip= background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

    public AudioSource GetAudioSource()
    {
        return musicSource;
    }
}
