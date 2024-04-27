using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendsButton : MonoBehaviour
{
   public scrapbooklFinalScene b;
   public GameObject a;
   public AudioSource help;

   private void OnMouseUpAsButton(){
        help.Play();
        b.listenFriends();
        a.SetActive(true);
    }
}
