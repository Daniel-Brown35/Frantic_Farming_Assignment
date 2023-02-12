using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGate1 : MonoBehaviour
{
    public GameObject closedGate;
    public GameObject openGate;
    private BoxCollider gateCollider;
    public HungryUiTutorial hungryUiTutorialScript;


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
        if (hungryUiTutorialScript.openGate1 == true)
        {
            GetComponent<Collider>().isTrigger = false;
            openGate.SetActive(true);
            closedGate.SetActive(false);
            gateCollider.enabled = false;
        }
    }
}
