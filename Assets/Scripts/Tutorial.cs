using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;

public class Tutorial : MonoBehaviour
{

    public FadeInOut overlay;
    public FadeInOut[] tutorialText;
    public SmoothMouseLook cam;
    public scrapBook scrapBook;
    public interactor raycast;

    private bool tutorialActive = false;
    private bool transitioning = false;
    private int tutorialStep = 0;

    private Quaternion camStartRot;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        foreach (FadeInOut panel in tutorialText)
        {
            panel.gameObject.SetActive(false);
        }
    }

    public void startTutorial()
    {
        gameObject.SetActive(true);
        cam.PauseLook();
        overlay.fadeInTo(0.5f, setStartCamPos);
        tutorialText[tutorialStep].fadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!transitioning)
        {
            if (tutorialActive && tutorialStep == 0)
                checkPass1();
            else if (!tutorialActive && tutorialStep == 1)
                checkStart2();
            else if (tutorialActive && tutorialStep == 1)
                checkPass2();
            else if (!tutorialActive && tutorialStep == 2)
                checkStart3();
            else if (tutorialActive && tutorialStep == 2)
                checkPass3();
            else if (!tutorialActive && tutorialStep == 3)
                checkStart4();
            else if (tutorialActive && tutorialStep == 3)
                checkPass4();
            else if (!tutorialActive && tutorialStep == 4)
                checkStart5();
            else if (!tutorialActive && tutorialStep == 5)
                checkStart6();

            Debug.Log("Active: " + tutorialActive + " // Step: " + tutorialStep);
        }
    }
    
    private void setStartCamPos()
    {
        tutorialActive = true;
        camStartRot = cam.transform.rotation;
        cam.ResumeLook();
    }

    private void checkPass1()
    {
        if (Math.Abs(Quaternion.Angle(camStartRot, cam.transform.rotation)) > 50)
        {
            passStep();
        }
    }

    private void checkStart2()
    {
        if (Math.Abs(Quaternion.Angle(Quaternion.Euler(10.8f, -1.95f, 0.0f), cam.transform.rotation)) < 15)
            startNextStep();
    }

    private void checkPass2()
    {
        if (cam.isPaused)
            passStep();
    }

    private void checkStart3()
    {
        if (!cam.isPaused)
            startNextStep();
    }

    private void checkPass3() // check if scrapbook has been open
    {
        if (scrapBook.backButton.gameObject.activeSelf)
            passStep();
    }

    private void checkStart4()
    {
        if (scrapBook.currPageIsActive())
        {
            // Skip step 4 without fading
            tutorialStep = 4;
        }
        else
            startNextStep(); // Start step 4
            Debug.Log("Curr page is inactive");
    }

    private void checkPass4()
    {
        if (scrapBook.currPageIsActive())
            passStep();
    }

    private void checkStart5()
    {
        if (scrapBook.travelButton.activeSelf)
        {
            startNextStep();
            StartCoroutine(PassAfterTime(3));
        }
    }

    IEnumerator PassAfterTime(int time)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);
        passStep();
    }

    private void checkStart6()
    {
        if (scrapBook.OnLastPage())
        {
            startNextStep();
        }
    }

    private void passStep()
    {
        transitioning = true;
        tutorialActive = false;
        overlay.fadeOut();
        FadeInOut[] children = tutorialText[tutorialStep].GetComponentsInChildren<FadeInOut>();
        foreach (var fadeInOut in children)
        {
            fadeInOut.fadeOut();
        }
        tutorialText[tutorialStep].fadeOut(endTransition);
        tutorialStep += 1;
    }

    private void startNextStep()
    {
        transitioning = true;
        tutorialActive = true;
        overlay.fadeInTo(0.5f);
        FadeInOut[] children = tutorialText[tutorialStep].GetComponentsInChildren<FadeInOut>();
        foreach (var fadeInOut in children)
        {
            fadeInOut.fadeIn();
        }
        tutorialText[tutorialStep].gameObject.SetActive(true);
        tutorialText[tutorialStep].fadeIn(endTransition);
    }

    private void endTransition()
    {
        transitioning = false;
    }

}
