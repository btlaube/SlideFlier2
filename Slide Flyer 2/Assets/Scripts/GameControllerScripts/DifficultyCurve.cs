using UnityEngine;

public class DifficultyCurve : MonoBehaviour {

    [SerializeField] private DifficultyStats difficultyStats;
    [SerializeField] private float difficultyIncreaseRate;

    void Start() {
        difficultyStats.spawnableSpeed.value = 1f;
        difficultyStats.cargoSpawnRate = 3f;
    }

    void FixedUpdate() {
        difficultyStats.spawnableSpeed.value = Mathf.Clamp(difficultyStats.spawnableSpeed.value + (Time.deltaTime / difficultyIncreaseRate), 1, 4);
        difficultyStats.cargoSpawnRate = Mathf.Clamp(difficultyStats.cargoSpawnRate - (Time.deltaTime / difficultyIncreaseRate), 1, 3);
    }

}
