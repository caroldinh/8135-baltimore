using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class familyButton : MonoBehaviour
{
   public scrapbooklFinalScene b;
   public GameObject a;
   public AudioSource help;

   private void OnMouseUpAsButton(){
        b.listenFamily();
        a.SetActive(true);
        help.Play();
    }

}
