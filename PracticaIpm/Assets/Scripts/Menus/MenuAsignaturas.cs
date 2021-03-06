﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsignaturas : MonoBehaviour {
    
    private Animator anim;
    private new AudioSource audio;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
	}

    void Update()
    {
        if (!audio.isPlaying)
        {
            anim.SetBool("Talking", false);
        }
    }

  
    public void playAudio(AudioClip audioC)
    {
        anim.SetBool("Talking", true);
        audio.clip = audioC;
        audio.Play();
    }

    public bool checkPlaying()
    {
        bool playing = audio.isPlaying;
        return playing;
    }

    public void PlayAndQuit(AudioClip audioC)
    {
        playAudio(audioC);
        StartCoroutine("Quit");
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(1.0f);
        Application.Quit();
    }
}
