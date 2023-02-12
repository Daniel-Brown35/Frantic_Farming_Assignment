using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsCanvasObject;
    private Canvas optionsCanvas;
    public bool gamePaused = false;
    private Gun gun;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        optionsCanvas = optionsCanvasObject.GetComponent<Canvas>();
        optionsCanvasObject.SetActive(false);
        pauseMenu.SetActive(false);
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused == false && Input.GetKeyDown("p"))
        {
            pauseMenu.SetActive(true);      
            gamePaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gun.readyToShoot = false;
        }
        if (gamePaused == true && Input.GetKeyDown("escape"))
        {
            UnpauseGame();
        }
    }
    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<PauseMenuActivator>().gamePaused = false;
        gamePaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gun.readyToShoot = true;
    }
    public void OptionsButtonPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        optionsCanvasObject.SetActive(true);
        optionsCanvas.sortingOrder = 2;
    }
}
