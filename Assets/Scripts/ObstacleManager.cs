using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float minSpeed = 2;
    public float maxSpeed = 5;

    private Rigidbody2D rb;
    
  
    void Start()
    {
        //----TODO add random starting position
        rb = GetComponent<Rigidbody2D>();
        float speedX = -Random.Range(minSpeed,maxSpeed);
        rb.velocity = new Vector3(speedX, 0, 0);
             
    }


    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
