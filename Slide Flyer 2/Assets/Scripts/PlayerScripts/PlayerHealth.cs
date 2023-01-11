using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private PlayerHealthInt currentHealth;
    [SerializeField] private PlayerHealthInt maxHealth;

    private bool dead;

    void Start() {
        currentHealth.value = maxHealth.value;
    }

    public void TakeDamage(int damage) {
        currentHealth.value = Mathf.Clamp(currentHealth.value - damage, 0, maxHealth.value);

        if(currentHealth.value > 0) {
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
