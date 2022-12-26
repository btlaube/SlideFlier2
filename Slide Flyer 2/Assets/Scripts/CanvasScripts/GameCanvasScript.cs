using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvasScript : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;

    //[SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private TMP_Text playerAmmoText;
    [SerializeField] private TMP_Text playerScoreText;

    void Start() {
        //playerHealthText.text = $"HP: {playerStats.playerCurrentHealth.value}";
        playerAmmoText.text = $"{playerStats.playerCurrentAmmo.value}";
        playerScoreText.text = $"{playerStats.playerScore.value}";
    }

    void Update() {
        //playerHealthText.text = $"HP: {playerStats.playerCurrentHealth.value}";
        playerAmmoText.text = $"{playerStats.playerCurrentAmmo.value}";
        playerScoreText.text = $"{playerStats.playerScore.value}";
    }

}
