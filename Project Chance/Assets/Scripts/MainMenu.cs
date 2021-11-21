using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======

    public void StartCutscene(GameObject go)
    {
        go.SetActive(true); 
>>>>>>> Production-Branch
    }

    public void NewGame()
    {
        GameManager.LoadScene(newGameScene, 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
