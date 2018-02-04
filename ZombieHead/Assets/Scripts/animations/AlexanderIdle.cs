using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 1. COPY/PASTE AND RENAME THIS FILE AND THE CLASS NAME BELOW TO "YourNameBlahAnimation"
 * 2. ASSOCIATE IT TO YOUR COPY OF THE ZOMBIE PREFAB
 * 3. RECONNECT TARGETS
 * 
 */


public class AlexanderIdle : AnimationScript // In case the 'actual' drag animation doesn't count.
{



    public float frequency = 2;
    public float xAmplitude = 1.5f;
    public float yAmplitude = 1.5f;
    public float zAmplitude = 1.5f;
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

    public Vector3[] positionArrayRight = new Vector3[4];
    public Vector3[] positionArrayLeft = new Vector3[4];
    public int curPosition = 0;

    // public float zlegLeft;
    // public float zlegRight;

    // Use this for initialization
    void Start()
    {
        phase = 0;
        localTime = 0;

        //example of using an array of locations to move the target
        positionArrayRight[0] = new Vector3(-0.2f, 0.5f, 0.5f);
        positionArrayRight[1] = new Vector3(2f, 1f, 0.5f);
        positionArrayRight[2] = new Vector3(1f, 1f, 2f);
        positionArrayRight[3] = new Vector3(0.2f, 0.5f, 2f);
        positionArrayLeft[0] = new Vector3(-0.2f, 0.5f, 0.5f);
        positionArrayLeft[1] = new Vector3(-2f, 1f, 0.5f);
        positionArrayLeft[2] = new Vector3(-1f, 1f, 2f);
        positionArrayLeft[3] = new Vector3(-0.2f, 0.5f, 2f);


    }

    // Update is called once per frame
    void Update()
    {

        //accumulate our own local time to this object
        localTime += Time.deltaTime;

        Vector3 finalRightArm = positionArrayRight[curPosition];
        Vector3 finalLeftArm = positionArrayLeft[curPosition];

        float z = Mathf.Sin((Time.time + Mathf.PI));

        finalRightArm.Set(finalRightArm.x, finalRightArm.y, finalRightArm.z + z);
        finalLeftArm.Set(finalLeftArm.x, finalLeftArm.y, finalLeftArm.z + z);


       // targetArmRight.localPosition = Vector3.Slerp(targetArmRight.localPosition, // Commenting it out so it's distinct from the actual Drag animation, so it can be seen in the State engine.
       //                                               finalRightArm,
       //                                               Time.deltaTime * 4.0f);

        targetArmLeft.localPosition = Vector3.Slerp(targetArmLeft.localPosition,
                                                      finalLeftArm,
                                                      Time.deltaTime * 3.0f);

        if (localTime > 1.0f)
        {
            curPosition++;

            if (curPosition >= positionArrayRight.Length)
                curPosition = 0;

            localTime = 0;
        }


        // zlegLeft = Mathf.Sin(frequency * Time.time + Mathf.PI) * amplitude;
        // zlegRight = Mathf.Sin(frequency * Time.time) * amplitude;

        //  curTlegleft.Set(targetLegLeft.localPosition.x, targetLegLeft.localPosition.y, zlegLeft);
        // targetLegLeft.localPosition = curTlegleft;

        // curTlegright.Set(targetLegRight.localPosition.x, targetLegRight.localPosition.y, zlegRight);
        // targetLegRight.localPosition = curTlegright;


        float y1 = Mathf.Sin(Time.time + (phase + Mathf.PI * frequency)) * -yAmplitude;
        float z1 = Mathf.Sin(Time.time + (phase + Mathf.PI * frequency)) * -zAmplitude;

        curThead.Set(targetHead.localPosition.x, 1.0f + y1 + -yAmplitude - 1, 1.0f + z1 + zAmplitude + 0.2f);
        targetHead.localPosition = curThead;


        /*
        float z2 = Mathf.Sin( localTime + (phase + Mathf.PI * frequency) ) * amplitude;
        float z3 = Mathf.Sin((localTime + phase) * frequency) * amplitude;
        
        curTarmleft.Set(targetArmLeft.localPosition.x, targetArmLeft.localPosition.y, deltaT.z + z2);
        targetArmLeft.localPosition = curTarmleft;

        curTarmright.Set(targetArmRight.localPosition.x, targetArmRight.localPosition.y, deltaT.z + z3);
        targetArmRight.localPosition = curTarmright;

         */




    }

}

