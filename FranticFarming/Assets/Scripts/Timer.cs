using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    
    private float gameTime;
    public float levelTimeLimit;

    private bool stopTimer;

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
    float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = levelTimeLimit;
        stopTimer = false;
        timerSlider.maxValue = levelTimeLimit;
        timerSlider.value = gameTime;
        levelComplete = GameObject.Find("LevelCompleteScreen");
        star1Image = star1.GetComponent<Image>();
        star2Image = star2.GetComponent<Image>();
        star3Image = star3.GetComponent<Image>();
        levelComplete.SetActive(false);
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime = gameTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (gameTime <= 0)
        {
            stopTimer = true;
            delay += Time.deltaTime;

            if (doOnceTimeoutSound == false)
            {
                doOnceTimeoutSound = true;
                audioSource.PlayOneShot(timeoutSound);
            }
            if (playerInventory.money >= playerInventory.currentStar1Requirement && delay >= 2f)
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

        if (stopTimer == false)
        {
            timerText.text = textTime; 
            timerSlider.value = gameTime;
        }

    }

    void ShowLevelComplete()
    {
        levelComplete.SetActive(true);
        score.text = playerInventory.money.ToString();
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
