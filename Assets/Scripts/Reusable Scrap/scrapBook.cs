using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapBook : MonoBehaviour
{
    public List<Highlight> activators;
    public List<scrapBookPage> pages;
    public List<activateUI> uis;

    public GameObject scrapBookButton;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject backButton;
    public GameObject travelButton;
    
    private int pageCounter = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach (Highlight activator in activators)
        {
            activator.setPage(pages[index]);
            activator.setActivateUI(uis[index]);
            index += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void open()
    {
        pageCounter = 0;
        scrapBookButton.SetActive(false);
        gameObject.SetActive(true);
        backButton.SetActive(true);
        pages[pageCounter].openPage();
        prevButton.SetActive(false);
        nextButton.SetActive(true);
        // Check if all pages are open
        bool allOpen = true;
        foreach (scrapBookPage page in pages)
        {
            if (page != null && !page.getActive())
            {
                allOpen = false;
            }
        }
        if (allOpen)
        {
            travelButton.SetActive(true);
        }
        else
        {
            travelButton.SetActive(false);
        }
    }
    
    public void close()
    {
        scrapBookButton.SetActive(true);
        //gameObject.SetActive(false);
        backButton.SetActive(false);
        prevButton.SetActive(false);
        nextButton.SetActive(false);
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
        if (pageCounter >= pages.Count || pages[pageCounter + 1] == null)
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
