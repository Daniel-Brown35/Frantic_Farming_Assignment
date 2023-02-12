using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSignpost9 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    public GameObject tutorialCow;
    public GameObject tutorialSheep;
    public GameObject tutorialChicken;

    // Start is called before the first frame update
    void Start()
    {
        tutorialSignCanvas.SetActive(false);
        tutorialCow.SetActive(false);
        tutorialSheep.SetActive(false);
        tutorialChicken.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            signpostActive = true;
            tutorialSignCanvas.SetActive(true);
            tutorialText.text = "You've learned all the core gameplay mechanics of Frantic Farming, on your left is a pen with animals in it for you to practice your new skills. You can go back to the previous area to refill your ammo. To end the tutorial sell any of the produce the animals drop at the trading post in the barn in front of you.";
                
        }
        if (signpostActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                signpostActive = false;
                tutorialSignCanvas.SetActive(false);
                tutorialCow.SetActive(true);
                tutorialSheep.SetActive(true);
                tutorialChicken.SetActive(true);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            playerInRange = false;
        }
    }
}
