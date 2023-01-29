using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.AI;

public class Walk : MonoBehaviour
{
    public HungryUi food;
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

    public AudioSource audioSource;
    public AudioClip eatSound;

    void Start()
    {
        Delay = Random.Range(0, MaxTime);
        theAgent = GetComponent<NavMeshAgent>();
        Invoke("move", Delay);
        food = GetComponentInChildren(typeof(HungryUi)) as HungryUi;
    }


    void Update()
    {

        if(Vector3.Distance(this.gameObject.transform.position, Destination) <0.01f )
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
     if (col.gameObject.tag == "grass" && food.want == "grass" )
        {
            reset = true;
            audioSource.PlayOneShot(eatSound);
            food.ResetVariables();
        }
        else if (col.gameObject.tag == "apple" && food.want == "apple")
        {
            reset = true;
            audioSource.PlayOneShot(eatSound);
            food.ResetVariables();
        }
        else if (col.gameObject.tag == "grain" && food.want == "grain")
        {
            reset = true;
            audioSource.PlayOneShot(eatSound);
            food.ResetVariables();
        }
    }
}