using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public string nextScene;

    public void ClickFunction()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        MenuManager1 menuManager = gameManager.GetComponent<MenuManager1>();
        menuManager.goToScene(nextScene);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
