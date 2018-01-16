using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootState : MonoBehaviour {


    protected List<StateNode> m_childStates ;

    public playerMotion playermotion; 


    // Use this for initialization prior to anything else happening
    void Awake () {

        playermotion = transform.GetComponent<playerMotion>();

        m_childStates = new List<StateNode>();

        //we must always add at least one, if we want the graph to run
        IdleState idlestate = new IdleState(this);        
        m_childStates.Add(idlestate);

        WalkState walkstate = new WalkState(this);
        idlestate.addChildState(walkstate);

        
    }

    void Start()
    {
        //place the dude
        transform.position.Set(5, 0, 5);
    }

    // Update is called once per frame
    void Update ()
    {
        //update the values that my child states need
        


        //iterate the child states, calling advanceTime
        foreach (StateNode child in m_childStates)
        {
            child.advanceTime(Time.deltaTime);
        }
        
    }

    //happens at the end of all other updates
    //useful for physics, and to ensure setup for
    //the next frame
    void LateUpdate()
    {

    }


    //Utility function to find nodes by name
    public Transform Search(Transform target, string name)
    {
        if (target.name == name) return target;

        for (int i = 0; i < target.childCount; i++)
        {
            //we use "var" because the component could be anything
            var result = Search(target.GetChild(i), name);

            if (result != null) return result;
        }

        return null;
    }
    
}
