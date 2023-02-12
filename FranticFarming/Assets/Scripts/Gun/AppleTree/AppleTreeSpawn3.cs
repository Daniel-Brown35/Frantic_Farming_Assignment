using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeSpawn3 : MonoBehaviour
{
    public GameObject spawnPoint;
    public bool appleReady;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harvest")
        {
            appleReady = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Harvest")
        {
            appleReady = false;
        }
    }
}
