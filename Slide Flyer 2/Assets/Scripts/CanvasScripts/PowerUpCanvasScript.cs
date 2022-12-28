using UnityEngine;

public class PowerUpCanvasScript : MonoBehaviour {
    
    public Transform powerUpsParent;
    public GameObject powerUpSlotPrefab;

    PowerUpManager powerUpManager;

    void Awake() {
        
    }

    void Start() {
        powerUpManager = PowerUpManager.instance;
        powerUpManager.onPowerUpChangedCallback += UpdateCanvas;
    }

    public void UpdateCanvas() {
        PowerUpSlotBehavior[] slots = powerUpsParent.GetComponentsInChildren<PowerUpSlotBehavior>();

        Debug.Log(powerUpManager.powerUps);
        Debug.Log(slots.Length);

        for (int i = 0; i < powerUpManager.powerUps.Count; i++) {
            if (slots.Length <= i) {
                GameObject newPowerUpSlot = Instantiate(powerUpSlotPrefab, powerUpsParent.position, Quaternion.identity, powerUpsParent);
                newPowerUpSlot.GetComponent<PowerUpSlotBehavior>().powerUpObject = powerUpManager.powerUps[i];
            }
            else {
                slots[i].timer += powerUpManager.powerUps[i].duration;
                Debug.Log(slots[i]);
                Debug.Log("increment");
            }
        }
    }

}