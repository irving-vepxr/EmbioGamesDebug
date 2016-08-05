using UnityEngine;
using System.Collections;

public class itemsSpawPoint : MonoBehaviour {

    public GameObject items;
    public float spawnTime = 80f;
    public Transform[] spawnPoints;
    public GameObject spawnPoint;
    private GameObject itemsChildren;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        itemsChildren = Instantiate(items, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
        itemsChildren.transform.parent = GameObject.FindGameObjectWithTag("Terrain").transform;
    }
}
