using UnityEngine;

public class PlayerSpriteController : MonoBehaviour {
    
    [SerializeField] private PlayerStats playerStats;
    private SpriteRenderer sr;
    [SerializeField] Sprite[] planeSprites;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
            
    public void UpdatePlayerSprite() {
        sr.sprite = planeSprites[playerStats.playerEquippedSprite];
    }

}
