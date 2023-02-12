using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost4 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton4;
    public Image keyBubble;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton4.SetActive(false);
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
            tutorialButton4.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "To collect grass, you must hold the right mouse button to use your vacuum whilst aiming your gun towards the grass. Once collected, proceed to the right of the area to learn about frantic animals.";
        }
        if (signpostActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gun.readyToShoot = true;
                signpostActive = false;
                tutorialSignCanvas.SetActive(false);
            }
        }
    }

    public void TutorialButton4Pressed()
    {
        if (signpostActive == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton4.SetActive(false);
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
