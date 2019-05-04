﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance=null;

    public float health;
    public Text gameOverText;
    public Text scoreText;
    public Text healthText;

    public GameObject background;
    public float screenspeed = 10;

    private float vertExtent, horzExtent;
    private float score;
    private List<GameObject> walls;
    private Vector3 wallMovement;
    private Vector3 wallWidth;

    public static GameManager getInstance() {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance !=this)
            Destroy(gameObject);

        vertExtent = GetComponent<Camera>().orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
    }

    void Start() 
    {
        //disable gameover text
        gameOverText.enabled = false;

        //initialize walls
        walls = new List<GameObject>();

        wallMovement = new Vector3(screenspeed,0,0);

        wallWidth = background.transform.GetChild(1).position;

        createWallPool();

        //score - distance ran
        score = 0;
        scoreText.text = "Score : 0";

        Debug.Log("num of walls: " + walls.Count);
        Debug.Log("wall width:"+wallWidth);
    }

    private void createWallPool() {
        Vector3 pos = wallWidth;
        pos += 2 * wallWidth;
        walls.Add(Instantiate(background, pos, Quaternion.identity));
        pos -= 2 * wallWidth;
        walls.Add(Instantiate(background,pos,Quaternion.identity));
        pos -= 2 * wallWidth;
        walls.Add(Instantiate(background,pos,Quaternion.identity));
    }

    void FixedUpdate() {
        //move walls
        foreach (GameObject o in walls) {
            o.transform.position -= wallMovement * Time.deltaTime;
            //if wall rightboarder out of camera vision
            if (o.transform.position.x+wallWidth.x < -horzExtent) {
                Vector3 pos = o.transform.position;
                pos += 6 * wallWidth;
                o.transform.position = pos;
                o.GetComponent<Wall>().RandomizeText();
            }
        }

        score+= wallMovement.x * Time.deltaTime;
        scoreText.text = "SCORE  -  " +(int)score;
    }


    /**
     * Return the camera X limit 
     */
    public float getVertExtent() { return vertExtent; }
    /**
     * Return the camera Y limit 
     */
    public float getHorzExtent() { return horzExtent; }
    
    
    public void DecreasePlayerHealth(float damage) {
        health -= damage;
        HealthUI.getInstance().updateHealthUI(health);
        Debug.Log(health);
        if (health == 0)
            GameOver();
    }

    private void GameOver() {
        gameOverText.enabled = true;
        
        gameOverText.text = "Your knees were destroyed dude";

        //disable player and spwaning obstacles
        GameObject.FindWithTag("Player").SetActive(false);
        GetComponent<ObstacleSpawner>().StopAllCoroutines();

    }
}
