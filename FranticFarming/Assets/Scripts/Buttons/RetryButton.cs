using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    public void ReturnButtonPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
