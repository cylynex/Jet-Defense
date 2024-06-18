using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    Vector3 startingPosition;
    float speed = 25;
    float backgroundCutoff;

    private void Start() {
        startingPosition = transform.position;
        backgroundCutoff = GetComponent<BoxCollider>().size.y / 2;
    }

    private void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < startingPosition.y - backgroundCutoff) {
            transform.position = startingPosition;
        }
    }

}
