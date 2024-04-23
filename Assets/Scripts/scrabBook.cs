using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrabBook : MonoBehaviour
{
    public GameObject scrapbook;
    public GameObject icon;
    public GameObject planRender;
    public GameObject blueprint;
    public GameObject design;

    public GameObject blueImage;
    public GameObject renderImage;
    public GameObject designImage;

    private int render = 0;
    private int blue = 0;
    private int des = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scrap(){
        scrapbook.SetActive(true);
        icon.SetActive(false);
        if(render == 1){
            renderImage.SetActive(true);
        }
        if(blue == 1){
            blueImage.SetActive(true);
        }
        if(des == 1){
            designImage.SetActive(true);
        }
    }

    public void back(){
        scrapbook.SetActive(false);
        planRender.SetActive(false);
        blueprint.SetActive(false);
        design.SetActive(false);
        icon.SetActive(true);
    }

    public void planR(){
        planRender.SetActive(true);
    }
    
    public void blueR(){
        blueprint.SetActive(true);
    }

    public void desR(){
        design.SetActive(true);
    }

    public void renderFound(){
        render = 1;
    }

    public void blueFound(){
        blue = 1;
    }

    public void desFound(){
        des = 1;
    }
}
