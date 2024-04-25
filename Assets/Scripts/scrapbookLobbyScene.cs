using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapbookLobbyScene : MonoBehaviour
{
    public GameObject scrapbook;
    public GameObject icon;
    public GameObject prev;
    public GameObject next;
    public GameObject backB;

    public GameObject disruption;
    public GameObject blueprints;
    public GameObject plan; 
    public GameObject checklist; 
    

    public GameObject planI; 
    public GameObject disruptionI;
    public GameObject blueprintsI;
    public GameObject checklistI; 

    
    public GameObject planUI; 
    public GameObject disruptionUI;
    public GameObject blueprintsUI;
    public GameObject checklistUI; 

    public GameObject travelButton;
    
    private int pageCounter = 0;
    private int disrupted = 0;
    private int blueprinted = 0;
    private int planned = 0;
    private int checklisted = 0;

    public void scrap(){
        scrapbook.SetActive(true);
        icon.SetActive(false);

        plan.SetActive(true); 
        disruption.SetActive(false);
        blueprints.SetActive(false);
        checklist.SetActive(false); 
        

        prev.SetActive(false);
        next.SetActive(true);
        
        if( planned != 0){
            planI.SetActive(true); 
        }
        if(disrupted != 0){
            disruptionI.SetActive(true);
        }
        if(blueprinted != 0){
            blueprintsI.SetActive(true);        
        }
        if(checklisted != 0){
            checklistI.SetActive(true);
        }

        if(disrupted != 0 && planned != 0 && blueprinted!= 0 && checklisted != 0){
            travelButton.SetActive(true);
        }  
    }

     public void back(){
        pageCounter = 0;
        scrapbook.SetActive(false);
        icon.SetActive(true);
        
        planUI.SetActive(false); 
        disruptionUI.SetActive(false);
        blueprintsUI.SetActive(false);
        checklistUI.SetActive(false); 
    }


    //PAGE ORDER:
        //PLAN
        //DISRUPTION
        //CHECKLIST
        //BLUEPRINT
    public void nextPage(){
        if(pageCounter == 0){
            prev.SetActive(true);
            disruption.SetActive(true);
            pageCounter++;
        }else if(pageCounter == 1){
            checklist.SetActive(true);
            pageCounter++;
        }else if(pageCounter == 2){
            blueprints.SetActive(true);
            pageCounter++;
            next.SetActive(false);
        }
    }

    public void prevPage(){
        if(pageCounter == 3){
            next.SetActive(true);
            blueprints.SetActive(false);
            pageCounter--;
        }else if(pageCounter == 2){
            checklist.SetActive(false);
            pageCounter--;
        }else if (pageCounter == 1){
            disruption.SetActive(false);
            prev.SetActive(false);
            pageCounter--;

        }
   }


    public void clickedDisrupted(){
        turnOffEverything();
        disruptionUI.SetActive(true);
        disrupted++;
        
    }

    public void clickedBlueprint(){
        turnOffEverything();
        //scrapbook.SetActive(true);
        blueprintsUI.SetActive(true);
        blueprinted++;
    }

    public void clickedPlan(){
        turnOffEverything();
        planUI.SetActive(true);
        planned++;
    }

    public void clickedChecklist(){
        turnOffEverything();
        checklistUI.SetActive(true);
        checklisted++;
    }

    public void turnOffEverything(){
        plan.SetActive(false);
        disruption.SetActive(false);
        blueprints.SetActive(false);
        checklist.SetActive(false);
        prev.SetActive(false);
        next.SetActive(false);
    }
    
    public void sceneLoad(){
          //SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
    }
}
