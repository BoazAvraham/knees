using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public AudioClip click;
    public GameObject pauseCanvas;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

   

    public void Pause() {
        source.PlayOneShot(click, 1);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume() {
        source.PlayOneShot(click, 1);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void Menu() {
        source.PlayOneShot(click, 1);
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        source.PlayOneShot(click,1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
