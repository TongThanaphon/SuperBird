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

    void Start()
    {
        if (PlayerPrefs.HasKey("SFX_VOL"))
        {
            sliderSFX.value = PlayerPrefs.GetFloat("SFX_VOL");
        }

        if (PlayerPrefs.HasKey("BG_VOL")) {
            sliderBG.value = PlayerPrefs.GetFloat("BG_VOL");
        }
    }

    void Update()
    {
        mixer.SetFloat("SFX_VOL", sliderSFX.value);
        mixer.SetFloat("BG_VOL", sliderBG.value);
    }

    public void SaveSettings() {
        PlayerPrefs.SetFloat("SFX_VOL", sliderSFX.value);
        PlayerPrefs.SetFloat("BG_VOL", sliderBG.value);
        PlayerPrefs.Save();
    }
}
