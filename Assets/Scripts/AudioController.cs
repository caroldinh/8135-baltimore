using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    private AudioSource audio;
    private bool audioActive = false;

    private RawImage _rawImage;

    public AudioLowPassFilter lowPassFilter;
    public FadeInOut alertIncomplete;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        _rawImage = GetComponentInChildren<RawImage>();
        _rawImage.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //_rawImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (audio.isPlaying)
        {
            _rawImage.gameObject.SetActive(true);
        }
        else
        {
            _rawImage.gameObject.SetActive(false);
            lowPassFilter.enabled = false;
        }
    }

    public void SetAndPlayAudio(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
        lowPassFilter.enabled = true;
    }

    public void alertIncompleteAudio()
    {
        alertIncomplete.fadeIn();
        StartCoroutine(FadeOutAlert());
    }
    
    
    IEnumerator FadeOutAlert()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        alertIncomplete.fadeOut();
    }

}
