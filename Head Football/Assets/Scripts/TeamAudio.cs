
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAudio : MonoBehaviour
{
    [SerializeField] AudioSource teamMusic;


    public AudioClip music;


    // Start is called before the first frame update
    void Start()
    {
        teamMusic.clip= music;
        teamMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
