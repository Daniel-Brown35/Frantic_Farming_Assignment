using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSignpost5 : MonoBehaviour
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
            tutorialText.text = "Now it's time to learn about frantic animals. Animals get frantic when their hunger bar is empty, when this happens, they will break out of their pen and attack you causing you to drop all the produce you have on the ground, to be collected again. After they've took their rage out on you, you can pacify them by shooting them with the food they want.";
                
        }
        if (signpostActive == true && onLastPage == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialText.text = "Once the animal is pacified it must be returned to its pen and the fence must be repaired to prevent them from escaping again." +
                    "To return an animal to its pen, grab the animal by pressing E, walk to the pen and press E again to place it back down. To repair the fence press R. Pacify the cow, place it back in the pen and repair the fence!";
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
                GameObject.Find("TutorialAnimalCowFrantic").GetComponentInChildren<AngerTimeTutorialFrantic>().startChase = true;
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
