using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainHarvestPoint : MonoBehaviour
{
    private float grainRespawnTimer;
    public float respawnDelay;
    public GameObject grainStage1;
    public GameObject grainStage2;
    public GameObject suckableGrain;
    private GameObject grainCheck;
    private bool readyToHarvest;
    private float grassStageUpTimer;
    public float stageUpDelay;
    private int grainStage;
    private Gun gun;
    private bool inSuckableArea;
    public bool needsFertilizing;
    private bool fertilizerDoOnce;
    public GameObject fertileField;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grainCheck == null)
        {
            grainRespawnTimer += Time.deltaTime;
        }
        if (grainCheck != null && needsFertilizing == false)
        {
            grassStageUpTimer += Time.deltaTime;
        }
        if (grassStageUpTimer >= (stageUpDelay))
        {
            if (fertilizerDoOnce == false)
            {
            fertilizerDoOnce = true;
            fertileField.GetComponent<FertilizerCheck>().showBubble = true;
            needsFertilizing = true;
            }
        }
        if (grassStageUpTimer >= stageUpDelay && needsFertilizing == false)
        {
            grassStageUpTimer = 0;
            
            if (grainStage == 1)
            {
                Destroy(grainCheck);
                GameObject newHarvestableGrain = Instantiate(grainStage2, gameObject.transform.position, Quaternion.identity);
                grainCheck = newHarvestableGrain;
                grainStage = 2;
                readyToHarvest = true;
            }
        }
        if (grainRespawnTimer >= respawnDelay)
        {
            fertilizerDoOnce = false;
            grainRespawnTimer = 0;
            GameObject newGrain = Instantiate(grainStage1, gameObject.transform.position, Quaternion.identity);
            grainCheck = newGrain;
            grainStage = 1;
        }
        if (readyToHarvest == true && inSuckableArea == true && gun.playerSucking == true)
        {
            readyToHarvest = false;
            Destroy(grainCheck);
            GameObject newSuckableGrass = Instantiate(suckableGrain, gameObject.transform.position, Quaternion.identity);           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SuckableArea")
        {
            inSuckableArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SuckableArea")
        {
            inSuckableArea = false;
        }
    }
}
