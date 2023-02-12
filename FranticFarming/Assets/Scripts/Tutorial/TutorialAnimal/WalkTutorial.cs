using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class WalkTutorial : MonoBehaviour
{
    public GameObject Player;
    public GameObject angerTimer;
    public GameObject thoughtBubble;
    public HungryUiTutorial hungryUITutorial;
    public AngerTimeTutorial angerTimeTutorial;
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

    public GameObject produce;
    public GameObject poop;
    private GameObject poopCheck;
    public Transform produceSpawnPoint;
    public float produceTimer;
    public float produceSpawnDelay;
    //public float highHappyProduceSpawnDelay;
    //public float mediumHappyProduceSpawnDelay;
    //public float lowHappyProduceSpawnDelay;

    private float poopSpawnTimer;
    public float poopSpawnDelay;

    void Start()
    {
        chasing = false;
        Delay = Random.Range(0, MaxTime);
        theAgent = GetComponent<NavMeshAgent>();
        Invoke("move", Delay);
        hungryUITutorial = GetComponentInChildren(typeof(HungryUiTutorial)) as HungryUiTutorial;

    }


    void Update()
    {
        float percent = angerTimeTutorial.timeLeft / angerTimeTutorial.maxTime;
        poopSpawnTimer += Time.deltaTime;
        if (percent <= 0)
        {
            if (chaseDoOnce == false)
            {
                chaseDoOnce = true;
                chasing = true;
                hungryUITutorial.enabled = false;
                angerTimeTutorial.enabled = false;
                thoughtBubble.SetActive(false);
                angerTimer.SetActive(false);
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
        if (Vector3.Distance(this.gameObject.transform.position, Destination) < 0.01f)
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
        Destination = new Vector3(xPos, 1.483333f, zPos);
        theAgent.SetDestination(Destination);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == hungryUITutorial.want)
        {
            reset = true;
            audioSource.PlayOneShot(eatSound);
            hungryUITutorial.ResetVariables();
            if (waitingForPacification == true)
            {
                Pacified();
            }
        }
        if (col.gameObject.name == "Player" && chasing == true)
        {
            chasing = false;
            GameObject player = GameObject.Find("Player");
            Vector3 lastPlayerPosition = player.transform.position;
            Vector3 forceDirection = (lastPlayerPosition - transform.position).normalized;
            player.GetComponent<Rigidbody>().velocity = forceDirection * 50;
            theAgent.SetDestination(gameObject.transform.position);
            col.gameObject.GetComponent<PlayerInventory>().DropProduce();
            hungryUITutorial.enabled = true;
            angerTimeTutorial.enabled = true;
            thoughtBubble.SetActive(true);
            angerTimer.SetActive(true);
            waitingForPacification = true;
        }
    }

    void Chase()
    {
        theAgent.SetDestination(GameObject.Find("Player").transform.position);
    }


    void Pacified()
    {
        hungryUITutorial.enabled = false;
        angerTimeTutorial.enabled = false;
        thoughtBubble.SetActive(false);
        angerTimer.SetActive(false);
        canBePickedUp = true;
        needsRepenning = true;
    }

    public void Repen()
    {
        hungryUITutorial.enabled = true;
        angerTimeTutorial.enabled = true;
        thoughtBubble.SetActive(true);
        angerTimer.SetActive(true);
        reset = true;
        canBePickedUp = false;
        hungryUITutorial.ResetVariables();
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