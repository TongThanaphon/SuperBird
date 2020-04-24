using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider sliderSFX;
    public Slider sliderBG;

    int sfx;
    int bg;

    void Start()
    {
        if (PlayerPrefs.HasKey("SFX_VOL"))
        {
            sfx = PlayerPrefs.GetInt("SFX_VOL");
            sliderSFX.value = Convert.ToSingle(sfx);
        }

        if (PlayerPrefs.HasKey("BG_VOL")) {
            bg = PlayerPrefs.GetInt("BG_VOL");
            sliderBG.value = Convert.ToSingle(bg);
        }
    }

    void Update()
    {
        mixer.SetFloat("SFX_VOL", sfx);
        mixer.SetFloat("BG_VOL", bg);
    }

    public void SaveSettings() {
        sfx = Convert.ToInt32(sliderSFX.value);
        bg = Convert.ToInt32(sliderBG.value);
        PlayerPrefs.SetInt("SFX_VOL", sfx);
        PlayerPrefs.SetInt("BG_VOL", bg);
        PlayerPrefs.Save();
    }
}
