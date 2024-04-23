using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapbooklFinalScene : MonoBehaviour
{
    public GameObject scrapbook;
    public GameObject icon;
    public GameObject couple;
    public GameObject friends;
    public GameObject family; 
    public GameObject prev;
    public GameObject next;

    public GameObject familyInspect;
    public GameObject friendsInspect;
    public GameObject coupleInspect;

    public GameObject familyText;
    public GameObject friendsText;
    public GameObject coupleText;

    
    public int pageCounter = 0;
    public int familyInteracted = 0;
    public int friendsInteracted = 0;
    public int coupleInteracted = 0;

    public void scrap(){
        scrapbook.SetActive(true);
        icon.SetActive(false);
        couple.SetActive(true);
        familyInspect.SetActive(false);
        friendsInspect.SetActive(false);
        coupleInspect.SetActive(false);

        prev.SetActive(false);
        next.SetActive(true);
        
        if(familyInteracted != 0){
            familyText.SetActive(true);
        }
        if(friendsInteracted != 0){
            friendsText.SetActive(true);
        }
        if(coupleInteracted != 0){
            coupleText.SetActive(true);
        }
       
    }

     public void back(){
        pageCounter = 0;
        scrapbook.SetActive(false);
        icon.SetActive(true);
        familyInspect.SetActive(false);
        friendsInspect.SetActive(false);
        coupleInspect.SetActive(false);
    }

    public void nextPage(){
        if(pageCounter == 0){
            prev.SetActive(true);
            friends.SetActive(true);
            pageCounter++;
        }else if(pageCounter == 1){
            next.SetActive(false);
            family.SetActive(true);
            pageCounter++;
        }
    }

    public void prevPage(){
        if(pageCounter == 2){
            next.SetActive(true);
            family.SetActive(false);
            pageCounter--;
        }else if(pageCounter == 1){
            prev.SetActive(false);
            friends.SetActive(false);
            pageCounter--;
        }
    }

    public void listenFamily(){
        turnOffEverything();
        familyInspect.SetActive(true);
        familyInteracted++;
        
    }

    public void listenFriends(){
        turnOffEverything();
        friendsInspect.SetActive(true);
        friendsInteracted++;
    }

    public void listenCouple(){
        turnOffEverything();
        coupleInspect.SetActive(true);
        coupleInteracted++;
    }

    public void turnOffEverything(){
        couple.SetActive(false);
        friends.SetActive(false);
        family.SetActive(false);
        prev.SetActive(false);
        next.SetActive(false);
    }
}
