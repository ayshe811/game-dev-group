using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue2 : MonoBehaviour
{
    public GameObject continuebutt;
    public GameObject Player;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    int index;
    public float typespeed;

    public GameObject DialogueCamera;
    private void Start()
    {
        StartCoroutine(type());
        DialogueCamera.SetActive(true);
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continuebutt.SetActive(true);
        }
    }
    IEnumerator type()
    {
        foreach (char letter in sentences[index].ToCharArray())

        {
            continuebutt.SetActive(false);
            textDisplay.text += letter;
            yield return new WaitForSeconds(typespeed);
            continuebutt.SetActive(true);
        }
    }
    public void nextsentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(type());

        }
        else
        {
            Player.GetComponent<player>().Dialogue.SetActive(false);
            DialogueCamera.SetActive(false);
        }
    }
}