using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private PlayerStats playerStats;
    private Transform projectileOrigin;

    private float fireTimer = 0f;

    void Awake() {
        projectileOrigin = transform.GetChild(0);
    }

    void Start() {
        //playerAmmo.currentAmount
        playerStats.playerCurrentAmmo.value = playerStats.playerMaxAmmo.value;
        fireTimer = Time.deltaTime;
    }

    void Update() {
        if (Input.touchCount > 1 ) {
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

    void Shoot() {

        foreach(Transform projectileOrigin in transform) {
            GameObject newProjectile = Instantiate(projectilePrefab, projectileOrigin.position, projectileOrigin.rotation, projectileOrigin);
            newProjectile.GetComponent<ProjectileBehavior>().projectileObject = playerStats.equippedProjectile;
        }
        playerStats.playerCurrentAmmo.value--;
        
    }

}
