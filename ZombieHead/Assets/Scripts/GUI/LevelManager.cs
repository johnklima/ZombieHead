﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    /* IMPORTANT NOTE: 
     * Scene lighting is currently not being loaded correctly when a level is loaded or replayed via the scene manager.
     * This is due to dynamic light baking being active. The problem will fix itself once lights have been baked manually.
     * 
     *      - Johnny B. Nilsen
    */

    // Update is called once per frame
    void Update () {

        // Pressing "Backspace" will reload current level if current level is not the Main Menu.
        if (Input.GetKey(KeyCode.Backspace) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            RestartCurrentLevel();
        }

        // Pressing "0" will load the Main Menu.
        if (Input.GetKey(KeyCode.Alpha0))
        {
            LoadMainMenu();
        }

        // Pressing "1" will load Level01.
        if (Input.GetKey(KeyCode.Alpha1))
        {
            LoadLevel01();
        }

        // Pressing "2" will load Level02.
        if (Input.GetKey(KeyCode.Alpha2))
        {
            LoadLevel02();
        }

        // Pressing "3" will load Level03.
        if (Input.GetKey(KeyCode.Alpha3))
        {
            LoadLevel03();
        }
    }

    public void RestartCurrentLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Replaying " + SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Main Menu loaded.");
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Level01 loaded.");
    }

    public void LoadLevel02()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Level02 loaded.");
    }

    public void LoadLevel03()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Level03 loaded.");
    }
}
