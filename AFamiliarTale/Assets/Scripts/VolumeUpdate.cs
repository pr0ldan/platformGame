using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUpdate : MonoBehaviour
{
    [SerializeField] Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }
    //changes volume with the slider
    public void ChangeVolume()
    {
        AudioListener.volume = volSlider.value;
        Save();
    }
    //will load the value that was saved
    public void Load()
    {
        volSlider.value = PlayerPrefs.GetFloat("musicVolume");
        ChangeVolume();
    }
    //saves value of slider
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volSlider.value);
    }
}
