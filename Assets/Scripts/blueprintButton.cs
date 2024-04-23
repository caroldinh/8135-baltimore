using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprintButton : MonoBehaviour
{
   public scrabBook b;

    private void OnMouseUpAsButton(){
        b.blueR();
        b.blueFound();
    }
}
