﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Suma : MonoBehaviour {
    public List<AudioClip> GoodAudios;
    public List<AudioClip> BadAudios;
	public List<GameObject> numeros;
    public AudioClip Instruction;
    public GameObject particleSystem;
    public GameObject Erizo;
	public GameObject canvas;
	public GameObject suma;
	GameObject sum1;
	GameObject sum2;
	GameObject sol;
	GameObject sol2;
	GameObject elefante;
	TileMapping script;
	int indice;
	// Use this for initialization
	void Start () {
		elefante = GameObject.Find("ElefantePadre");
		script = elefante.GetComponent<TileMapping>();
        MenuAsignaturas audioPlayer = Erizo.GetComponent<MenuAsignaturas>();
        audioPlayer.playAudio(Instruction);
        Sumauno ();
	}
	void Sumauno(){
		sum1 = Instantiate (numeros[2]) as GameObject;
		sum1.transform.position = new Vector3 (-7, 4, 0);
		sum2 = Instantiate (numeros[3]) as GameObject;
		sum2.transform.position = new Vector3 (-5, 4, 0);
		GameObject sum = Instantiate (suma) as GameObject;
		sum.transform.position = new Vector3 (-6, 4, 0);
		sum1.transform.parent = canvas.transform;
		sum2.transform.parent = canvas.transform;
		sum.transform.parent = canvas.transform;
		sum1.transform.localScale = new  Vector3 (1, 1, 1);
		sum2.transform.localScale = new  Vector3 (1, 1, 1);
		sum.transform.localScale = new  Vector3 (1, 1, 1);
		indice = 0;
	}
	void Sumados(){
		Destroy (sum1);
		Destroy (sum2);
		sum1 = Instantiate (numeros[4]) as GameObject;
		sum1.transform.position = new Vector3 (-7, 4, 0);
		sum2 = Instantiate (numeros[6]) as GameObject;
		sum2.transform.position = new Vector3 (-5, 4, 0);
		sum1.transform.parent = canvas.transform;
		sum2.transform.parent = canvas.transform;
		sum1.transform.localScale = new  Vector3 (1, 1, 1);
		sum2.transform.localScale = new  Vector3 (1, 1, 1);
		indice = 1;

	}
	void Sumatres(){
		Destroy (sum1);
		Destroy (sum2);
		sum1 = Instantiate (numeros[2]) as GameObject;
		sum1.transform.position = new Vector3 (-7, 4, 0);
		sum2 = Instantiate (numeros[4]) as GameObject;
		sum2.transform.position = new Vector3 (-5, 4, 0);
		sum1.transform.parent = canvas.transform;
		sum2.transform.parent = canvas.transform;
		sum1.transform.localScale = new  Vector3 (1, 1, 1);
		sum2.transform.localScale = new  Vector3 (1, 1, 1);
		indice = 2;
	}
	public void ComprobarSuma(){
		int pasos = script.pasos;
		switch (indice) {
		case 0:
			if (pasos == 5) {
                playAudioFromList(GoodAudios);
               generateStars();
				Sumados ();
				script.pasos = 0;
			} else {
				script.Reintentar ();
                playAudioFromList(BadAudios);
			}
			break;
		case 1:
			if (pasos == 10)
                {
                playAudioFromList(GoodAudios);
                generateStars();
                Sumatres ();
				script.pasos = 0;
			} else {
				script.Reintentar ();
                playAudioFromList(BadAudios);
                }
			break;
		case 2:
			if (pasos == 6) {
				SceneManager.LoadScene(5);
				script.pasos = 0;
			} else {
				script.Reintentar ();
                playAudioFromList(BadAudios);
                }
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

    void playAudioFromList(List<AudioClip> audioList)
    {
        MenuAsignaturas audioPlayer = Erizo.GetComponent<MenuAsignaturas>();
        System.Random rnd = new System.Random();
        int randomIndex = rnd.Next(audioList.Count);

        audioPlayer.playAudio(audioList[randomIndex]);
    }

    void generateStars()
    {
        StartCoroutine("destroyObject", Instantiate(particleSystem));
    }

    IEnumerator destroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(obj);
        yield return null;
    }

    IEnumerator RandomPhrase()
    {
        yield return new WaitForSeconds(10.0f);
        yield return null;
    }

	public void Solucion(int paso){
		Destroy (sol);
		Destroy (sol2);
		if (paso >= 10) {
			sol2 = Instantiate (numeros[1]) as GameObject;
			sol2.transform.position = new Vector3 (-7, 3, 0);
			sol2.transform.parent = canvas.transform;
			sol2.transform.localScale = new  Vector3 (1, 1, 1);
			paso = paso % 10;
		}
		sol = Instantiate (numeros[paso]) as GameObject;
		sol.transform.position = new Vector3 (-7, 3, 0);
		sol	.transform.parent = canvas.transform;
		sol.transform.localScale = new  Vector3 (1, 1, 1);
	}
}
