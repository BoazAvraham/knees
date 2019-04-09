using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public GameObject pauseCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause() {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume() {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Menu() {
        SceneManager.LoadScene(0);
    }

}
