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
	// Use this for initialization
	void Start () {
		Sumauno ();
	}
	void Sumauno(){
		GameObject sum1 = Instantiate (dos) as GameObject;
		sum1.transform.position = new Vector3 (-8, 2, 0);
		GameObject sum2 = Instantiate (tres) as GameObject;
		sum2.transform.position = new Vector3 (-6, 2, 0);



	}
	// Update is called once per frame
	void Update () {
		
	}
}
