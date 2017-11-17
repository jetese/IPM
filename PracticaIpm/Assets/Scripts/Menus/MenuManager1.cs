using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager1 : MonoBehaviour {
    public string prevScene;
    public bool isAutomatic = false;
    public bool goBack = false;
    public string nextScene;
    public List<AudioClip> CloseGameAudio;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey && isAutomatic) {
            if(goBack)
            {
                goToScene(prevScene);
            }
            else
            {
                goToScene(nextScene);
            }
        }
    }

    private void goToNextScene()
    {
        
        if (nextScene == "Work-in-progress")
        {
            isAutomatic = true;
            goBack = true;
        }
        else
        {
            isAutomatic = false;
            goBack = false;
        }
        SceneManager.LoadScene(nextScene);
    }

    public void goToScene(string scene)
    {
        prevScene = nextScene;
        nextScene = scene;
        goToNextScene();
    }

    public void EndGame()
    {
        print("Adios");
        GameObject ardilla = GameObject.FindGameObjectWithTag("Ardilla");
        System.Random rnd = new System.Random();
        int randomIndex = rnd.Next(CloseGameAudio.Count);
        ardilla.GetComponent<MenuAsignaturas>().PlayAndQuit(CloseGameAudio[randomIndex]);
    }
    
    public void goBackToMenu(AudioClip audio)
    {
        GameObject ardilla = GameObject.FindGameObjectWithTag("Ardilla");       
        ardilla.GetComponent<MenuAsignaturas>().playAudio(audio);
    }
}
