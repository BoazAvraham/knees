using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{

    public float speed = 10;

    private float direction = 0;
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(0, speed,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxis("Vertical");

        Vector3 movement= move * direction * Time.deltaTime;
     
        transform.position += movement;

    }
}
