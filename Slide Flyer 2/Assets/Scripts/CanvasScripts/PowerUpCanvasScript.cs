using UnityEngine;

public class PowerUpCanvasScript : MonoBehaviour {
    
    public Transform powerUpsParent;
    
    PowerUpManager powerUpManager;

    void Start() {
        powerUpManager = PowerUpManager.instance;
        powerUpManager.onPowerUpChangedCallback += UpdateCanvas;
    }

    void UpdateCanvas() {
        PowerUpSlotBehavior[] slots = itemsParent.GetComponentsInChildren<PowerUpSlotBehavior>();

        
    }

}