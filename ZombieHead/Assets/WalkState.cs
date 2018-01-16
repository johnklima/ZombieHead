using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateNode {

    public Vector3 velocity;
        
    //constructor
    public WalkState(RootState root)
    {
        rootState = root;
        m_childStates = new List<StateNode>();
    }


    public override bool advanceTime(float dt)
    {

        //if any child state is true, set my state and return
        //do not continue to process state tree, back out from here
        if (advanceState(dt) == true)
        {
            //if any child state is true, I am false
            p_isInState = false;

            //since a child state is true, return this fact!
            return true;
        }

        //Am I walking???
        p_isInState = false;
        if(rootState.playermotion.velocity.magnitude > 0.5f)
            p_isInState = true;


        if (p_isInState)
        {
            //do something
            Debug.Log("IN WALKING");
        }

        return p_isInState;
    }

}
