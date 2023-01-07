using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupScript : MonoBehaviour {
    
    public void OpenPauseCanvas() {
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void ClosePauseCanvas() {
        transform.GetChild(4).gameObject.SetActive(false);
    }

}
