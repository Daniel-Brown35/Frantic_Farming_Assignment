using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnPoint1 : MonoBehaviour
{
    public GameObject spawnPoint;
    public bool grassReady;
    public bool inSuckableArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SuckableArea")
        {
            inSuckableArea = true;
        }
        if (other.gameObject.tag == "Harvest")
        {
            grassReady = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Harvest")
        {
            grassReady = false;
        }
    }
}
