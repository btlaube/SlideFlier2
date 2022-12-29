using UnityEngine;

public class PowerUpCanvasScript : MonoBehaviour {
    
    public Transform powerUpsParent;
    public GameObject powerUpSlotPrefab;

    PowerUpManager powerUpManager;

    void Awake() {
        
    }

    void Start() {
        powerUpManager = PowerUpManager.instance;
        powerUpManager.onAddedPowerUpCallback += UpdateCanvas;
    }

    public void UpdateCanvas() {
        PowerUpSlotBehavior[] slots = powerUpsParent.GetComponentsInChildren<PowerUpSlotBehavior>();

        for (int i = 0; i < powerUpManager.powerUps.Count; i++) {

            if (i+1 > slots.Length) {
                GameObject newPowerUpSlot = Instantiate(powerUpSlotPrefab, powerUpsParent.position, Quaternion.identity, powerUpsParent);
                newPowerUpSlot.GetComponent<PowerUpSlotBehavior>().powerUpObject = powerUpManager.powerUps[i];
            }

            
            /*
            if (slots.Length <= i) {
                
            }
            else {
                //slots[i].totalTime += powerUpManager.powerUps[i].duration;
                slots[i].timer += powerUpManager.powerUps[i].duration;
            }
            */
        }
    }

    

}