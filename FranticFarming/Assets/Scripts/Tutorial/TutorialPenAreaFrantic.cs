using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialPenAreaFrantic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            other.gameObject.GetComponent<WalkTutorialFrantic>().inPenArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            other.gameObject.GetComponent<WalkTutorialFrantic>().inPenArea = false;
        }
    }
}
