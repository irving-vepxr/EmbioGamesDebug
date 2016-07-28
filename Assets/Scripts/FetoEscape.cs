using UnityEngine;
using System.Collections;

public class FetoEscape : MonoBehaviour {
	public float radioAlcanceParaEscapar = 12f;
	private Rotar rotar;
	private EstadoJuego estadoJuego;
	// Use this for initialization
	void Start () {
		rotar = GetComponent<Rotar>();
		estadoJuego = ControladorDejuego.ObtenerComponente<EstadoJuego>("ControladorJuego");
	}
	
	// Update is called once per frame
	void Update () {
		if(rotar.radioActual >= radioAlcanceParaEscapar){
			FetoSeEscapo();
		}
	}

	void FetoSeEscapo(){
		Destroy(gameObject);
		//Restar una vida
		estadoJuego.PerderUnaVida();
	}
}
