using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesandeggs : MonoBehaviour
{
    [SerializeField]
    GameObject[] hearts = default;
    int lives, eggs, i;

    [SerializeField]
    Text eggCount = default;

  

    void Start()
    {
        eggs = PlayerPrefs.GetInt("eggs", 0);
        lives = PlayerPrefs.GetInt("lives", 3);

        eggCount.text = eggs + " / 20";

        for (i = 0; i < 3; i++)
        {
            if (lives <= i)
                hearts[i].SetActive(false);
            else
                hearts[i].SetActive(true);
        }

    }
    
    IEnumerator remove_life()
    {
        SendMessageUpwards("play_fallingAC");

        yield return new WaitForSeconds(1.5f);

        lives--;
        eggs = PlayerPrefs.GetInt("eggs", 0);
        PlayerPrefs.SetInt("lives", lives);

        for (i = 0; i < 3; i++)
        {
            if (lives <= i)
            {
                hearts[i].SetActive(false);
           
            }
            else
            {
                hearts[i].SetActive(true);
                
            }
        }

        if (lives == 0)
        {
            SendMessageUpwards("LoadDeathPanel");
        }

        else
            SendMessageUpwards("RestartLevel");
    }


    void collect_egg(GameObject egg)
    {
        Destroy(egg);
        eggs++;
        eggCount.text = eggs + " / 20";
    }

    void save_eggCount()
    {
        PlayerPrefs.SetInt("eggs", eggs);
    }

}
