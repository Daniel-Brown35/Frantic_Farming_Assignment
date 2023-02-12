using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FertilizerCheck : MonoBehaviour
{
    public GameObject grainHarvestPoint;
    public GameObject grainHarvestPoint2;
    public GameObject grainHarvestPoint3;
    public GameObject grainHarvestPoint4;
    public GameObject grainHarvestPoint5;
    public GameObject grainHarvestPoint6;
    public GameObject grainHarvestPoint7;
    public GameObject grainHarvestPoint8;
    public GameObject grainHarvestPoint9;
    public bool showBubble;
    public Image thoughtBubbleObject;

    private void Update()
    {
        if (showBubble == true)
        {
            thoughtBubbleObject.enabled = true;
        }
        if (showBubble == false)
        {
            thoughtBubbleObject.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Poop")
        {
            showBubble = false;
            Destroy(collision.gameObject);
            grainHarvestPoint.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint2.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint3.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint4.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint5.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint6.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint7.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint8.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
            grainHarvestPoint9.GetComponent<GrainHarvestPoint>().needsFertilizing = false;
        }
    }
}
