using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private float volume;
    public Sprite earnedStar;
    public GameObject tutorialStar1;
    public GameObject tutorialStar2;
    public GameObject tutorialStar3;
    public GameObject levelOneStar1;
    public GameObject levelOneStar2;
    public GameObject levelOneStar3;

    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = volume;
        if (PlayerPrefs.GetInt("TutorialStars") >= 1)
        {
        tutorialStar1.GetComponent<Image>().sprite = earnedStar;
        }
        if (PlayerPrefs.GetInt("TutorialStars") >= 2)
        {
            tutorialStar2.GetComponent<Image>().sprite = earnedStar;
        }
        if (PlayerPrefs.GetInt("TutorialStars") >= 3)
        {
            tutorialStar3.GetComponent<Image>().sprite = earnedStar;
        }
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
    
}
