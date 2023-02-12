using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSignpost1 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
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
            signpostActive = true;
            tutorialSignCanvas.SetActive(true);
            tutorialText.text = "Hey farmer, welcome to the frantic farm! Here you will learn how to tend to animals, collect resources and trade in order to gain stars to win.";
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
