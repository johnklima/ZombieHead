using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MovingPlatform {

    public Transform target;

    // Use this for initialization
    void Start () {
        zMove = 0;
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        float z = transform.position.z;
        float s = Mathf.Sin(Time.time);

        Quaternion a = Quaternion.AngleAxis(s * Mathf.Rad2Deg, Vector3.right);
        transform.rotation = a;

        zMove = transform.position.z - z;



    }
}
