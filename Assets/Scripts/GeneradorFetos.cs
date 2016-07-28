using UnityEngine;
using System.Collections;

public class GeneradorFetos : MonoBehaviour {
	public Transform fetoPrefab;
	public Transform objetoGira;
	public Transform fetoPadre;

	public float esperaPrimerFeto = 3f;
	public float tiempoEntreFetos = 5f;
	private float horaSiguienteFeto;

	// Use this for initialization
	void Start () {
		horaSiguienteFeto = Time.time+esperaPrimerFeto;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= horaSiguienteFeto){
			horaSiguienteFeto = Time.time+tiempoEntreFetos;
			Transform fetoTransform = Instantiate(fetoPrefab,
				objetoGira.transform.position,objetoGira.transform.rotation) as Transform ;
			fetoTransform.parent = fetoPadre;
			Rotar rotar = fetoTransform.GetComponent<Rotar>();
			rotar.objetoCentroDeRotación = objetoGira;
		}
	}
}
