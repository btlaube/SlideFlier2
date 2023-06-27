using UnityEngine;

[ExecuteInEditMode]
public class SpawnerScaler : MonoBehaviour {

    void Start() {

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3 ((worldScreenWidth / 6f) - 0.05f, (worldScreenWidth / 6f) - 0.05f, (worldScreenWidth / 6f) - 0.05f);
    }

}
