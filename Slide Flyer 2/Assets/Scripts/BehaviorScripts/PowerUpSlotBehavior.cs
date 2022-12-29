using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpSlotBehavior : MonoBehaviour {
    
    public PowerUpObject powerUpObject;
    [SerializeField] private Image icon;
    private GameObject player;

    [SerializeField] private TMP_Text countText;

    public float totalTime;
    public float timer;
    [SerializeField] private Image totalTimerBar;
    [SerializeField] private Image currentTimerBar;

    void Awake() {
        player = GameObject.Find("Player");
    }

    void Start() {
        totalTime = powerUpObject.duration;
        timer = Time.deltaTime + totalTime;
        
        icon.sprite = powerUpObject.sprite;

        powerUpObject.Activate(player);

        countText.text = $"x{powerUpObject.count}";
    }

    void Update() {
        totalTime = powerUpObject.duration * powerUpObject.count;
        countText.text = $"x{powerUpObject.count}";
        timer -= Time.deltaTime;
        currentTimerBar.fillAmount = timer / totalTime;
        if (timer <= 0f) {
            powerUpObject.Deactivate();
            PowerUpManager.instance.Remove(powerUpObject);
            Destroy(gameObject);
        }
    }


}
