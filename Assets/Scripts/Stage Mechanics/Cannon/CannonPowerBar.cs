using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Implements a power bar that is used when the player is attached to a cannon
 * */

public class CannonPowerBar : MonoBehaviour {

    Slider powerBar;
    public int meterSpeed = 1;
    
	void Start () {
        powerBar = GetComponent<Slider>();
	}
	
	void Update () {

        //Adjust the slider 
        if (powerBar.value >= powerBar.maxValue||powerBar.value<=powerBar.minValue)
        {
            meterSpeed = meterSpeed * -1;
        }
        powerBar.value += (meterSpeed*0.01f);
	}
}
