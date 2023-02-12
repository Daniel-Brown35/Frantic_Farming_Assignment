using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSignpost5 : MonoBehaviour
{
    private bool playerInRange;
    private bool signpostActive;
    public GameObject tutorialSignCanvas;
    public TMP_Text tutorialText;
    private bool onLastPage;
    private Gun gun;
    private PlayerMovement playerMovement;
    public GameObject tutorialButton5;
    public Image keyBubble;
    public Image tutorialSignImage;
    public Sprite tutorialSignImageNext;
    public Sprite tutorialSignImageClose;

    // Start is called before the first frame update
    void Start()
    {
        tutorialButton5.SetActive(false);
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
            tutorialButton5.SetActive(true);
            tutorialSignImage.sprite = tutorialSignImageNext;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutorialText.text = "Now it's time to learn about frantic animals. Animals get frantic when their hunger bar is empty, when this happens, they will break out of their pen and attack you causing you to drop all the produce you have on the ground, to be collected again. You can pacify them as they make their way to take their rage out on you by shooting them with the food they want.";
                
        }
    }

    public void TutorialButton5Pressed()
    {
        if (signpostActive == true && onLastPage == true)
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gun.readyToShoot = true;
            signpostActive = false;
            tutorialButton5.SetActive(false);
            tutorialSignCanvas.SetActive(false);
            GameObject.Find("TutorialAnimalCowFrantic").GetComponentInChildren<AngerTimeTutorialFrantic>().startChase = true;
        }
        if (signpostActive == true && onLastPage == false)
        {
            tutorialText.text = "Once the animal is pacified it must be returned to its pen and the fence must be repaired to prevent them from escaping again." +
                    "To return an animal to its pen, grab the animal by pressing F, walk to the pen and press F again to place it back down. To repair the fence press R. Pacify the cow, place it back in the pen and repair the fence!";
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
