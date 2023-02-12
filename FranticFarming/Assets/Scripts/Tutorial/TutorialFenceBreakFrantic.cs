using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFenceBreakFrantic : MonoBehaviour
{
    
    public GameObject fenceModel;
    public GameObject brokenFenceModel;
    private bool playerInRange;

    public AudioSource audioSource;
    public AudioClip fenceBreakSound;

    // Start is called before the first frame update
    void Start()
    {
        fenceModel.SetActive(true);
        brokenFenceModel.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<BoxCollider>().enabled = true;
            fenceModel.SetActive(true);
            brokenFenceModel.SetActive(false);
            GameObject.Find("TutorialGate2").GetComponent<TutorialGate2>().fenceRepaired = true;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animal")
        {  
            if (col.gameObject.GetComponent<WalkTutorialFrantic>().chasing == true)
            {
                {
                    brokenFenceModel.SetActive(true);
                    fenceModel.SetActive(false);
                    GetComponent<BoxCollider>().enabled = false;
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
