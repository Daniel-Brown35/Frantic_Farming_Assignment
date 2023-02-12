using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupController : MonoBehaviour
{
    public Transform holdArea;
    private GameObject heldAnimal;
    private Rigidbody heldAnimalRB;
    private bool pickedPoop;

    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldAnimal == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    if (hit.transform.gameObject.tag == "Animal" && hit.transform.gameObject.GetComponent<Walk>().canBePickedUp == true)
                    {
                    PickupAnimal(hit.transform.gameObject);
                    }
                    else
                        if (hit.transform.gameObject.tag == "Poop")
                    {
                        PickupPoop(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                DropAnimal();
            }
        }
        if (heldAnimal != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldAnimal.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldAnimal.transform.position);
            heldAnimalRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupAnimal(GameObject pickObject)
    {
        NavMeshAgent animalNavMesh = pickObject.GetComponent<NavMeshAgent>();
        animalNavMesh.enabled = false;
        if(pickObject.GetComponent<Rigidbody>())
        { 
            heldAnimalRB = pickObject.GetComponent<Rigidbody>();
            heldAnimalRB.useGravity = false;
            heldAnimalRB.drag = 10;
            heldAnimalRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldAnimalRB.transform.parent = holdArea;
            pickObject.transform.position = new Vector3(holdArea.transform.position.x, holdArea.transform.position.y, holdArea.transform.position.z);
            heldAnimal = pickObject;
        }
    }
    void DropAnimal()
    {
        if (pickedPoop == true)
        {
            heldAnimalRB.useGravity = true;
            heldAnimalRB.drag = 1;
            heldAnimalRB.constraints = RigidbodyConstraints.None;
            heldAnimal.transform.parent = null;
            heldAnimal = null;
        }
        else
        {
            if (heldAnimal.GetComponent<Walk>().inPenArea == true)
            {
                heldAnimal.GetComponent<NavMeshAgent>().enabled = true;
                heldAnimalRB.useGravity = true;
                heldAnimalRB.drag = 1;
                heldAnimalRB.constraints = RigidbodyConstraints.None;
                heldAnimal.GetComponent<Walk>().Repen();
                heldAnimal.transform.parent = null;
                heldAnimal = null;
            }
        }
    }

    void PickupPoop(GameObject pickObject)
    {
        pickedPoop = true;
        if (pickObject.GetComponent<Rigidbody>())
        {
            heldAnimalRB = pickObject.GetComponent<Rigidbody>();
            heldAnimalRB.useGravity = false;
            heldAnimalRB.drag = 10;
            heldAnimalRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldAnimalRB.transform.parent = holdArea;
            pickObject.transform.position = new Vector3(holdArea.transform.position.x, holdArea.transform.position.y, holdArea.transform.position.z);
            heldAnimal = pickObject;
        }
    }
}
