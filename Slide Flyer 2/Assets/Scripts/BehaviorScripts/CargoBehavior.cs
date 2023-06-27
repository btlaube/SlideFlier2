using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBehavior : MonoBehaviour {
    
    public CargoObject cargoObject;

    [SerializeField] private GameObject pickUpPrefab;
    
    [SerializeField] private PlayerStats playerStats;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    private ObjectAudioSource audioSource;

    private int currentHealth;
    private int previousSpriteIndex;
    private int spriteIndex;
    [SerializeField] private float lowPitch;
    [SerializeField] private float highPitch;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<ObjectAudioSource>();
    }

    void Start() {
        sr.sprite = cargoObject.sprites[0];
        rb.velocity = transform.up * -cargoObject.speed.value;
        currentHealth = cargoObject.health;
    }

    void Update() {
        rb.velocity = transform.up * -cargoObject.speed.value;
    }

    public void TakeDamage(int damage) {

        spriteIndex = (int)((cargoObject.health-currentHealth)/cargoObject.sprites.Length);

        if (previousSpriteIndex != spriteIndex) {
            audioSource.RandomizePitch("Damage", lowPitch, highPitch);
            audioSource.Play("Damage");
        }
        else {
            audioSource.RandomizePitch("Hit", lowPitch, highPitch);
            audioSource.Play("Hit");
        }
        previousSpriteIndex = spriteIndex;

        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
        else {
            sr.sprite = cargoObject.sprites[spriteIndex];
        }
    }

    void Die() {
        audioSource.RandomizePitch("Break", lowPitch, highPitch);
        audioSource.Play("Break");

        if (cargoObject.drop != null) {
            GameObject newPickUp = Instantiate(pickUpPrefab, transform.position, Quaternion.identity, transform.parent);
            newPickUp.GetComponent<PickUpBehavior>().pickUpObject = cargoObject.drop;
        }
        playerStats.playerScore.value++;

        Instantiate(cargoObject.breakEffect, transform.position, Quaternion.identity);

        sr.enabled = false;
        bc.enabled = false;
        Invoke("DestroySelf", 1f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.tag == "Player") {
            Die();
            PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(cargoObject.damage.value);
        }
    }

    void DestroySelf() {
        Destroy(gameObject);
    }

}