using UnityEngine;
using System.Collections;

public class ControladorDejuego : MonoBehaviour {

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
