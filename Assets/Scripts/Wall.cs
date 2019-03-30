using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public string [] graffiti;

    //Maybe make these public
    float maxX = 18;
    float maxY = 3;
    float angle = 30;

    private string myText;
    private Transform textChild;
    void Start()
    {
        textChild = transform.GetChild(2);
    }

    public void RandomizeText() {
        myText = graffiti[Random.Range(0,graffiti.Length)];
        Vector3 newPos = new Vector3(Random.Range(-maxX, maxX),
                                   Random.Range(-maxY, maxY), 0);

        Vector3 euler = new Vector3(0, 0, Random.Range(-angle, angle));

        textChild.localPosition = newPos;
        textChild.localEulerAngles = euler;
        textChild.GetComponent<TextMesh>().text = myText;
    }
}
