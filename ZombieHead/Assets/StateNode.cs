using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this one is the "generic" state all others inherit from
public abstract class StateNode {
    
    //the list of child states
    protected List<StateNode> m_childStates;

    //is it currently in this state?
    public bool p_isInState;
    
    
    public void addChildState(StateNode state)
    {

        m_childStates.Add(state);

    }
     
    public abstract bool advanceTime(float dt);

    protected bool advanceState(float dt)
    {
        foreach (var child in m_childStates)
        {
            if (child.advanceTime(dt) == true)
            {
                //if any child is true, stop iterating and exit                
                return true;
            }
        }

        //if no child state is true, return false
        return false;
    }

}

//our first "concrete" state
public class IdleState : StateNode
{
    
    //constructor
    public IdleState()
    {
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

        //lets just say I am true, which in fact I always am if none of my children are true
        //as IDLE is the first state under root
        p_isInState = true;
        if (p_isInState)
        {
            //do something
        }
        
        return p_isInState;
    }


}
