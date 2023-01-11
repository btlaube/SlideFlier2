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
        }
    }

}
