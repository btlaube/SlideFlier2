using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpMagnet", menuName = "ScriptableObject/PowerUp/PickUpMagnet")]
public class PickUpMagnet : PowerUpObject {
    
    public float magnetRadius;
    public CircleCollider2D playerAttractArea;

    public override void Activate(GameObject target) {
        playerAttractArea = target.transform.GetChild(1).GetComponent<CircleCollider2D>();
        playerAttractArea.radius = magnetRadius;
    }

    public override void Deactivate() {
        playerAttractArea.radius = 0.5f;
    }

}
