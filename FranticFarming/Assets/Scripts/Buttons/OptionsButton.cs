using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSelect;

    public void OptionsButtonClick()
    {
        audioSource.PlayOneShot(buttonSelect);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
}
