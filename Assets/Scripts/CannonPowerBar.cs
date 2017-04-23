using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonPowerBar : MonoBehaviour {

    Slider powerBar;
    public int meterSpeed = 1;

	// Use this for initialization
	void Start () {
        GameObject temp = GameObject.Find("PowerBar");
        powerBar = temp.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (powerBar.value >= powerBar.maxValue||powerBar.value<=powerBar.minValue)
        {
            meterSpeed = meterSpeed * -1;
        }
        powerBar.value += (meterSpeed*0.01f);
	}
}
