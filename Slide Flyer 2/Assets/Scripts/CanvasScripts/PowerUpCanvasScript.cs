using UnityEngine;

public class PowerUpCanvasScript : MonoBehaviour {
    
    public Transform powerUpsParent;
    public GameObject powerUpSlotPrefab;

    PowerUpManager powerUpManager;

    void Awake() {
        
    }

    void Start() {
        powerUpManager = PowerUpManager.instance;
        powerUpManager.onAddedPowerUpCallback += AddPowerUpSlot;
    }

    public void AddPowerUpSlot() {
        GameObject newPowerUpSlot = Instantiate(powerUpSlotPrefab, powerUpsParent.position, Quaternion.identity, powerUpsParent);
        newPowerUpSlot.GetComponent<PowerUpSlotBehavior>().powerUpObject = powerUpManager.powerUps[powerUpManager.powerUps.Count-1];
    }

    

}