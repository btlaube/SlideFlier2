using UnityEngine;

[System.Serializable]
public class PlayerData {
    
    public int coinsAmount;
    public int highscore;
    public int[] unlockedPlanes;

    public PlayerData(PlayerStats player) {
        coinsAmount = player.playerCoins.value;
        highscore = player.playerHighscore.value;
        unlockedPlanes = player.unlockedPlanes.values;
    }

}
