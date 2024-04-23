using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderButton : MonoBehaviour
{
    public scrabBook b;

    private void OnMouseUpAsButton(){
        b.planR();
        b.renderFound();
    }
}
