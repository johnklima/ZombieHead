using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovment : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform ChildTransform;

    [SerializeField]
    private Transform transformB;

	// Use this for initialization
	void Start () {
        posA = ChildTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
	}
	
	// Update is called once per frame
	void Update () {

        Move();
	}

    private void Move()
    {
        ChildTransform.localPosition = Vector3.MoveTowards(ChildTransform.localPosition,nexPos,speed * Time.deltaTime);

        if (Vector3.Distance(ChildTransform.localPosition,nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}
