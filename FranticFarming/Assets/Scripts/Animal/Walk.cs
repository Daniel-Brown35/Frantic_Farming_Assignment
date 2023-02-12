using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Specialized;

public class Walk : MonoBehaviour
{
    public GameObject Player;
    public HungryUi food;
    public AngerTime script;
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
    public int damage = 1;

    public AudioSource audioSource;
    public AudioClip eatSound;

    void Start()
    {
        chasing = false;
        Delay = Random.Range(0, MaxTime);
        theAgent = GetComponent<NavMeshAgent>();
        Invoke("move", Delay);
        food = GetComponentInChildren(typeof(HungryUi)) as HungryUi;

    }


    void Update()
    {
        float percent = script.timeLeft / script.maxTime;

        if (percent <= 0)
        {
            chase();

        }
        if (Vector3.Distance(this.gameObject.transform.position, Destination) < 0.01f)
        {
            Invoke("move", Delay);
        }
    }
    void move()
    {

        xPos = Random.Range(MaxxPos, MinxPos);
        zPos = Random.Range(MaxzPos, MinzPos);
        Destination = new Vector3(xPos, 1.483333f, zPos);
        theAgent.SetDestination(Destination);

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == food.want)
        {
            reset = true;
            audioSource.PlayOneShot(eatSound);
            food.ResetVariables();
            if (chasing == true)
            {
                pacified();
            }
        }

    }


    /* private void FindPlayer()
     {
         float range = 50f;
         if(Vector3.Distance(transform.position, Player.GetPosition()) < range)
         {

         }
     }*/


    void chase()
    {
        theAgent.SetDestination(GameObject.Find("Player").transform.position);
        chasing = true;
    }


    void pacified()
    {
        this.enabled = false;
    }
}