using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;

    [SerializeField] private PlayerStats playerStats;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = powerUpObject.sprite;
        rb.velocity = transform.up * -powerUpObject.speed.value;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        //When this pick up object collides with the player
            //Activate this pickup
            //Delete this pick up
        if (hitInfo.tag == "Player") {
            //Activate this pickup
            Ability();
            Destroy(gameObject);
        }
    }

    void Ability() {
        //Mystery Item 
        //Cloud with question marks
            //Could be: ammo (any type, power up, spare parts, etc…)
        //Clone plane: Adds a double with all current upgrades
        //Rapid Fire: Increase fire rate
            //Add fire rate to PlayerStats
        //Big Bullets: Increased bullet size
            //Add equipped ProjectileObject to PlayerStats
            //Change equipped ProjectileObject
        //Side guns
            //Add two more ProjectileOrigin to Player
        //Explosive rounds
            //Change equipped ProjectileObject
        //Infinite Ammo
        //Pick up magnet

    }

}
