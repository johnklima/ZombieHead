using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdwinIdleAnimation : AnimationScript
{

   

    //animation targe spheres in the scene (the red spheres)
    public Transform targetHead;
    public Transform targetLegLeft;
    public Transform targetLegRight;
    public Transform targetArmLeft;
    public Transform targetArmRight;

    public float zlegLeft;
    public float zlegRight;

    // Use this for initialization
    void Start ()
    {

        targetHead.localPosition = new Vector3 (0.6f, -0.36f,1.1f);
        targetArmRight.localPosition = new Vector3 (3.0f, -1.4f, -2.0f);
        targetArmLeft.localPosition = new Vector3 (-0.37f, 0.72f, 3.32f);
        targetLegRight.localPosition = new Vector3 (2.0f, 0.32f, 0.6f);





    }

    // Update is called once per frame
    void Update()
    {

        //movement of the ball
        float t = Time.time;
        float y = Mathf.Sin(t * 2.6f) * 1.0f;
        float y2 = Mathf.Sin(t * 1.7f) * 0.5f;
        float z = Mathf.Sin(t * 1.6f) * 1.0f;
        float z1 = Mathf.Sin(t * 1.5f) * 1.5f;
        float x = Mathf.Sin(t * 1.5f) * 0.2f;
        float x2 = Mathf.Sin(t * 3.2f) * 3.1f;
        float z3 = Mathf.Sin(t * 2.3f) * 2.7f;
        float y3 = Mathf.Sin(t * 0.9f) * 1.2f;
        float y4 = Mathf.Sin(t * 1.0f) * 1.3f;
        float x3 = Mathf.Sin(t * 1.1f) * 1.4f;
        //action
        targetArmRight.localPosition = new Vector3(targetArmRight.localPosition.x, targetArmRight.localPosition.y, z3);
        targetHead.localPosition = new Vector3(x, z3, targetHead.localPosition.z);
        targetLegLeft.localPosition = new Vector3(x2, x2, targetLegLeft.localPosition.z);
        targetLegRight.localPosition = new Vector3(x2, z3, targetLegRight.localPosition.z);
        targetArmLeft.localPosition = new Vector3(x2, y3, targetArmLeft.localPosition.z);
    }
}

        



