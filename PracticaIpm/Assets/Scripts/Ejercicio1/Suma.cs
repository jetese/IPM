using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suma : MonoBehaviour {
	public GameObject cero;
	public GameObject uno;
	public GameObject dos;
	public GameObject tres;
	public GameObject cuatro;
	public GameObject cinco;
	public GameObject seis;
	public GameObject siete;
	public GameObject ocho;
	public GameObject nueve;
	public GameObject canvas;
	public GameObject suma;
	GameObject sum1;
	GameObject sum2;
	GameObject elefante;
	TileMapping script;
	int indice;
	// Use this for initialization
	void Start () {
		elefante = GameObject.Find("ElefantePadre");
		script = elefante.GetComponent<TileMapping>();
		Sumauno ();
	}
	void Sumauno(){
		sum1 = Instantiate (dos) as GameObject;
		sum1.transform.position = new Vector3 (-7, 4, 0);
		sum2 = Instantiate (tres) as GameObject;
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
		sum1 = Instantiate (cuatro) as GameObject;
		sum1.transform.position = new Vector3 (-7, 4, 0);
		sum2 = Instantiate (seis) as GameObject;
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
		sum1 = Instantiate (dos) as GameObject;
		sum1.transform.position = new Vector3 (-7, 4, 0);
		sum2 = Instantiate (cuatro) as GameObject;
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
				Sumados ();
				script.pasos = 0;
			} else {
				script.Reintentar ();
			}
			break;
		case 1:
			if (pasos == 10) {
				Sumatres ();
				script.pasos = 0;
			} else {
				script.Reintentar ();
			}
			break;
		case 2:
			if (pasos == 6) {
				//Llamar a acabar
				script.pasos = 0;
			} else {
				script.Reintentar ();
			}
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
