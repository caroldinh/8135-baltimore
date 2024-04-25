using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;
using UnityLibrary;

public class highlight : MonoBehaviour
{
    // Start is called before the first frame update
    //public VisualEffect particleSystem;
    //public GameObject activateUI;

    public scrapbookLobbyScene b;
    public int page;
    public Color activeColor;
    private SmoothMouseLook _mouseLook;
    public Material _material;


   /*private void OnMouseUpAsButton(){
       activateUI.SetActive(true);
       if (_mouseLook)
       {
           _mouseLook.PauseLook();
       }
    }*/
    void Start()
    {
        if (Camera.main)
            _mouseLook = Camera.main.GetComponent<SmoothMouseLook>();
        //_material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseExit()
    {
        //particleSystem.Stop();
        _material.DisableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

    }

    void OnMouseEnter()
    {
        //particleSystem.Play();
        _material.EnableKeyword("_EMISSION");
        _material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
        Debug.Log("working");
    }

      private void OnMouseUpAsButton(){
        Debug.Log(page);
            if(page == 0){
                b.clickedPlan();
            }else if (page == 1){
                b.clickedDisrupted();
            }else if(page == 2){
                b.clickedChecklist();
            }else if(page == 3){
                b.clickedBlueprint();
            }
    }
}
