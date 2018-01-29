using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 1. COPY/PASTE AND RENAME THIS FILE AND THE CLASS NAME BELOW TO "YourNameBlahAnimation"
 * 2. ASSOCIATE IT TO YOUR COPY OF THE ZOMBIE PREFAB
 * 3. RECONNECT TARGETS
 * 
 */


public class JohnIdleAnimation : AnimationScript
{

    

    public float frequency = 2;
    public float amplitude = 1.5f;
    public float phase = 0;

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

    // Use this for initialization
    void Start ()
    {
        phase = 0;
        localTime = 0;

        //example of using an array of locations to move the target
        positionArray[0] = new Vector3(0.0f, 0.0f, 0.0f);
        positionArray[1] = new Vector3(1.0f, 0.0f, 5.0f);
        positionArray[2] = new Vector3(0.2f, 0.3f, 1.4f);
        positionArray[3] = new Vector3(0.5f, 1.5f, 0.5f);

        
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


        zlegLeft = Mathf.Sin(  frequency * Time.time + Mathf.PI  ) * amplitude;
        zlegRight = Mathf.Sin(  frequency * Time.time            ) * amplitude;

        curTlegleft.Set(targetLegLeft.localPosition.x, targetLegLeft.localPosition.y, zlegLeft);
        targetLegLeft.localPosition = curTlegleft;

        curTlegright.Set(targetLegRight.localPosition.x, targetLegRight.localPosition.y, zlegRight);
        targetLegRight.localPosition = curTlegright;


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

