using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AngerTimeTutorialFrantic : MonoBehaviour
{
    public bool tutorialStopCounting;
    public bool startChase;
    public WalkTutorialFrantic shot;
    Image timerBar;
    public float maxTime;
    public float timeLeft;
    private bool reduceTimeLeft;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;

        shot = GetComponentInParent<WalkTutorialFrantic>();
    }

    void Update()
    {
        if (shot.stopChaseTutorial == false)
        {
        if (timeLeft > 0 && startChase == true)
        {
            timeLeft -= Time.deltaTime;
            
        }
        if (startChase == true)
        {
            if (reduceTimeLeft == false)
            {
                reduceTimeLeft = true;
                timeLeft = 0.5f;
            }
        }
        }
        timerBar.fillAmount = timeLeft / maxTime;

        if (shot.reset == true)
        {
            shot.reset = false;
            timeLeft = maxTime;
        }

    }

    

}