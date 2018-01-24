using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour {

    public float lives = 2.0f;

    public void RemoveLife()
    {
        lives -= 1.0f;
    }

    public float CheckLives()
    {
        return lives;
    }

    public void ResetLives()
    {
        lives = 2.0f;
    }
}
