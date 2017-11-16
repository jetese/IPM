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
	GameObject elefante;
	TileMapping script;
	int indice =0;
	// Use this for initialization
	void Start () {
		elefante = GameObject.Find("ElefantePadre");
		script = elefante.GetComponent<TileMapping>();
		Sumauno ();
	}
	void Sumauno(){
		GameObject sum1 = Instantiate (dos) as GameObject;
		sum1.transform.position = new Vector3 (-7, 1, 0);
		GameObject sum2 = Instantiate (tres) as GameObject;
		sum2.transform.position = new Vector3 (-5, 1, 0);
		GameObject sum = Instantiate (suma) as GameObject;
		sum.transform.position = new Vector3 (-6, 1, 0);
		sum1.transform.parent = canvas.transform;
		sum2.transform.parent = canvas.transform;
		sum.transform.parent = canvas.transform;
		sum1.transform.localScale = new  Vector3 (1, 1, 1);
		sum2.transform.localScale = new  Vector3 (1, 1, 1);
		sum.transform.localScale = new  Vector3 (1, 1, 1);

	}
	void Sumados(){
		GameObject sum1 = Instantiate (cuatro) as GameObject;
		sum1.transform.position = new Vector3 (-7, 1, 0);
		GameObject sum2 = Instantiate (seis) as GameObject;
		sum2.transform.position = new Vector3 (-5, 1, 0);
		GameObject sum = Instantiate (suma) as GameObject;
		sum.transform.position = new Vector3 (-6, 1, 0);
		sum1.transform.parent = canvas.transform;
		sum2.transform.parent = canvas.transform;
		sum.transform.parent = canvas.transform;
		sum1.transform.localScale = new  Vector3 (1, 1, 1);
		sum2.transform.localScale = new  Vector3 (1, 1, 1);
		sum.transform.localScale = new  Vector3 (1, 1, 1);

	}
	void Sumatres(){
		GameObject sum1 = Instantiate (dos) as GameObject;
		sum1.transform.position = new Vector3 (-7, 1, 0);
		GameObject sum2 = Instantiate (cuatro) as GameObject;
		sum2.transform.position = new Vector3 (-5, 1, 0);
		GameObject sum = Instantiate (suma) as GameObject;
		sum.transform.position = new Vector3 (-6, 1, 0);
		sum1.transform.parent = canvas.transform;
		sum2.transform.parent = canvas.transform;
		sum.transform.parent = canvas.transform;
		sum1.transform.localScale = new  Vector3 (1, 1, 1);
		sum2.transform.localScale = new  Vector3 (1, 1, 1);
		sum.transform.localScale = new  Vector3 (1, 1, 1);

	}
	void ComprobarSuma(){
		int pasos = script.pasos;
		switch (indice) {
		case 0:
			if (pasos == 5) {
				Sumados ();
				script.pasos = 0;
			} else {
				script.Reintentar (0);
			}
			break;
		case 1:
			if (pasos == 10) {
				Sumatres ();
				script.pasos = 0;
			} else {
				script.Reintentar (1);
			}
			break;
		case 2:
			if (pasos == 6) {
				Sumados ();
				script.pasos = 0;
			} else {
				script.Reintentar (2);
			}
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
