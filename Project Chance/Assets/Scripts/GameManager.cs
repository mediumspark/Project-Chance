using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine; 

public class GameManager 
{
    public static GameManager instance { get { return new GameManager(); } set { } }

    public void LevelReload()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string Levelname)
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene(Levelname);
    }

    public void LoadScene(int BuildOrder)
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene(BuildOrder);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SpawnPlayer(); 
    }

    private void SpawnPlayer()
    {
        Player player = GameObject.FindObjectOfType<Player>();

        if (player != null)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Respawn");
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = go.transform.position;
            player.GetComponent<CharacterController>().enabled = true;

            CinemachineVirtualCamera OWcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>(); 
            if(OWcam != null)
            {
                OWcam.Follow = player.transform; 
            }
        }
        else
        {
            GameObject go = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Player"));
            SpawnPlayer(); 
        }
    }

}
