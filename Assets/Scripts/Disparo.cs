using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {
	public float velocidad = 10;

	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent <Rigidbody>();
		rb.AddForce(transform.forward*velocidad);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.name == "Suelo"){
			EliminarDisparo();
		}
		else if(other.tag=="AlgoCool"){
			EliminarDisparo();
			other.SendMessage("Muere",SendMessageOptions.DontRequireReceiver);
		}
	}

	void EliminarDisparo(){
		Destroy(gameObject,1);
		GetComponentInChildren<ParticleSystem>().enableEmission = false;
	}
}
