using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public GameObject Player;
    public LevelManager levelManager;

    public float healthPoints = 100.0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Kill the player if health points reach 0 or less.
        // Currently only restarts level, but will be replaced with particle effects and 
		if (healthPoints < 0.0f)
        {
            levelManager.RestartCurrentLevel();
            Debug.Log("The player has died. Restarting current level.");
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
