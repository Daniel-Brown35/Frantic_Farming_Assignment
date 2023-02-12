using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckableArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<SuckableGrass>(out SuckableGrass suckGrassScript))
        {
            suckGrassScript.canSuck = true;
        }
        if (other.gameObject.TryGetComponent<SuckableGrain>(out SuckableGrain suckGrainScript))
        {
            suckGrainScript.canSuck = true;
        }
        if (other.gameObject.TryGetComponent<SuckableApple>(out SuckableApple suckAppleScript))
        {
            suckAppleScript.canSuck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<SuckableGrass>(out SuckableGrass suckGrassScript))
        {
            suckGrassScript.canSuck = false;
        }
        if (other.gameObject.TryGetComponent<SuckableGrain>(out SuckableGrain suckGrainScript))
        {
            suckGrainScript.canSuck = false;
        }
        if (other.gameObject.TryGetComponent<SuckableApple>(out SuckableApple suckAppleScript))
        {
            suckAppleScript.canSuck = false;
        }
    }
}
