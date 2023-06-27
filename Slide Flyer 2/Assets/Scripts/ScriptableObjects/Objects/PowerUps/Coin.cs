using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "ScriptableObject/PowerUp/Coin")]
public class Coin : PowerUpObject {
    
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private int value;

    public override void Activate(GameObject target) {
        playerStats.playerCoins.value += value;
        SaveSystem.SavePlayer(playerStats);
    }
    
    public override void Deactivate() {
    }

}
