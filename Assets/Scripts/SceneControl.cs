using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {
    

    public void ThirdPersonFollow() {
        GetComponent<ThirdPersonCamera>().enabled = true;
    }
}
