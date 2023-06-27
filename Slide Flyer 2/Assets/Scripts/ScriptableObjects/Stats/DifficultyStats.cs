using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyStats", menuName = "ScriptableObject/Stat/DifficultyStats")]
public class DifficultyStats : ScriptableObject {
    public SpawnableSpeed spawnableSpeed;
    public float cargoSpawnRate;

    //public float missileSpawnRate;
    //public float bombSpawnRate;
}
