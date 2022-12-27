using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clone", menuName = "ScriptableObject/PowerUp/Clone")]
public class Clone : PowerUpObject {

    [SerializeField] private GameObject clonePrefab;
    private GameObject clone;

    public override void Activate(GameObject target) {
        //Create copy of player gameObject
        clone = Instantiate(clonePrefab, new Vector2(target.transform.position.x + 1, target.transform.position.y), Quaternion.identity, target.transform);
    }

    public override void Deactivate() {
        //Remove clone
        Debug.Log($"Deleted {clone}");
        Destroy(clone);
    }

}
