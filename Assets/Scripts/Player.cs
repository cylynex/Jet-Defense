using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float horizontalInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform firePoint1;
    [SerializeField] GameObject projectile;
    float fireTime = 0.4f;
    float fireTimer = 0;

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);

        if (fireTimer <= 0) {
            if (Input.GetAxis("Fire1") > 0) {
                Instantiate(projectile, firePoint1.position, projectile.transform.rotation);
                fireTimer = fireTime;
            }
        } else {
            fireTimer -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other) {
        print("hit: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
    }

}
