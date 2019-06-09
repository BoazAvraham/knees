using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSetting : MonoBehaviour
{
    public Sprite smoothLeg;
    public Sprite halfHairLeg;
    public Sprite fullHairLeg;
    // Start is called before the first frame update

    GameObject player;
    SpriteRenderer kneesSkin;
    enum skin { SMOOTH=1 , HALF=2 , FULL=3 }
    int skinPick;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        kneesSkin = player.GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("skin")) {
            switch (PlayerPrefs.GetInt("skin")) {
                case 1:
                    setSmoothLeg();
                    break;
                case 2:
                    setHalfHairyLeg();
                    break;
                case 3:
                    setFullHairyLeg();
                    break;

            }
        }
    }

    public void setSmoothLeg() {
        kneesSkin.sprite = smoothLeg;
        PlayerPrefs.SetInt("skin", (int)skin.SMOOTH);
    }

    public void setHalfHairyLeg() {
        kneesSkin.sprite = halfHairLeg;
        PlayerPrefs.SetInt("skin", (int)skin.HALF);
    }

    public void setFullHairyLeg() {
        kneesSkin.sprite = fullHairLeg;
        PlayerPrefs.SetInt("skin", (int)skin.FULL);
    }
}
