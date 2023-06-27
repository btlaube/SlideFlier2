using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScript : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TMP_Text playerCoinsText;

    void Update() {
        playerCoinsText.text = $"{playerStats.playerCoins.value}";
    }

}
