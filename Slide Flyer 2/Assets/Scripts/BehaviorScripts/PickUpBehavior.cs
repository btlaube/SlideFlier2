using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;

    public PickUpObject pickUpObject;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int currentHealth;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = pickUpObject.sprite;
        rb.velocity = transform.up * -pickUpObject.speed.value;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        //When this pick up object collides with the player
            //Activate this pickup
            //Delete this pick up
        if (hitInfo.tag == "Player") {
            Ability();
            Destroy(gameObject);
        }
    }

    void Ability() {
        //TODO change hardcoded values
        switch(pickUpObject.ability) {
            case "Ammo":
                //playerStats.playerCurrentAmmo.value += 20;
                playerStats.playerCurrentAmmo.value = Mathf.Clamp(playerStats.playerCurrentAmmo.value + 20, 0, playerStats.playerMaxAmmo.value);
                break;
            case "Health":
                //playerStats.playerCurrentHealth.value += 1;
                playerStats.playerCurrentHealth.value = Mathf.Clamp(playerStats.playerCurrentHealth.value + 1, 0, playerStats.playerMaxHealth.value);
                break;
            case "Fuel":
                //playerStats.playerCurrentFuel.value += 20;
                playerStats.playerCurrentFuel.value = Mathf.Clamp(playerStats.playerCurrentFuel.value + 20, 0, playerStats.playerMaxFuel.value);
                break;

        }
    }

}
