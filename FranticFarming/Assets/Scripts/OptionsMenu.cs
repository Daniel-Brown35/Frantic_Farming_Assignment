using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private float volume;
    public Slider volumeSlider;
    private float sensitivity;
    public Slider sensitivitySlider;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume") == false)
        {
            PlayerPrefs.SetFloat("Volume", 0.5f);
        }
        if (PlayerPrefs.HasKey("Sensitivity") == false)
        {
            PlayerPrefs.SetFloat("Sensitivity", 0.5f);
        }
        volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volume;
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        sensitivitySlider.value = sensitivity;
    }

    public void VolumeSliderChanged()
    {
        volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = volume;
    }

    public void SensitivitySliderChanged()
    {
        sensitivity = sensitivitySlider.value;
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
    }
}
