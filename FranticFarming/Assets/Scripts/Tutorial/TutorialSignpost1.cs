using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost1 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton1;
    public Image keyBubble;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton1.SetActive(false);
        tutorialSignCanvas.SetActive(false);
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        keyBubble.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.canMove = false;
            gun.readyToShoot = false;
            signpostActive = true;
            tutorialSignCanvas.SetActive(true);
            tutorialButton1.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "Hey farmer, welcome to the frantic farm! Here you will learn how to tend to animals, collect resources and trade in order to gain stars to win.";
        }
    }
    public void TutorialButton1Pressed()
    {
            if (signpostActive == true)
            {
                playerMovement.canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gun.readyToShoot = true;
                signpostActive = false;
                tutorialButton1.SetActive(false);
                tutorialSignCanvas.SetActive(false);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
            keyBubble.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = false;
            keyBubble.enabled = false;
        }
    }
}
