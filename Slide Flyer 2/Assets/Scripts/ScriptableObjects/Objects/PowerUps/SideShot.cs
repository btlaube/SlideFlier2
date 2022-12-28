using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SideShot", menuName = "ScriptableObject/PowerUp/SideShot")]
public class SideShot : PowerUpObject {
    
    [SerializeField] private GameObject projectileOriginPrefab;
    private GameObject projectileOriginLeft;
    private GameObject projectileOriginRight;

    public override void Activate(GameObject target) {
        projectileOriginLeft = Instantiate(projectileOriginPrefab, new Vector2(target.transform.position.x - 0.5f, target.transform.position.y), Quaternion.identity, target.transform);
        projectileOriginLeft.transform.Rotate(0f, 0f, 90f);
        projectileOriginRight = Instantiate(projectileOriginPrefab, new Vector2(target.transform.position.x + 0.5f, target.transform.position.y), Quaternion.identity, target.transform);
        projectileOriginLeft.transform.Rotate(0f, 0f, -90f);
    }
    
    public override void Deactivate() {
        Destroy(projectileOriginLeft);
        Destroy(projectileOriginRight);
    }

}
