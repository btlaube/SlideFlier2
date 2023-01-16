using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InfiniteAmmo", menuName = "ScriptableObject/PowerUp/InfiniteAmmo")]
public class InfiniteAmmo : PowerUpObject {
    
    [SerializeField] private PlayerStats playerStats;
    private int previousCost;

    public override void Activate(GameObject target) {
        previousCost = playerStats.projectileCost;
        playerStats.playerCurrentAmmo.value = playerStats.playerMaxAmmo.value;
        playerStats.projectileCost = 0;
    }

    public override void Deactivate() {
        playerStats.projectileCost = previousCost;
    }

}
