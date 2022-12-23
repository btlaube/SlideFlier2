using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour {

    [SerializeField] private PlayerHealthInt playerHealth;
    [SerializeField] private PlayerAmmoInt playerAmmo;

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
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            //Activate this pickup
            Ability();
            Destroy(gameObject);
        }
    }

    void Ability() {
        //TODO change hardcoded values
        switch(pickUpObject.ability) {
            case "Ammo":
                playerAmmo.value += 20;
                break;
            case "Health":
                playerHealth.value += 1;
                break;
        }
    }

}
