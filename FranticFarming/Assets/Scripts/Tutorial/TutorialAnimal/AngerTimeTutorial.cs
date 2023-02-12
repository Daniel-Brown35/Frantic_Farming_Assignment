using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AngerTimeTutorial : MonoBehaviour
{
    public bool tutorialStopCounting;
    public WalkTutorial shot;
    Image timerBar;
    public float maxTime;
    public float timeLeft;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;

        shot = GetComponentInParent<WalkTutorial>();
    }

    void Update()
    {
        
        if (timeLeft > 0 && tutorialStopCounting == false)
        {
            timeLeft -= Time.deltaTime;
            
        }
        timerBar.fillAmount = timeLeft / maxTime;

        if (shot.reset == true)
        {
            shot.reset = false;
            timeLeft = maxTime;
        }

    }

    

}