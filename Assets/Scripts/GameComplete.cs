using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour {

    public GameObject myCam;
    public GameObject winCanvas;
    bool liftOff = false;
    float speed = 0.1f;

    // Once the player enters the jet, shows the final scene
    // and victory menu

    void Update()
    {
        if(!liftOff || transform.position.y > 11)
        {
            return;
        }
        float y = transform.position.y + speed * Time.deltaTime;
        speed += 0.05f;
        transform.position = new Vector3(0, y, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.instance.gameObject.SetActive(false);
            myCam.SetActive(true);
            StartCoroutine(FlyAway());
        }
    }

    IEnumerator FlyAway()
    {
        liftOff = true;
        yield return new WaitForSeconds(3);
        Cursor.visible = true;
        winCanvas.SetActive(true);
    }
}
