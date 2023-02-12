using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolPickup : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private bool doOnce;


    private AudioSource audioSource;
    public AudioClip pickupSound;

    private void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        audioSource = GameObject.Find("SoundSystem").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "PlayerModel")
        {
            if (doOnce == false && playerInventory.woolCount < 9)
            {
                doOnce = true;
                audioSource.PlayOneShot(pickupSound);
                playerInventory.AddWool(1);
                playerInventory.UpdateHUD();
                Destroy(gameObject);
            }
        }
    }
}
