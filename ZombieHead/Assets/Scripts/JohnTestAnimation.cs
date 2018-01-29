using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnTestAnimation : AnimationScript {

    public float frequency = 2;
    public float amplitude = 1.5f;
    public float phase = 0;

    Vector3 deltaT = new Vector3();
    Vector3 curThead = new Vector3();
    Vector3 curTlegleft = new Vector3();
    Vector3 curTlegright = new Vector3();
    Vector3 curTarmleft = new Vector3();
    Vector3 curTarmright = new Vector3();

    float localTime = 0;

    public Transform targetHead;
    public Transform targetLegLeft;
    public Transform targetLegRight;
    public Transform targetArmLeft;
    public Transform targetArmRight;

    // Use this for initialization
    void Start ()
    {
        deltaT = Vector3.zero;
        localTime = 0;
    }
	
	// Update is called once per frame
	void Update () {

        float z = Mathf.Sin( (localTime + phase) * frequency) * amplitude;

        curThead.Set(targetHead.localPosition.x, targetHead.localPosition.y, deltaT.z + z);        
        targetHead.localPosition = curThead;

        curTarmleft.Set(targetArmLeft.localPosition.x, targetArmLeft.localPosition.y, deltaT.z + z);
        targetArmLeft.localPosition = curTarmleft;

        curTarmright.Set(targetArmRight.localPosition.x, targetArmRight.localPosition.y, deltaT.z + z);
        targetArmRight.localPosition = curTarmright;

        curTlegleft.Set(targetLegLeft.localPosition.x, targetLegLeft.localPosition.y, deltaT.z + z);
        targetLegLeft.localPosition = curTlegleft;

        curTlegright.Set(targetLegRight.localPosition.x, targetLegRight.localPosition.y, deltaT.z + z);
        targetLegRight.localPosition = curTlegright;


        //accumulate our own local time to this object
        localTime += Time.deltaTime;
	}
}
