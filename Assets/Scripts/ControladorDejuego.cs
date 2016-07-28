using UnityEngine;
using System.Collections;

public class ControladorDejuego : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static T ObtenerComponente<T> (string nombreDelGameObject) where T : UnityEngine.Component{
		GameObject controlador = GameObject.Find(nombreDelGameObject);
		if(controlador!=null){
			return controlador.GetComponent<T>();
		}else{
			Debug.LogError("No se ha encontrado el GameObject con el nombre" + nombreDelGameObject);
			return null;
		}

	}
}
