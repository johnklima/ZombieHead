﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotion : MonoBehaviour {

    //gravity in meters per second per second
    static float GRAVITY_CONSTANT = -9.8f;              // -- for earth,  -1.6 for moon 
    public Vector3 velocity = new Vector3(0, 0, 0);            //current direction and speed of movement
    public Vector3 acceleration = new Vector3(0, 0, 0);        //movement controlled by player movement force and gravity

    public Vector3 moveForce = new Vector3(0, 0, 0);    //combined force of all axis from input for move
    public Vector3 totalForce = new Vector3(0, 0, 0);   //total of ALL forces applied


    //player characteristics
    public float mass = 1.0f;
    public float energy = 1.0f;
    public float verticalForce = GRAVITY_CONSTANT * -2;  //our jump force (Y axis)
    public float lateralForce = 10.0f;                   //our position force (X,Z axis)
    public float consumption = 0.0f;                     //energy burn rate
    public float friction = 0.975f;                      //TODO: put into world property

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (handleGround() == false)
        {
            handleInput();
            handleMovement();
        }

        if (transform.position.y > 0.5f)        {

            //I'm in the air - state ?
        }
        else if (transform.position.y < 0.5f)
        {
            //I'm below the surface, so push me up           
            transform.position.Set(transform.position.x, 0.5f, transform.position.z);
        }
 
    }
    private void LateUpdate()
    {
      
    }
    void handleInput()
    {
        
        //clear out the move force each frame
        moveForce.Set(0, 0, 0);       

        //vertical thrust
        if (Input.GetKey(KeyCode.Space) && energy > 0.0f)
        {
            moveForce.y = verticalForce;
            energy -= consumption * Time.deltaTime;            

        }

        if (Input.GetKey(KeyCode.A) && energy > 0.0f)
        {
            moveForce.z = -lateralForce;
            energy -= consumption * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.D) && energy > 0.0f)
        {
            moveForce.z = lateralForce;
            energy -= consumption * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.W) && energy > 0.0f)
        {
            moveForce.x = -lateralForce;
            energy -= consumption * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.S) && energy > 0.0f)
        {
            moveForce.x = lateralForce;
            energy -= consumption * Time.deltaTime;

        }
    }

    void handleMovement()
    {
        //initial force of gravity
        totalForce.Set(0, 0.0f , 0);
        totalForce *= GRAVITY_CONSTANT;

        //add our ship moveForce
        totalForce += moveForce;

        //maybe some wind?
        //forces += wind * Mathf.Sin(Time.time);
        //Debug.Log (Mathf.Sin (Time.time));

        acceleration = totalForce / mass;
        velocity += acceleration * Time.deltaTime;

        //move the player
        transform.position += velocity * Time.deltaTime;

        velocity *= friction;
        

    }

    bool handleGround()
    {
        //keep the player within bounds
        /*
            z = -50, 50
            x = -15, 15
        */

        bool ret = false;

        if (transform.position.x > 14)
        {
            Vector3 pos = new Vector3(13.5f, transform.position.y, transform.position.z);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }
        if (transform.position.x < -14)
        {
            Vector3 pos = new Vector3(-13.5f, transform.position.y, transform.position.z);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }
        if (transform.position.z > 49)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 48.5f);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }
        if (transform.position.z < -49)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, -48.5f);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }

        return ret;


    }

}
