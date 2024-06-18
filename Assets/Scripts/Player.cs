using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] float horizontalInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform[] firePoints;
    [SerializeField] GameObject projectile;
    float fireTime = 0.4f;
    float fireTimer = 0;
    bool multiShot = false;
    [SerializeField] int points = 0;
    [SerializeField] TMP_Text pointsDisplay;
    [SerializeField] int lives = 3;
    [SerializeField] TMP_Text livesDisplay;
    Vector3 spawnPoint;

    private void Start() {
        livesDisplay.text = lives.ToString();
        spawnPoint = transform.position;
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);

        if (fireTimer <= 0) {
            if (Input.GetAxis("Fire1") > 0) {
                if (multiShot) {
                    FireMultiShot();
                } else {
                    Fire();
                }
                fireTimer = fireTime;
            }
        } else {
            fireTimer -= Time.deltaTime;
        }
    }

    void Fire() {
        Instantiate(projectile, firePoints[0].position, projectile.transform.rotation);
    }

    void FireMultiShot() {
        Instantiate(projectile, firePoints[1].position, projectile.transform.rotation);
        Instantiate(projectile, firePoints[2].position, projectile.transform.rotation);
    }

    private void OnTriggerEnter(Collider other) {
        print("hit: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy")) {

            if (lives > 0) {
                transform.position = spawnPoint;
                lives--;
                livesDisplay.text = lives.ToString();
            }
            else if (lives <= 0) {
                Debug.Log("GAME OVER");
                Time.timeScale = 0f;
            }
        }
    }

    public void UpgradeMultiShot() {
        multiShot = true;
    }

    public void AddScore(int amount) {
        points += amount;
        pointsDisplay.text = points.ToString();
    }

}
