using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //force the camera to follow the ship
        transform.position = target.position + new Vector3(3, 2, 0);
        transform.LookAt(target);

    }
}
