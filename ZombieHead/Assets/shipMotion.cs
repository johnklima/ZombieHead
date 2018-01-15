using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMotion : MonoBehaviour {

    //gravity in meters per second per second
    static float GRAVITY_CONSTANT = -1.6f; //-9.8f for earth -1.6 for moon ;
    Vector3 velocity = new Vector3(0, 0, 0);            //current direction and speed of movement
    Vector3 acceleration = new Vector3(0, 0, 0);        //movement controlled by thruster force and gravity

    Vector3 thrusters = new Vector3(0, 0, 0);			//combined force of all thrusters
    
    
    //ship characteristics
    public float mass = 1.0f;
    public float fuel = 1.0f;
    public float verticalForce = 1.0f;
    public float consumption = 0.01f;

    public Transform thruster;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        handleInput();

        if (transform.position.y > 0.0f)
        {

            handleMovement();

        }
        else
        {
            
            Debug.Log("SPLAT");
        }

        
	}
    void handleInput()
    {

        thrusters = new Vector3(0,0,0);
        thruster.localPosition = thrusters;

        //vertical thrust
        if (Input.GetKey(KeyCode.Space) && fuel > 0.0f)
        {
            thrusters.y = verticalForce;
            fuel -= consumption;

            thruster.localPosition += new Vector3(0, -0.75f, 0);

        }
    }
        void handleMovement()
    {
        //initial force of gravity
        Vector3 forces = new Vector3(0, 1.0f, 0) * GRAVITY_CONSTANT;

        //add our ship thrusters
        forces += thrusters;

        //maybe some wind?
        //forces += wind * Mathf.Sin(Time.time);
        //Debug.Log (Mathf.Sin (Time.time));

        acceleration = forces / mass;
        velocity += acceleration * Time.deltaTime;

        //move the ship
        transform.position += velocity * Time.deltaTime;




    }
}
