using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitProgram : MonoBehaviour {

	public void Exit() 
	{
#if UNITY_EDITOR
		Debug.Log ("We're quitting the game now!");
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}