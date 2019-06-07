
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public AudioClip click;
    public AudioMixer audioMixer;

    private AudioSource source;
    private int levelToLoad;

    public Slider audioSlider;
    public GameObject buttonsPanel;
    public GameObject settingsPanel;
    public GameObject scoreboardPanel;
    public Text lastScore;
    public Text highScore;

    public void Start()
    {
        source = GetComponent<AudioSource>();
        if (PlayerPrefs.GetFloat("Volume") != null) {
            float volume = PlayerPrefs.GetFloat("Volume");
            audioSlider.value = volume;
            audioMixer.SetFloat("Volume", volume);
        }
        scoreboardPanel.SetActive(false);

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

        if (PlayerPrefs.HasKey("last_score")) {
            int s = (int)PlayerPrefs.GetFloat("last_score");
            lastScore.text = "last score: " + s.ToString();
        }
        else {
            lastScore.text="NOOB";
        }
        if (PlayerPrefs.HasKey("highscore")) {
            int s = (int)PlayerPrefs.GetFloat("highscore");
            highScore.text = "highscore: " + s.ToString();
        }
        else {
            highScore.text = "NOOB";
        }
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume",volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }



}
