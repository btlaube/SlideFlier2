using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScaleToFitScreen : MonoBehaviour
{
    [SerializeField] private RawImage image;

    private void Start()
    {

        float worldScreenHeight = Camera.main.orthographicSize * 2;

        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth,
            worldScreenWidth, 1);
    }
}
