using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromCredits : MonoBehaviour
{
    public GameObject creditsCanvasObject;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    // Update is called once per frame
    public void ReturnFromCreditsPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        creditsCanvasObject.GetComponent<Canvas>().sortingOrder = 0;
        creditsCanvasObject.SetActive(false);
    }
}
