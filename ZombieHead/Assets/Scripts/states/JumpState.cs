using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//our first "concrete" state
public class  JumpState: StateNode
{

    private enum StateProgessStates { Start, InAir, Fall, Land};
    private int stateProgress = 0;

    //constructor
    public JumpState(RootState root)
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

            rootState.playermotion.jump.enabled = false;
            rootState.playermotion.isJumping = false;

            //since a child state is true, return this fact!
            return true;
        }

        if ( Input.GetKeyDown(KeyCode.Space)        && 
             rootState.playermotion.energy > 0.0f   && 
             !p_isInState)
        {

            rootState.playermotion.isJumping = true;
            
            //TODO: enable energy
            rootState.playermotion.energy -= 0.0f; // subtract none for now

            p_isInState = true;
            stateProgress = (int) StateProgessStates.Start;

            rootState.playermotion.jumpForce = rootState.playermotion.velocity
                                             + rootState.playermotion.transform.forward * 100.0f
                                             + rootState.playermotion.transform.up * 700.0f;

            Debug.Log("Jump init");

        }

        if (p_isInState)
        {

            if (stateProgress == (int)StateProgessStates.Start)
            {
                
                stateProgress = (int)StateProgessStates.InAir;
                rootState.playermotion.jump.enabled = true;
                Debug.Log("Jump Start");
            }
            else if (stateProgress == (int)StateProgessStates.InAir)
            {
                //handle motion and animation in air
                Debug.Log("In Air");

                if(rootState.playermotion.isJumping == false)
                    stateProgress = (int)StateProgessStates.Land;

                if (rootState.playermotion.gameObject.transform.position.y < rootState.playermotion.terrainHeight + 0.1f)
                    stateProgress = (int)StateProgessStates.Land;
                
            }
            else if (stateProgress == (int)StateProgessStates.Land)
            {
                //return to the ground
                Debug.Log("Land");
                rootState.playermotion.jump.enabled = false;
                rootState.playermotion.isJumping = false;
                rootState.playermotion.velocity *= 0.2f;
                p_isInState = false;
            }

           
        }

        return p_isInState;
    }


}