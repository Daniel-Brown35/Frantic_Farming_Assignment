using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
private LevelSelector levelSelector;

	void Start()
	{
		levelSelector = GameObject.Find("EventSystem").GetComponent<LevelSelector>();
	}
    public void PlayButtonClick()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			if (levelSelector.levelSelected == 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
			if (levelSelector.levelSelected == 1)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
			}
			if (levelSelector.levelSelected == 2)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
			}
		}
	}
}
