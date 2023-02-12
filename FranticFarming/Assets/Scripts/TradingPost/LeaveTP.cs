using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeaveTP : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSelect;
    public void ManualExit()
    {
        audioSource.PlayOneShot(buttonSelect);
        GameObject.Find("TradingPostPlaceholder").GetComponent<TradingPost>().DeactivateTP();
    }
}
