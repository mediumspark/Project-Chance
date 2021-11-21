using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI textComponent;
    private string[] lines;
    public float textSpeed;
    private int index;

    private bool dialogueBox;
    private bool finished;
    public bool Finished => finished; 

    public TextAsset textFile;

    void Start()
    {
        textBox = CanvasManager.instance.TextBox;
        textComponent = textBox != null ? textBox.GetComponentInChildren<TextMeshProUGUI>() : null; 

        if (textFile != null && textComponent != null)
        {
            lines = (textFile.text.Split('\n'));
            textComponent.text = string.Empty;
            dialogueBox = false;
            textBox.SetActive(false);
            finished = false;
        }
    }

    void Update()
    {
        // Check Enter button to skip to next line
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if (dialogueBox == true && finished == false)
            {
                //Debug.Log("textComponent.text: " + textComponent.text);
                //Debug.Log("lines[index]: " + lines[index]);
                //Debug.Log("lines: " + lines[0]);
                //Debug.Log("index is " + index);
                //Debug.Log("text component is " + textComponent.text);
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

     public void StartDialogue()
    {
        if (dialogueBox == false && textComponent != null)
        {
            Time.timeScale = 0;
            textComponent.text = string.Empty;
            textBox.SetActive(true);
            index = 0;
            StartCoroutine(TypeLine());
            dialogueBox = true;
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textBox.SetActive(false);
            finished = true;
            Time.timeScale = 1;
        }
    }
}
