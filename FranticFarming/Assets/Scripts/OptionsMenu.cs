using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private float volume;
    public Slider volumeSlider;
    private float sensitivity;
    public Slider sensitivitySlider;
    private MainMenu mainMenu;
    public Image camShakeCheckbox;
    public Sprite camShakeChecked;
    public Sprite camShakeUnchecked;
    public AudioSource audioSource;
    public AudioClip buttonPressed;

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
        if (PlayerPrefs.HasKey("CameraShake") == false)
        {
            PlayerPrefs.SetInt("CameraShake", 1);
        }
        volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volume;
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        sensitivitySlider.value = sensitivity;
        if (PlayerPrefs.GetInt("CameraShake") == 1)
        {
            camShakeCheckbox.sprite = camShakeChecked;
        }
        else
        {
            camShakeCheckbox.sprite = camShakeUnchecked;
        }
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
        mainMenu = GameObject.Find("MainMenuCanvas").GetComponent<MainMenu>();
        }
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

    public void ResetOptionsPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        PlayerPrefs.SetFloat("Volume", 0.5f);
        PlayerPrefs.SetFloat("Sensitivity", 0.5f);
        volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volume;
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        sensitivitySlider.value = sensitivity;
        PlayerPrefs.SetInt("CameraShake", 1);
        camShakeCheckbox.sprite = camShakeChecked;
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = volume;
    }

    public void CamShakePressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        if (PlayerPrefs.GetInt("CameraShake") == 1)
        {
            PlayerPrefs.SetInt("CameraShake", 0);
            camShakeCheckbox.sprite = camShakeUnchecked;
        }
        else
        {
            PlayerPrefs.SetInt("CameraShake", 1);
            camShakeCheckbox.sprite = camShakeChecked;
        }
    }

    public void DeleteSavePressed()
    {
        audioSource.PlayOneShot(buttonPressed);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Volume", 0.5f);
        PlayerPrefs.SetFloat("Sensitivity", 0.5f);
        volume = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volume;
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        sensitivitySlider.value = sensitivity;
        PlayerPrefs.SetInt("CameraShake", 1);
        camShakeCheckbox.sprite = camShakeChecked;
        GameObject.Find("EventSystem").GetComponent<AudioSource>().volume = volume;
        GameObject.Find("SoundSystem").GetComponent<AudioSource>().volume = volume;
        mainMenu.Start();
    }
}
