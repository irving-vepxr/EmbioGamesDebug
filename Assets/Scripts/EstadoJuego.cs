using UnityEngine;
using System.Collections;

public class EstadoJuego : MonoBehaviour {
	public int vidasActuales = 0;
	public int VidasIniciales = 3;

	public GUITexture guiVidas;
	public Texture[] vidasImagenes;

	public GUIText guiPuntuacion;
	public int puntuacion = 0;

    void Start () {
		vidasActuales = VidasIniciales;
		guiVidas.texture = vidasImagenes[vidasActuales];
		puntuacion = 0;
		ActualizarPuntuacion();
	}

	public void PerderUnaVida(){
		if(vidasActuales>0){
			vidasActuales-=1;
		}

		if(vidasActuales< vidasImagenes.Length){
			guiVidas.texture = vidasImagenes[vidasActuales];
		}

		if(vidasActuales<=0){
			SendMessage("PartidaTermina",SendMessageOptions.DontRequireReceiver);
		}
	}

	public void IncrementarPuntuacion(int valorIncrementar){
		puntuacion += valorIncrementar;
		ActualizarPuntuacion();
	}

	public void ActualizarPuntuacion(){
		guiPuntuacion.text=puntuacion.ToString("D5");
	}
}
