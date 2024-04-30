using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateUI : MonoBehaviour
{

    //public List<GameObject> childrenToEnable;
    private Slerp _camera;
    private GameObject _updated;
    
    // Start is called before the first frame update
    void Start(){
        if (Camera.main)
            _camera = Camera.main.GetComponent<Slerp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (_camera)
        {
            _camera.PauseLook();
        }
    }

    private void OnDisable()
    {
        if (_camera)
            _camera.ResumeLook();
    }

    public void closeUI()
    {
        gameObject.SetActive(false);
    }
}
