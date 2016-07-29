using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {
	public float velocidad = 10;

	void Start () {
		Rigidbody rb = GetComponent <Rigidbody>();
		rb.AddForce(transform.forward*velocidad);

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
