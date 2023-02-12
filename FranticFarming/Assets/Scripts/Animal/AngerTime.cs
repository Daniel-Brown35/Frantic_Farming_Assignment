using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AngerTime : MonoBehaviour
{
    public bool Peace = false;
    public bool Anger;
    public Walk shot;
    Image timerBar;
    public float maxTime;
    public float timeLeft;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;

        shot = GetComponentInParent<Walk>();
    }

    void Update()
    {
        
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }

        if (timeLeft <= 0)
        {
            Anger = true;

        }

        if (shot.reset == true)
        {
            shot.reset = false;
            timeLeft = maxTime;
            if (Anger == true)
            {
                Peace = true;
            }
        }

    }

    

}