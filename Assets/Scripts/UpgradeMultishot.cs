using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMultishot : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            print("hit upgrade MS");
            other.gameObject.GetComponent<Player>().UpgradeMultiShot();
        }
    }

}
