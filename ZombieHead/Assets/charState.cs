using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charState : MonoBehaviour {



    public Transform terrain = null;
    public float heightOffset = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        

        float x = transform.position.x;
        float z = transform.position.z;
        float speed = 1.5f;

        if (Input.GetKey(KeyCode.LeftArrow))
            x = x + speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            x = x - speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
            z = z - speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            z = z + speed * Time.deltaTime;

        float y = transform.position.y;

        // place the dude
        //first  get the exact height
        float goalY = 0;

        //and interp to position quickly
        if(Mathf.Abs(goalY - y) > 0.01f)
            y = y + (goalY - y) * 10.0f * Time.deltaTime ;

        transform.position = new Vector3(x, y, z);

    }
}
