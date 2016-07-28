using UnityEngine;
using System.Collections;

public class Destruir : MonoBehaviour {
	public float tiempoVida = 2f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, tiempoVida);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
