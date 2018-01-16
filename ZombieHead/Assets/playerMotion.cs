using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotion : MonoBehaviour {

    //gravity in meters per second per second
    static float GRAVITY_CONSTANT = -9.8f;              // -- for earth,  -1.6 for moon 
    Vector3 velocity = new Vector3(0, 0, 0);            //current direction and speed of movement
    Vector3 acceleration = new Vector3(0, 0, 0);        //movement controlled by thruster force and gravity

    public Vector3 moveForce = new Vector3(0, 0, 0);    //combined force of all axis from input for move
    public Vector3 totalForce = new Vector3(0, 0, 0);   //total of ALL forces applied


    //player characteristics
    public float mass = 1.0f;
    public float energy = 1.0f;
    public float verticalForce = GRAVITY_CONSTANT * -2;  //our jump force (Y axis)
    public float lateralForce = 5.0f;                   //our position force (X,Z axis)
    public float consumption = 0.1f;                    //energy burn rate

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        handleInput();
        handleMovement();

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
    }

    void handleMovement()
    {
        //initial force of gravity
        totalForce.Set(0, 0.0f, 0);
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
        

    }
}
