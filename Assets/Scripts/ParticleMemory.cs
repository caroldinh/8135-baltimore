using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;
using UnityLibrary;

public class ActivateParticleMemory : MonoBehaviour
{
    // Start is called before the first frame update
    public VisualEffect particleSystem;
    public GameObject activateUI;
    public Color activeColor;
    private SmoothMouseLook _mouseLook;
    private Material _material;

   private void OnMouseUpAsButton(){
       activateUI.SetActive(true);
       if (_mouseLook)
       {
           _mouseLook.PauseLook();
       }
    }
    void Start()
    {
        if (Camera.main)
            _mouseLook = Camera.main.GetComponent<SmoothMouseLook>();
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        particleSystem.Stop();
        _material.DisableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
    }

    void OnMouseExit()
    {
        particleSystem.Play();
        _material.EnableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
    }
}
