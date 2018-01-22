using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinkHip : AnimationScript
{
    //put players y axes too 3 in unity
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //move the hips ball back and forth
        float t = Time.time;

        float y = Mathf.Sin(t * 0.05f) * 0.05f;

        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

    }
}