using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassField : MonoBehaviour
{
    public GameObject grassSpawnPoint1;
    public GameObject grassSpawnPoint2;
    public GameObject grassSpawnPoint3;
    public GameObject grassSpawnPoint4;
    public GameObject grassSpawnPoint5;
    public GameObject grassSpawnPoint6;
    public GameObject grassSpawnPoint7;
    public GameObject grassSpawnPoint8;
    public GameObject grassSpawnPoint9;
    private GrassSpawnPoint1 grassSpawnPoint1Script;
    private GrassSpawnPoint2 grassSpawnPoint2Script;
    private GrassSpawnPoint3 grassSpawnPoint3Script;
    private GrassSpawnPoint4 grassSpawnPoint4Script;
    private GrassSpawnPoint5 grassSpawnPoint5Script;
    private GrassSpawnPoint6 grassSpawnPoint6Script;
    private GrassSpawnPoint7 grassSpawnPoint7Script;
    private GrassSpawnPoint8 grassSpawnPoint8Script;
    private GrassSpawnPoint9 grassSpawnPoint9Script;

    public GameObject grassStage1;
    public GameObject grassStage2;
    public GameObject grassStage3;
    public GameObject grassStage4;

    private float grass1Timer;
    private float grass2Timer;
    private float grass3Timer;
    private float grass4Timer;
    private float grass5Timer;
    private float grass6Timer;
    private float grass7Timer;
    private float grass8Timer;
    private float grass9Timer;

    private int grass1Stage;
    private int grass2Stage;
    private int grass3Stage;
    private int grass4Stage;
    private int grass5Stage;
    private int grass6Stage;
    private int grass7Stage;
    private int grass8Stage;
    private int grass9Stage;

    private float grass1SpawnDelay;
    private float grass2SpawnDelay;
    private float grass3SpawnDelay;
    private float grass4SpawnDelay;
    private float grass5SpawnDelay;
    private float grass6SpawnDelay;
    private float grass7SpawnDelay;
    private float grass8SpawnDelay;
    private float grass9SpawnDelay;
    public float spawnDelay;
    public float nextStageDelay;

    private Gun gun;

    private GameObject grass1;
    private GameObject grass2;
    private GameObject grass3;
    private GameObject grass4;
    private GameObject grass5;
    private GameObject grass6;
    private GameObject grass7;
    private GameObject grass8;
    private GameObject grass9;
    public GameObject suckableGrass;
    private bool testBool;

    // Start is called before the first frame update
    void Start()
    {
        grassSpawnPoint1Script = grassSpawnPoint1.GetComponent<GrassSpawnPoint1>();
        grassSpawnPoint2Script = grassSpawnPoint2.GetComponent<GrassSpawnPoint2>();
        grassSpawnPoint3Script = grassSpawnPoint3.GetComponent<GrassSpawnPoint3>();
        grassSpawnPoint4Script = grassSpawnPoint4.GetComponent<GrassSpawnPoint4>();
        grassSpawnPoint5Script = grassSpawnPoint5.GetComponent<GrassSpawnPoint5>();
        grassSpawnPoint6Script = grassSpawnPoint6.GetComponent<GrassSpawnPoint6>();
        grassSpawnPoint7Script = grassSpawnPoint7.GetComponent<GrassSpawnPoint7>();
        grassSpawnPoint8Script = grassSpawnPoint8.GetComponent<GrassSpawnPoint8>();
        grassSpawnPoint9Script = grassSpawnPoint9.GetComponent<GrassSpawnPoint9>();
        gun = GameObject.Find("Gun").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(grassSpawnPoint1Script.grassReady);

        Debug.Log("In Suckable Area:" + grassSpawnPoint1Script.inSuckableArea);
        Debug.Log("Player Sucking :" + gun.playerSucking);
        //Debug.Log(testBool);
        if (grassSpawnPoint1Script.grassReady == false)
        {
            grass1SpawnDelay += Time.deltaTime;
        }
        if (grass1SpawnDelay >= spawnDelay)
        {
            grass1SpawnDelay = 0;
            grass1 = Instantiate(grassStage1, grassSpawnPoint1.transform.position, Quaternion.identity);
            grass1Timer = 0;
            grass1Stage = 4;
        }
        if (grassSpawnPoint1Script.inSuckableArea == true && grass1Stage == 4 && gun.playerSucking == true)
        {
            testBool = true;
        }
        
        if (testBool == true)
        {
            Destroy(grass1);
            GameObject newSuckableGrass = Instantiate(suckableGrass, grassSpawnPoint1.transform.position, Quaternion.identity);
        }

        //if (grassSpawnPoint1Script.grassReady == true)
        //{
        //    grass1Timer += Time.deltaTime;
        //    if (grass1Timer >= 5f)
        //    {
        //        grass1 = grassStage2;
        //    }
        //}
    }
}
