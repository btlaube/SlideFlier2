using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    
    public static PowerUpManager instance;
    [SerializeField] private GameEvent onPowerUpAdded;

    void Awake() {
        instance = this;
    }

    public List<PowerUpObject> powerUps = new List<PowerUpObject>();

    public void Add(PowerUpObject powerUp) {
        if (powerUps.Contains(powerUp)) {
            powerUp.count++;
            powerUp.timer += powerUp.duration;
        }
        else {
            powerUps.Add(powerUp);
            powerUp.count = 1;
            onPowerUpAdded.TriggerEvent();
        }
    }

    public void Remove(PowerUpObject powerUp) {
        powerUp.count = 0;
        powerUps.Remove(powerUp);
    }

}
