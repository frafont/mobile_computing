using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] AudioSource menuMusic;


    public AudioClip music;


    // Start is called before the first frame update
    void Start()
    {
        menuMusic.clip= music;
        menuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

