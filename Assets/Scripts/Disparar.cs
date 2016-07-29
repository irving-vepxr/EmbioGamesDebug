using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {
	public Transform disparoPrefab;
	public float tiempoDisparos = 0.5f;
	private float siguienteDisparo = 0f;

	void Update () {
		if((Input.GetButtonDown("Fire1")|| Input.touchCount>0) && Time.time>siguienteDisparo){
			siguienteDisparo = Time.time+tiempoDisparos;
			Instantiate(disparoPrefab,transform.position,transform.rotation);

		}
	}
}
