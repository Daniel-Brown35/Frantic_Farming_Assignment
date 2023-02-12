using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGate2 : MonoBehaviour
{
    public GameObject closedGate;
    public GameObject openGate;
    private BoxCollider gateCollider;
    private WalkTutorialFrantic walkTutorialFranticScript;
    public bool fenceRepaired;
    private bool tutorialPassed;
    private Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        
        closedGate.SetActive(true);
        openGate.SetActive(false);
        gateCollider = GetComponent<BoxCollider>();
        walkTutorialFranticScript = GameObject.Find("TutorialAnimalCowFrantic").GetComponent<WalkTutorialFrantic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.grassAmmoLeft < 1 && tutorialPassed == false)
        {
            gun.HarvestedGrass();
        }
        if (gun.grainAmmoLeft < 1 && tutorialPassed == false)
        {
            gun.HarvestedGrain();
        }
        if (gun.appleAmmoLeft < 1 && tutorialPassed == false)
        {
            gun.HarvestedApple();
        }
        if (walkTutorialFranticScript.stopChaseTutorial == true && fenceRepaired == true)
        {
            GetComponent<Collider>().isTrigger = false;
            openGate.SetActive(true);
            closedGate.SetActive(false);
            gateCollider.enabled = false;
            tutorialPassed = true;
        }
    }
}
