using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
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
    }
}
