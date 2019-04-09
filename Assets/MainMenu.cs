
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int levelToLoad;
    
    public void LoadKneesLevel() {
        SceneManager.LoadScene(1);
    }


}
