using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost7 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton7;
    public Image keyBubble;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton7.SetActive(false);
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            signpostActive = true;
            tutorialSignCanvas.SetActive(true);
            tutorialButton7.SetActive(true);
            tutorialText.text = "To grow grain, you collect poop dropped from animals by pressing F then carry it over to the grain field and place it in the growing area by pressing E again. You can tell if the grain field needs fertilizing with poo if there’s a poo thought bubble above the field. From there, you can collect grain by vacuuming it with a held right mouse button exactly like you did in the previous area.";           
        }
    }

    public void TutorialButton7Pressed()
    {
        if (signpostActive == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton7.SetActive(false);
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
