using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    private LevelSelector levelSelector;
    public Button tutorialButton;
    public Button levelOneButton;
    public Button levelTwoButton;
    public Color selectedColor;
    public Color notSelectedColor;

    void Start()
    {
        levelSelector = GameObject.Find("EventSystem").GetComponent<LevelSelector>();
        tutorialButton.GetComponent<Image>().color = selectedColor;
    }

    public void TutorialClicked()
    {
        levelSelector.levelSelected = 0;
        tutorialButton.GetComponent<Image>().color = selectedColor;
        levelOneButton.GetComponent<Image>().color = notSelectedColor;
        levelTwoButton.GetComponent<Image>().color = notSelectedColor;
    }
    public void LevelOneClicked()
    {
        levelSelector.levelSelected = 1;
        tutorialButton.GetComponent<Image>().color = notSelectedColor;
        levelOneButton.GetComponent<Image>().color = selectedColor;
        levelTwoButton.GetComponent<Image>().color = notSelectedColor;
    }
    public void LevelTwoClicked()
    {
        levelSelector.levelSelected = 2;
        tutorialButton.GetComponent<Image>().color = notSelectedColor;
        levelOneButton.GetComponent<Image>().color = notSelectedColor;
        levelTwoButton.GetComponent<Image>().color = selectedColor;
    }
}
