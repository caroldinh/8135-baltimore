using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp : MonoBehaviour
{
	private Vector2 rotation;
	private Quaternion target;
	private Transform from;
	private Transform to;
	private float timeCount = 0.0f;
	private bool isPaused;

	public int slowFactor = 500;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (!isPaused)
	    {
			rotation.y += Input.GetAxis ("Mouse X");
			rotation.x += -Input.GetAxis ("Mouse Y");
			Quaternion target = Quaternion.Euler(rotation.x, rotation.y, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, timeCount / slowFactor);
			timeCount = timeCount + Time.deltaTime;
	    }
    }
    
	public void PauseLook()
	{
		isPaused = true;
	}

	public void ResumeLook()
	{
		isPaused = false;
	}
}
