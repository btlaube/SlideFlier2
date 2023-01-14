using UnityEngine;

public class DifficultyCurve : MonoBehaviour {

    [SerializeField] private DifficultyStats difficultyStats;

    void Start() {
        difficultyStats.spawnableSpeed.value = 1f;
        difficultyStats.cargoSpawnRate = 3f;
    }

    void FixedUpdate() {
        difficultyStats.spawnableSpeed.value = Mathf.Clamp(difficultyStats.spawnableSpeed.value + (Time.deltaTime / 60f), 1, 4);
        difficultyStats.cargoSpawnRate = Mathf.Clamp(difficultyStats.cargoSpawnRate - (Time.deltaTime / 60f), 1, 3);
    }

}
