using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; // allows for a slider to be assigned

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) // if player has a preference named musicVolume use this if not default = 1
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }

    public void ChangeVolume() // volume = slider value
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load() // loads preference and assigns as value
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save() // save current volume config as preference
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
