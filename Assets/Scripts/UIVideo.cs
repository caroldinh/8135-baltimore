using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityLibrary;

public class UIVideo : MonoBehaviour
{

    private VideoPlayer _videoPlayer;

    private SmoothMouseLook _mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main)
            _mouseLook = Camera.main.GetComponent<SmoothMouseLook>();
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached  += CheckOver;
    }
    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
       if (_mouseLook)
       {
           _mouseLook.ResumeLook();
       }
       gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _videoPlayer.frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
