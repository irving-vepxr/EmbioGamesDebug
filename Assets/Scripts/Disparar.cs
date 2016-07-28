using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {
	public Transform disparoPrefab;
	public float tiempoDisparos = 0.5f;
	private float siguienteDisparo = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetButtonDown("Fire1")|| Input.touchCount>0) && Time.time>siguienteDisparo){
			siguienteDisparo = Time.time+tiempoDisparos;
			Instantiate(disparoPrefab,transform.position,transform.rotation);

		}
	}
}
