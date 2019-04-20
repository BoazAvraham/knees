using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10;
    public Animator animator;
    public GameObject slidePoint;

    public AudioClip hitSound;
    public AudioClip jumpSound;

    private float direction = 0;
    private Vector3 move;
    private float yBound;
    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private AudioSource source;

    private Vector2 startTouch;
    private Vector2 endTouch;

    // Start is called before the first frame update
    void Start() {
        move = new Vector3(0, speed, 0);
        yBound = GameManager.instance.getVertExtent();


        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, slidePoint.transform.position);

        //audio source
        source = GetComponent<AudioSource>();

        Debug.Log(yBound);
    }

  
    void FixedUpdate() {

        Vector3 movement = move * direction * Time.deltaTime;

//#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }


//#elif UNITY_IOS || UNITY_ANDROID

        if (Input.touchCount > 0) {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
                startTouch = touch.position;
            else if (touch.phase == TouchPhase.Ended) {
                endTouch = touch.position;
                ClacDirection();
            }



            //Touch t= Input.touches[0];
            //Vector3 touchPos=Camera.main.ScreenToWorldPoint(t.position);
            //if (touchPos.y > 0)
            //    Jump();
            //else
            //    Slide();
        }
       
//#endif

    }

    private void ClacDirection() {
        Vector2 swipe = endTouch - startTouch;
        if (swipe.y > 0) 
            Jump();
        else
            Slide();

        //startTouch = endTouch = Vector2.zero;

    }

    void Jump() {
        source.PlayOneShot(jumpSound, 0.53f);
        animator.SetTrigger("dimple");
    }

    void Slide() {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        animator.SetTrigger("slide");
        Vector3.Lerp(transform.position, slidePoint.transform.position, fracJourney);
    }

    void OnCollisionEnter(Collision col)
    {
        source.PlayOneShot(hitSound,0.53f);
    }
}
