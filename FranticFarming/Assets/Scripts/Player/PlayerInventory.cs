using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    public TMP_Text star1TextHUD;
    public TMP_Text star2TextHUD;
    public TMP_Text star3TextHUD;

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
    private TutorialRequirements tutorialRequirements;

    private float angle;
    private float degreesBetweenSpawns;
    private Vector3 startPosition;
    private float radius = 10f;
    public GameObject milkProduce;
    public GameObject eggProduce;
    public GameObject woolProduce;
    public float produceSpeed;
    private bool tempDisableCollision;
    private float delay;

    private bool doOnceLevelComplete;
    public AudioClip levelCompleteSound;
    public TMP_Text score;
    public GameObject lcStar1;
    public GameObject lcStar2;
    public GameObject lcStar3;
    private Image lcStar1Image;
    private Image lcStar2Image;
    private Image lcStar3Image;
    private GameObject levelComplete;

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
            star1TextHUD.text = currentStar1Requirement.ToString();
            star2TextHUD.text = currentStar2Requirement.ToString();
            star3TextHUD.text = currentStar3Requirement.ToString();
        }
        if (SceneManager.GetActiveScene().name == "LevelTwoScene")
        {
            levelTwoRequirements = GameObject.Find("EventSystem").GetComponent<LevelTwoRequirements>();
            currentStar1Requirement = levelTwoRequirements.star1Requirement;
            currentStar2Requirement = levelTwoRequirements.star2Requirement;
            currentStar3Requirement = levelTwoRequirements.star3Requirement;
            star1TextHUD.text = currentStar1Requirement.ToString();
            star2TextHUD.text = currentStar2Requirement.ToString();
            star3TextHUD.text = currentStar3Requirement.ToString();
        }
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            tutorialRequirements = GameObject.Find("EventSystem").GetComponent<TutorialRequirements>();
            currentStar1Requirement = tutorialRequirements.star1Requirement;
            currentStar2Requirement = tutorialRequirements.star2Requirement;
            currentStar3Requirement = tutorialRequirements.star3Requirement;
            star1TextHUD.text = currentStar1Requirement.ToString();
            star2TextHUD.text = currentStar2Requirement.ToString();
            star3TextHUD.text = currentStar3Requirement.ToString();
        }
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
        levelComplete = GameObject.Find("LevelCompleteScreen");
        lcStar1Image = lcStar1.GetComponent<Image>();
        lcStar2Image = lcStar2.GetComponent<Image>();
        lcStar3Image = lcStar3.GetComponent<Image>();
        levelComplete.SetActive(false);
        }
    }

    private void Update()
    {
        if (tempDisableCollision == true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;        
            delay += Time.deltaTime;
            if (delay >= 1f)
            {
                tempDisableCollision = false;
                delay = 0f;
                gameObject.GetComponent<BoxCollider>().enabled = true; 
            }

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

    public void DropProduce()
    {
        tempDisableCollision = true;

        degreesBetweenSpawns = 360f / milkCount; 
        
        angle = 0f;
        startPosition = GameObject.Find("Player").transform.position;

        for (int i = 0; i < milkCount; i++) 
        {
            float produceDirXPosition = startPosition.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius; 
            float produceDirYPosition = startPosition.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius; 
            float produceDirZPosition = startPosition.z + Mathf.Tan((angle * Mathf.PI) / 180) * radius;

            produceDirXPosition += 2f;
            produceDirYPosition += 2f;
            produceDirZPosition += 2f;

            Vector3 produceVector = new Vector3(produceDirXPosition, produceDirYPosition, produceDirZPosition); 
            Vector3 produceMoveDirection = (produceVector - startPosition).normalized * produceSpeed; 



            GameObject produceDrops = Instantiate(milkProduce, startPosition, Quaternion.identity); 
            produceDrops.GetComponent<Rigidbody>().velocity = new Vector3(produceMoveDirection.x, produceMoveDirection.y, produceMoveDirection.z); 


            angle += degreesBetweenSpawns; 
        }
        milkCount = 0;

        degreesBetweenSpawns = 360f / eggCount;
        angle = 0f;

        for (int i = 0; i < eggCount; i++)
        {
            float produceDirXPosition = startPosition.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float produceDirYPosition = startPosition.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
            float produceDirZPosition = startPosition.z + Mathf.Tan((angle * Mathf.PI) / 180) * radius;

            produceDirXPosition += 2f;
            produceDirYPosition += 2f;
            produceDirZPosition += 2f;

            Vector3 produceVector = new Vector3(produceDirXPosition, produceDirYPosition, produceDirZPosition);
            Vector3 produceMoveDirection = (produceVector - startPosition).normalized * produceSpeed;


            GameObject produceDrops = Instantiate(eggProduce, startPosition, Quaternion.identity);
            produceDrops.GetComponent<Rigidbody>().velocity = new Vector3(produceMoveDirection.x, produceMoveDirection.y, produceMoveDirection.z);


            angle += degreesBetweenSpawns;
        }
        eggCount = 0;

        degreesBetweenSpawns = 360f / woolCount;
        angle = 0f;

        for (int i = 0; i < woolCount; i++)
        {
            float produceDirXPosition = startPosition.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float produceDirYPosition = startPosition.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
            float produceDirZPosition = startPosition.z + Mathf.Tan((angle * Mathf.PI) / 180) * radius;

            produceDirXPosition += 2f;
            produceDirYPosition += 2f;
            produceDirZPosition += 2f;

            Vector3 produceVector = new Vector3(produceDirXPosition, produceDirYPosition, produceDirZPosition);
            Vector3 produceMoveDirection = (produceVector - startPosition).normalized * produceSpeed;


            GameObject produceDrops = Instantiate(woolProduce, startPosition, Quaternion.identity);
            produceDrops.GetComponent<Rigidbody>().velocity = new Vector3(produceMoveDirection.x, produceMoveDirection.y, produceMoveDirection.z);


            angle += degreesBetweenSpawns;
        }
        woolCount = 0;
        UpdateHUD();
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

        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            if (money >= currentStar1Requirement)
            {
                if (doOnceLevelComplete == false)
                {
                    doOnceLevelComplete = true;
                    audioSource.PlayOneShot(levelCompleteSound);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    levelComplete.SetActive(true);
                    score.text = money.ToString();
                    if (money >= currentStar1Requirement)
                    {
                        lcStar1Image.sprite = earnedStar;
                    }
                    if (money >= currentStar2Requirement)
                    {
                        lcStar2Image.sprite = earnedStar;
                    }
                    if (money >= currentStar3Requirement)
                    {
                        lcStar3Image.sprite = earnedStar;
                    }
                }
            }
        }
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
