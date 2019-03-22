using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float vertExtent, horzExtent;

    public static GameManager instance=null;

    public float health;
    public Text gameOverText;
    
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
        gameOverText.enabled = false;
    }


    public float getVertExtent() { return vertExtent; }
    public float getHorzExtent() { return horzExtent; }
    
    
    public void DecreasePlayerHealth(float damage) {
        health -= damage;
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
