using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromOptions : MonoBehaviour
{
    public GameObject optionsCanvasObject;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    public void ReturnFromOptionsPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        optionsCanvasObject.GetComponent<Canvas>().sortingOrder = 0;
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            GameObject.Find("EventSystem").GetComponent<TutorialRequirements>().UpdateValues();
        }
        if (SceneManager.GetActiveScene().name == "LevelOneScene") 
        {
            GameObject.Find("EventSystem").GetComponent<LevelOneRequirements>().UpdateValues();
        }
        if (SceneManager.GetActiveScene().name == "LevelTwoScene")
        {
            //GameObject.Find("EventSystem").GetComponent<LevelTwoRequirements>().UpdateSensitivity();
        }
        optionsCanvasObject.SetActive(false);
    }
}
