using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private float volume;
    public Sprite earnedStar;
    public GameObject levelOneStar1;
    public GameObject levelOneStar2;
    public GameObject levelOneStar3;
    public GameObject levelTwoStar1;
    public GameObject levelTwoStar2;
    public GameObject levelTwoStar3;
    public TMP_Text levelOneBestScore;
    public TMP_Text levelTwoBestScore;

    public void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = volume;
        if (PlayerPrefs.HasKey("LevelOneStars"))
        {
            if (PlayerPrefs.GetInt("LevelOneStars") >= 1)
            {
                levelOneStar1.GetComponent<Image>().sprite = earnedStar;
            }
            if (PlayerPrefs.GetInt("LevelOneStars") >= 2)
            {
                levelOneStar2.GetComponent<Image>().sprite = earnedStar;
            }
            if (PlayerPrefs.GetInt("LevelOneStars") >= 3)
            {
                levelOneStar3.GetComponent<Image>().sprite = earnedStar;
            }
        }
        if (PlayerPrefs.HasKey("LevelOneScore"))
        {
        levelOneBestScore.text = PlayerPrefs.GetInt("LevelOneScore").ToString();
        }
        else
        {
            levelOneBestScore.text = "0000";
        }
        if (PlayerPrefs.HasKey("LevelTwoStars"))
        {
            if (PlayerPrefs.GetInt("LevelTwoStars") >= 1)
            {
                levelTwoStar1.GetComponent<Image>().sprite = earnedStar;
            }
            if (PlayerPrefs.GetInt("LevelTwoStars") >= 2)
            {
                levelTwoStar2.GetComponent<Image>().sprite = earnedStar;
            }
            if (PlayerPrefs.GetInt("LevelTwoStars") >= 3)
            {
                levelTwoStar3.GetComponent<Image>().sprite = earnedStar;
            }
        }
        if (PlayerPrefs.HasKey("LevelTwoScore"))
        {
        levelTwoBestScore.text = PlayerPrefs.GetInt("LevelOneScore").ToString();
        }
        else
        {
            levelTwoBestScore.text = "0000";
        }
    }
    
}
