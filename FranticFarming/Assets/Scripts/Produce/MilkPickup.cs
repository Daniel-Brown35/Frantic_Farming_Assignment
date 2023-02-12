using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPickup : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private bool doOnce = false;
    private bool ifDoOnce;
    public float volume;

    private AudioSource audioSource;
    public AudioClip pickupSound;
    public AudioClip inventoryFullSound;

    private void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        audioSource = GameObject.Find("SoundSystem").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (playerInventory.milkCount >= 9 && ifDoOnce == false)
            {
                ifDoOnce = true;
                audioSource.PlayOneShot(inventoryFullSound, volume);
            }
            if (doOnce == false && playerInventory.milkCount < 9)
            {
                doOnce = true;
                audioSource.PlayOneShot(pickupSound);
                playerInventory.AddMilk(1);
                playerInventory.UpdateHUD();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ifDoOnce = false;
        }
    }
}
