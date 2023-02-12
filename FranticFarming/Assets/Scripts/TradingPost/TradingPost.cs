using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradingPost : MonoBehaviour
{
    private GameObject tpCanvas;
    public bool activelyTrading;
    private PlayerInventory playerInventory;
    private Gun gun;

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

    private AudioSource audioSource;

    private void Start()
    {
        tpCanvas = GameObject.Find("TradingPostUI");
        tpCanvas.SetActive(false);

        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "PlayerModel")
        {
            playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
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
