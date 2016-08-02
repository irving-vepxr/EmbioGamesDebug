using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventoMarcador : MonoBehaviour {
	public Text notificacion;
    public Text nameOrgan;
	public bool detener=true;

	void Start () {
        detener = true;
        nameOrgan.enabled = false;
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
            nameOrgan.enabled = true;
		}
		Time.timeScale = 1f;
		
	}

	public void MarcadorPerdido(){
        detener = true;
        if (notificacion!=null){
			notificacion.enabled = true;
            nameOrgan.enabled = false;
		}
		Time.timeScale = 0f;
	}
}
