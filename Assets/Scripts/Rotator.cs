using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        float x = 0.5f + 0.2f * Mathf.Sin(3 * Time.time);
        float y = 0.5f+ 0.2f * Mathf.Sin(3 * Time.time);
        float z = 0.5f + 0.2f * Mathf.Sin(3 * Time.time);

        transform.localScale = new Vector3(x, y, z);
    }
}
