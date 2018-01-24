using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public GameObject Player;

    public float lives;
    public float healthPoints = 100.0f;

    // References are set to private since we're calling them via the script.
    private LevelManager levelManager;
    private LivesManager livesManager;

    // Use this for initialization
    void Start ()
    {
        // GameObject references will be lost on RestartCurrentLevel() so we find and retrieve
        // these references again once the level loads.
        levelManager = GameObject.Find("GameManager").GetComponentInChildren<LevelManager>();
        livesManager = GameObject.Find("GameManager").GetComponentInChildren<LivesManager>();

        lives = livesManager.lives;
    }

    // Update is called once per frame
    void Update ()
    {

        // Kill the player if health points reach 0 or less.
        // Currently only restarts level, but will be replaced with death effects and
        // HUD notification at a later stage.

        if (healthPoints < 0.0f)
        {
            livesManager.RemoveLife();
            Debug.Log("Player died! Player has " + lives + " lives left. Restarting current level.");
            levelManager.RestartCurrentLevel();
        }


        // We check how many lives the player has left, and if it goes below 0, we reset the lives and level.

        livesManager.CheckLives();

        if (lives < 0.0f)
        {
            livesManager.ResetLives();
            levelManager.RestartCurrentLevel();
            Debug.Log("Game Over. Restarting current level.");
        }

	}

    // Subtract 200.0f HP if player's collision box collides with the collison boxes of spikes.
    void OnTriggerEnter (Collider collisionDamage)
    {
        if (collisionDamage.gameObject.tag == "Spikes")
        {
            healthPoints -= 200.0f;
        }
    }
}
