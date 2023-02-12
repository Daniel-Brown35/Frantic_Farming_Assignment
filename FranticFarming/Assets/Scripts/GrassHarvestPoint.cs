using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassHarvestPoint : MonoBehaviour
{
    private float grassRespawnTimer;
    public float respawnDelay;
    public GameObject grassStage1;
    public GameObject suckableGrass;
    private GameObject grassCheck;
    private bool readyToHarvest;
    private float grassStageUpTimer;
    public float stageUpDelay;
    public Material stage1Material;
    public Material stage2Material;
    public Material stage3Material;
    public Material stage4Material;
    private int grassStage;
    private Gun gun;
    private bool inSuckableArea;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grassCheck == null)
        {
            grassRespawnTimer += Time.deltaTime;
        }
        if (grassCheck != null)
        {
            grassStageUpTimer += Time.deltaTime;
        }
        if (grassStageUpTimer >= stageUpDelay)
        {
            Debug.Log(grassCheck.GetComponentInChildren<MeshRenderer>().material == stage1Material);
            grassStageUpTimer = 0;
            
            if (grassStage == 1)
            {
                grassCheck.GetComponentInChildren<MeshRenderer>().material = stage2Material;
                grassStage = 2;
            }
            if (grassStage == 2)
            {
                grassCheck.GetComponentInChildren<MeshRenderer>().material = stage3Material;
                grassStage = 3;
            }
            if (grassStage == 3)
            {
                grassCheck.GetComponentInChildren<MeshRenderer>().material = stage4Material;
                grassStage = 4;
                readyToHarvest = true;
            }
        }
        if (grassRespawnTimer >= respawnDelay)
        {
            grassRespawnTimer = 0;
            GameObject newGrass = Instantiate(grassStage1, gameObject.transform.position, Quaternion.identity);
            grassCheck = newGrass;
            grassCheck.GetComponentInChildren<MeshRenderer>().material = stage1Material;
            grassStage = 1;
        }
        if (readyToHarvest == true && inSuckableArea == true && gun.playerSucking == true)
        {
            readyToHarvest = false;
            Destroy(grassCheck);
            GameObject newSuckableGrass = Instantiate(suckableGrass, gameObject.transform.position, Quaternion.identity);
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
