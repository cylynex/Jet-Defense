using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed = 1;

    private void Update() {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    

}
