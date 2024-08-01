using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    private Image _self;
    public float fadeRate;
    
    // Start is called before the first frame update
    void Start()
    {
        _self = gameObject.GetComponent<Image>();
    }

    void OnEnable()
    {
        StartCoroutine(FadeOutTransition()); // fade out
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void fadeIn(){
        
    }

    public void fadeOut()
    {
        
    }
    
    IEnumerator FadeOutTransition()
    {
        float targetAlpha = 0.0f;
        Color curColor = _self.color;
        while(Mathf.Abs(curColor.a - targetAlpha) > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            _self.color = curColor;
            yield return null;
        }
    }
}
