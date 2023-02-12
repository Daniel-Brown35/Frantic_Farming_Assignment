using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost9 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    public GameObject tutorialCow;
    public GameObject tutorialSheep;
    public GameObject tutorialChicken;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton9;
    public Image keyBubble;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton9.SetActive(false);
        tutorialSignCanvas.SetActive(false);
        tutorialCow.SetActive(false);
        tutorialSheep.SetActive(false);
        tutorialChicken.SetActive(false);
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
            tutorialButton9.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "You've learned all the core gameplay mechanics of Frantic Farming, on your left is a pen with animals in it for you to practice your new skills. You can go back to the previous area to refill your ammo. To end the tutorial sell any of the produce the animals drop at the trading post in the barn in front of you.";
                
        }
    }

    public void TutorialButton9Pressed()
    {
        if (signpostActive == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton9.SetActive(false);
            tutorialSignCanvas.SetActive(false);
            tutorialCow.SetActive(true);
            tutorialSheep.SetActive(true);
            tutorialChicken.SetActive(true);
            tutorialCow.GetComponent<Walk>().Invoke("move", tutorialCow.GetComponent<Walk>().Delay);
            tutorialSheep.GetComponent<Walk>().Invoke("move", tutorialSheep.GetComponent<Walk>().Delay);
            tutorialChicken.GetComponent<Walk>().Invoke("move", tutorialChicken.GetComponent<Walk>().Delay);
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
