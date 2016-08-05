using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject bullet;
	public float force;
	private GameObject tmpBullet;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			tmpBullet = (GameObject)Instantiate (bullet, transform.position, bullet.transform.rotation);
			tmpBullet.transform.up = -transform.forward;
			tmpBullet.GetComponent<Rigidbody> ().AddForce (transform.forward*force, ForceMode.Impulse);
			Destroy (tmpBullet, 10f);
		}
	}
}
