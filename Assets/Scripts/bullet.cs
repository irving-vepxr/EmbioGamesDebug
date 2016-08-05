using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	public GameObject explosion;
	//public GameObject decalExplosion;

	void OnCollisionEnter(Collision bulletCollisiont){
        EnemyAtack enemyAtack = bulletCollisiont.collider.GetComponent<EnemyAtack>();
        if (enemyAtack != null)
        {
            enemyAtack.TakeDamage(1);
        }

        Destroy(Instantiate(explosion,    bulletCollisiont.contacts[0].point,    Quaternion.identity), 2f);
        Destroy(this.gameObject);
    }

   

}
