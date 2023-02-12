using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewPickup : MonoBehaviour
{
    public LayerMask pickupMask;
    public Camera playerCamera;
    public Transform pickupTarget;
    public float pickupRange;
    private Rigidbody currentObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentObject != null)
            {
                if (currentObject.gameObject.tag == "Animal" && currentObject.gameObject.name != "TutorialAnimalCowFrantic")
                {
                    if (currentObject.gameObject.name == "TutorialAnimalCow")
                    {
                        if (currentObject.gameObject.GetComponent<WalkTutorial>().inPenArea == true)
                        {
                        currentObject.gameObject.GetComponent<WalkTutorial>().Repen();
                        }
                    }
                    else
                    {
                        if (currentObject.gameObject.GetComponent<Walk>().inPenArea == true)
                        {
                        currentObject.gameObject.GetComponent<Walk>().Repen();
                        }
                    }
                }
                if (currentObject.gameObject.name == "TutorialAnimalCowFrantic")
                {
                    if (currentObject.gameObject.GetComponent<WalkTutorialFrantic>().inPenArea == true)
                    {
                        currentObject.gameObject.GetComponent<WalkTutorialFrantic>().Repen();
                    }
                }
                if (currentObject.gameObject.tag != "Poop")
                {
                currentObject.gameObject.GetComponent<NavMeshAgent>().enabled = true;
                }
                currentObject.useGravity = true;
                currentObject = null;
                return;
            }
            else
            {
                Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, pickupRange, pickupMask))
                {
                    if (hitInfo.transform.gameObject.tag == "Animal")
                    {
                        if (hitInfo.transform.gameObject.name == "TutorialAnimalCowFrantic")
                        {
                            if (hitInfo.transform.gameObject.GetComponent<WalkTutorialFrantic>().canBePickedUp == true)
                            {
                                hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                                currentObject = hitInfo.rigidbody;
                                currentObject.freezeRotation = true;
                                currentObject.useGravity = false;
                            }
                        }
                        else
                        {
                            if (hitInfo.transform.gameObject.name == "TutorialAnimalCow")
                            {
                                if (hitInfo.transform.gameObject.GetComponent<WalkTutorial>().canBePickedUp == true)
                                {
                                    hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                                    currentObject = hitInfo.rigidbody;
                                    currentObject.freezeRotation = true;
                                    currentObject.useGravity = false;
                                }
                            }
                            else
                            {
                                if (hitInfo.transform.gameObject.GetComponent<Walk>().canBePickedUp == true)
                                {
                                    hitInfo.transform.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                                    currentObject = hitInfo.rigidbody;
                                    currentObject.freezeRotation = true;
                                    currentObject.useGravity = false;
                                }
                            }
                        }
                    }
                    if (hitInfo.transform.gameObject.tag == "Poop")
                    {
                    currentObject = hitInfo.rigidbody;
                    currentObject.freezeRotation = true;
                    currentObject.useGravity = false;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentObject != null)
        {
            Vector3 directionToPoint = pickupTarget.position - currentObject.position;
            float distanceToPoint = directionToPoint.magnitude;

            currentObject.velocity = directionToPoint * 12f * distanceToPoint;
        }
    }
}
