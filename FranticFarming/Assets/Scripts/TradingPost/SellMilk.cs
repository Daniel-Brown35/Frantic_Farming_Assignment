using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMilk : MonoBehaviour
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

    public void SellMilkClicked()
    {
        if (playerInventory.milkCount > 0)
        {
            audioSource.PlayOneShot(buttonSelect);
            playerInventory.milkCount--;
            playerInventory.money += 50;
            playerInventory.UpdateHUD();
            tradingPost.UpdateTPHUD();
        }
    }
}
