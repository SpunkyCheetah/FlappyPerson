using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawnManager : MonoBehaviour
{
    // Variables
    [Header("Spawn Rate")]
    public float startDelay;
    public float spawnDelay;
    [Header("Game Objects")]
    public GameObject obstacle;
    public PlayerController player;
    [Header("Positioning")]
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnDecoration", startDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnDecoration()
    {
        offset = new Vector3(Random.Range(-2, 1), Random.Range(-10, 10), 0);
        Instantiate(obstacle, transform.position + offset, transform.rotation);

    }
}
