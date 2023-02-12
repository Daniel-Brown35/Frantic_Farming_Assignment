using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellEgg : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private TradingPost tradingPost;
    private bool doOnce;
    public AudioSource audioSource;
    public AudioClip buttonSelect;
    private void Start()
    {
       playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
       tradingPost = GameObject.Find("TradingPostPlaceholder").GetComponent<TradingPost>();
    }

    public void SellEggClicked()
    {
        if (playerInventory.eggCount > 0)
        {
            audioSource.PlayOneShot(buttonSelect);
            playerInventory.eggCount--;
            playerInventory.money += 50;
            playerInventory.UpdateHUD();
            tradingPost.UpdateTPHUD();
        }
    }
}
