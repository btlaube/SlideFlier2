using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvasScript : MonoBehaviour {
    
    [SerializeField] private PlayerHealthInt playerHealth;
    [SerializeField] private PlayerAmmoInt playerAmmo;
    [SerializeField] private PlayerScoreInt playerScore;

    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private TMP_Text playerAmmoText;
    [SerializeField] private TMP_Text playerScoreText;

    void Start() {
        playerHealthText.text = $"HP: {playerHealth.value}";
        playerAmmoText.text = $"Ammo: {playerAmmo.value}";
        playerScoreText.text = $"Score: {playerScore.value}";
    }

    void Update() {
        playerHealthText.text = $"HP: {playerHealth.value}";
        playerAmmoText.text = $"Ammo: {playerAmmo.value}";
        playerScoreText.text = $"Score: {playerScore.value}";
    }

}
