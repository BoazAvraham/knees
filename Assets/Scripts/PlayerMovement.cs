using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10;
    public Animator animator;
    public GameObject slidePoint;


    private float direction = 0;
    private Vector3 move;
    private float yBound;
    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;


    // Start is called before the first frame update
    void Start() {
        move = new Vector3(0, speed, 0);
        yBound = GameManager.instance.getVertExtent();


        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, slidePoint.transform.position);
    
        Debug.Log(yBound);
    }

    // Update is called once per frame
    void FixedUpdate() {
        //direction = Input.GetAxis("Vertical");

        Vector3 movement = move * direction * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("dimple");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            animator.SetTrigger("slide");
            Vector3.Lerp(transform.position, slidePoint.transform.position,fracJourney);
        }

        Vector3 newPos = transform.position + movement;
        if (newPos.y < yBound && newPos.y > -yBound)
            transform.position = newPos;

    }
}
