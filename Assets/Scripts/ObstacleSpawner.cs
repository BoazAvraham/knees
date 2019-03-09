using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
    public float timeBetweenSpawns=3;


    private int numOfObstacles;
    private float rightBoarder=0; //TODO find this in start depends on camera
    private float yHight=5; //TODO find this in start depends on camera
    

    void Start()
    {
        numOfObstacles = obstacles.Length;
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            int i = Random.Range(0, numOfObstacles);
            Vector3 pos = Vector3.zero;
            pos.x += rightBoarder;
            pos.y = Random.Range(-yHight, yHight);
            GameObject obst = Instantiate(obstacles[i], pos, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

   
}
