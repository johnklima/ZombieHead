using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Simple steering behaviors for path following / goal seeking and obstacle avoidance

*/
public class steering : MonoBehaviour
{

    public Vector3 velocity = new Vector3(0, 0, 1.5f);
    private Vector3 goalVelocity = new Vector3(0, 0, 1.5f); //the velocity we want to smooth too
    public float maxSpeed = 5.0f;
    public float speed = 0;
    public float radius = 2.0f;

    //STEERING
    public Vector3 steeringForce = new Vector3(0, 0, 0);
    public float steeringForceFactor = 0.01f;
    public float dotproduct = 0;

    public int curPoint = 0;
    public int pointCount = 0;
    private Vector3[] points;

    public Transform Player;

    public enum STATES {

        WAIT = 0,
        SEEK = 1,
        FLEE = 2,
        HIT = 3,
    }

    public STATES state = STATES.SEEK;

    // Use this for initialization
    void Start() {

        


    }

    // Update is called once per frame
    void Update() {

        float dt = Time.deltaTime;
        
        if(state == STATES.SEEK)
            seek(dt);
        else if(state == STATES.FLEE)
            flee(dt);
        else if(state == STATES.WAIT)
            wait(dt);
        
        handleMove(dt);
    }

    

    void avoidObstacles(float dt) {

        

    }

    void seek(float dt) {

        Vector3 target = Player.position;
        Vector3 targetDirection = Vector3.Normalize(target - transform.position);
        velocity += targetDirection * dt * 50;

    }

    void flee(float dt)
    {
        Vector3 target = Player.transform.localPosition;

        if(Vector3.Distance(target, transform.position) < 20.0f) {

            state = STATES.SEEK;
            return;
        }

        Vector3 targetDirection = Vector3.Normalize(target - transform.position);

        velocity += targetDirection * dt * 50;

    }

    void wait(float dt) {




    }


    void handleMove(float dt) {


        Vector3 curpos = transform.position;

        
        //GENERAL RULE OF VELOCITY : don't let them go too fast!!!        
        float maxSpeedSquared = maxSpeed * maxSpeed;
        float velMagSquared = velocity.magnitude * velocity.magnitude;
        if(velMagSquared > maxSpeedSquared) {
            velocity *= (maxSpeed / velocity.magnitude);
        }

        //and then we "normalize" to get a heading, or rather, a lookAt position
        Vector3 heading = velocity;
        heading.Normalize();
        Vector3 lookAtPoint = transform.position + (heading * 2); //look a bit in front of me
        transform.LookAt(lookAtPoint);    //we may want to interpolate the turn (or the camera)


        transform.position += velocity * dt;

       
        


    }
}
