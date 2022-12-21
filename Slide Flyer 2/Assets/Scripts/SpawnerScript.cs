using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    
    [SerializeField] private ObstacleObject[] thingsToSpawn;
    [SerializeField] private GameObject objectToSpawn;

    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnTimer = 0f;

    void Start() {
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
        int rand = Random.Range(0, thingsToSpawn.Length);
        GameObject newSpawnable = Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);
        //set either ObstacleObject or PickUpObject of newSpawnable
        //set ObstacleObject
        newSpawnable.GetComponent<ObstacleBehavior>().obstacleObject = thingsToSpawn[rand];
    }

}
