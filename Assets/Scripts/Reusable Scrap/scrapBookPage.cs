using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapBookPage : MonoBehaviour
{

    private bool active = false;
    public GameObject barePage;
    public GameObject activePage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        active = true;
    }

    public void openPage()
    {
        gameObject.SetActive(true);
        if (active)
        {
            barePage.SetActive(false);
            activePage.SetActive(true);
        }
        else
        {
            barePage.SetActive(true);
            activePage.SetActive(false);
        }
    }
    
    public void closePage()
    {
        gameObject.SetActive(false);
    }

    public bool getActive()
    {
        return active;
    }
    
}
