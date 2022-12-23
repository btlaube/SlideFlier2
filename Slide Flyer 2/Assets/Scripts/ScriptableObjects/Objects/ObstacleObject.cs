using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle", menuName = "ScriptableObject/Obstacle")]
public class ObstacleObject : SpawnableObject {
    public Sprite[] sprites;
    public ObstacleDamage damage;
    public int health;
}
