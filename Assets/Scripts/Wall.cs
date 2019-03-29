using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public string graffiti="sample text";

    //Maybe make these public
    float maxX = 12;
    float maxY = 3;
    float angle = 80;

    private string myText;
    private Transform textChild;
    void Start()
    {
        textChild = transform.GetChild(2);
    }

    public void RandomizeText() {
        myText = "WOOT SUCCESS !!!!";
        Vector3 newPos = new Vector3(Random.Range(-maxX, maxX),
                                   Random.Range(-maxY, maxY), 0);

        Vector3 euler = new Vector3(0, 0, Random.Range(-angle, angle));

        textChild.position = newPos;
        textChild.eulerAngles = euler;
        textChild.GetComponent<TextMesh>().text = myText;
    }
}
