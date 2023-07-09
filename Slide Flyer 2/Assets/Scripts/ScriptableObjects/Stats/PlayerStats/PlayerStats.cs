using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "ScriptableObject/Stat/PlayerStats")]
public class PlayerStats : ScriptableObject {
    public PlayerHealthInt playerCurrentHealth;
    public PlayerHealthInt playerMaxHealth;
    public PlayerScoreInt playerScore;
    public PlayerScoreInt playerHighscore;
    public PlayerAmmoInt playerCurrentAmmo;
    public PlayerAmmoInt playerMaxAmmo;
    public PlayerCoinsInt playerCoins;
    public PlayerFuelFloat playerCurrentFuel;
    public PlayerFuelFloat playerMaxFuel;
    public float fuelDecrementRate;

    public float fireRate;
    public ProjectileObject equippedProjectile;
    public ProjectileObject defaultProjectile;
    public int projectileCost;

    public IntList unlockedPlanes;
    public int equippedPlane;

    public int adsWatched;
}
