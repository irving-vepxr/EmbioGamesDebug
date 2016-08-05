using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventoMarcador : MonoBehaviour {
	public Text notificacion;
    public Text nameOrgan;
	public bool detener=true;


    public GameObject sliderMusic;
    public GameObject sliderEffects;
    public GameObject lifeImage;
    public GameObject exitButton;

	void Start () {
        detener = true;
        nameOrgan.enabled = false;
        sliderMusic.SetActive(false);
        sliderEffects.SetActive(false);
        lifeImage.SetActive(true);
        exitButton.SetActive(false);
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
            sliderMusic.SetActive(false);
            sliderEffects.SetActive(false);
            exitButton.SetActive(false);
            lifeImage.SetActive(true);
        }
		Time.timeScale = 1f;
		
	}

	public void MarcadorPerdido(){
        detener = true;
        if (notificacion!=null){
			notificacion.enabled = true;
            nameOrgan.enabled = false;
            sliderMusic.SetActive(true);
            sliderEffects.SetActive(true);
            exitButton.SetActive(true);
            lifeImage.SetActive(false);
        }
		Time.timeScale = 0f;
	}
}
