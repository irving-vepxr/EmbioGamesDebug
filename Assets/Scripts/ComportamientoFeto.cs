using UnityEngine;
using System.Collections;

public class ComportamientoFeto : MonoBehaviour {
	public Transform explosionPrefab;
	private EstadoJuego estadoJuego;

	// Use this for initialization
	void Start () {
		estadoJuego = ControladorDejuego.ObtenerComponente<EstadoJuego>("ControladorJuego");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Muere(){
		Rotar rotar = transform.parent.GetComponent<Rotar>();
		FetoEscape fetoEscape = transform.parent.GetComponent<FetoEscape>();
		int puntuacion = (int)(100 * rotar.radioActual/ fetoEscape.radioAlcanceParaEscapar);
		estadoJuego.IncrementarPuntuacion(puntuacion);
		Instantiate(explosionPrefab,transform.position,transform.rotation);
		//Debug.Log("muere");
		Destroy(gameObject.transform.parent.gameObject);
	}
}
