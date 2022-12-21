using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Obstacle", menuName = "ScriptableObject/Obstacle")]
public class ObstacleObject : ScriptableObject {
    public SpawnableSpeed speed;
    public Sprite sprite;
}
