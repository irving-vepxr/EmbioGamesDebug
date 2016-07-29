using UnityEngine;
using System.Collections;

public class Destruir : MonoBehaviour {
	public float tiempoVida = 2f;

	void Start () {
		Destroy(gameObject, tiempoVida);
	}
}
