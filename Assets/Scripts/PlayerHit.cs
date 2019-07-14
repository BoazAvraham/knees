using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public float flashTime;
    public bool flashActive;
    public AudioClip hitSound;


    private AudioSource source;
    private float flashCounter;
    private SpriteRenderer playerSprite;
    private Color workingColor;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        workingColor = playerSprite.color;

        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive) {
            
            if (flashCounter > 0.66 * flashTime) {
                workingColor.g = 0;
                workingColor.b = 0;
                playerSprite.color = workingColor;
            }
            else if (flashCounter > 0.33 * flashTime) {
                workingColor.g = 1;
                workingColor.b = 1;
                playerSprite.color = workingColor;
            }
            else if (flashCounter > 0) {
                workingColor.g = 0;
                workingColor.b = 0;
                playerSprite.color = workingColor;
            }
            else {
                workingColor.g = 1;
                workingColor.b = 1;
                playerSprite.color = workingColor;
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }

    }

    void OnCollisionEnter(Collision col) {
        source.PlayOneShot(hitSound, 0.53f);
        flashActive = true;
        flashCounter = flashTime;
    }
}
