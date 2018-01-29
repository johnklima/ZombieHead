﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSystem3d : MonoBehaviour
{
    public Segment3d[] segments;
    public Transform target = null;
    public Transform parentTransform;

    public bool isReaching = false;
    public bool isDragging = false;

    private Segment3d lastSegment = null;
    private Segment3d firstSegment = null;

    private bool wasDragging = false;
    public int childcount = 0;

    public bool useAltIK = false;
    public bool useCCD = false;

    // Use this for initialization
    void Awake()
    {

        //lets buffer our segements in an array
        childcount = transform.childCount;           
    
        segments = new Segment3d[childcount];
        int i = 0;
        foreach (Transform child in transform)
        {
            segments[i] = child.GetComponent<Segment3d>();
            i++;
        }
        

        firstSegment = segments[0];
        lastSegment = segments[childcount - 1];
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = Vector3.zero;
        Quaternion rotation = Quaternion.identity;

        //if we assigned a parent xform, move to origin (ik with constraints)
        if (parentTransform)
        {
            position = parentTransform.position;
            rotation = parentTransform.rotation;


            parentTransform.position = Vector3.zero;
            parentTransform.rotation = Quaternion.identity;
        }

        if (useCCD)
        {
            //to be implemented
            firstSegment.reachCCD(target.position);

        }
            
        
        if (useAltIK)
        {
            // call reach on the first
            firstSegment.reachAlt(target.position);
            return;

        }

        if (isDragging)
        {
            
            lastSegment.drag(target.position);
            wasDragging = true;
        }
        else if (wasDragging && (!isDragging || isReaching))
        {
            isDragging = false;    //if reaching brought use here, we should reset.
            wasDragging = false;

            transform.position = firstSegment.transform.position;
            firstSegment.transform.position = transform.position;
            
            //do one reach cycle to get things in a nice state
            lastSegment.reach(target.position);
            firstSegment.transform.position = transform.position;
            firstSegment.updateSegmentAndChildren();

        }
        else if (isReaching)
        {
            //call reach on the last
            lastSegment.reach(target.position);

            //and forward update on the first
            //we needed to maintain that first segment original position
            //which is the position of the IK system itself
            firstSegment.transform.position = transform.position;
            firstSegment.updateSegmentAndChildren();



        }

        //move back
        if (parentTransform)
        {
            parentTransform.position = position;
            parentTransform.rotation = rotation;
        }
    }
}

