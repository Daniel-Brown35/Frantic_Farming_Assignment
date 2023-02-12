using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBreak : MonoBehaviour
{
    
    public GameObject fenceModel;
    public GameObject brokenFenceModel;
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().isTrigger = false;
        fenceModel.SetActive(true);
        brokenFenceModel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Collider>().isTrigger = false;
            fenceModel.SetActive(true);
            brokenFenceModel.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Animal")
        {  
            if (col.gameObject.GetComponentInChildren<AngerTime>().timeLeft <= 0)
            {
                {
                    brokenFenceModel.SetActive(true);
                    fenceModel.SetActive(false);
                    GetComponent<Collider>().isTrigger = true;
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
