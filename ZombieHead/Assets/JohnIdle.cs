using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnIdle : AnimationScript
{

    //we need to accumulate time so when the anim is disabled. it continues from where it left off
    //TODO: ultimately we want to transition between states and animations
    private float accumTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move the hips ball back and forth
        accumTime += Time.deltaTime;
        
        float y = Mathf.Sin(accumTime * 4.0f) * 0.5f;

        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

    }
}
