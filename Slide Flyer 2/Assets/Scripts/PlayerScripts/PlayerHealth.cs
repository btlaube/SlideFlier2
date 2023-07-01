using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    private bool dead;
    private ObjectAudioSource audioSource;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D bc;
    
    void Awake() {
        audioSource = GetComponent<ObjectAudioSource>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damage) {
        playerStats.playerCurrentHealth.value = Mathf.Clamp(playerStats.playerCurrentHealth.value - damage, 0, playerStats.playerMaxHealth.value);

        if(playerStats.playerCurrentHealth.value > 0) {
            audioSource.Play("PlayerHit");
        }
        else {
            if(!dead) {
                dead = true;
                Deactivate();
            }            
        }
    }

    public void Respawn()
    {
        sr.enabled = true;
        bc.enabled = true;
    }

    private void Deactivate() {
        // Destroy(gameObject);
        sr.enabled = false;
        bc.enabled = false;
    }

}
