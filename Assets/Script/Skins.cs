using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    [SerializeField]
    GameObject foot;
    int furbyColor;
    [SerializeField]
    Sprite f1 = default,
           f2 = default,
           f3 = default,
           f4 = default;

    void Start()
    {
        furbyColor = PlayerPrefs.GetInt("furbySkin", 0);

        if (furbyColor == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = f1;
            foot.GetComponent<SpriteRenderer>().sprite = f3;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = f2;
            foot.GetComponent<SpriteRenderer>().sprite = f4;
        }
    }

}
