using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrapBook : MonoBehaviour
{
    public List<Highlight> activators;
    public List<scrapBookPage> pages;
    public List<activateUI> uis;

    public GameObject alwaysCanvas;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject backButton;
    public GameObject travelButton;

    public bool allActive;
    
    private int pageCounter = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach (Highlight activator in activators)
        {
            if (activator != null)
            {
                activator.setPage(pages[index]);
                activator.setActivateUI(uis[index]);
                index += 1;
            }
        }

        if (allActive)
        {
            foreach (scrapBookPage page in pages)
            {
                if (page != null)
                {
                    page.activate();
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void open()
    {
        pageCounter = 0;
        alwaysCanvas.SetActive(false);
        gameObject.SetActive(true);
        backButton.SetActive(true);
        pages[pageCounter].openPage();
        prevButton.SetActive(false);
        nextButton.SetActive(true);
        // Check if all pages are open
        bool allOpen = true;
        foreach (activateUI ui in uis)
        {
            if (ui != null)
            {
                ui.closeUI();
            }
        }
        foreach (scrapBookPage page in pages)
        {
            if (page != null && !page.getActive())
            {
                allOpen = false;
            }
        }
        if (allOpen && !allActive)
        {
            travelButton.SetActive(true);
        }
        else if (!allActive)
        {
            travelButton.SetActive(false);
        }
    }
    
    public void close()
    {
        alwaysCanvas.SetActive(true);
        //gameObject.SetActive(false);
        backButton.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(false);
        if (travelButton != null)
            travelButton.SetActive(false);
        foreach (scrapBookPage page in pages)
        {
            if (page != null)
            {
                page.closePage();
            }
        }
    }
    
    public void nextPage()
    {
        pageCounter++;
        displayCurrPage();
        prevButton.SetActive(true);
        if (pageCounter == pages.Count - 1 || pages[pageCounter + 1] == null)
        {
            nextButton.SetActive(false);
        }
    }

    public void prevPage(){
        pageCounter--;
        displayCurrPage();
        nextButton.SetActive(true);
        if (pageCounter == 0)
        {
            prevButton.SetActive(false);
        }
    }

    private void displayCurrPage()
    {
        foreach (scrapBookPage page in pages)
        {
            if (page != null)
            {
                if (pages.IndexOf(page) == pageCounter)
                {
                    page.openPage();
                }
                else
                {
                    page.closePage();
                } 
            }
        }
    }

}
