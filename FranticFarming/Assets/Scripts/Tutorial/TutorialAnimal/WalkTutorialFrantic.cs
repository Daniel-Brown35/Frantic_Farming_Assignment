using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class WalkTutorialFrantic : MonoBehaviour
{
    public GameObject Player;
    private CameraShaker cameraShaker;
    public GameObject angerTimer;
    public GameObject thoughtBubble;
    public HungryUiTutorialFrantic hungryUITutorialFrantic;
    public AngerTimeTutorialFrantic angerTimeTutorialFrantic;
    public Vector3 Destination;
    NavMeshAgent theAgent;
    public int MaxTime;
    public int MaxxPos;
    public int MinxPos;
    public int xPos;
    public int MaxzPos;
    public int MinzPos;
    public int zPos;
    public int Delay;
    public bool reset = false;
    public bool chasing;
    private bool chaseDoOnce;
    private bool waitingForPacification;
    public bool canBePickedUp;
    public bool needsRepenning;
    public AudioSource audioSource;
    public AudioClip eatSound;
    public bool inPenArea;
    public bool stopChaseTutorial;

    public GameObject produce;
    public GameObject poop;
    private GameObject poopCheck;
    public Transform produceSpawnPoint;
    public float produceTimer;
    public float produceSpawnDelay;
    private bool resetCharController;
    private float resetCharControllerTimer;
    private float resetCharControllerDelay = 1f;
    //public float highHappyProduceSpawnDelay;
    //public float mediumHappyProduceSpawnDelay;
    //public float lowHappyProduceSpawnDelay;

    private float poopSpawnTimer;
    public float poopSpawnDelay;
    public GameObject eyebrow001LowNormal;
    public GameObject eyebrow002LowNormal;
    public GameObject eyebrow001LowAngry;
    public GameObject eyebrow002LowAngry;

    void Start()
    {
        cameraShaker = GameObject.Find("Player").GetComponent<CameraShaker>();
        chasing = false;
        Delay = Random.Range(0, MaxTime);
        theAgent = GetComponent<NavMeshAgent>();
        Invoke("move", Delay);
        hungryUITutorialFrantic = GetComponentInChildren(typeof(HungryUiTutorialFrantic)) as HungryUiTutorialFrantic;
        eyebrow001LowAngry.SetActive(false);
        eyebrow002LowAngry.SetActive(false);
    }


    void Update()
    {
        float percent = angerTimeTutorialFrantic.timeLeft / angerTimeTutorialFrantic.maxTime;
        poopSpawnTimer += Time.deltaTime;
        if (resetCharController == true)
        {
            resetCharControllerTimer += Time.deltaTime;
            if (resetCharControllerTimer >= resetCharControllerDelay)
            {
                GameObject.Find("Player").GetComponent<CharacterController>().enabled = true;
                resetCharController = false;
                resetCharControllerTimer = 0f;
                cameraShaker.shakeCamera = false;
            }
        }
        if (percent <= 0)
        {
            if (chaseDoOnce == false)
            {
                eyebrow001LowNormal.SetActive(false);
                eyebrow002LowNormal.SetActive(false);
                eyebrow001LowAngry.SetActive(true);
                eyebrow002LowAngry.SetActive(true);
                chaseDoOnce = true;
                chasing = true;
                waitingForPacification = true;
                //hungryUITutorialFrantic.enabled = false;
                //angerTimeTutorialFrantic.enabled = false;
                //thoughtBubble.SetActive(false);
                //angerTimer.SetActive(false);
            }
        }
        if (percent > 0)
        {
            produceTimer += Time.deltaTime;
        }
        if (produceTimer >= produceSpawnDelay)
        {
            SpawnProduce();
        }
        if (chasing == true)
        {
            Chase();
        }
        if (Vector3.Distance(this.gameObject.transform.position, Destination) < 0.1f)
        {
            Invoke("move", Delay);
        }
        if (poopSpawnTimer >= poopSpawnDelay)
        {
            poopSpawnTimer = 0;
            SpawnPoop();
        }
    }
    void move()
    {
        if (waitingForPacification == false)
        {
        xPos = Random.Range(MaxxPos, MinxPos);
        zPos = Random.Range(MaxzPos, MinzPos);
        Destination = new Vector3(xPos, this.gameObject.transform.position.y, zPos);
        theAgent.SetDestination(Destination);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == hungryUITutorialFrantic.want)
        {
            reset = true;
            audioSource.PlayOneShot(eatSound);
            hungryUITutorialFrantic.ResetVariables();         
            if (waitingForPacification == true)
            {
                Pacified();
            }
        }
        if (col.gameObject.name == "Player" && chasing == true)
        {
            chasing = false;
            GameObject player = GameObject.Find("Player");
            cameraShaker.shakeCamera = true;
            player.GetComponent<CharacterController>().enabled = false;
            resetCharController = true;
            Vector3 lastPlayerPosition = player.transform.position;
            Vector3 forceDirection = (lastPlayerPosition - transform.position).normalized;
            player.GetComponent<Rigidbody>().velocity = forceDirection * 50;
            theAgent.SetDestination(gameObject.transform.position);
            col.gameObject.GetComponent<PlayerInventory>().DropProduce();
            //hungryUITutorialFrantic.enabled = true;
            //angerTimeTutorialFrantic.enabled = true;
            //thoughtBubble.SetActive(true);
            //angerTimer.SetActive(true);
        }
    }

    void Chase()
    {
        theAgent.SetDestination(GameObject.Find("Player").transform.position);
    }


    void Pacified()
    {
        //hungryUITutorialFrantic.enabled = false;
        //angerTimeTutorialFrantic.enabled = false;
        //thoughtBubble.SetActive(false);
        //angerTimer.SetActive(false);
        eyebrow001LowNormal.SetActive(true);
        eyebrow002LowNormal.SetActive(true);
        eyebrow001LowAngry.SetActive(false);
        eyebrow002LowAngry.SetActive(false);
        chasing = false;
        waitingForPacification = false;
        canBePickedUp = true;
        needsRepenning = true;
    }

    public void Repen()
    {
        needsRepenning = false;
        GetComponent<NavMeshAgent>().enabled = true;
        Invoke("move", Delay);
        chaseDoOnce = false;
        hungryUITutorialFrantic.enabled = true;
        angerTimeTutorialFrantic.enabled = true;
        thoughtBubble.SetActive(true);
        angerTimer.SetActive(true);
        reset = true;
        canBePickedUp = false;
        stopChaseTutorial = true;
        hungryUITutorialFrantic.ResetVariables();
    }

    void SpawnProduce()
    {
        produceTimer = 0;
        GameObject newProduce = Instantiate(produce, produceSpawnPoint.position, Quaternion.identity);
    }

    void SpawnPoop()
    {
       if (poopCheck == null)
        {
        GameObject newPoop = Instantiate(poop, produceSpawnPoint.position, Quaternion.identity);
        poopCheck = newPoop;
        }
    }
}