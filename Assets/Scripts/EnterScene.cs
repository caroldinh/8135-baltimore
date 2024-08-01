using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityLibrary;

public class EnterScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject StartScreenCanvas;
    private TextMeshProUGUI _tmp;
    private SmoothMouseLook _camera;
    
    // Start is called before the first frame update
    void Start()
    {
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        if (Camera.main) {
            _camera = Camera.main.GetComponent<SmoothMouseLook>();
            if (_camera)
                _camera.PauseLook();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void TriggerSceneEnter(){
        if (_camera == null && Camera.main) {
            _camera = Camera.main.GetComponent<SmoothMouseLook>();
        }
        if (_camera)
            _camera.ResumeLook();
       StartScreenCanvas.SetActive(false);
   }
    
   public void OnPointerEnter(PointerEventData eventData)
   {
       Debug.Log("Pointer enter");
        _tmp.outlineWidth = 0.2f;
        //float intensity = 2;
        //_tmp.outlineColor = new Color(255*intensity, 255*intensity, 255*intensity);
   }

   public void OnPointerExit(PointerEventData eventData)
   {
       Debug.Log("Pointer exit");
        _tmp.outlineWidth = 0.0f;
    }
}
