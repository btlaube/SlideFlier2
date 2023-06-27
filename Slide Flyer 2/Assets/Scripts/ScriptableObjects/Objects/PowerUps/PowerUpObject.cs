using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpObject : ScriptableObject {
    public Sprite sprite;
    public SpawnableSpeed speed;
    public float duration;

    public int count;
    public float timer;

    public abstract void Activate(GameObject target);
    public abstract void Deactivate();

}
