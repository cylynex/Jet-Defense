using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    private void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

}
