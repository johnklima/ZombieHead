using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnHeadRoll : MonoBehaviour {


    public PlayerMotion playerMotion;
    public float rollFactor = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.right, - playerMotion.velocity.magnitude * rollFactor * Time.deltaTime );
		
	}
}
