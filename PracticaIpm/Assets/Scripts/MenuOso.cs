using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOso : MonoBehaviour {

    Animator anim;
    new AudioSource audio;

    void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        StartCoroutine("startAudio");
	}
	
	// Update is called once per frame
	void Update () {
        if (!audio.isPlaying)
        {
            anim.SetBool("Talking", false);
        }
	}

    IEnumerator startAudio()
    {
        print("Inicio");
        yield return new WaitForSeconds(2f);
        print("Fin");
        yield return null;
        playWelcome();
    }

    private void playWelcome()
    {

        anim.SetBool("Talking", true);
        audio.Play();
    }
}
