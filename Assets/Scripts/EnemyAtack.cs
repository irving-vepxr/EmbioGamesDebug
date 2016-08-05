using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class EnemyAtack : MonoBehaviour {

    public int startingHealth = 3;
    public int currentHealth;
    public Slider EnemyHealthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool isDead;
    bool damaged;

    //public float timeBetweenAttacks = 0.5f;
    //public int attackDamage = 10;

    Animator anim;
	GameObject player;
	GameObject enemy;
	bool playerInRange;
	float timer;
	SphereCollider sphereCollider;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Fire");
		sphereCollider = GetComponent<SphereCollider> ();
		anim = GetComponent <Animator> ();
        currentHealth = startingHealth;
	}

    void update() {
        if (damaged)
        {
            //Establece el color de daño
            damageImage.color = flashColour;
        }
        else
        {
            //interpolacion de color de rojo a transparente
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

    }

    void Death() {
        isDead = true;
        anim.SetTrigger("Dead");
        sphereCollider.enabled = false;
        sphereCollider.isTrigger = false;
        StartCoroutine(Delay());

    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;
        EnemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    /*
    void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.FindGameObjectWithTag("Fire")==true)
		{
            Debug.Log("colision fire");
            playerInRange = true;
            damaged = true;
            currentHealth -= 1;
            EnemyHealthSlider.value = currentHealth;
            if (currentHealth <= 0 && !isDead)
                Death();
		}
	}
    

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
    */

	IEnumerator Delay() {
		yield return new WaitForSeconds (5);
		Destroy (this.gameObject);
	}

		
	
}
