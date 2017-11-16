using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileMapping : MonoBehaviour {
    List<GameObject> Tiles;
    Animator anim;
    int index = 0;
	int ejer;
    bool moving = false;
	public int pasos;

    // Use this for initialization
    void Start () {
        Tiles = (from tile in GameObject.FindGameObjectsWithTag("Tile")
                 orderby int.Parse(tile.name)
                 select tile).ToList<GameObject>();
        transform.localPosition = Tiles[index].transform.position;
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!moving && index<Tiles.Count-1)
            {
                index++;
				pasos++;
                StartCoroutine("move");
            }
        }
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (!moving && index>0)
			{
				index--;
				pasos--;
				StartCoroutine("moveback");
			}
		}
	}

	public void Avanzar(){
		if (!moving)
		{
			index++;
			pasos++;
			StartCoroutine("move");
		}
	}

	public void Retroceder(){
		if (!moving) {
			index--;
			pasos--;
			StartCoroutine ("moveback");
		}
	}
	public void Reintentar(int ejemplo){
		switch (ejemplo) {
		case 0:
			ejer = 0;
			doCoroutine ();
			break;
		case 1:
			
			break;
		case 2:
			
			break;
		}
	}

	IEnumerator doCoroutine(){
		if (index <=ejer)
			yield return null;
		while (moving == false) {
			StartCoroutine ("moveback");
			yield return new WaitForFixedUpdate();
		}
	}

    IEnumerator move()
    {
        moving = true;
        anim.SetBool("Walking", true);

        if (transform.localPosition.x <= Tiles[index].transform.position.x)
        {
            while (transform.localPosition.x <= Tiles[index].transform.position.x)
            {
                transform.Translate(new Vector3(0.05f, 0, 0));
                yield return new WaitForFixedUpdate();
            }
        }
        if (transform.localPosition.y <= Tiles[index].transform.position.y)
        {
            while (transform.localPosition.y <= Tiles[index].transform.position.y)
            {
                transform.Translate(new Vector3(0, 0.05f, 0));
                yield return new WaitForFixedUpdate();
            }
        }
        if (transform.localPosition.y >= Tiles[index].transform.position.y)
        {
            while (transform.localPosition.y >= Tiles[index].transform.position.y)
            {
                transform.Translate(new Vector3(0, -0.05f, 0));
                yield return new WaitForFixedUpdate();
            }
        }
        moving = false;
        anim.SetBool("Walking", false);
        yield return null;
    }

	IEnumerator moveback()
	{
		moving = true;
		anim.SetBool("Walking", true);

		if (transform.localPosition.x >= Tiles[index].transform.position.x)
		{
			while (transform.localPosition.x >= Tiles[index].transform.position.x)
			{
				transform.Translate(new Vector3(-0.05f, 0, 0));
				yield return new WaitForFixedUpdate();

			}
		}
		if (transform.localPosition.y >= Tiles[index].transform.position.y)
		{
			while (transform.localPosition.y >= Tiles[index].transform.position.y)
			{
				transform.Translate(new Vector3(0, -0.05f, 0));
				yield return new WaitForFixedUpdate();
			}
		}
		if (transform.localPosition.y <= Tiles[index].transform.position.y)
		{
			while (transform.localPosition.y <= Tiles[index].transform.position.y)
			{
				transform.Translate(new Vector3(0, +0.05f, 0));
				yield return new WaitForFixedUpdate();
			}
		}

		moving = false;
		anim.SetBool("Walking", false);
		yield return null;
	}


}
