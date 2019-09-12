using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSounds : MonoBehaviour
{
    [SerializeField]
    AudioClip eatingAC = default,
              fallingAC = default;

    [SerializeField]
    AudioSource audioSource = default;

    void play_eatingAC()
    {
        audioSource.clip = eatingAC;
        audioSource.Play();
    }

    void play_fallingAC()
    {
        audioSource.clip = fallingAC;
        audioSource.Play();
    }

}
