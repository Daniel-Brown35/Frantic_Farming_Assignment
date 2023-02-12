using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromOptions : MonoBehaviour
{
    public GameObject optionsCanvasObject;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    public void ReturnFromOptionsPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        optionsCanvasObject.GetComponent<Canvas>().sortingOrder = 0;
        optionsCanvasObject.SetActive(false);
    }
}
