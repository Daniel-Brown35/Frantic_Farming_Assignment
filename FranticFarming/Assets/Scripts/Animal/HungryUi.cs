using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungryUi : MonoBehaviour
{
    [SerializeField] GameObject _object;
    public GameObject produce;
    public Transform produceSpawnPoint;
    public AngerTime script;
    public Image image1;
    public Image image2;
    public Image image3;
    public string want;

    public float produceTimer;
    private float produceSpawnDelay;
    public float highHappyProduceSpawnDelay;
    public float mediumHappyProduceSpawnDelay;
    public float lowHappyProduceSpawnDelay;

    public AudioSource audioSource;
    public AudioClip cowMoo;
    private bool mooOnce;
    public AudioClip angryCowMoo;
    private bool angryMooOnce;
    public AudioClip angrierCowMoo;
    private bool angrierMooOnce;
    private bool doOnce1T;
    private bool doOnce2T;
    private bool doOnce3T;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _object.transform.position);
        float percent = script.timeLeft / script.maxTime;

        if (percent > 0)
        {
            produceTimer += Time.deltaTime;
        }
        if (percent > 0 && percent < 0.25)
        {
            produceSpawnDelay = lowHappyProduceSpawnDelay;
        }
        if (percent >= 0.25 && percent < 0.5)
        {
            produceSpawnDelay = mediumHappyProduceSpawnDelay;
        }
        if (percent >= 0.5)
        {
            produceSpawnDelay = highHappyProduceSpawnDelay;
        }

        if (produceTimer >= produceSpawnDelay)
        {
            SpawnProduce();
        }

        if (percent < 0.25 && doOnce3T == false)
        {
            doOnce3T = true;
            int randomFood = Random.Range(1, 4);
            if (randomFood == 1)
            {
                image3.enabled = true;
                image2.enabled = false;
                image1.enabled = false;
                want = "grass";
            }
            if (randomFood == 2)
            {
                image2.enabled = true;
                image3.enabled = false;
                image1.enabled = false;
                want = "grain";
            }
            if (randomFood == 3)
            {
                image1.enabled = true;
                image3.enabled = false;
                image2.enabled = false;
                want = "apple";
            }
            if (mooOnce == false)
            {
                mooOnce = true;
                audioSource.PlayOneShot(angrierCowMoo);
            }
        }
        else if (percent < 0.50 && doOnce2T == false)
        {
            doOnce2T = true;
            int randomFood = Random.Range(1, 4);
            if (randomFood == 1)
            {
                image3.enabled = true;
                image2.enabled = false;
                image1.enabled = false;
                want = "grass";
            }
            if (randomFood == 2)
            {
                image2.enabled = true;
                image3.enabled = false;
                image1.enabled = false;
                want = "grain";
            }
            if (randomFood == 3)
            {
                image1.enabled = true;
                image3.enabled = false;
                image2.enabled = false;
                want = "apple";
            }
            if (angryMooOnce == false)
            {
                angryMooOnce = true;
                audioSource.PlayOneShot(angryCowMoo);
            }
        }
        else if (percent < 0.75 && doOnce1T == false)
        {
            doOnce1T = true;
            int randomFood = Random.Range(1, 4);
            if (randomFood == 1)
            {
                image3.enabled = true;
                image2.enabled = false;
                image1.enabled = false;
                want = "grass";
            }
            if (randomFood == 2)
            {
                image2.enabled = true;
                image3.enabled = false;
                image1.enabled = false;
                want = "grain";
            }
            if (randomFood == 3)
            {
                image1.enabled = true;
                image3.enabled = false;
                image2.enabled = false;
                want = "apple";
            }
            if (angrierMooOnce == false)
            {
                angrierMooOnce = true;
                audioSource.PlayOneShot(cowMoo);
            }
        }
    }

    void SpawnProduce()
    {
        produceTimer = 0;
        GameObject newProduce = Instantiate(produce, produceSpawnPoint.position, Quaternion.identity);
    }

    public void ResetVariables()
    {
        mooOnce = false;
        angryMooOnce = false;
        angrierMooOnce = false;
        doOnce1T = false;
        doOnce2T = false;
        doOnce3T = false;
        image1.enabled = false;
        image2.enabled = false;
        image3.enabled = false;
        want = "";
    }
}
