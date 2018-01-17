using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationScript : MonoBehaviour
{

}
public class johnWalking : AnimationScript
{

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update ()
    {

        //move the target ball back and forth
        float t = Time.time;
        float z = Mathf.Sin(t * 4.0f);

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
		
    }
}
