using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;
using UnityLibrary;

public class Highlight : MonoBehaviour
{
    // Start is called before the first frame update
    public VisualEffect particleSystem;
    
    private SmoothMouseLook _mouseLook;
    public Material _material;
    
    private activateUI _activateUI;
    private scrapBookPage _page;


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
        
    }

    void OnMouseExit()
    {
        if (particleSystem)
            particleSystem.Play();
        _material.DisableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

    }

    void OnMouseEnter()
    {
        if (particleSystem)
            particleSystem.Stop();
        _material.EnableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
    }

    public void setPage(scrapBookPage page)
    {
        _page = page;
    }

    public void setActivateUI(activateUI ui)
    {
        _activateUI = ui;
    }

   private void OnMouseUpAsButton(){
       if (EventSystem.current.IsPointerOverGameObject()) return;
       if (_activateUI)
           _activateUI.gameObject.SetActive(true);
       if (_page)
           _page.activate();
   }
}
