using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    float negativeOffset = -30f;
    float positiveOffset = 150f;

    private void Update() {
        if (transform.position.y < negativeOffset) {
            Destroy(gameObject);
        }

        if (transform.position.y > positiveOffset) {
            Destroy(gameObject);
        }
    }

}
