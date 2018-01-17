using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//our first "concrete" state
public class  JumpState: StateNode
{

    enum StateProgessStates { Start, InAir, Land};
    int stateProgress = 0;
    float jumptimer = 0;
    float durationOfJump = 2.0f;

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

            //since a child state is true, return this fact!
            return true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && rootState.playermotion.energy > 0.0f)
        {

            rootState.playermotion.isJumping = true;
            rootState.playermotion.energy -= 0.0f; // subtract none for now
            p_isInState = true;
            stateProgress = (int) StateProgessStates.Start;
            Debug.Log("Jump init");

        }

        if (p_isInState)
        {

            if (stateProgress == (int)StateProgessStates.Start)
            {
                //initialize jump
                jumptimer = Time.time;
                stateProgress = (int)StateProgessStates.InAir;
                rootState.playermotion.jump.enabled = true;
                Debug.Log("Jump Start");
            }
            else if (stateProgress == (int)StateProgessStates.InAir)
            {
                //handle motion and animation in air
                Debug.Log("In Air");

                if (Time.time - jumptimer > durationOfJump)
                {
                    stateProgress = (int)StateProgessStates.Land;
                }
            }
            else if (stateProgress == (int)StateProgessStates.Land)
            {
                //return to the ground
                Debug.Log("Land");
                rootState.playermotion.jump.enabled = false;
                p_isInState = false;
            }

           
        }

        return p_isInState;
    }


}