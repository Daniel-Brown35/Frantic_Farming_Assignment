using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public int milkCount;
    public int eggCount;
    public int woolCount;

    public int money;

    public TMP_Text milkTextHUD;
    public TMP_Text eggTextHUD;
    public TMP_Text woolTextHUD;
    public TMP_Text moneyTextHUD;

    public Sprite earnedStar;
    public Sprite nonFullMilkSprite;
    public Sprite nonFullEggSprite;
    public Sprite nonFullWoolSprite;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject milkObjectHUD;
    public GameObject eggObjectHUD;
    public GameObject woolObjectHUD;
    private Image star1Image;
    private Image star2Image;
    private Image star3Image;
    public AudioSource audioSource;
    public AudioClip starEarnSound;
    public int currentStar1Requirement;
    public int currentStar2Requirement;
    public int currentStar3Requirement;
    private bool star1Earned;
    private bool star2Earned;
    private bool star3Earned;
    private Image milkImage;
    private Image eggImage;
    private Image woolImage;
    public Sprite fullMilkSprite;
    public Sprite fullEggSprite;
    public Sprite fullWoolSprite;

    private LevelOneRequirements levelOneRequirements;
    private LevelTwoRequirements levelTwoRequirements;
    

    // Start is called before the first frame update
    void Start()
    {
        milkCount = 0;
        eggCount = 0;
        woolCount = 0;
        milkTextHUD.text = milkCount.ToString();
        eggTextHUD.text = eggCount.ToString();
        woolTextHUD.text = woolCount.ToString();
        moneyTextHUD.text = money.ToString();
        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
        milkImage = milkObjectHUD.GetComponent<Image>();
        eggImage = eggObjectHUD.GetComponent<Image>();
        woolImage = woolObjectHUD.GetComponent<Image>();

        if (SceneManager.GetActiveScene().name == "LevelOneScene")
        {
            levelOneRequirements = GameObject.Find("EventSystem").GetComponent<LevelOneRequirements>();
            currentStar1Requirement = levelOneRequirements.star1Requirement;
            currentStar2Requirement = levelOneRequirements.star2Requirement;
            currentStar3Requirement = levelOneRequirements.star3Requirement;
        }
    }

    public void AddMilk(int amount)
    {
        milkCount = milkCount + amount;
        milkTextHUD.text = milkCount.ToString();
        if (milkCount == 9)
        {
            milkImage.sprite = fullMilkSprite;
        }
    }
    
    public void AddEgg(int amount)
    {
        eggCount = eggCount + amount;
        eggTextHUD.text = eggCount.ToString();
        if (eggCount == 9)
        {
            eggImage.sprite = fullEggSprite;
        }
    }
    public void AddWool(int amount)
    {
        woolCount = woolCount + amount;
        woolTextHUD.text = woolCount.ToString();
        if (woolCount == 9)
        {
            woolImage.sprite = fullWoolSprite;
        }
    }

    public void UpdateHUD()
    {
        if (milkCount < 9)
        {
            milkImage.sprite = nonFullMilkSprite;
        }
        if (eggCount < 9)
        {
            eggImage.sprite = nonFullEggSprite;
        }
        if (woolCount < 9)
        {
            woolImage.sprite = nonFullWoolSprite;
        }
        milkTextHUD.text = milkCount.ToString();
        eggTextHUD.text = eggCount.ToString();
        woolTextHUD.text = woolCount.ToString();
        moneyTextHUD.text = money.ToString();
        UpdateStar();
    }

    public void UpdateStar()
    {
        if (money >= currentStar1Requirement)
        {
            star1Image.sprite = earnedStar;
            if (star1Earned == false)
            {
                audioSource.PlayOneShot(starEarnSound);
                star1Earned = true;
            }
        }
        if (money >= currentStar2Requirement)
        {
            star2Image.sprite = earnedStar;
            if (star2Earned == false)
            {
                audioSource.PlayOneShot(starEarnSound);
                star2Earned = true;
            }
        }
        if (money >= currentStar3Requirement)
        {
            star3Image.sprite = earnedStar;
            if (star3Earned == false)
            {
                audioSource.PlayOneShot(starEarnSound);
                star3Earned = true;
            }
        }
    }
}
