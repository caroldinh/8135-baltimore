using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;

public class activateUI : MonoBehaviour
{

    //public List<GameObject> childrenToEnable;
    private SmoothMouseLook _camera;
    private GameObject _updated;
    public AudioLowPassFilter lowPassFilter;
    
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (_camera == null && Camera.main)
            _camera = Camera.main.GetComponent<SmoothMouseLook>();
        if (lowPassFilter)
            lowPassFilter.enabled = true;
        if (_camera)
        {
            _camera.PauseLook();
        }
    }

    private void OnDisable()
    {
        if (lowPassFilter)
            lowPassFilter.enabled = false;
        if (_camera)
        {
            _camera.ResumeLook();
        }
    }

    public void closeUI()
    {
        gameObject.SetActive(false);
    }
}
