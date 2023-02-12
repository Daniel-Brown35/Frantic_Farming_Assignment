using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost6 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton6;
    public Image keyBubble;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton6.SetActive(false);
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
            tutorialButton6.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "Animals request random food, so it's important to stay topped up on your food ammunition. To the right is more grass to harvest, to the left is a grain field and an apple orchard. To proceed, completely fill up all three of your gun's ammo stockpiles. That's 20 per ammo type!";       
        }
    }

    public void TutorialButton6Pressed()
    {
        if (signpostActive == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton6.SetActive(false);
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
