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
    bool movingBack = false;

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
                StartCoroutine("move");
            }
        }
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (!moving && index>0)
			{
				StartCoroutine("moveback", 1);
			}
		}
	}


	public void Avanzar(){
		if (!moving && index<Tiles.Count-1)
		{
			StartCoroutine("move");
		}
	}

	public void Retroceder(){
		if (!moving && index>0) {
			StartCoroutine ("moveback", 1);
		}
	}
	public void Reintentar(){
        if (!moving && index > 0)
        {
            StartCoroutine("moveback", pasos);
        }
    }
    



    IEnumerator move()
    {

        index++;
        pasos++;
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

	IEnumerator moveback(int iterations = 1)
	{
        while (iterations > 0)
        {
            index--;
            pasos--;
            moving = true;
            movingBack = true;
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
            movingBack = false;
            iterations--;
        }
		yield return null;
	}


}
