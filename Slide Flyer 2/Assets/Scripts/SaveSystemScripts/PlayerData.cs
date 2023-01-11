using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    
    public int coinsAmount;
    public int highscore;

    public PlayerData(PlayerStats player) {
        coinsAmount = player.playerCoins.value;
        highscore = player.playerHighscore.value;
    }

}
