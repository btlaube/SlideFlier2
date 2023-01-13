using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private PlayerStats playerStats;

    private float fireTimer = 0f;
    private bool fire = false;

    void Start() {
        fireTimer = Time.deltaTime;
    }

    void Update() {
        if (fire) {
            fireTimer += Time.deltaTime;
            if (playerStats.playerCurrentAmmo.value > 0 && fireTimer >= playerStats.fireRate) {
                Shoot();
                fireTimer = Time.deltaTime;
            }
            else if (playerStats.playerCurrentAmmo.value <= 0) {
                //Change this to an Event
                //FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

    public void CheckFire(bool fireBool) {
        fire = fireBool;
    }

    void Shoot() {
        foreach(Transform projectileOrigin in transform) {
            GameObject newProjectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation, projectileOrigin);
            newProjectile.GetComponent<ProjectileBehavior>().projectileObject = playerStats.equippedProjectile;
        }
        playerStats.playerCurrentAmmo.value--;
    }
}
