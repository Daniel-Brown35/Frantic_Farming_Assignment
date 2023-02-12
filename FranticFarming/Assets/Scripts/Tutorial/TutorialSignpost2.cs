using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSignpost2 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private bool onLastPage;
    private Gun gun;
    

    // Start is called before the first frame update
    void Start()
    {
        tutorialSignCanvas.SetActive(false);
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            gun.readyToShoot = false;
            onLastPage = false;
            signpostActive = true;
            tutorialSignCanvas.SetActive(true);
            tutorialText.text = "To get started, you must learn how to feed the animals. Feeding animals is important for keeping animals happy and ensuring they don't go frantic. Happy animals will occasionally drop produce which can be sold for money at the trading post in the barn.";
        }
        if (signpostActive == true && onLastPage == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialText.text = "To feed an animal you must select the correct food type! Press 1 for grass, 2 for grain and 3 for apples. With the correct ammo selected press left mouse to shoot your feed at the animal.";
                onLastPage = true;
            }
        }
        if (signpostActive == true && onLastPage == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gun.readyToShoot = true;
                signpostActive = false;
                tutorialSignCanvas.SetActive(false);
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
