using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle1, obstacle2;
    [HideInInspector]
    public float obstacleSpawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {
            StopCoroutine("SpawnObstacles");
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1, 3);
        
        if (random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, 0.2f, 0), Quaternion.identity);
        }

        else
        {
            Instantiate(obstacle2, new Vector3(transform.position.x, 0.2f, 0), Quaternion.identity);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }
}
