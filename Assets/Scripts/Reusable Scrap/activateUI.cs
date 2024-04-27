using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateUI : MonoBehaviour
{

    //public List<GameObject> childrenToEnable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnEnable()
    {
        foreach (GameObject child in childrenToEnable)
        {
            child.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach (GameObject child in childrenToEnable)
        {
            child.SetActive(false);
        }
    }
    */

    public void closeUI()
    {
        gameObject.SetActive(false);
    }
}
