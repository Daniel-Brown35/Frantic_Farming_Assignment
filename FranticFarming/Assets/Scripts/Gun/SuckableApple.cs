using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SuckableApple : MonoBehaviour
{
    private GameObject target;
    private Gun gun;
    public float moveSpeed;
    private Rigidbody rb;
    private bool canSuck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        target = GameObject.Find("ProjectileSpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.playerSucking == true && canSuck == true)
        {
            rb.useGravity = false;
            transform.position = Vector3.Lerp(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        if (gun.playerSucking == false)
        {
            rb.useGravity = true;
        }
    }
    private void OnCollisionEnter(Collision collider)
    {
            if (collider.gameObject.name == "Player" && gun.playerSucking == true)
            {
                gun.HarvestedApple();
                Destroy(gameObject);
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SuckableArea")
        {
            canSuck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SuckableArea")
        {
            canSuck = false;
        }
    }
}
