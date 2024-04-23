using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class designButton : MonoBehaviour
{
    public scrabBook b;

    private void OnMouseUpAsButton(){
        b.desR();
        b.desFound();
    }
}
