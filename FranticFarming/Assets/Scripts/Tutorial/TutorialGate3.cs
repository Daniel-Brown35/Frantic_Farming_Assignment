using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGate3 : MonoBehaviour
{
    public GameObject closedGate;
    public GameObject openGate;
    private BoxCollider gateCollider;
    private Gun gun;
    public GameObject thirdWallBarrier;


    // Start is called before the first frame update
    void Start()
    {
        closedGate.SetActive(true);
        openGate.SetActive(false);
        gateCollider = GetComponent<BoxCollider>();
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.grassAmmoLeft == gun.magazineSize && gun.grainAmmoLeft == gun.magazineSize && gun.appleAmmoLeft == gun.magazineSize)
        {
            thirdWallBarrier.GetComponent<BoxCollider>().enabled = false;
            GetComponent<Collider>().isTrigger = false;
            openGate.SetActive(true);
            closedGate.SetActive(false);
            gateCollider.enabled = false;
        }
    }
}
