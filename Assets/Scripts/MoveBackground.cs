using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    Vector3 startingPosition;
    [SerializeField] float repeatWidth;
    [SerializeField] float speed = 10f;

    private void Start() {
        startingPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
        repeatWidth = 80;
    }

    private void Update() {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        if (transform.position.z < startingPosition.z - repeatWidth) {
            transform.position = startingPosition;
        }
    }

}
