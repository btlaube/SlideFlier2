using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public abstract class PowerUpObject : ScriptableObject, ISerializationCallbackReceiver {
    public Sprite sprite;
    public SpawnableSpeed speed;
    public float duration;

    public int initialCount;
    public int runtimeCount;

    public abstract void Activate(GameObject target);
    public abstract void Deactivate();

    public void OnAfterDeserialize() {
        runtimeCount = initialCount;
    }

    public void OnBeforeSerialize() { }
}
