using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            playerStats.equippedPlaneIndex.value = data.equippedPlaneIndex;
            if (data.unlockedPlanes != null)
            {
                playerStats.unlockedPlanes.values = data.unlockedPlanes;
            }
            else
            {
                int size = 24;
                playerStats.unlockedPlanes.values = new int[size];
                for (int i = 0; i < size; i++)
                {
                    playerStats.unlockedPlanes.values[i] = 0;
                }
            }
            playerStats.unlockedPlanes.values[0] = 1;
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
