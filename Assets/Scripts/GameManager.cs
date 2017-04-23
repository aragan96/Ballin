using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //MODIFIED GameManager script from Unity's GameManager tutorial

    // instance for Singleton pattern
    public static GameManager instance = null;

    public int numStages;
    public int currentStage = 0;
    public bool[] stageUnlocked;

//    public delegate void EventHandler(GameObject unit);

 //   public static event EventHandler tutorialComplete;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        stageUnlocked = new bool[numStages + 1];

        stageUnlocked[0] = true;
        stageUnlocked[1] = true;

        for (int i = 2; i < numStages; i++)
            stageUnlocked[i] = true;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
