using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost2 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private bool onLastPage;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton2;
    public Image keyBubble;
    public Image tutorialSignImage;
    public Sprite tutorialSignImageNext;
    public Sprite tutorialSignImageClose;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton2.SetActive(false);
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
            onLastPage = false;
            signpostActive = true;
            tutorialSignCanvas.SetActive(true);
            tutorialButton2.SetActive(true);
            tutorialSignImage.sprite = tutorialSignImageNext;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "To get started, you must learn how to feed the animals. Feeding animals is important for keeping animals happy and ensuring they don't go frantic. Happy animals will occasionally drop produce which can be sold for money at the trading post in the barn.";
        }
    }

    public void TutorialButton2Pressed()
    {
        if (signpostActive == true && onLastPage == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton2.SetActive(false);
            tutorialSignCanvas.SetActive(false);
        }
        if (signpostActive == true && onLastPage == false)
        {
            tutorialText.text = "To feed an animal you must select the correct food type! Press 1 for grass, 2 for grain and 3 for apples. With the correct ammo selected press left mouse to shoot your feed at the animal.";
            onLastPage = true;
            tutorialSignImage.sprite = tutorialSignImageClose;
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
