using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRequirements : MonoBehaviour
{
    public int star1Requirement;
    public int star2Requirement;
    public int star3Requirement;
    public int maxSensitivity;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerMovement.lookSensitivity = PlayerPrefs.GetFloat("Sensitivity") * maxSensitivity;
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("Gun").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("TradingPostPlaceholder").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }
    public void UpdateValues()
    {
        playerMovement.lookSensitivity = PlayerPrefs.GetFloat("Sensitivity") * maxSensitivity;
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("Gun").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GameObject.Find("TradingPostPlaceholder").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }
}
