using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePendulum : MonoBehaviour {

    // Float values for manipulating swing radius and speed.
    public float angleDegrees = 28.0f;
    public float rotationSpeed = 2.0f;

    // Should we declare an offset value to our GameObjects in start, 
    // so that our swing starts at a random point within our swing?
    // Randomizing swing with different rotationSpeed values for now.
	void Start ()
    {
		
	}
	

	void Update ()
    {
        // We use Quaternion to declare a rotation, and use Mathf.Sin on Z-axis, 
        // along with our float values in order to make our object swing.
        transform.rotation = Quaternion.Euler(0, 0, angleDegrees * Mathf.Sin(Time.time * rotationSpeed));
	}
}
