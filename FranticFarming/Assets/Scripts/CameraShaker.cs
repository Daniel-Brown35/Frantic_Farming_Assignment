using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float power;
    public float maxShakeTime;
    public Transform playerCamera;
    public bool shakeCamera;
    private Vector3 startPosition;
    private float currentShakeTime;
    public bool optionsShakeAllowed;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = playerCamera.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeCamera == true && optionsShakeAllowed == true)
        {
            if (currentShakeTime < maxShakeTime)
            {
                playerCamera.localPosition = startPosition + Random.insideUnitSphere * power;
                currentShakeTime += Time.deltaTime;
            }
            else
            {
                shakeCamera = false;
                currentShakeTime = 0.0f;
                playerCamera.localPosition = startPosition;
            }
        }
    }
}
