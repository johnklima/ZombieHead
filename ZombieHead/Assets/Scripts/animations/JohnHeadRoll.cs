﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnHeadRoll : AnimationScript {


    public PlayerMotion playerMotion;
    public Transform theHead; 
    public float rollFactor = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        theHead.transform.Rotate(Vector3.right, playerMotion.velocity.magnitude * rollFactor * Time.deltaTime );
		
	}
}
