using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    private bool dead;
    
    public void TakeDamage(int damage) {
        playerStats.playerCurrentHealth.value = Mathf.Clamp(playerStats.playerCurrentHealth.value - damage, 0, playerStats.playerMaxHealth.value);

        if(playerStats.playerCurrentHealth.value > 0) {
            //audioManager.Play("PlayerHit");
        }
        else {
            if(!dead) {
                dead = true;
                Deactivate();
            }            
        }
    }

    private void Deactivate() {
        Destroy(gameObject);
    }

}
