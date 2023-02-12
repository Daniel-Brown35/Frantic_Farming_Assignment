using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TradingPost : MonoBehaviour
{
    private GameObject tpCanvas;
    public bool activelyTrading;
    private PlayerInventory playerInventory;
    private Gun gun;
    private PlayerMovement playerMovement;

    public TMP_Text tpMilkHUD;
    public TMP_Text tpEggHUD;
    public TMP_Text tpWoolHUD;
    public TMP_Text tpMoneyHUD;

    public Sprite earnedStar;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private Image star1Image;
    private Image star2Image;
    private Image star3Image;

    public TMP_Text tpStar1Text;
    public TMP_Text tpStar2Text;
    public TMP_Text tpStar3Text;

    public Slider tpSlider;
    public TMP_Text tpSliderText;
    private Timer timer;

    private AudioSource audioSource;

    private void Start()
    {
        tpCanvas = GameObject.Find("TradingPostUI");
        if (SceneManager.GetActiveScene().name == "LevelOneScene")
        {
            timer = GameObject.Find("PlayerHUD").GetComponentInChildren<Timer>();
            tpSlider.maxValue = timer.levelTimeLimit;
            tpStar1Text.text = GameObject.Find("EventSystem").GetComponent<LevelOneRequirements>().star1Requirement.ToString();
            tpStar2Text.text = GameObject.Find("EventSystem").GetComponent<LevelOneRequirements>().star2Requirement.ToString();
            tpStar3Text.text = GameObject.Find("EventSystem").GetComponent<LevelOneRequirements>().star3Requirement.ToString();
        }
        if (SceneManager.GetActiveScene().name == "LevelTwoScene")
        {
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            tpSlider.maxValue = timer.levelTimeLimit;
            tpStar1Text.text = GameObject.Find("EventSystem").GetComponent<LevelTwoRequirements>().star1Requirement.ToString();
            tpStar2Text.text = GameObject.Find("EventSystem").GetComponent<LevelTwoRequirements>().star2Requirement.ToString();
            tpStar3Text.text = GameObject.Find("EventSystem").GetComponent<LevelTwoRequirements>().star3Requirement.ToString();
        }
        tpCanvas.SetActive(false);

        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "TutorialScene")
        {
            tpSlider.value = timer.timeLeft;

            int minutes = (int)(timer.timeLeft / 60);
            int seconds = (int)(timer.timeLeft - minutes * 60f);

            if (timer.timerStopped == false)
            {
                tpSliderText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
                tpSlider.value = timer.timeLeft;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "PlayerModel")
        {
            playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
            playerMovement.canMove = false;
            tpMilkHUD.text = playerInventory.milkCount.ToString();
            tpEggHUD.text = playerInventory.eggCount.ToString();
            tpWoolHUD.text = playerInventory.woolCount.ToString();
            tpMoneyHUD.text = playerInventory.money.ToString();
            tpCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            activelyTrading = true;
            gun.readyToShoot = false;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "PlayerModel")
        {
            DeactivateTP();
        }
    }

    public void DeactivateTP()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        activelyTrading = false;
        audioSource.Stop();
        tpCanvas.SetActive(false);
        gun.readyToShoot = true;
        playerMovement.canMove = true;
    }

    public void UpdateTPHUD()
    {
        tpMilkHUD.text = playerInventory.milkCount.ToString();
        tpEggHUD.text = playerInventory.eggCount.ToString();
        tpWoolHUD.text = playerInventory.woolCount.ToString();
        tpMoneyHUD.text = playerInventory.money.ToString();
        UpdateStar();
    }
    public void UpdateStar()
    {
        if (playerInventory.money >= playerInventory.currentStar1Requirement)
        {
            star1Image.sprite = earnedStar;
        }
        if (playerInventory.money >= playerInventory.currentStar2Requirement)
        {
            star2Image.sprite = earnedStar;
        }
        if (playerInventory.money >= playerInventory.currentStar3Requirement)
        {
            star3Image.sprite = earnedStar;
        }
    }
}
