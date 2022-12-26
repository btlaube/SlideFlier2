using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    
    [SerializeField] private CargoObject[] cargos;
    [SerializeField] private PowerUpObject[] powerUps;

    [SerializeField] private GameObject cargoPrefab;
    [SerializeField] private GameObject powerUpPrefab;

    [SerializeField] private float spawnRate = 2f;
    private float spawnTimer = 0f;

    //Spawn rate variables
    [SerializeField] private float missleRate;
    [SerializeField] private float pickUpRate;
    [SerializeField] private int firstPickUpIndex;

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
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate) {
            Spawn();
            spawnTimer = Time.deltaTime;
        }
    }

    private void Spawn() {
        foreach (Transform spawner in transform) {
            bool spawnCargo = Random.value < 0.8;

            if (spawnCargo) {
                GameObject newCargo = Instantiate(cargoPrefab, spawner.position, Quaternion.identity, spawner);
                newCargo.GetComponent<CargoBehavior>().cargoObject = cargos[Random.Range(0, cargos.Length)];
            }
            else {
                GameObject newPowerUp = Instantiate(powerUpPrefab, spawner.position, Quaternion.identity, spawner);
                newPowerUp.GetComponent<PowerUpBehavior>().powerUpObject = powerUps[Random.Range(0, powerUps.Length)];
            }
        }
    }
}
