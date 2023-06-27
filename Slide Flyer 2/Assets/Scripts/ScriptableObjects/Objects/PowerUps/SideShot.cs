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
        projectileOriginLeft.transform.eulerAngles += new Vector3 (0, 0, 90);
        projectileOriginRight = Instantiate(projectileOriginPrefab, new Vector2(target.transform.position.x + 0.5f, target.transform.position.y), Quaternion.identity, target.transform);
        projectileOriginRight.transform.eulerAngles += new Vector3 (0, 0, -90);
    }
    
    public override void Deactivate() {
        Destroy(projectileOriginLeft);
        Destroy(projectileOriginRight);
    }

}
