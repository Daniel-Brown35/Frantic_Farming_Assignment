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
    private TradingPost tradingPost;

    // Start is called before the first frame update
    void Start()
    {
        tradingPost = GameObject.Find("TradingPostPlaceholder").GetComponent<TradingPost>();
        optionsCanvas = optionsCanvasObject.GetComponent<Canvas>();
        optionsCanvasObject.SetActive(false);
        pauseMenu.SetActive(false);
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused == false && tradingPost.activelyTrading == false)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
        
        
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        gamePaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gun.readyToShoot = false;
    }

    public void UnpauseGame()
    {
        audioSource.PlayOneShot(buttonPressed);
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
        optionsCanvas.sortingOrder = 3;
    }
}
