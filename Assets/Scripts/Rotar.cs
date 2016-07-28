using UnityEngine;
using System.Collections;

public class Rotar : MonoBehaviour {

	public Transform objetoCentroDeRotación;
	public float rotacionPorSegundo = 75.0f;

	public float radioActual= 2f;
	public float incrementoRadioPorSegundo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		radioActual +=incrementoRadioPorSegundo *Time.deltaTime;
		//Time.timeScale = 0.5;
		transform.position = new Vector3(objetoCentroDeRotación.position.x,transform.position.y,objetoCentroDeRotación.position.z);
		transform.Translate(-radioActual,0,0);
		transform.RotateAround(objetoCentroDeRotación.position, Vector3.up, rotacionPorSegundo* Time.deltaTime);
			
	}
}
