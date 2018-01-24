using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Segment3d : MonoBehaviour
{
    public Vector3 Apos = new Vector3(0, 0, 0);
    public Vector3 Bpos = new Vector3(0, 0, 0);

    protected float length = 0;

    public Segment3d parent = null;
    public Segment3d child = null;

    public float interpRate = 3;

    private IKSystem3d parentSystem;
    public Quaternion initialRotation;
    public float twist;
    public float constrainX = 180;
     
    void Awake()
    {
        //aquire the length of this segment - the dummy geometry will always be child zero
        length = transform.GetChild(0).localScale.z;
        parentSystem = transform.GetComponentInParent<IKSystem3d>();
        initialRotation = transform.GetChild(0).rotation;
        
    }

    public void updateSegmentAndChildren()
    {
        length = transform.GetChild(0).localScale.z;

        updateSegment();

        //update its children
        if (child)
            child.updateSegmentAndChildren();
    }

    public void updateSegment()
    {

       
        if (parent)
        {
            Apos = parent.Bpos;         //could also use parent endpoint...
            transform.position = Apos;  //move me to Bpos (parent endpoint)
        }
        else
        {
            //Apos is always my position
            Apos = transform.position;
        }

        //Bpos is always where the endpoint will be, as calculated from length 
        calculateBpos();
    }

    void calculateBpos()
    {   
        Bpos = Apos + transform.forward * length;
    }
    
    public void pointAt(Vector3 target)
    {
        Quaternion a = transform.rotation;          //save it
        transform.LookAt(target);                   //look at target
        Quaternion b = transform.rotation;          //get new rotation
        transform.rotation = a;                     //set it back
        
        
        //if the system is in drag mode, we want to crank the interpolation
        //otherwise, the chain is "lazy," it doesnt need to do anything
        float ir = interpRate;
        if (parentSystem.isDragging)
            ir *= 10;

  

        //spherical interpolate
        float t = Time.deltaTime;                   
        Quaternion c = Quaternion.Slerp(a, b, t * ir);

        //Vector3 euler = c.eulerAngles;
        //euler.Set(euler.x - constrainX, euler.y, euler.z);
        //c.eulerAngles = euler;

        transform.rotation = c;

        //twist back local rotation on geometry so it returns to forward facing
        //get the angle between player forward and geom Y
        /*
        
        Vector3 v1 = transform.right;
        Vector3 v2 = transform.parent.right;
        twist = Vector3.Angle(v1, v2);

        transform.Rotate(Vector3.forward, twist, Space.Self);
       
         */

    }

    
    public void drag(Vector3 target)
    {
        pointAt(target);
        transform.position = target - transform.forward * length;

        if (parent)
            parent.drag(transform.position);


    }

    public void reach(Vector3 target)
    {
        drag(target);
        updateSegment();
    }
}
