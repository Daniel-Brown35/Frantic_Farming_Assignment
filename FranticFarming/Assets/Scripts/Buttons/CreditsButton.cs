using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSelect;
    public void CreditsButtonClick()
    {
        audioSource.PlayOneShot(buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }
}
