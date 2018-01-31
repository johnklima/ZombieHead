﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdrianIdleAnimation : AnimationScript
{



    private float frequency = 1.5f;
    private float amplitude = 1.5f;
    private float phase = 0;

    Vector3 deltaT = new Vector3();

    //accumulated tranformations on my spheres
    Vector3 curThead = new Vector3();
    Vector3 curTlegleft = new Vector3();
    Vector3 curTlegright = new Vector3();
    Vector3 curTarmleft = new Vector3();
    Vector3 curTarmright = new Vector3();

    float localTime = 0;

    //animation targe spheres in the scene (the red spheres)
    public Transform targetHead;
    public Transform targetLegLeft;
    public Transform targetLegRight;
    public Transform targetArmLeft;
    public Transform targetArmRight;

    public Vector3[] positionArray = new Vector3[4];
    public int curPosition = 0;

    public float zlegLeft;
    public float zlegRight;
    public float zarmLeft;
    public float zarmRight;
 



    // Use this for initialization
    void Start()
    {
        phase = 0;
        localTime = 0;

        //example of using an array of locations to move the target
        positionArray[0] = new Vector3(0.0f, 0.0f, 0.0f);
        positionArray[1] = new Vector3(1.0f, 0.0f, 5.0f);
        positionArray[2] = new Vector3(0.2f, 0.3f, 1.4f);
        positionArray[3] = new Vector3(0.5f, 1.0f, 0.5f);


    }

    // Update is called once per frame
    void Update()
    {

        //accumulate our own local time to this object
        localTime += Time.deltaTime;

        Vector3 finalPos = positionArray[curPosition];

        float z = Mathf.Sin(localTime + (phase + Mathf.PI * frequency)) * amplitude;

        finalPos.Set(finalPos.x, finalPos.y, finalPos.z);

    


        if (localTime > 1.0f)
        {
            curPosition++;

            if (curPosition >= positionArray.Length)
                curPosition = 0;

            localTime = 0;
        }

        //Animation idle unstable sway
        zlegLeft = Mathf.Sin(0.1f * Time.time + Mathf.PI) * 1.0f;
        zlegRight = Mathf.Sin(0.1f * Time.time) * 1.0f;
        zarmLeft = Mathf.Sin(0.2f * Time.time+Mathf.PI) * 0.3f;
        zarmRight = Mathf.Sin(1.0f * Time.time) * 1.0f;
        

        curTlegleft.Set(targetLegLeft.localPosition.x, targetLegLeft.localPosition.y, zlegLeft);
        targetLegLeft.localPosition = curTlegleft;

        curTlegright.Set(targetLegRight.localPosition.x, targetLegRight.localPosition.y, zlegRight);
        targetLegRight.localPosition = curTlegright;

        curTarmleft.Set(targetArmLeft.localPosition.x, targetArmLeft.localPosition.y, zarmLeft);
        targetArmLeft.localPosition = curTarmleft;

        curTarmright.Set(targetArmRight.localPosition.x, targetArmRight.localPosition.y, zarmRight);
        targetArmRight.localPosition = curTarmright;

    



    }

}

