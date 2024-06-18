using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float moveSpeed = 10f;

    private void Update() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            int pointsEarned = other.GetComponent<Enemy>().GetPoints;
            FindObjectOfType<Player>().AddScore(pointsEarned);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
