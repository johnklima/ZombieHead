using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class johnHips : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move the hips ball back and forth
        float t = Time.time;
        
        float y = Mathf.Sin(t * 4.0f) * 0.5f;

        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

    }
}
