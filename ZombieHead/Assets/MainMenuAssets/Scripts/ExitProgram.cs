using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitProgram : MonoBehaviour {

	void doExitGame() 
	{
		Debug.Log ("We're quitting the game now!");
		Application.Quit();
	}
}