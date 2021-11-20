using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject TextBox; 

    private void Awake()
    {
        instance = this;
        TextBox.SetActive(false);    
    }
}
