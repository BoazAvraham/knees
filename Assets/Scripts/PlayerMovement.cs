using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10;

    private float direction = 0;
    private Vector3 move;
    private float yBound;

    public Animator animator;

    // Start is called before the first frame update
    void Start() {
        move = new Vector3(0, speed, 0);
        yBound = GameManager.instance.getVertExtent();

        
        Debug.Log(yBound);
    }

    // Update is called once per frame
    void FixedUpdate() {
        direction = Input.GetAxis("Vertical");

        Vector3 movement = move * direction * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("dimple");
        }
        
        Vector3 newPos = transform.position + movement;
        if (newPos.y < yBound && newPos.y > -yBound)
            transform.position = newPos;

    }
}
