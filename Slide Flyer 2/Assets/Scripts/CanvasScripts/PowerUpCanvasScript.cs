using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCanvasScript : MonoBehaviour {
    
    [SerializeField] private Transform powerUpsParent;
    [SerializeField] private GameObject powerUpSlot;

    void Awake() {
        powerUpsParent = transform.GetChild(0);
    }

    public void AddPowerUp(PowerUpObject powerUpObject) {
        GameObject newPowerUpSlot = Instantiate(powerUpSlot, powerUpsParent.position, Quaternion.identity, powerUpsParent);
        newPowerUpSlot.GetComponent<PowerUpSlotBehavior>().powerUpObject = powerUpObject;
    }

}
