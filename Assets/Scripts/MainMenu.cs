
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip click;
    private AudioSource source;
    private int levelToLoad;

    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void LoadKneesLevel() {
        source.PlayOneShot(click, 1);
        SceneManager.LoadScene(1);
    }






}
