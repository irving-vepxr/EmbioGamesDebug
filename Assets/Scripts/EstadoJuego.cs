using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EstadoJuego : MonoBehaviour {
    public int vidasActuales = 0;
    public int VidasIniciales = 3;

    public RawImage guiVidas;
    public Texture[] vidasImagenes;

    public int puntuacion;
    public Text guiPuntuacion;

    public GameObject camara;

    private List<GameObject> organList = new List<GameObject>();

    void Awake() {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Organ"))
        {
            organList.Add(gameObj);
            //Debug.Log("Lista de organos: "+gameObj.transform.name);
        }
        //Debug.Log("Primer organo es"+ organList[0].transform.name);
    }


    void Start () {

        camara.GetComponent<WarningVisionImageEffect>().enabled = false;
		vidasActuales = VidasIniciales;
		guiVidas.texture = vidasImagenes[vidasActuales];
		puntuacion = 0;
		ActualizarPuntuacion();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PerderUnaVida();
        }
    }

	public void PerderUnaVida(){
        Debug.Log(vidasActuales);
		if(vidasActuales>0){
			vidasActuales-=1;
		}

		if(vidasActuales< vidasImagenes.Length){
			guiVidas.texture= vidasImagenes[vidasActuales];
		}

        if (vidasActuales == 1)
        {
            camara.GetComponent<WarningVisionImageEffect>().enabled = true;
        }

		if(vidasActuales<=0){
			SendMessage("PartidaTermina",SendMessageOptions.DontRequireReceiver);
            camara.GetComponent<WarningVisionImageEffect>().enabled = true;
		}
	}

	public void IncrementarPuntuacion(int valorIncrementar){
		puntuacion += valorIncrementar;
		ActualizarPuntuacion();
	}

	public void ActualizarPuntuacion(){
		guiPuntuacion.text=puntuacion.ToString("D5");
	}


    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.7f, Screen.height * 0.3f, Screen.width*0.3f, Screen.height*0.3f), organList[0].transform.name);
    }
}
