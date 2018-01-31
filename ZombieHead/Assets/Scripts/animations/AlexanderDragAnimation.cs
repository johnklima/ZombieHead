using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 1. COPY/PASTE AND RENAME THIS FILE AND THE CLASS NAME BELOW TO "YourNameBlahAnimation"
 * 2. ASSOCIATE IT TO YOUR COPY OF THE ZOMBIE PREFAB
 * 3. RECONNECT TARGETS
 * 
 */


public class AlexanderDragAnimation : AnimationScript
{

    

    public float frequency = 2;
    public float amplitude = 1.5f;
    public float phase = 0;

    Vector3 deltaT = new Vector3();

    //accumulated tranformations on my spheres
    Vector3 curThead = new Vector3();
    // Vector3 curTlegleft = new Vector3();
    // Vector3 curTlegright = new Vector3();
    Vector3 curTarmleft = new Vector3();
    Vector3 curTarmright = new Vector3();

    float localTime = 0;

    //animation targe spheres in the scene (the red spheres)
    public Transform targetHead;
    // public Transform targetLegLeft;
    // public Transform targetLegRight;
    public Transform targetArmLeft;
    public Transform targetArmRight;

    public Vector3[] positionArray = new Vector3[4];
    public int curPosition = 0;

    public float zarmLeft;
    public float zarmRight;

    public float yarmLeft;
    public float yarmRight;


    // Use this for initialization
    void Start ()
    {
        phase = 0;
        localTime = 0;

        
        
    }

    // Update is called once per frame
    void Update()
    {

        //accumulate our own local time to this object
        localTime += Time.deltaTime;

        Vector3 finalPos = positionArray[curPosition];

        float z = Mathf.Sin((Time.time + Mathf.PI));

        finalPos.Set(finalPos.x, finalPos.y, finalPos.z + z);


        targetArmRight.localPosition = Vector3.Slerp( targetArmRight.localPosition , 
                                                      finalPos,
                                                      Time.deltaTime * 10.0f       );

        if (localTime > 1.0f)
        {
            curPosition++;

            if (curPosition >= positionArray.Length)
                curPosition = 0;

            localTime = 0;
        }


        zarmLeft = Mathf.Sin(  frequency * Time.time + Mathf.PI  ) * amplitude;
        zarmRight = Mathf.Sin(  frequency * Time.time            ) * amplitude;

        yarmLeft = Mathf.Sin(frequency * Time.time ) * amplitude + 5.0f;
        yarmRight = Mathf.Sin(frequency * Time.time + Mathf.PI) * amplitude + 5.0f;


        curTarmleft.Set(targetArmLeft.localPosition.x, yarmLeft, zarmLeft);
        targetArmLeft.localPosition = curTarmleft;

        curTarmright.Set(targetArmRight.localPosition.x, yarmRight, zarmRight);
        targetArmRight.localPosition = curTarmright;


        /*

        float z1 = Mathf.Sin( localTime + (phase + Mathf.PI * frequency) ) * amplitude;
        float z2 = Mathf.Sin( localTime + (phase + Mathf.PI * frequency) ) * amplitude;
        float z3 = Mathf.Sin((localTime + phase) * frequency) * amplitude;




        curThead.Set(targetHead.localPosition.x, targetHead.localPosition.y, deltaT.z + z1);        
        targetHead.localPosition = curThead;

        curTarmleft.Set(targetArmLeft.localPosition.x, targetArmLeft.localPosition.y, deltaT.z + z2);
        targetArmLeft.localPosition = curTarmleft;

        curTarmright.Set(targetArmRight.localPosition.x, targetArmRight.localPosition.y, deltaT.z + z3);
        targetArmRight.localPosition = curTarmright;

         */




    }

}

