using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBreak : MonoBehaviour
{
    
    public GameObject fenceModel;
    public GameObject brokenFenceModel;
    private bool playerInRange;
    public BoxCollider unbrokenFenceCollider;
    public BoxCollider leftSideBrokenFenceCollider;
    public BoxCollider rightSideBrokenFenceCollider;

    public AudioSource audioSource;
    public AudioClip fenceBreakSound;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Collider>().isTrigger = false;
        fenceModel.SetActive(true);
        brokenFenceModel.SetActive(false);
        leftSideBrokenFenceCollider.enabled = false;
        rightSideBrokenFenceCollider.enabled = false;
    }

    private void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.R))
        {
            //GetComponent<Collider>().isTrigger = false;
            fenceModel.SetActive(true);
            brokenFenceModel.SetActive(false);
            leftSideBrokenFenceCollider.enabled = false;
            rightSideBrokenFenceCollider.enabled = false;
            unbrokenFenceCollider.enabled = true;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animal")
        {  
            if (col.gameObject.GetComponent<Walk>().chasing == true)
            {
                {
                    brokenFenceModel.SetActive(true);
                    fenceModel.SetActive(false);
                    //GetComponent<Collider>().isTrigger = true;
                    leftSideBrokenFenceCollider.enabled = true;
                    rightSideBrokenFenceCollider.enabled = true;
                    unbrokenFenceCollider.enabled = false;
                    audioSource.PlayOneShot(fenceBreakSound);
                }
            }   
        }
       

    }
      void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            playerInRange = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
        playerInRange = false;

        }
    }
}
