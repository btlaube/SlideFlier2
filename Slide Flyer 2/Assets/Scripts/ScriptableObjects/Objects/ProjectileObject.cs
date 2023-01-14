using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "ScriptableObject/Projectile")]
public class ProjectileObject : ScriptableObject {
    public SpawnableSpeed speed;
    public ProjectileDamage damage;
    public Sprite sprite;
    public int health;
}
