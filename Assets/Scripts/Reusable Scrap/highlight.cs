using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;
using UnityLibrary;

/*
[Serializable]
public class CustomClickEvent : UnityEvent {}
*/

public class Highlight : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public VisualEffect particleSystem;
    public progressImage progressImage;
    public AudioClip audioClip;
    public AudioController audioController;
    
    private SmoothMouseLook _mouseLook;
    public Material _material;
    
    private activateUI _activateUI;
    private scrapBookPage _page;

    private bool _startedActive = false;
    private bool _startedIdle = false;

    public UnityEvent onClick;

    void Start()
    {
        if (Camera.main)
            _mouseLook = Camera.main.GetComponent<SmoothMouseLook>();
        
        if(particleSystem)
            particleSystem.Play();
        _material.DisableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (_isFocused && !_startedActive)
        {
        }
        else if (!_startedIdle)
        {
        }
        */
    }

    /*
    void OnMouseExit()
    {

    }

    void OnMouseEnter()
    {
    }
    */

    public void setPage(scrapBookPage page)
    {
        _page = page;
    }

    public void setActivateUI(activateUI ui)
    {
        _activateUI = ui;
    }

   private void OnMouseUpAsButton(){
   }

   public void Interact()
   {
       if (EventSystem.current.IsPointerOverGameObject()) return;
        if (audioClip && audioController)
        {
            if (audioController.GetComponent<AudioSource>().isPlaying)
            {
                audioController.alertIncompleteAudio();
                return;
            }
            audioController.SetAndPlayAudio(audioClip);
        }
       if (_activateUI)
           _activateUI.gameObject.SetActive(true);
       if (_page && !_page.getActive())
       {
           _page.activate();
           progressImage.updateProgress();
       }

       if (onClick != null)
       {
           onClick.Invoke();
       }
   }

   public void Hover()
   {
       if (!_startedActive)
       {
            _startedActive = true;
            _startedIdle = false;
            if (particleSystem)
                particleSystem.Stop();
            _material.EnableKeyword("_EMISSION");
            _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
       }
   }

   public void Exit()
   {
       if (!_startedIdle)
       {
            _startedIdle = true;
            _startedActive = false;
            if (particleSystem)
                particleSystem.Play();
            _material.DisableKeyword("_EMISSION");
            _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
       }
   }
   
}
