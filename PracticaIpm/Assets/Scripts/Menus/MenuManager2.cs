using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager2 : MonoBehaviour {

    public GameObject Ages;
    public GameObject Subjects;
    void Start()
    {
        Subjects.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showSubjects()
    {
        StartCoroutine("moveAges");
        //Ages.transform.Translate(new Vector3(-280, 0, 0));
        //Subjects.SetActive(true);
    }

    IEnumerator moveAges()
    {
        while(Ages.transform.localPosition.x > -204.1)
        {
            Ages.transform.Translate(new Vector3(-10, 0, 0));
            yield return new WaitForFixedUpdate();
        }
        Subjects.SetActive(true);
        yield return null;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
