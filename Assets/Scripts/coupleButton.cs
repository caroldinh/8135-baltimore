using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coupleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public scrapbooklFinalScene b;
   public GameObject a;
   public AudioSource help;

   private void OnMouseUpAsButton(){
        b.listenCouple();
        a.SetActive(true);
        help.Play();
    }
}
