using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float vertExtent, horzExtent;

    public static GameManager instance=null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance !=this)
            Destroy(gameObject);

        vertExtent = GetComponent<Camera>().orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
    }


    public float getVertExtent() { return vertExtent; }
    public float getHorzExtent() { return horzExtent; }
    // Update is called once per frame
    void Update()
    {
        
    }
}
