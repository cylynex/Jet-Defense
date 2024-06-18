using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        print("hit: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
    }

}
