using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {
    
    public ProjectileObject projectileObject;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int currentHealth;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = projectileObject.sprite;
        rb.velocity = transform.parent.up * projectileObject.speed.value;
        currentHealth = projectileObject.health;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        CargoBehavior cargo = hitInfo.GetComponent<CargoBehavior>();
        if (cargo != null) {
            cargo.TakeDamage(projectileObject.damage.value);
            TakeDamage(cargo.cargoObject.damage.value);
            //
        }
    }

}
