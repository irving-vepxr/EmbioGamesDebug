using UnityEngine;
using System.Collections;
enum EnemyState{PATROL, CHASING}

public class EnemyController : MonoBehaviour {
    public Vector2 areaPatrol;
    public float patrolUpdate;
    private Vector3 randomDestination;
    private Vector3 startPosition;

    private GameObject player;
    private Animator enemyAnimator;
    private NavMeshAgent agent;
    private EnemyState currentState;

	public float min_distance;
	private float distance;
	private float velocity;

	void Start () {
        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        currentState = EnemyState.PATROL;
        StartCoroutine("Patrol");
    }

    void Update() {
		distance = Vector3.Distance (transform.position, player.transform.position);
		//Vector3 v3 = new Vector3 (distance, distance, distance);
		//Debug.Log (v3);

		if (distance <= min_distance)
			currentState = EnemyState.CHASING;
		else {
			currentState = EnemyState.PATROL;
			velocity = agent.speed;

		}
		if (currentState == EnemyState.CHASING) {
			agent.SetDestination (player.transform.position);
			velocity = agent.velocity.magnitude * 0.1f;
			//enemyAnimator.SetFloat ("speed", agent.speed);
			//
		}

		enemyAnimator.SetFloat ("speed", velocity);
	}

    IEnumerator Patrol() {
		randomDestination = startPosition + new Vector3 (Random.Range (-areaPatrol.x, areaPatrol.x), 0, Random.Range (-areaPatrol.y, areaPatrol.y));
		agent.SetDestination (randomDestination);
		yield return new WaitForSeconds (patrolUpdate);

        if (currentState == EnemyState.PATROL)
            StartCoroutine("Patrol");
        
    }

}
