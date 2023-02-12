using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
private LevelSelector levelSelector;
	public AudioSource audioSource;
	public AudioClip buttonSelect;

	void Start()
	{
		levelSelector = GameObject.Find("EventSystem").GetComponent<LevelSelector>();
	}
    public void PlayButtonClick()
	{
        audioSource.PlayOneShot(buttonSelect);
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
