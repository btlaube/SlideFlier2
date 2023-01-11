using UnityEngine;

public class PowerUpCanvasScript : MonoBehaviour {
    
    public Transform powerUpsParent;
    public GameObject powerUpSlotPrefab;

    public void AddPowerUpSlot() {
        GameObject newPowerUpSlot = Instantiate(powerUpSlotPrefab, powerUpsParent.position, Quaternion.identity, powerUpsParent);
        newPowerUpSlot.GetComponent<PowerUpSlotBehavior>().powerUpObject = PowerUpManager.instance.powerUps[PowerUpManager.instance.powerUps.Count-1];
    }

    

}