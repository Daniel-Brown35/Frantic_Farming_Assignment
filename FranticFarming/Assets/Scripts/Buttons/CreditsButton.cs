using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public GameObject creditsCanvasObject;
    private Canvas creditsCanvas;
    public AudioSource audioSource;
    public AudioClip buttonSelect;

    private void Start()
    {
        creditsCanvas = creditsCanvasObject.GetComponent<Canvas>();
    }
    public void CreditsButtonClick()
    {
        audioSource.PlayOneShot(buttonSelect);
        creditsCanvasObject.SetActive(true);
        creditsCanvas.sortingOrder = 2;
    }
}
