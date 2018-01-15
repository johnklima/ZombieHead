using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followShip : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //force the camera to follow the ship
        transform.position = target.position + new Vector3(0, 3, -4);
        transform.LookAt(target);

    }
}
