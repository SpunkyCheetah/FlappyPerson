using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
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

        InvokeRepeating("SpawnObstacle", startDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnObstacle()
    {
        offset = new Vector3(0, Random.Range(-5, 5), 0);
        Instantiate(obstacle, transform.position + offset, transform.rotation);

    }
}
