using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    
    [SerializeField] private CargoObject[] cargos;
    [SerializeField] private PowerUpObject[] powerUps;

    [SerializeField] private GameObject cargoPrefab;
    [SerializeField] private GameObject powerUpPrefab;

    [SerializeField] private float spawnRate;
    [SerializeField] private DifficultyStats difficultyStats;
    private float spawnTimer = 0f;

    //Spawn rate variables
    //[SerializeField] private float missleRate;
    //[SerializeField] private float pickUpRate;
    //[SerializeField] private int firstPickUpIndex;
    [SerializeField] private float minSpawnCount;
    [SerializeField] private float maxSpawnCount;

    [SerializeField] List<Transform> spawnerList;

    void Start() {
        spawnerList = new List<Transform>();
        foreach (Transform spawner in transform) {
            spawnerList.Add(spawner);
        }

        Spawn();
        spawnTimer = Time.deltaTime;
    }

    void Update() {
        spawnRate = difficultyStats.cargoSpawnRate;
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate) {
            Spawn();
            spawnTimer = Time.deltaTime;
        }
    }

    private void Spawn() {

        List<GameObject> spawnList = new List<GameObject>();

        while (spawnList.Count < Random.Range(minSpawnCount, maxSpawnCount)) {
            if (!spawnList.Contains(powerUpPrefab)) {
                bool addPowerUp = Random.value > 0.7;

                if (addPowerUp) {
                    spawnList.Add(powerUpPrefab);
                }
                else {
                    spawnList.Add(cargoPrefab);
                }
            }
            else {
                spawnList.Add(cargoPrefab);
            }
        }

        List<Transform> spawnerListCopy = new List<Transform>(spawnerList);
        List<Transform> randomizedSpawnerList = new List<Transform>();
        int n = spawnerListCopy.Count;
        for (int i = 0; i < n; i++) {
            int rand = Random.Range(0, spawnerListCopy.Count);
            randomizedSpawnerList.Add(spawnerListCopy[rand]);
            spawnerListCopy.RemoveAt(rand);
        }

        for (int i = 0; i < spawnList.Count; i++) {
            if (spawnList[i] == cargoPrefab) {
                GameObject newCargo = Instantiate(cargoPrefab, randomizedSpawnerList[i].position, Quaternion.identity, randomizedSpawnerList[i]);
                newCargo.GetComponent<CargoBehavior>().cargoObject = cargos[Random.Range(0, cargos.Length)];
            }
            else if (spawnList[i] == powerUpPrefab) {
                GameObject newPowerUp = Instantiate(powerUpPrefab, randomizedSpawnerList[i].position, Quaternion.identity, randomizedSpawnerList[i]);
                newPowerUp.GetComponent<PowerUpBehavior>().powerUpObject = powerUps[Random.Range(0, powerUps.Length)];
            }
        }
    }
}
