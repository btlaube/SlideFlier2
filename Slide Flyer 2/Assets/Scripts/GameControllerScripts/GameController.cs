using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameEvent onLose;

    public static GameController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null) {
            playerStats.playerCoins.value = data.coinsAmount;
            playerStats.playerHighscore.value = data.highscore;
            if (data.unlockedPlanes == null)
            {
                playerStats.unlockedPlanes.values = Enumerable.Repeat(0, 24).ToArray();
            }
            else
            {
                playerStats.unlockedPlanes.values = data.unlockedPlanes;
            }
            playerStats.unlockedPlanes.values[0] = 1;
            // Debug.Log(data.unlockedPlanes);
        }
    }

    void onPause() {
        SaveSystem.SavePlayer(playerStats);
    }

    public void Save() {
        SaveSystem.SavePlayer(playerStats);
    }

    void Update() {
        if (playerStats.playerCurrentHealth.value <= 0) {
            onLose.TriggerEvent();
            playerStats.playerCurrentHealth.value = playerStats.playerMaxHealth.value;
        }
        if (playerStats.playerCurrentFuel.value <= 0) {
            onLose.TriggerEvent();
            playerStats.playerCurrentFuel.value = playerStats.playerMaxFuel.value;
        }
    }
}
