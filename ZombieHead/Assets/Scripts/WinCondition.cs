using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public LevelManager levelManager;

    // Toggle current level on to load correct scene for next level.
    public bool level01;
    public bool level02;

    void Start()
    {
        // Hardcoding LevelManager.cs reference to prevent it falling out when restarting the level
        levelManager = GameObject.Find("GameManager").GetComponentInChildren<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Load Level02
        if(other.gameObject.tag == "Player" && level01 == true)
        {
            levelManager.LoadLevel02();
        }

        // Load Level03
        if (other.gameObject.tag == "Player" && level02 == true)
        {
            levelManager.LoadLevel03();
        }
    }

}
