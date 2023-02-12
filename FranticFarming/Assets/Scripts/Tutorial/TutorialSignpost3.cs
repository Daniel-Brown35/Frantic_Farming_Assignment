using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost3 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton3;
    public Image keyBubble;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton3.SetActive(false);
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
            tutorialButton3.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "Great job on feeding the cow. In this area, you'll learn how to replenish your grass ammunition. Proceed to the signpost on the left to learn how to harvest grass.";
        }
    }

    public void TutorialButton3Pressed()
    {
        if (signpostActive == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton3.SetActive(false);
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
