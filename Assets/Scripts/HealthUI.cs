using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image health1;
    public Image health2;
    public Image health3;

    static HealthUI instance = null;

    public static HealthUI getInstance() {
        return instance;
    }

    // Start is called before the first frame update
    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
  

    public void updateHealthUI(float health) {
        if (health >= 3) {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = true;
        }
        else if (health == 2) {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = false;
        }
        else if (health == 1) {
            health1.enabled = true;
            health2.enabled = false;
            health3.enabled = false;
        }
        else {
            health1.enabled = false;
            health2.enabled = false;
            health3.enabled = false;
        }
    }

}
