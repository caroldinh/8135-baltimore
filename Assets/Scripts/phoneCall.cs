using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneCall : MonoBehaviour
{
    public AudioSource ring;
    public AudioSource michael;
    public AudioSource janice;
    public AudioSource danny;
    public AudioSource ashley;
    public AudioSource andrea;


    private int count = 0; 
    private bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        ring.Play();
    }

    // Update is called once per frame
    

    private void OnMouseUpAsButton(){
        if(active){
            ring.Pause();

            if(count==0){
                count++;
                michael.Play();
                StartCoroutine(ExampleCoroutine());            
            }else if(count==1){
                count++;
                janice.Play();
                StartCoroutine(ExampleCoroutine());
            }else if(count==2){
                count++;
                danny.Play();
                StartCoroutine(ExampleCoroutine());
            }else if(count==3){
                count++;
                ashley.Play();
                StartCoroutine(ExampleCoroutine());
            }else if(count==4){
                count = 0;
                andrea.Play();
                StartCoroutine(ExampleCoroutine());
            }
        }
    }


    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        active = false;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(40);
        ring.Play();
        active = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
