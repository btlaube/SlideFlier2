using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;

    void Start() {
        playerStats.playerScore.value = 0;
        playerStats.playerCurrentAmmo.value = playerStats.playerMaxAmmo.value;
        playerStats.playerCurrentHealth.value = playerStats.playerMaxHealth.value;
        playerStats.playerCurrentFuel.value = playerStats.playerMaxFuel.value;
        playerStats.equippedProjectile = playerStats.defaultProjectile;
    }

    void Update() {
        if (playerStats.playerScore.value > playerStats.playerHighscore.value) {
            playerStats.playerHighscore.value = playerStats.playerScore.value;
            SaveSystem.SavePlayer(playerStats);
        }
    }

    void FixedUpdate() {
        //Decrement Fuel independent of framerate
        playerStats.playerCurrentFuel.value = Mathf.Clamp(playerStats.playerCurrentFuel.value - Time.deltaTime * playerStats.fuelDecrementRate, 0, playerStats.playerMaxFuel.value);
    }

    public void RespawnPlayer()
    {
        playerStats.playerCurrentAmmo.value = playerStats.playerMaxAmmo.value;
        playerStats.playerCurrentHealth.value = playerStats.playerMaxHealth.value;
        playerStats.playerCurrentFuel.value = playerStats.playerMaxFuel.value;
    }

}
