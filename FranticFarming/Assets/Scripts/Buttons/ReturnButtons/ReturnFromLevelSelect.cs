using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromLevelSelect : MonoBehaviour
{
    public GameObject levelSelectCanvasObject;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    public void ReturnFromLevelSelectPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        levelSelectCanvasObject.GetComponent<Canvas>().sortingOrder = 0;
        levelSelectCanvasObject.SetActive(false);
    }
}
