using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void fadeIn(Action then = null){
        
        gameObject.SetActive(true);
        StartCoroutine(FadeIn(then)); // fade in
    }

    public void fadeOut(Action then = null)
    {
        
        gameObject.SetActive(true);
        StartCoroutine(FadeOut(then)); // fade in
    }

    public void fadeInTo(float to, Action then = null)
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeInTo(to, then)); // fade in
    }
    
    public IEnumerator FadeIn(Action then = null)
    {
        float targetAlpha = 1.0f;
        Color curColor = _self.color;
        curColor.a = 0.0f;
        _self.color = curColor;
        while(Mathf.Abs(curColor.a - targetAlpha) > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            _self.color = curColor;
            yield return null;
        }
        //curColor.a = 1.0f;
        if (then != null)
            then.Invoke();
    }
    
    public IEnumerator FadeInTo(float targetAlpha, Action then = null)
    {
        Color curColor = _self.color;
        curColor.a = 0.0f;
        _self.color = curColor;
        while(Mathf.Abs(curColor.a - targetAlpha) > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            _self.color = curColor;
            yield return null;
        }
        //curColor.a = targetAlpha;
        if (then != null)
            then.Invoke();
    }
    
    public IEnumerator FadeOut(Action then = null)
    {
        float targetAlpha = 0.0f;
        Color curColor = _self.color;
        curColor.a = 1.0f;
        _self.color = curColor;
        while(Mathf.Abs(curColor.a - targetAlpha) > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            _self.color = curColor;
            yield return null;
        }
        //curColor.a = 0.0f;
        if (then != null)
            then.Invoke();
    }
    
}
