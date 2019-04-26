
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    public AudioClip click;
    public AudioMixer audioMixer;

    private AudioSource source;
    private int levelToLoad;



    public GameObject buttonsPanel;
    public GameObject settingsPanel;
    public GameObject scoreboardPanel;


    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void LoadKneesLevel() {
        source.PlayOneShot(click, 1);
        SceneManager.LoadScene(1);
    }


    public void LoadMainMenu() {
        settingsPanel.SetActive(false);
        scoreboardPanel.SetActive(false);
        buttonsPanel.SetActive(true);

        source.PlayOneShot(click, 1);
    }

    public void LoadSettingsMenu() {
        buttonsPanel.SetActive(false);
        scoreboardPanel.SetActive(false);
        settingsPanel.SetActive(true);

        source.PlayOneShot(click, 1);
    }

    public void LoadScoreboardMenu() {
        buttonsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        scoreboardPanel.SetActive(true);

        source.PlayOneShot(click, 1);
    }


    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume",volume);
    }






}
