using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EstadoJuego : MonoBehaviour {

	public static EstadoJuego instance;
    void Awake()
    {
        instance = this;

    }

    public int vidasActuales = 0;
    public int VidasIniciales = 3;

    public RawImage guiVidas;
    public Texture[] vidasImagenes;

    public int puntuacion;
    public Text guiPuntuacion;

    public GameObject camara;

    private List<GameObject> organList = new List<GameObject>();
    public Text guiOrganName;
    private int selectOrgan;
    public int puntuationCorrect;

    public GameObject answerCorrectPrefab;
    private bool finishGame = false;

    void Start () {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Organ"))
        {
            organList.Add(gameObj);
        }
        camara.GetComponent<WarningVisionImageEffect>().enabled = false;
		vidasActuales = VidasIniciales;
		guiVidas.texture = vidasImagenes[vidasActuales];
		puntuacion = 0;//Leer de archivo
		ActualizarPuntuacion();
        randomOrganSelect();
        finishGame = false;
	}

    void Update()
    {
        if (finishGame == true)
        {
            StartCoroutine(finish());
        }
       /* else { 
            if (Input.GetKeyDown(KeyCode.A))
            {
                PerderUnaVida();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                IncrementarPuntuacion(10);
            }
        }*/
           
    }

	public void PerderUnaVida(){
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

		if(vidasActuales==0){
			SendMessage("PartidaTermina",SendMessageOptions.DontRequireReceiver);
            finishGame = true;
        }
	}

	public void IncrementarPuntuacion(int valorIncrementar){
		puntuacion += valorIncrementar;
        organList.Remove(organList[selectOrgan]);
        randomOrganSelect();
		ActualizarPuntuacion();

	}

    public void randomOrganSelect()
    {
        if (organList.Count > 0)
        {
            selectOrgan = Random.Range(0, organList.Count);
            //  Debug.Log("list " + organList.Count + organList[selectOrgan].name);
            guiOrganName.text = organList[selectOrgan].name;
        }
        else
        {
            CountDown restTime = GetComponent<CountDown>();
            puntuacion += (int)restTime.timeLeft * 2 + vidasActuales*50;
            finishGame = true;
        }
    }

    public void compareOrgan(GameObject rayOrganCast)
    {
      
        if (rayOrganCast.transform.name == organList[selectOrgan].name)
        {
            Destroy(Instantiate(answerCorrectPrefab, rayOrganCast.transform.localPosition, Quaternion.identity), 2f);
            Destroy(rayOrganCast, 0.5f);
            organList.Remove(organList[selectOrgan]);
            IncrementarPuntuacion(puntuationCorrect);
        }
        else
        {
            PerderUnaVida();
        }
    }

	public void ActualizarPuntuacion(){
		guiPuntuacion.text=puntuacion.ToString("D5");
	}


    IEnumerator finish()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
