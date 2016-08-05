using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class playerController : MonoBehaviour {
    private Animator playeranimator;
    private CapsuleCollider capsule;
    private float startColliderHeight;

#if UNITY_IOS || UNITY_ANDROID
    private Vector3 accel;
    private Touch finger;
#endif

    Animator anim;
	GameObject enemy;
	bool enemyInRange;
	float timer;
	private bool dead=false;

    public int healtRobot = 10;
    public int currentHealth;
    public Slider EnemyHealthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    bool damaged;

    void Start () {
        playeranimator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        startColliderHeight = capsule.height;

		enemy = GameObject.FindGameObjectWithTag ("Enemy");
        currentHealth = healtRobot;
        EnemyHealthSlider.value = currentHealth;
    }

	void OnTriggerEnter (Collider other)
	{
		if(GameObject.FindGameObjectWithTag ("Enemy") && dead==false)
		{
            Debug.Log("Enemyatack");
            enemyInRange = true;
            damaged = true;
            currentHealth -= 1;
            EnemyHealthSlider.value = currentHealth;
            if (currentHealth <= 0)
            {
                dead = true;
                playeranimator.SetTrigger("Dead");
                StartCoroutine(Delay());
            }
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == enemy)
		{
			enemyInRange = false;
		}
	}

	void Update () {
#if UNITY_STANDALONE

        playeranimator.SetFloat("direction", Input.GetAxis("Horizontal"));
        playeranimator.SetFloat("speed", Input.GetAxis("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.Space) && playeranimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
            playeranimator.SetTrigger("jump");

        if (Input.GetKeyDown(KeyCode.H))
            playeranimator.SetTrigger("wave");
		if (Input.GetMouseButtonDown (0))
			playeranimator.SetTrigger("Shoot");
		//if(Input.GetKeyDown(KeyCode.L))
		//	playeranimator.SetTrigger ("Dead");

        if (playeranimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            capsule.height = playeranimator.GetFloat("ColliderHeight");
        else
            capsule.height = startColliderHeight;

#endif

#if UNITY_IOS || UNITY_ANDROID
        accel = Input.acceleration;
        playeranimator.SetFloat("direction", accel.x);
        if (Input.GetMouseButtonDown(0))
            playeranimator.SetTrigger("Shoot");
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                finger = Input.GetTouch(i);
                //Debug.Log("Position" + finger.position);
                if (finger.position.x >= Screen.width * 0.5f)
                    playeranimator.SetFloat("speed", 1f);

                else {
                    playeranimator.SetFloat("speed", 0f);
                    if (finger.phase == TouchPhase.Began && playeranimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
                        playeranimator.SetTrigger("jump");
                }
            }
        }

        else
            playeranimator.SetFloat("speed", 0);

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

#endif

    }

	IEnumerator Delay() {
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

}
