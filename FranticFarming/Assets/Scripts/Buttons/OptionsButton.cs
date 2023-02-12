using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsCanvasObject;
    private Canvas optionsCanvas;
    public AudioSource audioSource;
    public AudioClip buttonSelect;

    private void Start()
    {
        optionsCanvas = optionsCanvasObject.GetComponent<Canvas>();
    }

    public void OptionsButtonPressed()
    {
        audioSource.PlayOneShot(buttonSelect);
        optionsCanvasObject.SetActive(true);
        optionsCanvas.sortingOrder = 2;
    }
}
