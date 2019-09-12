using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript: MonoBehaviour
{
    [SerializeField]
    AudioClip menuSong = default;

    [SerializeField]
    AudioSource songSource = default;

    float volume;
    [SerializeField]
    Slider volumeSlider = default;

    [SerializeField]
    GameObject speakerOn = default, speakerOff = default;

    [SerializeField]
    GameObject[] toggleButtons = default;

    Image t1 = default,
          t2 = default;
    

    void Start()
    {
        t1 = toggleButtons[0].GetComponent<Image>();
        t2 = toggleButtons[1].GetComponent<Image>();

        songSource.clip = menuSong;
        songSource.Play();
    }

    public void change_volume()
    {
        volume = volumeSlider.GetComponent<Slider>().value;
        songSource.volume = volume;

        if(volume == 0)
        {
            speakerOn.SetActive(false);
            speakerOff.SetActive(true);
        }

        else
        {
            speakerOff.SetActive(false);
            speakerOn.SetActive(true);
        }
    }

    public void change_furby()
    {
        bool temp;

        temp = t1.enabled;
        t2.enabled = temp;
        t1.enabled = !temp;

        if (t1.enabled)
            PlayerPrefs.SetInt("furbySkin", 0);
        else
            PlayerPrefs.SetInt("furbySkin", 1);
    }
}
