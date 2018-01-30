using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenjaminIdleAnimation : AnimationScript
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
    void Start()
    {
        
        //Set target position
        targetArmLeft.localPosition = new Vector3(-1.46f, -3.02f, 0.0f );
        targetArmRight.localPosition = new Vector3(0.88f, -3.69f, 0.2f);
        targetHead.localPosition = new Vector3(0.285f, 0f, 2.608f);
        
    }

    // Update is called once per frame
    void Update()
    {
    
        //Values for Animation
        float t = Time.time;
        float y = Mathf.Sin(t * 1.0f) * 1.0f;
        float y2 = Mathf.Sin(t * 0.5f) * 0.5f;
        float z = Mathf.Sin(t * 1.0f) * 1.0f;
        float z1 = Mathf.Sin(t * 1.5f) * 1.5f;
        float x = Mathf.Sin(t * 0.5f) * 0.2f;
        //Animations
        targetArmLeft.localPosition = new Vector3(targetArmLeft.localPosition.x, targetArmLeft.localPosition.y, z);
        targetArmRight.localPosition = new Vector3(targetArmRight.localPosition.x, targetArmRight.localPosition.y, z1);
        targetHead.localPosition = new Vector3(x, y2, targetHead.localPosition.z);
    }

}
