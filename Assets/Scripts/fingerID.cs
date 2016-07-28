using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fingerID : MonoBehaviour {

	void Update () {
	
	}

    void OnGUI()
    {
        foreach(Touch touch in Input.touches)
        {
            string texto = "";
            texto += "ID: " + touch.fingerId + "\n";
            texto += "TapCount: " + touch.tapCount + "\n";
            texto += "phase: " + touch.phase.ToString() + "\n";
            texto += "Pos x: " + touch.position.x.ToString() + "\n";
            texto += "Pos y: " + touch.position.y.ToString() + "\n";

            int num = touch.fingerId;
            GUI.Label(new Rect(0 + 130 * num, 0, 120, 100), texto);
        }
    }
}
