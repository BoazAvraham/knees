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
        rightBoarder = GameManager.instance.getHorzExtent();
        yHight = GameManager.instance.getVertExtent();
    }

    IEnumerator SpawnObstacle() {
        
        while (true) {
            float[] yPoss = { -yHight, -2/3 * yHight };
            yield return new WaitForSeconds(timeBetweenSpawns);

            int i = Random.Range(0, numOfObstacles);
            Vector3 pos = Vector3.zero;
            pos.x += rightBoarder;

            pos.y = yPoss[Random.Range(0, 2)];
            GameObject obst = Instantiate(obstacles[i], pos, Quaternion.identity);

        }
    }

   
}
