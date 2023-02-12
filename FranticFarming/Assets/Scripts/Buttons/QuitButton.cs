using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSelect;
    public void QuitButtonClick()
    {
        audioSource.PlayOneShot(buttonSelect);
        Application.Quit();
    }
}
