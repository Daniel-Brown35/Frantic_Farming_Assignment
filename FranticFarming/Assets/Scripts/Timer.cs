using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public TMP_Text timerText;   
    private float timeLeft;
    public float levelTimeLimit;
    private bool timerStopped;

    private GameObject levelComplete;
    private PlayerInventory playerInventory;
    public TMP_Text score;
    public Sprite earnedStar;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private Image star1Image;
    private Image star2Image;
    private Image star3Image;

    public AudioSource audioSource;
    public AudioClip timeoutSound;
    public AudioClip levelCompleteSound;
    private bool doOnceTimeoutSound;
    private bool doOnceLevelComplete;
    public float levelCompleteDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = levelTimeLimit;
        timerStopped = false;
        timerSlider.maxValue = levelTimeLimit;
        timerSlider.value = timeLeft;
        if (SceneManager.GetActiveScene().name != "TutorialScene")
        {
        levelComplete = GameObject.Find("LevelCompleteScreen");
        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
        levelComplete.SetActive(false);
        }
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "TutorialScene")
        {
            timeLeft = timeLeft -= Time.deltaTime;
        }

        int minutes = (int)(timeLeft / 60);
        int seconds = (int)(timeLeft - minutes * 60f);

        if (timeLeft <= 0)
        {
            timerStopped = true;
            levelCompleteDelay += Time.deltaTime;

            if (doOnceTimeoutSound == false)
            {
                doOnceTimeoutSound = true;
                audioSource.PlayOneShot(timeoutSound);
            }
            if (playerInventory.money >= playerInventory.currentStar1Requirement && levelCompleteDelay >= 2f)
            {
                if (doOnceLevelComplete == false) 
                {
                    doOnceLevelComplete = true;
                    audioSource.PlayOneShot(levelCompleteSound);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    ShowLevelComplete();
                }
            }
        }
        if (timerStopped == false)
        {
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); 
            timerSlider.value = timeLeft;
        }
    }

    void ShowLevelComplete()
    {
        levelComplete.SetActive(true);
        score.text = playerInventory.money.ToString();
        if (playerInventory.money >= playerInventory.currentStar1Requirement)
        {
            star1Image.sprite = earnedStar;
            if (SceneManager.GetActiveScene().name == "LevelOneScene")
            {
            PlayerPrefs.SetInt("LevelOneStars", 1);
            }
        }
        if (playerInventory.money >= playerInventory.currentStar2Requirement)
        {
            star2Image.sprite = earnedStar;
            if (SceneManager.GetActiveScene().name == "LevelOneScene")
            {
                PlayerPrefs.SetInt("LevelOneStars", 2);
            }
        }
        if (playerInventory.money >= playerInventory.currentStar3Requirement)
        {
            star3Image.sprite = earnedStar;
            if (SceneManager.GetActiveScene().name == "LevelOneScene")
            {
                PlayerPrefs.SetInt("LevelOneStars", 3);
            }
        }
    }
}
