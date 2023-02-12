using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    private LevelSelector levelSelector;
    public GameObject tutorialButtonObject;
    public GameObject levelOneButtonObject;
    public GameObject levelTwoButtonObject;
    private Image tutorialButtonImage;
    private Image levelOneButtonImage;
    private Image levelTwoButtonImage;
    public Sprite tutorialNotSelectedSprite;
    public Sprite levelOneNotSelectedSprite;
    public Sprite levelTwoNotSelectedSprite;
    public Sprite tutorialSelectedSprite;
    public Sprite levelOneSelectedSprite;
    public Sprite levelTwoSelectedSprite;

    public AudioSource audioSource;
    public AudioClip buttonSelect;
    void Start()
    {
        levelSelector = GameObject.Find("EventSystem").GetComponent<LevelSelector>();
        tutorialButtonImage = tutorialButtonObject.GetComponent<Image>();
        levelOneButtonImage = levelOneButtonObject.GetComponent<Image>();
        levelTwoButtonImage = levelTwoButtonObject.GetComponent<Image>();
        tutorialButtonImage.sprite = tutorialSelectedSprite;
    }

    public void TutorialClicked()
    {
        audioSource.PlayOneShot(buttonSelect);
        levelSelector.levelSelected = 0;
        tutorialButtonImage.sprite = tutorialSelectedSprite;
        levelOneButtonImage.sprite = levelOneNotSelectedSprite;
        levelTwoButtonImage.sprite = levelTwoNotSelectedSprite;
    }
    public void LevelOneClicked()
    {
        audioSource.PlayOneShot(buttonSelect);
        levelSelector.levelSelected = 1;
        tutorialButtonImage.sprite = tutorialNotSelectedSprite;
        levelOneButtonImage.sprite = levelOneSelectedSprite;
        levelTwoButtonImage.sprite = levelTwoNotSelectedSprite;
    }
    public void LevelTwoClicked()
    {
        audioSource.PlayOneShot(buttonSelect);
        levelSelector.levelSelected = 2;
        tutorialButtonImage.sprite = tutorialNotSelectedSprite;
        levelOneButtonImage.sprite = levelOneNotSelectedSprite;
        levelTwoButtonImage.sprite = levelTwoSelectedSprite;
    }
}
