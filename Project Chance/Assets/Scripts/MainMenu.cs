using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;

    public void StartCutscene(GameObject go)
    {
        go.SetActive(true); 
    }

    public void NewGame()
    {
        GameManager.LoadScene(newGameScene, -1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
