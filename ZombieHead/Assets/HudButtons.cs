using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudButtons : MonoBehaviour {

    private LivesManager livesManager;

    void Start()
    {
        livesManager = GameObject.Find("GameManager").GetComponentInChildren<LivesManager>();
    }

    public void LoadMainMenu(int sceneIndex)
    {
        livesManager.ResetLives();
        SceneManager.LoadScene(0);
    }

    public void LoadLevel01(int sceneIndex)
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel02(int sceneIndex)
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel03(int sceneIndex)
    {
        SceneManager.LoadScene(3);
    }

    public void ReplayCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        livesManager.ResetLives();
        SceneManager.LoadScene(1);
    }

    public void ExitGame ()
    {
        #if UNITY_EDITOR
        Debug.Log("We're quitting the game now!");
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }
}
