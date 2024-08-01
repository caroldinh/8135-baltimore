using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable{
    public void Interact();
    public void Hover();
    public void Exit();
}

public class interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractionRange;
    private IInteractable lastInteracted;

    public bool hit = false;

    // Update is called once per frame
    public void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if(Physics.Raycast(r, out RaycastHit hitInfo, InteractionRange))
        {
            hit = true;
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Hover();
                if (lastInteracted != null && interactObj != lastInteracted)
                {
                    lastInteracted.Exit();
                }
                lastInteracted = interactObj;
                if (Input.GetMouseButtonDown(0))
                {
                    interactObj.Interact();
                }
            } 
        } else if (lastInteracted != null)
        {
            hit = false;
            lastInteracted.Exit();
            lastInteracted = null;
        }
        else
        {
            hit = false;
        }
        /*
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractionRange)){
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                    interactObj.Interact();
                }
            }
        }
        else
        {
            
        }
        */
    }
}
