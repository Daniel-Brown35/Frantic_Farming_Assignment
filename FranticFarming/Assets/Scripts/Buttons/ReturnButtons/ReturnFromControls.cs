using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromControls : MonoBehaviour
{
    public GameObject controlsCanvasObject;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    // Update is called once per frame
    public void ReturnFromControlsPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        controlsCanvasObject.GetComponent<Canvas>().sortingOrder = 0;
        controlsCanvasObject.SetActive(false);
    }
}
