using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {
    
    public ProjectileObject projectileObject;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = projectileObject.sprite;
        rb.velocity = transform.up * projectileObject.speed.value;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        CargoBehavior cargo = hitInfo.GetComponent<CargoBehavior>();
        if (cargo != null) {
            cargo.TakeDamage(projectileObject.damage.value);
            Destroy(gameObject);
        }
    }

}
