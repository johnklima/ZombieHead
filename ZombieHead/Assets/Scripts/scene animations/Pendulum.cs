using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {


    public MovingPlatform target;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        float z = target.gameObject.transform.position.z;

        float s = Mathf.Sin(Time.time);

        Quaternion a = Quaternion.AngleAxis(s * Mathf.Rad2Deg, Vector3.right);
        transform.rotation = a;

        target.zMove = target.gameObject.transform.position.z - z;



    }
}
