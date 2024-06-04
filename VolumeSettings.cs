using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider masterSlider;

    bool isMuted;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            SetMasterVolume();
        }

    }

    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            myMixer.SetFloat("music", -80);
            isMuted = true;
        }
        else
        {
            LoadVolume();
            isMuted = false;
            SetMusicVolume();
        }
    }
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", volume);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        if (isMuted == false)
        {
            float volume = musicSlider.value;
            myMixer.SetFloat("music", volume);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }


}
