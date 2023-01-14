using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BigBullets", menuName = "ScriptableObject/PowerUp/BigBullets")]
public class BigBullets : PowerUpObject {
    
    private ProjectileObject previousProjectile;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private ProjectileObject bigBullets;

    public override void Activate(GameObject target) {
        previousProjectile = playerStats.equippedProjectile;
        playerStats.equippedProjectile = bigBullets;
    }

    public override void Deactivate() {
        playerStats.equippedProjectile = previousProjectile;
    }

}
