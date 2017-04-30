using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
 * Starts the Game
 * */

public class StartGame : MonoBehaviour {

	public void Begin()
    {
        GameManager.instance.BeginGame();
    }
	
}
