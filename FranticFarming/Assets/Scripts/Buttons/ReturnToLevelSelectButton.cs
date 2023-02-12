using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToLevelSelectButton : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip buttonSelect;
    private PauseMenuActivator pauseMenuActivator;

    public void ReturnToLevelSelectClicked()
    {
        pauseMenuActivator = GameObject.Find("EventSystem").GetComponent<PauseMenuActivator>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (pauseMenuActivator.gamePaused == true)
        {
            pauseMenuActivator.UnpauseGame();
        }
        audioSource.PlayOneShot(buttonSelect);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}
