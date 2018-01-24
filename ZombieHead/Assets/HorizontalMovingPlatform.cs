using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base class for all moving platforms, exposing z and x 
//delta per frame, so play glues to it.
public class MovingPlatform : MonoBehaviour
{
    public float zMove = 0;
    public float xMove = 0;

}

public class HorizontalMovingPlatform : MovingPlatform
{

    public Vector3 StartPosition;
    public float maximumDisplacement = 39.0f;
    public Vector3 curDisplacement = new Vector3(0, 0, 0);
    
	// Use this for initialization
	void Awake () {

        StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {

        
        float f = Mathf.Sin(Time.time/2);
        float move = (f * maximumDisplacement / 2);
        curDisplacement.Set(transform.position.x, transform.position.y, StartPosition.z + move );

        //get how much the platform moved THIS FRAME 
        //(we add this to the player position when on the platform)
        zMove = curDisplacement.z - transform.position.z;

        //move the platform
        transform.position = curDisplacement;
        
    }
}
