using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGate : MonoBehaviour
{
    public GameObject closedGate;
    public GameObject openGate;
    private bool playerInRange;
    private bool isGateOpen;
    private BoxCollider gateCollider;


    // Start is called before the first frame update
    void Start()
    {
        closedGate.SetActive(true);
        openGate.SetActive(false);
        gateCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E) && isGateOpen == false)
        {
            OpenGate();
        }
        else
        {
            if (playerInRange == true && Input.GetKeyDown(KeyCode.E) && isGateOpen == true)
            {
                openGate.SetActive(false);
                closedGate.SetActive(true);
                gateCollider.enabled = true;
                isGateOpen = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Walk>(out Walk walkComponent))
        {
            if (walkComponent.chasing == true && isGateOpen == false)
            {
                OpenGate();
            }
        }
        if (collision.gameObject.TryGetComponent<WalkTutorialFrantic>(out WalkTutorialFrantic walkTutFranticComponent))
        {
            if (walkTutFranticComponent.chasing == true && isGateOpen == false)
            {
                OpenGate();
            }
        }
   
    }

    void OpenGate()
    {
        GetComponent<Collider>().isTrigger = false;
        openGate.SetActive(true);
        closedGate.SetActive(false);
        gateCollider.enabled = false;
        isGateOpen = true;
    }
}
