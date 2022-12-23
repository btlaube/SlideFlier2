using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    
    [SerializeField] private SpawnableObject[] thingsToSpawn;
    [SerializeField] private GameObject cargoPrefab;

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

        //build list of things to spawn
        List<int> spawnList = new List<int> {-1, -1, -1, -1, -1, -1};
        List<int> randomizedSpawnList = new List<int>();

        spawnList = BuildCargoList(spawnList);

        //Randomize spawn list
        int n = spawnerList.Count;
        for (int i = 0; i < n; i++) {
            int rand = Random.Range(0, spawnList.Count);
            randomizedSpawnList.Add(spawnList[rand]);
            spawnList.RemoveAt(rand);
        }

        //Spawn items in randomized spawn list and assign appropriate scriptable object
        for (int i = 0; i < spawnerList.Count; i++) {
            int rand = Random.Range(0, thingsToSpawn.Length);
            if (randomizedSpawnList[i] >= 0) {
                GameObject newSpawnable = Instantiate(cargoPrefab, spawnerList[i].position, Quaternion.identity, spawnerList[i]);
                newSpawnable.GetComponent<CargoBehavior>().cargoObject = thingsToSpawn[randomizedSpawnList[i]] as CargoObject;    
            }
        }
    }

    private List<int> BuildCargoList(List<int> spawnList) {
        //Populate spawn list with random number (3, 4, 5, or 6) of cargo
        for (int i = 0; i < Random.Range(3, 6); i++) {
            spawnList[i] = Random.Range(0, thingsToSpawn.Length);
        }

        return spawnList;
    }

}
