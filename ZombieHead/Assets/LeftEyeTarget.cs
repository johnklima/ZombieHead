using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEyeTarget : MonoBehaviour {
    public float xamplitude = 1.0f;
    public float xfrequency = 1.0f;
    public float yamplitude = 1.0f;
    public float yfrequency = 1.0f;
    public float zamplitude = 1.0f;
    public float zfrequency = 1.0f;

    Vector3 startPosition;

    // Use this for initialization
    void Start () {
      startPosition = transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {

        float x = Mathf.Sin(Time.time * xfrequency) * xamplitude;
        float y = Mathf.Sin(Time.time * yfrequency + Mathf.PI) * yamplitude;
        float z = Mathf.Sin(Time.time * zfrequency) * zamplitude;

        Vector3 pos = Vector3.zero;
        pos.Set(startPosition.x + x, startPosition.y + y, startPosition.z + z);

        transform.localPosition = pos;
    }
}
