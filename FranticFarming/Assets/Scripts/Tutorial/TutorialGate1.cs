using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGate1 : MonoBehaviour
{
    public GameObject closedGate;
    public GameObject openGate;
    private BoxCollider gateCollider;
    public HungryUiTutorial hungryUiTutorialScript;
    private TutorialSignpost1 tutorialSignpost1;
    public GameObject firstWallBarrier;


    // Start is called before the first frame update
    void Start()
    {
        closedGate.SetActive(true);
        openGate.SetActive(false);
        gateCollider = GetComponent<BoxCollider>();
        tutorialSignpost1 = GameObject.Find("TutorialSign1").GetComponent<TutorialSignpost1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hungryUiTutorialScript.openGate1 == true)
        {
            firstWallBarrier.GetComponent<BoxCollider>().enabled = false;
            GetComponent<Collider>().isTrigger = false;
            openGate.SetActive(true);
            closedGate.SetActive(false);
            gateCollider.enabled = false;
        }
    }
}
