using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject apple;
    public GameObject appleSpawnPoint1;
    public GameObject appleSpawnPoint2;
    public GameObject appleSpawnPoint3;
    private AppleTreeSpawn1 appleTreeSpawn1Script;
    private AppleTreeSpawn2 appleTreeSpawn2Script;
    private AppleTreeSpawn3 appleTreeSpawn3Script;

    private float apple1RespawnTimer;
    private float apple2RespawnTimer;
    private float apple3RespawnTimer;
    public float respawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        appleTreeSpawn1Script = appleSpawnPoint1.GetComponent<AppleTreeSpawn1>();
        appleTreeSpawn2Script = appleSpawnPoint2.GetComponent<AppleTreeSpawn2>();
        appleTreeSpawn3Script = appleSpawnPoint3.GetComponent<AppleTreeSpawn3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (appleTreeSpawn1Script.appleReady == false)
        {
            apple1RespawnTimer += Time.deltaTime;
        }
        if (appleTreeSpawn2Script.appleReady == false)
        {
            apple2RespawnTimer += Time.deltaTime;
        }
        if (appleTreeSpawn3Script.appleReady == false)
        {
            apple3RespawnTimer += Time.deltaTime;
        }
        if (apple1RespawnTimer >= respawnDelay)
        {
            apple1RespawnTimer = 0;
            GameObject newApple1 = Instantiate(apple, appleSpawnPoint1.transform.position, Quaternion.identity);
        }
        if (apple2RespawnTimer >= respawnDelay)
        {
            apple2RespawnTimer = 0;
            GameObject newApple2 = Instantiate(apple, appleSpawnPoint2.transform.position, Quaternion.identity);
        }
        if (apple3RespawnTimer >= respawnDelay)
        {
            apple3RespawnTimer = 0;
            GameObject newApple3 = Instantiate(apple, appleSpawnPoint3.transform.position, Quaternion.identity);
        }
    }
}
