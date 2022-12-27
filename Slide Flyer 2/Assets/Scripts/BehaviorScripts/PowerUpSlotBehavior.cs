using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlotBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;
    [SerializeField] private Image icon;

    void Start() {
        icon.sprite = powerUpObject.sprite;
    }


}
