using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour {

    //gravity in meters per second per second
    static float GRAVITY_CONSTANT = -9.8f;                      // -- for earth,  -1.6 for moon 
    public Vector3 velocity = new Vector3(0, 0, 0);             //current direction and speed of movement
    public Vector3 acceleration = new Vector3(0, 0, 0);         //movement controlled by player movement force and gravity

    public Vector3 moveForce = new Vector3(0, 0, 0);            //combined force of all axis from input for move
    public Vector3 totalForce = new Vector3(0, 0, 0);           //total of ALL forces applied
    
    //character animation scripts triggered by state machine
    public AnimationScript walk;
    public AnimationScript idle;
    public AnimationScript jump;

    static int GROUND_LAYER = 1 << 8;

    //player characteristics
    public float mass = 1.0f;
    public float energy = 1.0f;
    public float verticalForce = GRAVITY_CONSTANT * -2;  //our jump force (Y axis)
    public float lateralForce = 10.0f;                   //our position force (X,Z axis)
    public float consumption = 0.0f;                     //energy burn rate
    public float friction = 0.975f;                      //TODO: put into world property
    public float lookRate = 3.0f;                        //interpolation rate for looking
    public float groundOffset = 1.0f;                    //how high off ground (terrain)
    public float groundRate = 1.0f;

    public bool isJumping = false;
    public float terrainHeight = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //make sure we are within the defined bounds of our level
        //isOutOfBounds returns True if we are out of bounds
        if (isOutOfBounds() == false)
        {
            //all good so do key input and movement
            handleInput();
            handleMovement();
        }

        //we always deal with terrain and player facing
        handleTerrain();
        handleFacing();
                
 
    }
    private void LateUpdate()
    {
      
    }

    void handleInput()
    {
        
        //clear out the move force each frame
        moveForce *= 0;       

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

        /*
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
        */
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

        //decay velocity
        velocity *= friction;
        

    }

    bool isOutOfBounds()
    {
        //keep the player within bounds
   

        bool ret = false;

        if (transform.position.x > 30)
        {
            Vector3 pos = new Vector3(29.5f, transform.position.y, transform.position.z);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }
        if (transform.position.x < 10)
        {
            Vector3 pos = new Vector3(10.5f, transform.position.y, transform.position.z);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }
        if (transform.position.z > 99)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 98.5f);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }
        if (transform.position.z < 1)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 1.5f);
            transform.position = pos;
            velocity *= 0;
            ret = true;
        }

        return ret;


    }

    void handleFacing()
    {

        //face the character in the direction of their velocity
        Vector3 face = velocity.normalized;
        pointAt(transform.position + face * 2.0f);
        
    }

    void pointAt(Vector3 target)
    {
        Quaternion a = transform.rotation;          //save it
        transform.LookAt(target);                   //look at target
        Quaternion b = transform.rotation;          //get new rotation
        transform.rotation = a;                     //set it back
        
        //spherical interpolate
        float t = Time.deltaTime;
        Quaternion c = Quaternion.Slerp(a, b, t * lookRate);

        transform.rotation = c;

    }

    void handleTerrain()
    {


        //we want to raycast
        float h = 1;
        RaycastHit hit;
        int layerMask = GROUND_LAYER;

        Vector3 raycastPoint = transform.position;
        raycastPoint += new Vector3(0, 1, 0);

        if (Physics.Raycast(raycastPoint, -Vector3.up, out hit, 100, layerMask))
        {

            h = hit.point.y ;
            
        }

        terrainHeight = h + groundOffset;

        //ensure I am NEVER below the surface
        if (transform.position.y < terrainHeight)
        {
            Vector3 pos = new Vector3(transform.position.x, terrainHeight, transform.position.z);
            transform.position = pos;
        }


        //TODO: this should also be part of the state machine DAG???
        if (!isJumping )
        {
            //I'm below the surface, so push me up 
            Vector3 pos = new Vector3(transform.position.x,  terrainHeight, transform.position.z);
            pos = Vector3.Lerp(transform.position, pos, Time.deltaTime * groundRate);
            transform.position = pos;
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
    }

}
