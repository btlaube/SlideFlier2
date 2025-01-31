using UnityEngine;
using UnityEngine.UI;

public class ShopItemScript : MonoBehaviour {

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private int cost;

    [SerializeField] private GameObject lockedSprite;
    [SerializeField] private GameObject equippedBorder;
    [SerializeField] private Image planeIcon;
    [SerializeField] private Sprite planeSprite;
    [SerializeField] private GameObject buyButton;

    private ShopButtonManager shopButtonManager;

    private bool purchased = false;

    void Awake() {
        shopButtonManager = GetComponentInParent<ShopButtonManager>();
    }

    void Start() {
        planeIcon.sprite = planeSprite;
    }
    
    public void Purchase() {
        if (playerStats.playerCoins.value >= cost) {
            playerStats.playerCoins.value -= cost;

            Destroy(buyButton);
            Destroy(lockedSprite);
            purchased = true;
            shopButtonManager.AddPlane(gameObject);
        }   
    }

    public void SetPurchased() {
        Destroy(buyButton);
        Destroy(lockedSprite);
        purchased = true;
    }

    public void Equip() {
        if (purchased) {
            equippedBorder.SetActive(true);
            shopButtonManager.EquipPlane(gameObject);
        }
    }
    
    public void Unequip() {
        equippedBorder.SetActive(false);
    }

}
