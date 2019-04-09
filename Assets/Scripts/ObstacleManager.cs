using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float minSpeed = 10;
    public float maxSpeed = 10;

    public float myDamage = 1;

    private Rigidbody rb;
    
  
    void Start()
    {      
        rb = GetComponent<Rigidbody>();
        float speedX = -Random.Range(minSpeed,maxSpeed);
        rb.velocity = new Vector3(speedX, 0, 0);      
    }


    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col) {
        GameManager.instance.DecreasePlayerHealth(myDamage);
        Destroy(gameObject);
    }
}
