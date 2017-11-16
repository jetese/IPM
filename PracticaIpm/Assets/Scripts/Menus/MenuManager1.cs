using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager1 : MonoBehaviour {
    private string prevScene;
    public bool isAutomatic = false;
    public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey && isAutomatic) {
            SceneManager.LoadScene(nextScene);    
        }
    }

    public void goToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void goBackScene()
    {
        SceneManager.LoadScene(prevScene);
    }
}
