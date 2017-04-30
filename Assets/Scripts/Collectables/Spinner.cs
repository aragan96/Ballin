using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
	
	void Update () {

        //Spin the attached object
		transform.Rotate (0,0,50*Time.deltaTime);
	}
}
