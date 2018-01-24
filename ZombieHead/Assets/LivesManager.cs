using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour {

    // Total amount of player lives
    public float lives = 3.0f;

    // Has the player los a life this round?
    public bool lostLife = true;

    // We remove a life if the player hasn't lost a life this round,
    // and then set the lostLife to true to prevent any further deductions.
    public void RemoveLife()
    {
        if (lostLife == false)
            lives -= 1.0f;
            lostLife = true;
            CheckLives();
    }

    // Check how many lives the player has
    public float CheckLives()
    {
        return lives;
    }

    // Refresh the amount of lives.
    public void ResetLives()
    {
        lives = 3.0f;
    }
}
