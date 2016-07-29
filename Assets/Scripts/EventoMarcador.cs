using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventoMarcador : MonoBehaviour {
	public Text notificacion;
	public bool detener=true;

	void Start () {
        detener = true;
	}
	
	void Update () {
		//Hack para corregir el timeScale en Android
		if(detener==true && Time.frameCount >= 2){
			Time.timeScale = 0f;
		}
		if(Input.GetKeyDown(KeyCode.Q)){
			MarcadorPerdido();
		}
		else if (Input.GetKeyDown(KeyCode.W)){
				MarcadorEncontrado();
			}
	}

	public void MarcadorEncontrado(){
        detener = false;
        if (notificacion!=null){
			notificacion.enabled = false;
		}
				//	Debug.Log("Marcador Encontrado");
		//resume game
		//resume game
		Time.timeScale = 1f;
		
	}

	public void MarcadorPerdido(){
        detener = true;
        if (notificacion!=null){
			notificacion.enabled = true;
		}
		Time.timeScale = 0f;
		
		//pause game
		//			Debug.Log("Marcador Perdido");
	}
}
