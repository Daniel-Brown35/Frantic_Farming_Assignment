using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    public GameObject controlsCanvasObject;
    private Canvas controlsCanvas;
    public AudioSource audioSource;
    public AudioClip buttonSelect;

    // Start is called before the first frame update
    void Start()
    {
        controlsCanvas = controlsCanvasObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    public void ControlsButtonPressed()
    {
        audioSource.PlayOneShot(buttonSelect);
        controlsCanvasObject.SetActive(true);
        controlsCanvas.sortingOrder = 2;
    }
}
