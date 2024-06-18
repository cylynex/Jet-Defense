using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    float horizontalInput;
    [SerializeField] Transform[] firePoints;
    [SerializeField] float moveSpeed = 5f;

    Vector3 spawnPoint;

    [Header("Firing")]
    [SerializeField] GameObject projectile;
    [SerializeField] float fireTime = 0.4f;
    float fireTimer = 0;
    bool canFire = true;

    // Upgrades
    bool multiShot = false;

    [Header("UI")]
    [SerializeField] TMP_Text livesDisplay;
    [SerializeField] TMP_Text pointsDisplay;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Slider heatBar;
    [SerializeField] TMP_Text heatDisplay;

    // Gamekeeping
    int points = 0;
    int lives = 3;

    // Sound
    AudioSource sound;
    [SerializeField] AudioClip blaster;

    // Heat
    int heat;
    float heatTime = 0.5f;
    float heatTimer = 0;

    private void Start() {
        livesDisplay.text = lives.ToString();
        spawnPoint = transform.position;
        Time.timeScale = 1.0f;
        sound = GetComponent<AudioSource>();
        heatBar.value = 0;
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);

        FireControl();

        ManageHeat();

    }

    void FireControl() {
        if ((fireTimer <= 0) && (canFire)) {
            if (Input.GetAxis("Fire1") > 0) {
                if (multiShot) {
                    FireMultiShot();
                }
                else {
                    Fire();
                }
                fireTimer = fireTime;
            }
        }
        else {
            fireTimer -= Time.deltaTime;
        }

        if (!canFire) {
            if (heat < 75) {
                canFire = true;
            }
        }
    }

    void ManageHeat() {
        if (heat > 0) {
            heatTimer -= Time.deltaTime;
            if (heatTimer <= 0) {
                heat--;
                heatTimer = heatTime;
            }
            heatDisplay.text = heat.ToString();
            heatBar.value = heat;
        }
    }

    void Fire() {
        Instantiate(projectile, firePoints[0].position, projectile.transform.rotation);
        sound.PlayOneShot(blaster);
        UpdateHeat(1);        
    }

    void FireMultiShot() {
        Instantiate(projectile, firePoints[1].position, projectile.transform.rotation);
        Instantiate(projectile, firePoints[2].position, projectile.transform.rotation);
        sound.PlayOneShot(blaster);
        UpdateHeat(2);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {

            if (lives > 0) {
                transform.position = spawnPoint;
                lives--;
                livesDisplay.text = lives.ToString();
            }
            else if (lives <= 0) {
                gameOverScreen.SetActive(true);
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

    void UpdateHeat(int amount) {
        heat += amount;
        heatDisplay.text = heat.ToString();
        if (heat > 75) {
            DisableFiring();
        }
    }

    void DisableFiring() {
        canFire = false;
    }

}
