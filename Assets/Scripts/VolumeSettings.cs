using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;

    void Start()
    {
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        // Volume works on a logarithmic scale, so we need to convert the slider value to a logarithmic value
        audioMixer.SetFloat("LowpassCutoff_Freq", 22000);
        float musicV = musicSlider.value;
        float sfxV = sfxSlider.value;

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicV) * 20);
        //To not explode the ears of the player, I set 10 options for the volume
        // 1 -10 whole numbers so we need to convert the slider value to a logarithmic value
        if (sfxV == 0)
        {
            sfxV = 0.0001f;
        } else if (sfxV <=9) {
            sfxV = (sfxV/10)*(sfxV/10);
        } else {
            sfxV = Mathf.Pow((sfxV/10)*(sfxV/10),2);
        }
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxV) * 20);
    }
}
