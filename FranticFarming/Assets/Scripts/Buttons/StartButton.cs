using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject levelSelectCanvasObject;
    private Canvas levelSelectCanvas;
    public AudioSource audioSource;
    public AudioClip buttonSelect;

    // Start is called before the first frame update
    void Start()
    {
        levelSelectCanvas = levelSelectCanvasObject.GetComponent<Canvas>();
    }

    public void StartButtonPressed()
    {
        audioSource.PlayOneShot(buttonSelect);
        levelSelectCanvasObject.SetActive(true);
        levelSelectCanvas.sortingOrder = 2;
    }
}
