using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSignpost7 : MonoBehaviour
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
            tutorialText.text = "To grow grain, you collect poop dropped from animals by pressing E then carry it over to the grain field and place it in the growing area by pressing E again. You can tell if the grain field needs fertilizing with poo if there’s a poo thought bubble above the field. From there, you can collect grain by vacuuming it with a held right mouse button exactly like you did in the previous area.";
                
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
