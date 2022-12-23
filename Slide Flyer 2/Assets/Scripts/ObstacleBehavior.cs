using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour {
    
    [SerializeField] private PlayerScoreInt playerScore;
    public ObstacleObject obstacleObject;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int currentHealth;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        sr.sprite = obstacleObject.sprites[0];
        rb.velocity = transform.up * -obstacleObject.speed.value;
        currentHealth = obstacleObject.health;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
        sr.sprite = obstacleObject.sprites[currentHealth];
    }

    void Die() {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        playerScore.value++;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.TakeDamage(obstacleObject.damage.value);
            Destroy(gameObject);
        }
    }

}
