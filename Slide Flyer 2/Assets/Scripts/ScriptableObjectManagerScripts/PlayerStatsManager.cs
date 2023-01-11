using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;

    void Start() {
        playerStats.playerScore.value = 0;
    }

    void Update() {
        if (playerStats.playerScore.value > playerStats.playerHighscore.value) {
            playerStats.playerHighscore.value = playerStats.playerScore.value;
            SaveSystem.SavePlayer(playerStats);
        }
    }

}
