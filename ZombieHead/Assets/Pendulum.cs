using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    public float zMove = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        float s = Mathf.Sin(Time.time);

        Quaternion a = Quaternion.AngleAxis(s * Mathf.Rad2Deg, Vector3.right);
        transform.rotation = a;




    }
}
