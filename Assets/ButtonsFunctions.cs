
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    private int levelToLoad;
    
    public void LoadKneesLevel() {
        SceneManager.LoadScene(1);
    }


}
