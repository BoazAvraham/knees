using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject arrow;
    public float timeBetweenSpawns=3;
    public float arrowSpeed=300;

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
        int count = 3;
        float[] yPoss = { -yHight, -2 / 3 * yHight };
        while (true) {
            yield return new WaitForSeconds(timeBetweenSpawns);

            int i = Random.Range(0, numOfObstacles);
            Vector3 pos = Vector3.zero;
            pos.x += rightBoarder;

            pos.y = yPoss[Random.Range(0, 2)];

            count--;
            if (count == 0) {
                count = Random.Range(3, 6);
                pos.y = yPoss[1];
                GameObject obst = Instantiate(arrow, pos , Quaternion.AngleAxis(90,Vector3.forward));
                obst.GetComponent<Rigidbody>().AddForce(Vector3.left * arrowSpeed);
            }
            else
                Instantiate(obstacles[i], pos, Quaternion.identity);
        }
    }

   
}
