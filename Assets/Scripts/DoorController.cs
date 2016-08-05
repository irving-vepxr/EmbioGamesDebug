using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public void OpenDoor() {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void CloseDoor() {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
