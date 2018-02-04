using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public GameObject Player;

    public ParticleSystem bloodSplat;

    public GameObject retryScreen;
    public GameObject gameOverScreen;

    public float healthPoints = 100.0f;

    // References are set to private since we're calling them via the script.
    // Manager scripts:
    private LevelManager levelManager;
    private LivesManager livesManager;

    // HUD Images:
    private Image heart1Full;
    private Image heart1Empty;
    private Image heart2Full;
    private Image heart2Empty;
    private Image heart3Full;
    private Image heart3Empty;

    // Use this for initialization
    void Start()
    {
        // GameObject references will be lost on RestartCurrentLevel() so we find and retrieve
        // these references again once the level loads.
        levelManager = GameObject.Find("GameManager").GetComponentInChildren<LevelManager>();
        livesManager = GameObject.Find("GameManager").GetComponentInChildren<LivesManager>();

        heart1Full = GameObject.Find("fullHeart1").GetComponentInChildren<Image>();
        heart1Empty = GameObject.Find("emptyHeart1").GetComponentInChildren<Image>();
        heart2Full = GameObject.Find("fullHeart2").GetComponentInChildren<Image>();
        heart2Empty = GameObject.Find("emptyHeart2").GetComponentInChildren<Image>();
        heart3Full = GameObject.Find("fullHeart3").GetComponentInChildren<Image>();
        heart3Empty = GameObject.Find("emptyHeart3").GetComponentInChildren<Image>();

        // Here we tell that the lostLife bool in LivesManager should be set to false
        // once Unity loads and reloads the level. This will let us play animations
        // and effects on death, without losing more than 1 life despite the player
        // taking damage constantly.
        livesManager.lostLife = false;

        retryScreen.SetActive(false);
        gameOverScreen.SetActive(false);


        //Resets timeScale at start.
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Kill the player if health points reach 0 or less.
        // Currently only restarts level, but will be replaced with death effects and
        // HUD notification at a later stage.
        if (healthPoints < 0.0f && livesManager.lives > 0.9f)
        {
            livesManager.RemoveLife();
            retryScreen.SetActive(true);
            Debug.Log("Player died! Player has " + (livesManager.lives) + " lives left. Restarting current level.");
        }

        // Change heart count depending on remaining lives.
        if (livesManager.lives > 2.9f)
        {
            ThreeHearts();
        }

        else if (livesManager.lives > 1.9f)
        {
            TwoHearts();
        }

        else if (livesManager.lives > 0.9f)
        {
            OneHeart();
        }

        // We check how many lives the player has left, and if it goes below 0.8f, we reset the lives and level.
        else if (livesManager.lives < 0.1f)
        {
            NoHearts();
            retryScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            Debug.Log("Game over.");
        }
    }

    // Change heart count depending on remaining lives. We do this by toggling the images on/off,
    // which will also allow us to play animations on active elements later.
    void ThreeHearts()
    {
        heart1Full.enabled = true;
        heart1Empty.enabled = false;
        heart2Full.enabled = true;
        heart2Empty.enabled = false;
        heart3Full.enabled = true;
        heart3Empty.enabled = false;

    }

    void TwoHearts()
    {
        heart1Full.enabled = true;
        heart1Empty.enabled = false;
        heart2Full.enabled = true;
        heart2Empty.enabled = false;
        heart3Full.enabled = false;
        heart3Empty.enabled = true;
    }

    void OneHeart()
    {
        heart1Full.enabled = true;
        heart1Empty.enabled = false;
        heart2Full.enabled = false;
        heart2Empty.enabled = true;
        heart3Full.enabled = false;
        heart3Empty.enabled = true;
    }

    void NoHearts()
    {
        heart1Full.enabled = false;
        heart1Empty.enabled = true;
        heart2Full.enabled = false;
        heart2Empty.enabled = true;
        heart3Full.enabled = false;
        heart3Empty.enabled = true;
    }

    public void BloodSplatter()
    {
        bloodSplat.Play();
    }

    // Subtract 200.0f HP if player's collision box collides with the collison boxes of spikes.
    void OnTriggerEnter(Collider collisionDamage)
    {
        if (collisionDamage.gameObject.tag == "Spikes")
        {
            healthPoints -= 200.0f;
            BloodSplatter();

            //Lowers timeScale after death for a slow-motion effect.
            Time.timeScale = 0.2f;
        }

        // Quick fix: We're using this method to declare axe damage as well.
        if (collisionDamage.gameObject.tag == "Axe")
        {
            healthPoints -= 200.0f;
            BloodSplatter();

            //Lowers timeScale after death for a slow-motion effect.
            Time.timeScale = 0.2f;
        }

        // Same with SpikeBall as with axes.
        if (collisionDamage.gameObject.tag == "SpikeBall")
        {
            healthPoints -= 200.0f;
            BloodSplatter();

            //Lowers timeScale after death for a slow-motion effect.
            Time.timeScale = 0.2f;
        }
    }
}
